using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using VrrrRent.Abstractions;
using VrrrRent.Models;

namespace VrrrRent.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected VrrrRentContext VrrrRentContext { get; set; }

        public RepositoryBase(VrrrRentContext vrrrRentContext)
        {
            this.VrrrRentContext = vrrrRentContext;
        }

        public IQueryable<T> FindAll()
        {
            return this.VrrrRentContext.Set<T>().AsNoTracking();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return this.VrrrRentContext.Set<T>().Where(expression).AsNoTracking();
        }

        public void Create(T entity)
        {
            this.VrrrRentContext.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            this.VrrrRentContext.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            this.VrrrRentContext.Set<T>().Remove(entity);
        }

    }
}
