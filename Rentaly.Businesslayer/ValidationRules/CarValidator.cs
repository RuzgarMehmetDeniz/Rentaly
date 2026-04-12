using FluentValidation;
using Rentaly.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rentaly.Businesslayer.ValidationRules
{
    public class CarValidator:AbstractValidator<Car>
    {
        public CarValidator()
        {
            // Plate Number
            RuleFor(x => x.PlateNumber)
                .NotEmpty().WithMessage("Plaka boş geçilemez")
                .MaximumLength(10).WithMessage("Plaka en fazla 10 karakter olabilir");

            // VIN (Şasi No)
            RuleFor(x => x.VIN)
                .NotEmpty().WithMessage("Şasi numarası boş geçilemez")
                .Length(17).WithMessage("Şasi numarası 17 karakter olmalıdır");

            // Foreign Keys
            RuleFor(x => x.BrandId)
                .GreaterThan(0).WithMessage("Marka seçimi yapılmalıdır");

            RuleFor(x => x.CarModelId)
                .GreaterThan(0).WithMessage("Model seçimi yapılmalıdır");

            RuleFor(x => x.CategoryId)
                .GreaterThan(0).WithMessage("Kategori seçimi yapılmalıdır");

            RuleFor(x => x.BranchId)
                .GreaterThan(0).WithMessage("Şube seçimi yapılmalıdır");

            // Year
            RuleFor(x => x.Year)
                .InclusiveBetween(1990, DateTime.Now.Year)
                .WithMessage("Araç yılı geçerli bir değer olmalıdır");

            // Kilometer
            RuleFor(x => x.Kilometer)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Kilometre negatif olamaz");

            // Daily Price
            RuleFor(x => x.DailyPrice)
                .GreaterThan(0)
                .WithMessage("Günlük fiyat 0'dan büyük olmalıdır");

            // Deposit
            RuleFor(x => x.DepositAmount)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Depozito negatif olamaz");

            // Image
            RuleFor(x => x.ImageUrl)
                .NotEmpty().WithMessage("Araç görseli boş olamaz");

            // Seat Count
            RuleFor(x => x.SeatCount)
                .InclusiveBetween(1, 12)
                .WithMessage("Koltuk sayısı 1 ile 12 arasında olmalıdır");

            // Luggage
            RuleFor(x => x.LuggageCount)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Bagaj sayısı negatif olamaz");

            // Fuel Type
            RuleFor(x => x.FuelType)
                .NotEmpty().WithMessage("Yakıt tipi boş geçilemez");

        }
    }
}
