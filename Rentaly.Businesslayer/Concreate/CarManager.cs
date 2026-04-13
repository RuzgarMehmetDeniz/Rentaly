using Rentaly.Businesslayer.Abstract;
using Rentaly.DataAccessLayer.Abstract;
using Rentaly.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rentaly.Businesslayer.Concreate
{
    public class CarManager : ICarService
    {
        private readonly ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }
        public List<Car> TGetCarsByCategoryId(int id)
        {
            return _carDal.GetCarsByCategoryId(id);
        }
        public async Task TDeleteAsync(int id)
        {
            await _carDal.DeleteAsync(id);
        }

        public async Task<List<Car>> TGetAllCarWithCategoryAsync()
        {
           return await _carDal.GetAllCarWithCategoryAsync();
        }

        public async Task<Car> TGetByIdAsync(int id)
        {
            return await _carDal.GetByIdAsync(id);
        }

        public async Task<List<Car>> TGetListAsync()
        {
           return await _carDal.GetListAsync();
        }

        public async Task TInsertAsync(Car entity)
        {
           await _carDal.InsertAsync(entity);
        }

        public async Task TUpdateAsync(Car entity)
        {
           await _carDal.UpdateAsync(entity);
        }
    }
}
