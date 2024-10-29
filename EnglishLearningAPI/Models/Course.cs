using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class Course
{
    [Key]
    public int course_id { get; set; }

    [StringLength(255)]
    public string course_name { get; set; }

    public string description { get; set; }

    // Navigation properties
    public ICollection<Topic> Topics { get; set; }
}
