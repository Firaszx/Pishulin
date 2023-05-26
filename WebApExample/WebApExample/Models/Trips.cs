using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.ComponentModel.DataAnnotations;
namespace WebApExample.Models
{
    public class Trips
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TravelID { get; set; }
        public int Cost { get; set; }
        public int Duration { get; set; }
        public int PasNum { get; set; }
        public virtual Cars? Cars { get; set; }
        public virtual Persons? Persons { get; set; }

    }
}
