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
    public class AwardManager : IAwardService
    {
        private readonly IAwardDal _awardDal;

        public AwardManager(IAwardDal awardDal)
        {
            _awardDal = awardDal;
        }

        public async Task TDeleteAsync(int id)
        {
            await _awardDal.DeleteAsync(id);
        }

        public async Task<Award> TGetByIdAsync(int id)
        {
          return await _awardDal.GetByIdAsync(id);
        }

        public async Task<List<Award>> TGetListAsync()
        {
           return await _awardDal.GetListAsync();
        }

        public async Task TInsertAsync(Award entity)
        {
           await _awardDal.InsertAsync(entity);
        }

        public async Task TUpdateAsync(Award entity)
        {
           await _awardDal.UpdateAsync(entity);
        }
    }
}
