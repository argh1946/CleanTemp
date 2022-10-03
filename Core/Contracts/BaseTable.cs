namespace Core.Contracts
{
    public abstract class BaseTable : BaseEntity
    {
        public int Creator { get; set; }
        public DateTime CreatedDate { get; set; }     
        public DateTime? ModifiedDate { get; set; }        
    }
}