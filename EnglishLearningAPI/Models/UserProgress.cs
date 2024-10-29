using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class UserProgress
{
    [Key]
    public int progress_id { get; set; }

    [ForeignKey("User")]
    public int user_id { get; set; }

    [ForeignKey("Vocabulary")]
    public int vocab_id { get; set; }

    public int review_interval { get; set; }

    public DateTime last_reviewed { get; set; }

    public DateTime next_review { get; set; }

    // Navigation properties
    public User User { get; set; }
    public Vocabulary Vocabulary { get; set; }
}
