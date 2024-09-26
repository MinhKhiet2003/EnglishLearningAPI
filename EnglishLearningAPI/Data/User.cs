using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnglishLearningAPI.Data
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int user_id { get; set; }
        [Required]
        [EmailAddress]
        public string email { get; set; }
        [Required]
        public string password { get; set; }
        [Required]
        public int subscription_plan { get; set; }
        public DateTime? subscription_start_date { get; set; }
        public DateTime? subscription_end_date { get; set; }
        [Required]
        public string role { get; set; }

    }
}
