using System.ComponentModel.DataAnnotations.Schema;

using System.ComponentModel.DataAnnotations;
namespace WebApExample.Models
{
    public class Cars
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CarId { get; set; }
        public int CarName { get; set; }
        public string? CarType { get; set; }
        public int MaxPasNum { get; set; }
        public virtual ICollection<Trips>? Trips{ get; set; }
    }
}
