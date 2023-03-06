using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MultiBackend.Entities
{
    public class BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTimeOffset? CreatedDate { get; set; } = DateTimeOffset.UtcNow;
        virtual public DateTimeOffset? UpdatedDate { get; set; } = DateTimeOffset.UtcNow;
    }
}
