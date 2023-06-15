using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Organization.Models
{
    public class TradingOrganization
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TOId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string DirectorFullName { get; set; }
        public string NalogNumber { get; set; }
        public virtual ICollection<TradingPoint> TradingPoint { get; set; }
        //public virtual ICollection<SupplierOrder> SupplierOrder { get; set; }
    }
}