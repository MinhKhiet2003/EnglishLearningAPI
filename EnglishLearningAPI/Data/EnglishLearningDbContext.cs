using Microsoft.EntityFrameworkCore;

namespace EnglishLearningAPI.Data
{
    public class EnglishLearningDbContext : DbContext
    {
        public EnglishLearningDbContext(DbContextOptions<EnglishLearningDbContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Vocabulary> Vocabularies { get; set; }
        public DbSet<UserProgress> UserProgresses { get; set; }
       
    }
}
