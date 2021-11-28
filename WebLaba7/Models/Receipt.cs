using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebLaba7.Models
{
    public class Receipt
    {
        [Key]
        [Required]
        public int Id { get; set; }
        
        public string ClientFirstName { get; set; }
        
        public string ClientLastName { get; set; }
        
        [Required]
        public string ClientPhoneNumber { get; set; }
        
        [Required]
        public int MedicineId { get; set; }
        
        [ForeignKey("MedicineId")]
        public Medicine Medicine { get; set; }
    }
}