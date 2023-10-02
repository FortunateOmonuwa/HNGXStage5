

namespace TestmeQA.Domain.Common
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public string CreatedBy { get; set; } = null!;
        public DateTime DateCreated { get; set; }
        public string Updatedby { get; set; } = null!;
        public DateTime UpdatedDate { get; set; }
    }
}
