using NewsFood.Core.Dto;
using NewsFood.Core.Entities.BaseEntities;
using NewsFood.Core.Interface.BaseEntity;
using NewsFood.Core.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NewsFood.Infurstructure.Data.Repository.BaseRepository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly IUnitOfWork _unitOfWork;
        public BaseRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> InsertAsync(TEntity entity)
        {
            _unitOfWork.Repository<TEntity>().Insert(entity);
            var result = await _unitOfWork.SaveChangeAsync();
            return result;
        }

        public async Task<int> DeleteSoft(TEntity entity)
        {
            entity.IsDeleted = true;
            _unitOfWork.Repository<TEntity>().Update(entity);
            var result = await _unitOfWork.SaveChangeAsync();
            return result;
        }

        public async Task<bool> Delete(TEntity entity)
        {
            _unitOfWork.Repository<TEntity>().Delete(entity);
            var result = await _unitOfWork.SaveChangeAsync();
            if(result > 0)
            {
                return true;
            }
            return false;
        }

        public async Task<int> UpdateAsync(TEntity entity)
        {
            _unitOfWork.Repository<TEntity>().Update(entity);
            var result = await _unitOfWork.SaveChangeAsync();
            return result;
        }
    }
}
