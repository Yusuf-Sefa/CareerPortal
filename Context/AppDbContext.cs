
using CareerPortal.Models;
using Microsoft.EntityFrameworkCore;

namespace CareerPortal.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<User> Users => Set<User>();
    public DbSet<UserProfile> UserProfiles => Set<UserProfile>();
    public DbSet<RecruiterProfile> RecruiterProfiles => Set<RecruiterProfile>();
    public DbSet<Company> Companies => Set<Company>();
    public DbSet<UserExperience> UserExperiences => Set<UserExperience>();
    public DbSet<UserEducation> UserEducations => Set<UserEducation>();
    public DbSet<Skill> Skills => Set<Skill>();
    public DbSet<UserSkill> UserSkills => Set<UserSkill>();
    public DbSet<UserSkillHistory> UserSkillHistories => Set<UserSkillHistory>();
    public DbSet<JobPosting> JobPostings => Set<JobPosting>();
    public DbSet<JobSkill> JobSkills => Set<JobSkill>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.HasPostgresExtension("vector");


        modelBuilder.Entity<UserSkill>()
            .HasKey(us => new { us.UserProfileId, us.SkillId });

        modelBuilder.Entity<JobSkill>()
            .HasKey(js => new { js.JobPostingId, js.SkillId });


        modelBuilder.Entity<UserProfile>(entity =>
        {
            // float[] dizisini pgvector vector(1536) tipine eşleştirildi
            entity.Property(u => u.CvEmbedding)
                  .HasColumnType("vector(1536)");

            // Kosinüs benzerliği aramaları için HNSW indeksi
            entity.HasIndex(u => u.CvEmbedding)
                  .HasMethod("hnsw")
                  .HasOperators("vector_cosine_ops");
        });

        modelBuilder.Entity<JobPosting>(entity =>
        {
            entity.Property(j => j.JobEmbedding)
                  .HasColumnType("vector(1536)");

            entity.HasIndex(j => j.JobEmbedding)
                  .HasMethod("hnsw")
                  .HasOperators("vector_cosine_ops");
        });

        modelBuilder.Entity<JobPosting>()
            .HasOne(j => j.RecruiterProfile)
            .WithMany(r => r.JobPostings)
            .HasForeignKey(j => j.RecruiterProfileId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}