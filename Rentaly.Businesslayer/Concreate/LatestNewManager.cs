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
    public class LatestNewManager : ILatestNewService
    {
        private readonly ILatestNewDal _latestNewDal;

        public LatestNewManager(ILatestNewDal latestNewDal)
        {
            _latestNewDal = latestNewDal;
        }

        public async Task TDeleteAsync(int id)
        {
            await _latestNewDal.DeleteAsync(id);
        }

        public async Task<LatestNew> TGetByIdAsync(int id)
        {
           return await _latestNewDal.GetByIdAsync(id);
        }

        public async Task<List<LatestNew>> TGetListAsync()
        {
           return await _latestNewDal.GetListAsync();
        }

        public async Task TInsertAsync(LatestNew entity)
        {
           await _latestNewDal.InsertAsync(entity);
        }

        public async Task TUpdateAsync(LatestNew entity)
        {
           await _latestNewDal.UpdateAsync(entity);
        }
    }
}
