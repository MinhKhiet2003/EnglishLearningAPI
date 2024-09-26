namespace EnglishLearningAPI.Models
{
    public class Payment
    {
        public int payment_id { get; set; }
        public int user_id { get; set; }
        public decimal amount { get; set; }
        public DateTime payment_date { get; set; }
        public string payment_method { get; set; }

        public User user { get; set; }
    }
}
