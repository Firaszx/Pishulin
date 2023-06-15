using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace Organization.Models
{
    public class TradingPoint
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TPId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int TOId { get; set; }
        public string Address { get; set; }
        public string ManagerFullName { get; set; }

        //
        public string TOName { get; set; }
        public virtual TradingOrganization TradingOrganization { get; set; }
        //
        public string ProdavecName { get; set; }
        public virtual Seller Seller { get; set; }
        //
        public virtual ICollection<SupplierOrder> SupplierOrder { get; set; }
        //public virtual ICollection<Seller> Sellers { get; set; }
        //public virtual ICollection<SupplierOrder> SupplierOrders { get; set; }
        //public virtual TradingOrganization TradingOrganization { get; set; }
    }
}
