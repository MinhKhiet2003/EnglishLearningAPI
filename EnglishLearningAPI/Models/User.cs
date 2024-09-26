namespace EnglishLearningAPI.Models
{
    public class User
    {
        public int user_id { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string? subscription_plan { get; set; }
        public DateTime? subscription_start_date { get; set; }
        public DateTime? subscription_end_date { get; set; }
        public string role { get; set; }

        public ICollection<Subscription> Subscriptions { get; set; }
        public ICollection<User_Progress> Progresses { get; set; }
    }
}
