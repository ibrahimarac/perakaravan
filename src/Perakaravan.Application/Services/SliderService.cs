using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using Perakaravan.Application.Dtos.Request.Sliders;
using Perakaravan.Application.Interfaces;
using Perakaravan.Application.Wrapper;
using Perakaravan.Domain.Entities;
using Perakaravan.Domain.Repositories;
using Perakaravan.InfraPack.Utils;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

namespace Perakaravan.Application.Services
{
    public class SliderService : ISliderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly ILogger<SliderService> _logger;

        public SliderService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<SliderService> logger, IHostingEnvironment hostingEnvironment)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
            _hostingEnvironment = hostingEnvironment;
        }

        public async Task<Result> CreateSlider(SliderCreateRequestDto sliderModel)
        {
            #region Model kontrolü

            var sliderExistsByTitle = await _unitOfWork.SliderRepository.AnyAsync(x => x.Title == sliderModel.Title);
            if (sliderExistsByTitle)
            {
                return Result.Error("Bu başlığa sahip bir slider daha önce eklenmiştir.");
            }

            #endregion

            var sliderEntity = _mapper.Map<Slider>(sliderModel);

            try
            {
                #region Resim yükle

                var fileName = ProcessImageHelper.GenerateFileName(sliderModel.ImageFile);

                using (Image image = Image.Load(sliderModel.ImageFile.OpenReadStream()))
                {
                    var optimizedImage = ProcessImageHelper.ResizeImage(image, 1920, 683);
                    var filePath = Path.Combine("slider", fileName);
                    await image.SaveAsJpegAsync($"{_hostingEnvironment.WebRootPath}/{filePath}");
                    sliderEntity.ImageUrl = filePath;
                }

                #endregion

                #region Kayıt işlemi

                await _unitOfWork.SliderRepository.AddAsync(sliderEntity);
                await _unitOfWork.CommitAsync();

                #endregion

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "SliderService => CreateSlider : Slider kaydedilirken bir hata oluştu.");
                return Result.Error("Slider kaydedilemedi.");
            }

            return Result.Success(sliderEntity);
        }
    }
}
