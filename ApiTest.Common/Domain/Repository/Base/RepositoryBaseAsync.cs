using Microsoft.EntityFrameworkCore;
using ApiTest.Common.Domain.Entity.Base;
using ApiTest.Common.Domain.Specifications.Base;
using ApiTest.Common.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ApiTest.Common.Domain.Repository.Base
{
    public abstract class RepositoryBaseAsync<TEntity> : IRepositoryAsync<TEntity>
        where TEntity : EntityBase
    {
        protected readonly AppDbContext dbcontext;

        public RepositoryBaseAsync(AppDbContext context)
        {
            this.dbcontext = context;
        }

        
        public virtual async Task<TEntity> GetByIdAsync(int id)
        {
            TEntity entity = await dbcontext.Set<TEntity>().FindAsync(id);
            dbcontext.Entry(entity).State = EntityState.Detached;
            return entity;
        }
        

        public async Task<IReadOnlyList<TEntity>> ListAllAsync()
        {
            return await dbcontext.Set<TEntity>().AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetPaginatedResult(int pageSize, int pageNumber)
        {
            return await this.dbcontext.Set<TEntity>().Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
        }

        public async Task<int> CountTotalRecords()
        {
            return await dbcontext.Set<TEntity>().CountAsync();
        }

        public async Task<IReadOnlyList<TEntity>> ListAsync(ISpecification<TEntity> spec)
        {
            return await ApplySpecification(spec).AsNoTracking().ToListAsync();
        }

        public async Task<int> CountAsync(ISpecification<TEntity> spec)
        {
           return await ApplySpecification(spec).CountAsync();
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
           dbcontext.Set<TEntity>().Add(entity);
           await dbcontext.SaveChangesAsync();
           dbcontext.Entry(entity).State = EntityState.Detached;
           return entity;
        }

        public async Task UpdateAsync(TEntity entity)
        {
            dbcontext.Entry(entity).State = EntityState.Modified;
            await dbcontext.SaveChangesAsync();
            dbcontext.Entry(entity).State = EntityState.Detached;
        }


        public async Task UpdateAsync(TEntity oldEntity, TEntity newEntity)
        {
            dbcontext.Entry(oldEntity).CurrentValues.SetValues(newEntity);
            await dbcontext.SaveChangesAsync();
            dbcontext.Entry(oldEntity).State = EntityState.Detached;
            dbcontext.Entry(newEntity).State = EntityState.Detached;
        }



        public async Task DeleteAsync(TEntity entity)
        {
            dbcontext.Set<TEntity>().Remove(entity);
            await dbcontext.SaveChangesAsync();
            dbcontext.Entry(entity).State = EntityState.Detached;
        }

        private IQueryable<TEntity> ApplySpecification(ISpecification<TEntity> spec)
        {
            return SpecificationEvaluator<TEntity>.GetQuery(dbcontext.Set<TEntity>().AsQueryable(), spec);
        }
    }
}
