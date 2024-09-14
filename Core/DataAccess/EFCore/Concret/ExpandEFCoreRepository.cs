using Core.DataAccess.EFCore.Abstract;
using Core.Entiites;
using Microsoft.EntityFrameworkCore;

namespace Core.DataAccess.EFCore.Concret
{
    public class ExpandEFCoreRepository<TModel, TContext>
                      : IEfCoreRepository<TModel, TContext>
        where TModel : BaseEntity, IEntity, new()
        where TContext : DbContext
    {
        public TModel Add(TModel t)
        {
            throw new NotImplementedException();
        }

        public void Delete(TModel t)
        {
            throw new NotImplementedException();
        }

        public List<TModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public TModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public TModel Update(TModel t)
        {
            throw new NotImplementedException();
        }

        public TModel AddRange()
        {
            throw new NotImplementedException();
        }


        public TModel AddRangeAsc()
        {
            throw new NotImplementedException();
        }

        public TModel GetByIdAnc(int id)
        {
            throw new NotImplementedException();
        }
    }
}
