using FluentValidation;
using Rentaly.EntityLayer.Entities;

namespace Rentaly.Businesslayer.ValidationRules
{
    public class BrandValidator : AbstractValidator<Brand>
    {
        public BrandValidator()
        {
            // Marka adı boş olamaz
            RuleFor(x => x.BrandName)
                .NotEmpty().WithMessage("Marka adı boş geçilemez");

            // Minimum karakter
            RuleFor(x => x.BrandName)
                .MinimumLength(2).WithMessage("Marka adı en az 2 karakter olmalıdır");

            // Maximum karakter
            RuleFor(x => x.BrandName)
                .MaximumLength(30).WithMessage("Marka adı en fazla 30 karakter olabilir");

            // Sadece harf içermesi
            RuleFor(x => x.BrandName)
                .Matches(@"^[a-zA-ZğüşıöçĞÜŞİÖÇ\s]+$")
                .WithMessage("Marka adı sadece harf içermelidir");

            // İlk harf büyük olmalı
            RuleFor(x => x.BrandName)
                .Must(StartWithUpperLetter)
                .WithMessage("Marka adı büyük harfle başlamalıdır");

            // Image Url boş olamaz
            RuleFor(x => x.ImageUrl)
                .NotNull().WithMessage("Marka görseli null olamaz");

            // Url format kontrolü
            RuleFor(x => x.ImageUrl)
                .Must(BeAValidUrl)
                .WithMessage("Geçerli bir görsel URL giriniz");
        }

        private bool StartWithUpperLetter(string brandName)
        {
            if (string.IsNullOrEmpty(brandName))
                return false;

            return char.IsUpper(brandName[0]);
        }

        private bool BeAValidUrl(string url)
        {
            if (string.IsNullOrEmpty(url))
                return false;

            return Uri.TryCreate(url, UriKind.Absolute, out _);
        }

    }
}