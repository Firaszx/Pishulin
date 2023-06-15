using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace Organization.Models
{
        public class Seller
        {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SellerId { get; set; }
            public string LastName { get; set; }
            public string FirstName { get; set; }
            public string MiddleName { get; set; }
            public int TPId { get; set; }
            public string Position { get; set; }
            public int BirthYear { get; set; }
            public string Gender { get; set; }
            public string Address { get; set; }
            public string City { get; set; }
            public virtual ICollection<TradingPoint> TradingPoint{ get; set; }
    }
}
//into
//public virtual  TradingPoint TradingPoint { get; set; }