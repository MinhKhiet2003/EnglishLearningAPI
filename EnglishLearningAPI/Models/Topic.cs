using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Topic
{
    [Key]
    public int topic_id { get; set; }

    [StringLength(255)]
    public string topic_name { get; set; }

    [ForeignKey("Course")]
    public int course_id { get; set; }

    public string description { get; set; }

    public int order { get; set; }

    // Navigation properties
    public Course Course { get; set; }
    public ICollection<Vocabulary> Vocabularies { get; set; }
}
