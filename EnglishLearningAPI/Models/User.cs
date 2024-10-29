using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class User
{
    [Key]
    public int user_id { get; set; }

    [Required]
    [StringLength(255)]
    public string email { get; set; }

    [Required]
    [StringLength(255)]
    public string password { get; set; }

    [StringLength(50)]
    public string subscription_plan { get; set; }

    public DateTime? subscription_start_date { get; set; }

    public DateTime? subscription_end_date { get; set; }

    [StringLength(50)]
    public string role { get; set; }

    [StringLength(512)]
    public string refresh_token { get; set; }

    public DateTime? refresh_token_expiry { get; set; }

    // Navigation properties
    public ICollection<Payment> Payments { get; set; }
    public ICollection<Subscription> Subscriptions { get; set; }
    public ICollection<UserProgress> User_Progresses { get; set; }
}
