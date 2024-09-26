namespace EnglishLearningAPI.Models
{
    public class Course
    {
        public int course_id { get; set; }
        public string course_name { get; set; }
        public string description { get; set; }

        public ICollection<Topic> topic { get; set; }
        public ICollection<User_Progress> user_progress { get; set; }
    }
}
