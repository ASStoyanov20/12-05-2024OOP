using HrManagement.DataAccess.Data;
using HrManagement.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace HrManagement.DataAccess.Repository.Base
{
    public abstract class BaseRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly HrManagementDbContext _context;
        private readonly DbSet<T> _dbSet;

        protected BaseRepository(HrManagementDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public virtual T? GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public virtual IQueryable<T> GetAll()
        {
            return _dbSet.AsQueryable();
        }

        public virtual bool Add(T entity)
        {
            _dbSet.Add(entity);
            return _context.SaveChanges() > 0;
        }

        public virtual bool Update(T entity)
        {
            var trackedEntity = _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            return _context.SaveChanges() > 0;
        }

        protected abstract void UpdateEntity(T existingEntity, T newEntity);

        public virtual bool Delete(int id)
        {
            var entity = GetById(id);
            if (entity == null) return false;

            _dbSet.Remove(entity);
            DeleteAdditionalDependencies(entity);
            return _context.SaveChanges() > 0;
        }

        protected virtual void DeleteAdditionalDependencies(T entity)
        {
        }
    }
}