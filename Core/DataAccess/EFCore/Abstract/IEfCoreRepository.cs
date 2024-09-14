namespace Core.DataAccess.EFCore.Abstract
{
    public interface IEfCoreRepository<TEntity, TContext>
    {
        TEntity Add(TEntity t);
        TEntity Update(TEntity t);
        void Delete(TEntity t);
        List<TEntity> GetAll();
        TEntity GetById(int id);
    }
}
