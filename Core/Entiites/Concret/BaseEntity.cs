namespace Core.Entiites
{
    public abstract class BaseEntity : IEntity
    {
        public int ID { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int Deleted { get; set; }  
    }
}
