using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Organization.Models
{
    public class SupplierOrder
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SupOId { get; set; }
        public DateTime OrderDate { get; set; }
      
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        //
        public string SupName { get; set; }
        public virtual Supplier Supplier { get; set; }
        //
        public string name { get; set; }
        public virtual TradingPoint TradingPoint { get; set; }
        //
    }
}
//public int TPId { get; set; }
//public virtual TradingPoint TradingPoint { get; set; }
//public int SupId { get; set; }
//public virtual Supplier Supplier { get; set; }