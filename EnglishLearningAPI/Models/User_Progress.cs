namespace EnglishLearningAPI.Models
{
    public class User_Progress
    {
        public int progress_id { get; set; }
        public int user_id { get; set; }
        public int vocab_id { get; set; }
        public int review_interval { get; set; }
        public DateTime? last_reviewed { get; set; }
        public DateTime? next_review { get; set; }

        public User User { get; set; }
        public Course Course { get; set; }
    }
}
