using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Models
{
    public class Clips
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Clip Name")]
        [MaxLength(30)]
        public string? Name { get; set; }
        [Required]
        [DisplayName("Clip Description")]
        // [Range(1,100)]
        public string? Description { get; set; }
    }
}
