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
    public class FAQManager : IFAQService
    {
        private readonly IFAQDal _faqDal;

        public FAQManager(IFAQDal faqDal)
        {
            _faqDal = faqDal;
        }

        public async Task TDeleteAsync(int id)
        {
          await _faqDal.DeleteAsync( id );
        }

        public async Task<FAQ> TGetByIdAsync(int id)
        {
            return await _faqDal.GetByIdAsync( id );
        }

        public async Task<List<FAQ>> TGetListAsync()
        {
            return await _faqDal.GetListAsync();
        }

        public async Task TInsertAsync(FAQ entity)
        {
            await _faqDal.InsertAsync(entity);
        }

        public async Task TUpdateAsync(FAQ entity)
        {
            await _faqDal.UpdateAsync(entity);
        }
    }
}
