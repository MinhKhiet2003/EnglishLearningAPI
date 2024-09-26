namespace EnglishLearningAPI.Models
{
    public class Subscription
    {
        public int subscription_id { get; set; }
        public int user_id { get; set; }
        public string plan { get; set; }
        public DateTime start_date { get; set; }
        public DateTime end_date { get; set; }

        public User user { get; set; }
    }
}
