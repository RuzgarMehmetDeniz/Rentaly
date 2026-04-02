using FluentValidation;
using Rentaly.Businesslayer.Abstract;
using Rentaly.Businesslayer.ValidationRules;
using Rentaly.DataAccessLayer.Abstract;
using Rentaly.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rentaly.Businesslayer.Concreate
{
    public class BrandManager : IBrandService
    {
        private readonly IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public async Task TDeleteAsync(int id)
        {
            await _brandDal.DeleteAsync(id);
        }

        public async Task<Brand> TGetByIdAsync(int id)
        {
            return await _brandDal.GetByIdAsync(id);
        }

        public async Task<List<Brand>> TGetListAsync()
        {
            return await _brandDal.GetListAsync();
        }

        public async Task TInsertAsync(Brand entity)
        {
            var validator = new BrandValidator();
            var results = validator.Validate(entity);

            if (!results.IsValid)
            {
                var errors = string.Join(", ", results.Errors.Select(x => x.ErrorMessage));
                throw new ValidationException(errors);
            }

            await _brandDal.InsertAsync(entity);
        }

        public async Task TUpdateAsync(Brand entity)
        {
            await _brandDal.UpdateAsync(entity);
        }
    }
}
