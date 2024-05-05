using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using Perakaravan.Application.Dtos.Request.Sliders;
using Perakaravan.Application.Dtos.Response.Logins;
using Perakaravan.Application.Interfaces;
using Perakaravan.Application.Wrapper;
using Perakaravan.Domain.Entities;
using Perakaravan.Domain.Repositories;
using Perakaravan.InfraPack.Utils;
using SixLabors.ImageSharp;

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

        public async Task<Result> GetAllSlider()
        {
            var sliders = await _unitOfWork.SliderRepository.GetAllAsync();
            var sliderDtos = _mapper.Map<IEnumerable<SliderResponseDto>>(sliders);

            return Result.Success(sliderDtos);
        }

        public async Task<Result> GetAllSliderDetail()
        {
            var sliders = await _unitOfWork.SliderRepository.GetAllAsync();
            var sliderDtos = _mapper.Map<IEnumerable<SliderDetailResponseDto>>(sliders);

            return Result.Success(sliderDtos);
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

            #region Kayıt işlemi

            try
            {
                #region Resim yükle

                var fileName = ProcessImageHelper.GenerateFileName(sliderModel.ImageFile);

                using (Image image = Image.Load(sliderModel.ImageFile.OpenReadStream()))
                {
                    var optimizedImage = ProcessImageHelper.ResizeImage(image, 1920, 683);
                    var fileUrl = $"slider/{fileName}";
                    await image.SaveAsJpegAsync($"{_hostingEnvironment.WebRootPath}/{fileUrl}");
                    sliderEntity.ImageUrl = fileUrl;
                }

                #endregion

                await _unitOfWork.SliderRepository.AddAsync(sliderEntity);
                await _unitOfWork.CommitAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "SliderService => CreateSlider : Slider kaydedilirken bir hata oluştu.");
                return Result.Error("Slider kaydedilemedi.");
            }

            #endregion

            return Result.Success(sliderEntity, "Slider başarıyla eklendi.");
        }

        public async Task<Result> UpdateSlider(SliderUpdateRequestDto sliderModel)
        {
            var existsSlider = await _unitOfWork.SliderRepository.GetByIdAsync(sliderModel.Id);            

            #region Model kontrolü

            var sliderExistsByTitle = await _unitOfWork.SliderRepository.AnyAsync(x => x.Id != sliderModel.Id && x.Title == sliderModel.Title);

            if(existsSlider is null)
            {
                return Result.Error("Güncellenecek slider bulunamadı.");
            }
            else if (sliderExistsByTitle)
            {
                return Result.Error("Bu başlığa sahip bir slider daha önce eklenmiştir.");
            }            

            #endregion

            var sliderEntity = _mapper.Map(sliderModel, existsSlider);

            #region Kayıt işlemi

            try
            {
                if (sliderModel.ImageFile is not null)
                {
                    #region Mevcut resmi sil

                    var filePath = Path.Combine(_hostingEnvironment.WebRootPath, existsSlider.ImageUrl);
                    if (File.Exists(filePath))
                    {
                        File.Delete(filePath);
                    }

                    #endregion

                    #region Yeni resmi yükle

                    var fileName = ProcessImageHelper.GenerateFileName(sliderModel.ImageFile);

                    using (Image image = Image.Load(sliderModel.ImageFile.OpenReadStream()))
                    {
                        var optimizedImage = ProcessImageHelper.ResizeImage(image, 1920, 683);
                        var fileUrl = $"slider/{fileName}";
                        await image.SaveAsJpegAsync($"{_hostingEnvironment.WebRootPath}/{fileUrl}");
                        sliderEntity.ImageUrl = fileUrl;
                    }

                    #endregion
                }

                _unitOfWork.SliderRepository.Update(sliderEntity);
                await _unitOfWork.CommitAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "SliderService => UpdateSlider : Slider güncellenirken bir hata oluştu.");
                return Result.Error("Slider kaydedilemedi.");
            }

            #endregion

            return Result.Success(sliderEntity, "Slider başarıyla güncellendi.");
        }

        public async Task<Result> DeleteSlider(int id)
        {
            var sliderEntity = await _unitOfWork.SliderRepository.GetByIdAsync(id);

            #region Model kontrolü

            if(sliderEntity is null)
            {
                return Result.Error("Silinecek kayıt bulunamadı.");
            }

            #endregion

            #region Kayıt işlemi

            try
            {
                _unitOfWork.SliderRepository.Remove(id);
                await _unitOfWork.CommitAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "SliderService => DeleteSlider : Slider güncellenirken bir hata oluştu.");
                return Result.Error("Slider silinemedi.");
            }

            #endregion

            return Result.Success("Slider başarıyla silindi.");
        }
    }
}
