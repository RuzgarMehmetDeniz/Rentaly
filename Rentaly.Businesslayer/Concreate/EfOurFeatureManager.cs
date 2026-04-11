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
    public class EfOurFeatureManager : IOurFeatureService
    {
        private readonly IOurFeatureDal _ourFeatureDal;

        public EfOurFeatureManager(IOurFeatureDal ourFeatureDal)
        {
            _ourFeatureDal = ourFeatureDal;
        }

        public async Task TDeleteAsync(int id)
        {
            await _ourFeatureDal.DeleteAsync(id);
        }

        public async Task<OurFeature> TGetByIdAsync(int id)
        {
           return await _ourFeatureDal.GetByIdAsync(id);
        }

        public Task<List<OurFeature>> TGetListAsync()
        {
           return _ourFeatureDal.GetListAsync();
        }

        public async Task TInsertAsync(OurFeature entity)
        {
           await _ourFeatureDal.InsertAsync(entity);
        }

        public async Task TUpdateAsync(OurFeature entity)
        {
           await _ourFeatureDal.UpdateAsync(entity);
        }
    }
}
