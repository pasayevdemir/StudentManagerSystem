using Core.Entiites;

namespace Entities.TableModels
{
    public class Student : BaseEntity, IEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
