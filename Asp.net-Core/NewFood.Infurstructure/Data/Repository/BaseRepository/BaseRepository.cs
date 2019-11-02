using NewsFood.Core.Dto;
using NewsFood.Core.Entities.BaseEntities;
using NewsFood.Core.Interface.BaseEntity;
using NewsFood.Core.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NewFood.Infurstructure.Data.Repository.BaseRepository
{
    public class BaseRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly IUnitOfWork _unitOfWork;
        public BaseRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public virtual async Task<int> InsertAsync(TEntity entity)
        {
            _unitOfWork.Repository<TEntity>().Insert(entity);
            var result = await _unitOfWork.SaveChangeAsync();
            return result;
        }

        public virtual async Task<int> DeleteSoft(TEntity entity)
        {
            entity.IsDeleted = true;
            _unitOfWork.Repository<TEntity>().Update(entity);
            var result = await _unitOfWork.SaveChangeAsync();
            return result;
        }

        public virtual async Task<bool> Delete(TEntity entity)
        {
            _unitOfWork.Repository<TEntity>().Delete(entity);
            var result = await _unitOfWork.SaveChangeAsync();
            if(result > 0)
            {
                return true;
            }
            return false;
        }

        public virtual async Task<int> UpdateAsync(TEntity entity)
        {
            _unitOfWork.Repository<TEntity>().Update(entity);
            var result = await _unitOfWork.SaveChangeAsync();
            return result;
        }
    }
}
