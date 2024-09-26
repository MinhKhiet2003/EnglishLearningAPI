using Microsoft.EntityFrameworkCore;

namespace EnglishLearningAPI.Data
{
    public class EnglishLearningContext : DbContext
    {
        public EnglishLearningContext(DbContextOptions<EnglishLearningContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<User_Progress> User_Progresses { get; set; }
        public DbSet<Vocabulary> Vocabularys { get; set; }
    }
}
