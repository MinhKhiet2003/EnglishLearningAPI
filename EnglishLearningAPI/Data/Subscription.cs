using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnglishLearningAPI.Data
{
    public class Subscription
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int subscription_id { get; set; }
        [Required]
        public int user_id { get; set; }
        [Required]
        public int plan { get; set; }
        public DateTime? start_date { get; set; }
        public DateTime? end_date { get; set; }

    }
}
