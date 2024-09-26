namespace EnglishLearningAPI.Models
{
    public class Topic
    {
        public int topic_id { get; set; }
        public string topic_name { get; set; }
        public int course_id { get; set; }
        public string description { get; set; }
        public int order { get; set; }

        public Course course { get; set; }
    }
}
