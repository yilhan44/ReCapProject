using Core.DataAccess;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Core.EntityFramework
{
    public class EfEntityFrameworkBase<TEntity, TContex> : IEntityRepository<TEntity> where TEntity : class, IEntity, new()
        where TContex : DbContext, new()
    {
        public void Add(TEntity entity)
        {
            using (TContex contex = new TContex())
            {

                var addedEntity = contex.Entry(entity);
                addedEntity.State = EntityState.Added;
                contex.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContex contex = new TContex())
            {
                var deletedEntity = contex.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                contex.SaveChanges();
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContex contex = new TContex())
            {
                return filter == null ? contex.Set<TEntity>().ToList()
                    : contex.Set<TEntity>().Where(filter).ToList();
            }
        }


        public TEntity GetById(Expression<Func<TEntity, bool>> filter)
        {
            using (TContex contex = new TContex())
            {
                return contex.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public void Update(TEntity entity)
        {
            using (TContex contex = new TContex())
            {
                var updatedEntity = contex.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                contex.SaveChanges();
            }
        }
    }
}
