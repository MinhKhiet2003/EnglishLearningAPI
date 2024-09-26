using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnglishLearningAPI.Data
{
    public class User_Progress
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int progress_id { get; set; }
        [Required]
        public int user_id { get; set; }
        [Required]
        public int vocab_id { get; set; }
        [Required]
        public int review_interval { get; set; }
        public DateTime? last_reviewed { get; set; }
        public DateTime? next_review { get; set; }

    }
}
