using FluentValidation;
using Perakaravan.Application.Dtos.Request.Sliders;
using Perakaravan.Application.Dtos.Request.Statics;
using Perakaravan.InfraPack.Utils;

namespace Perakaravan.Application.Validators
{
    public class SiteStaticRequestValidator : AbstractValidator<SiteStaticRequestDto>
    {
        public SiteStaticRequestValidator()
        {
            RuleFor(x => x.Phone)     
                .NotNull()
                .WithMessage("Telefon numarası boş olamaz.")
                .MaximumLength(12)
                .WithMessage("Telefon numarası en fazla 12 karakter olabilir.");

            RuleFor(x => x.Email)
                .NotNull()
                .WithMessage("Eposta adresi boş olamaz.")
                .MaximumLength(200)
                .WithMessage("Eposta adresi en fazla 200 karakter olabilir.");

            RuleFor(x => x.Address)
                .NotNull()
                .WithMessage("Adres bilgisi boş olamaz.")
                .MaximumLength(255)
                .WithMessage("Adres bilgisi en fazla 200 karakter olabilir.");

            RuleFor(x => x.GoogleMap)
                .NotNull()
                .WithMessage("Google map adresi boş olamaz.")
                .MaximumLength(50)
                .WithMessage("Google map adresi en fazla 50 karakter olabilir.");

            RuleFor(x => x.Instagram)
                .NotNull()
                .WithMessage("Instagram adresi boş olamaz.")
                .MaximumLength(150)
                .WithMessage("Instagram adresi en fazla 150 karakter olabilir.");

            RuleFor(x => x.Facebook)
                .NotNull()
                .WithMessage("Facebook adresi boş olamaz.")
                .MaximumLength(150)
                .WithMessage("Facebook adresi en fazla 150 karakter olabilir.");

            RuleFor(x => x.Twitter)
                .NotNull()
                .WithMessage("Twitter adresi boş olamaz.")
                .MaximumLength(150)
                .WithMessage("Twitter adresi en fazla 150 karakter olabilir.");

            RuleFor(x => x.HomepageTitle)
                .NotNull()
                .WithMessage("Anasayfa başlık bilgisi boş olamaz.")
                .MaximumLength(255)
                .WithMessage("Anasayfa başlık bilgisi en fazla 255 karakter olabilir.");

            RuleFor(x => x.Footer)
                .NotNull()
                .WithMessage("Footer bilgisi boş olamaz.")
                .MaximumLength(255)
                .WithMessage("Footer bilgisi en fazla 255 karakter olabilir.");

            RuleFor(x => x.LogoFile)
                .Must(x => ProcessImageHelper.GetFileType(x) != FileType.Unknown)
                .When(x => x != null)
                .WithMessage("Geçerli bir resim dosyası seçilmelidir.")
                .Must(x => x.Length < 3 * 1024 * 1024)
                .When(x => x != null)
                .WithMessage("Resim dosyası 3 MB'dan büyük olamaz.");

            RuleFor(x => x.LogoTitle)
                .MaximumLength(100)
                .When(x => x != null)
                .WithMessage("Logo metni en fazla 100 karakter olabilir.");

            RuleFor(x => x.SmtpUrl)
                .MaximumLength(100)
                .When(x => x != null)
                .WithMessage("Smtp adresi en fazla 100 karakter olabilir.");

            RuleFor(x => x.SmtpDisplayName)
                .MaximumLength(100)
                .When(x => x != null)
                .WithMessage("Eposta görünen adresi en fazla 100 karakter olabilir.");

        }
    }
}
