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
    public class RentalManager : IRentalService
    {
        private readonly IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public async Task TDeleteAsync(int id)
        {
            await _rentalDal.DeleteAsync(id);
        }

        public async Task<Rental> TGetByIdAsync(int id)
        {
         return await _rentalDal.GetByIdAsync(id);
        }

        public async Task<List<Rental>> TGetListAsync()
        {
            return await _rentalDal.GetListAsync();
        }

        public async Task TInsertAsync(Rental entity)
        {
            await _rentalDal.InsertAsync(entity);
        }

        public async Task TUpdateAsync(Rental entity)
        {
            await _rentalDal.UpdateAsync(entity);
        }
    }
}
