using Core.DataAccess.EFCore.Abstract;
using Core.Entiites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Core.DataAccess.EFCore.Concret
{
    public class EFCoreRepository<TEntity, TContext> : IEfCoreRepository<TEntity, TContext>
        where TEntity : BaseEntity, IEntity, new()
        where TContext : DbContext
    {
        public EFCoreRepository(TContext context)
        {
            Context = context;
        }
        protected TContext Context { get; }

        public TEntity Add(TEntity t)
        {
            //1.Əlavə etmək üçün sql code genarasiya edir.
            //insert into Student(...) values(..) 
            //2.Kodu database işlədir.
            //3.Geri bir nəticə qaytarır.
            var entity = Context.Add(t).Entity;
            Context.SaveChanges();
            return entity;
        }

        public TEntity Update(TEntity t)
        {
            var entity = Context.Update(t).Entity;
            Context.SaveChanges();
            return entity;
        }

        public void Delete(TEntity t)
        {
            var entity = Context.Remove(t).Entity;
            Context.SaveChanges();
        }

        public List<TEntity> GetAll()
        {
            return Context.Set<TEntity>().AsQueryable().AsNoTracking().ToList();
        }

        public TEntity GetById(int id)
        {
            return Context.Set<TEntity>().SingleOrDefault(x => x.ID == id);
        }
    }
}
