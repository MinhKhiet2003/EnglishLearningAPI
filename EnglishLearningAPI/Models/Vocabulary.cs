using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Vocabulary
{
    [Key]
    public int vocab_id { get; set; }

    [StringLength(255)]
    public string word { get; set; }

    public string meaning { get; set; }

    public string example_sentence { get; set; }

    [ForeignKey("Topic")]
    public int topic_id { get; set; }

    public string pronunciation { get; set; }

    // Navigation properties
    public Topic Topic { get; set; }
    public ICollection<UserProgress> User_Progresses { get; set; }
}
