using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Subscription
{
    [Key]
    public int subscription_id { get; set; }

    [ForeignKey("User")]
    public int user_id { get; set; }

    [StringLength(50)]
    public string plan { get; set; }

    public DateTime start_date { get; set; }

    public DateTime end_date { get; set; }

    // Navigation property
    public User User { get; set; }
}
