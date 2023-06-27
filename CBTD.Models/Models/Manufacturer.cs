using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace CBTD.ApplicationCore.Models
{
    public class Manufacturer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public DateTime DateModified { get; set; } = DateTime.Now;

    }
}
