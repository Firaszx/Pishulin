using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Organization.Models
{
    public class Supplier
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SupId { get; set; }
        public string Name { get; set; }
        public string ActivityType { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public virtual ICollection<SupplierOrder> SupplierOrder { get; set; }
    }
}
