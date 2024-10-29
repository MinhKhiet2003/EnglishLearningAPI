using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Payment
{
    [Key]
    public int payment_id { get; set; }

    [ForeignKey("User")]
    public int user_id { get; set; }

    public decimal amount { get; set; }

    public DateTime payment_date { get; set; }

    [StringLength(255)]
    public string payment_method { get; set; }

    // Navigation property
    public User User { get; set; }
}
