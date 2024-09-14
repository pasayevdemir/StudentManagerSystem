using Core.DataAccess.EFCore.Concret;
using DataAccess.Context;
using Entities.TableModels;

namespace DataAccess.EFCore
{
    public class StudentDal : EFCoreRepository<Student, MyDbContext>, IStudentDal
    {
        public StudentDal(MyDbContext context) : base(context)
        {
        }
    }
}
