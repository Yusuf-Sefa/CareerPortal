
namespace CareerPortal.Models;

public class UserSkillHistory
{
    public int Id { get; set; }
    public int UserProfileId { get; set; }
    public int SkillId { get; set; }
    public string? AiCoachNote { get; set; }
    public DateTime RecordedAt { get; set; } = DateTime.UtcNow;

    // Navigation Properties
    public UserProfile UserProfile { get; set; } = null!;
    public Skill Skill { get; set; } = null!;
}