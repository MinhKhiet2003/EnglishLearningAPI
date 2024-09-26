using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnglishLearningAPI.Data
{
    public class Payment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int payment_id { get; set; }
        [Required]
        public int user_id { get; set; }
        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal amount { get; set; }
        public DateTime? payment_date { get; set; }
        public string? payment_method { get; set; }
    }
}
