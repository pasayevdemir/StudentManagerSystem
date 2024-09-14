using Core.DataAccess.EFCore.Abstract;
using DataAccess.Context;
using Entities.TableModels;

namespace DataAccess.EFCore
{
    public interface IStudentDal : IEfCoreRepository<Student,MyDbContext>
    {
    }
}
