namespace EnglishLearningAPI.Models
{
    public class Vocabulary
    {
        public int vocab_id { get; set; }
        public string word { get; set; }
        public string meaning { get; set; }
        public string example_sentence { get; set; }
        public int topic_id { get; set; }
        public string pronunciation { get; set; }

    }
}
