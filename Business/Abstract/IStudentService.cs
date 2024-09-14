using Core.Results.Abstract;
using Entities.TableModels;

namespace Business.Abstract
{
    public interface IStudentService
    {
        IResult Add(Student student);
        IResult Update(Student student);
        IResult Delete(int id);
        IDataResult<List<Student>> GetAll();
        IDataResult<Student> GetById(int id);
    }
}
