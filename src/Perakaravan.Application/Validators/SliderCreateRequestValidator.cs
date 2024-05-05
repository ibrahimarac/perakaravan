using FluentValidation;
using Perakaravan.Application.Dtos.Request.Sliders;
using Perakaravan.InfraPack.Utils;

namespace Perakaravan.Application.Validators
{
    public class SliderCreateRequestValidator : AbstractValidator<SliderCreateRequestDto>
    {
        public SliderCreateRequestValidator()
        {
            RuleFor(x => x.Title)
                .MaximumLength(150).WithMessage("Başlık bilgisi en fazla 150 karakter olabilir.");

            RuleFor(x => x.SubTitle)
                .MaximumLength(300).WithMessage("Alt başlık bilgisi en fazla 300 karakter olabilir.");

            RuleFor(x => x.ImageFile)
                .NotNull().WithMessage("Resim dosyası seçilmelidir.")
                .Must(x => ProcessImageHelper.GetFileType(x) != FileType.Unknown)
                .WithMessage("Geçerli bir resim dosyası seçilmelidir.")
                .Must(x => x.Length < 3 * 1024 * 1024)
                .WithMessage("Resim dosyası 3 MB'dan büyük olamaz.");

            RuleFor(x => x.RedirectUrl)
                .MaximumLength(200).WithMessage("Yönlendirme adresi en fazla 200 karakter olabilir.");
        }
    }
}
