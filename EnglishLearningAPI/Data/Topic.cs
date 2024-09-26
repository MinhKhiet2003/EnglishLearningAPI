using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnglishLearningAPI.Data
{
    public class Topic
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int topic_id { get; set; }
        public string? topic_name { get; set; }
        [Required]
        public int course_id { get; set; }
        public string? description { get; set; }
        [Required]
        public int order { get; set; }

    }
}
