using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnglishLearningAPI.Data
{
    public class Course
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int course_id { get; set; }
        [Required]
        public string course_name { get; set; }
        [Required]
        public string description { get; set; }
    }
}
