using ApiTest.Common.Domain.Entity.Base;
using ApiTest.Common.Domain.Specifications.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTest.Common.Domain.Repository.Base
{
    public interface IRepositoryAsync<TEntity> where TEntity : EntityBase
    {
        Task<TEntity> GetByIdAsync(int id);

        Task<IReadOnlyList<TEntity>> ListAllAsync();

        Task<IReadOnlyList<TEntity>> ListAsync(ISpecification<TEntity> spec);

        Task<IEnumerable<TEntity>> GetPaginatedResult(int pageSize, int pageNumber);

        Task<int> CountTotalRecords();

        Task<TEntity> AddAsync(TEntity entity);        

        Task UpdateAsync(TEntity entity);
        Task UpdateAsync(TEntity oldEntity, TEntity newEntity);

        Task DeleteAsync(TEntity entity);

        Task<int> CountAsync(ISpecification<TEntity> spec);
    }
}
