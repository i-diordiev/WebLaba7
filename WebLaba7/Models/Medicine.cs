using System.ComponentModel.DataAnnotations;

namespace WebLaba7.Models
{
    public class Medicine
    {
        [Key]
        [Required]
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }
        
        [Required]
        public float Price { get; set; }
    }
}