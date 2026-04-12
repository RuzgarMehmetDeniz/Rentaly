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
    public class ContactManager : IContactService
    {
        private readonly IContactDal _contactDal;

        public ContactManager(IContactDal contactDal)
        {
            _contactDal = contactDal;
        }

        public async Task TDeleteAsync(int id)
        {
            await _contactDal.DeleteAsync(id);
        }

        public async Task<Contact> TGetByIdAsync(int id)
        {
            return await _contactDal.GetByIdAsync(id);
        }

        public async Task<List<Contact>> TGetListAsync()
        {
            return await _contactDal.GetListAsync();
        }

        public async Task TInsertAsync(Contact entity)
        {
            await _contactDal.InsertAsync(entity);
        }

        public async Task TUpdateAsync(Contact entity)
        {
            await _contactDal.UpdateAsync(entity);
        }
    }
}
