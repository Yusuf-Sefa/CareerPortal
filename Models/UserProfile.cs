
namespace CareerPortal.Models;

public class UserProfile
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Title { get; set; }
    public string? Summary { get; set; }
    public string? CvRawText { get; set; }
    public float[]? CvEmbedding { get; set; }
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;


    // Navigation Properties
    public User User { get; set; } = null!;
    public ICollection<UserExperience> Experiences { get; set; } = [];
    public ICollection<UserEducation> Educations { get; set; } = [];
    public ICollection<UserSkill> UserSkills { get; set; } = [];
    public ICollection<UserSkillHistory> SkillHistories { get; set; } = [];
}