using Business.Abstract;
using Business.Validations;
using Core.Results.Abstract;
using Core.Results.Concrete;
using DataAccess.EFCore;
using Entities.TableModels;

namespace Business.Concrete
{
    public class StudentManager : IStudentService
    {
        private IStudentDal _studentDal;
        private StudentValidation _validationRules;

        public StudentManager(StudentValidation validationRules, IStudentDal studentDal)
        {
            _validationRules = validationRules;
            _studentDal = studentDal;
        }

        public IResult Add(Student student)
        {
            //Validate
            var vaildation = _validationRules.Validate(student);
            if (!vaildation.IsValid)
            {
                foreach (var error in vaildation.Errors)
                {
                    return new ErrorResult(error.ErrorMessage);
                }
            }
            //add Database
            var result = _studentDal.Add(student);
            if (result is null)
                return new ErrorResult("Error");
            return new SuccessResult("Əməliyyat uğurla tamamlandı!");
        }

        public IResult Delete(int id)
        {
            //check in database inculding entity
            var foundStudent = _studentDal.GetById(id);
            if (foundStudent != null)
            {
                return new ErrorResult("Element tapılmadı!");
            }
            //Delete Database
            _studentDal.Delete(foundStudent);
            return new SuccessResult("Əməliyyat uğurla tamamlandı!");
        }

        public IDataResult<List<Student>> GetAll()
        {
            var student = _studentDal.GetAll();
            if (student is null)
            {
                return new ErrorDataResult<List<Student>>("Element tapılmadı!");
            }
            return new SuccessDataResult<List<Student>>(student);
        }

        public IDataResult<Student> GetById(int id)
        {
            var student = _studentDal.GetById(id);
            if(student is null)
            {
                return new ErrorDataResult<Student>("Element tapılmadı!");
            }
            return new SuccessDataResult<Student>(student);
        }

        public IResult Update(Student student)
        {
            //Validate
            var vaildation = _validationRules.Validate(student);
            if (!vaildation.IsValid)
            {
                foreach (var error in vaildation.Errors)
                {
                    return new ErrorResult(error.ErrorMessage);
                }
            }

            //update Database
            _studentDal.Update(student);
            return new SuccessResult("Əməliyyat uğurla tamamlandı!");
        }
    }
}
