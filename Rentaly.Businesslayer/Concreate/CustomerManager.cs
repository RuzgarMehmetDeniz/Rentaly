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
    public class CustomerManager : ICustomerService
    {
        private readonly ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public async Task TDeleteAsync(int id)
        {
            await _customerDal.DeleteAsync(id);
        }

        public async Task<Customer> TGetByIdAsync(int id)
        {
            return await _customerDal.GetByIdAsync(id);
        }

        public async Task<List<Customer>> TGetListAsync()
        {
            return await _customerDal.GetListAsync();
        }

        public async Task TInsertAsync(Customer entity)
        {
           await _customerDal.InsertAsync(entity);
        }

        public async Task TUpdateAsync(Customer entity)
        {
            await _customerDal.UpdateAsync(entity);
        }
    }
}
