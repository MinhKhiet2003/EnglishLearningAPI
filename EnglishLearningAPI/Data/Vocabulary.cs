using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnglishLearningAPI.Data
{
    public class Vocabulary
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int vocab_id { get; set; }
        public string word { get; set; }
        public string meaning { get; set; }
        public string example_sentence { get; set; }
        [Required]
        public int topic_id { get; set; }
        public string pronunciation { get; set; }

    }
}
