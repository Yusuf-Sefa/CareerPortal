
namespace CareerPortal.Models;

public class UserSkillHistory
{
    public Guid Id { get; set; }
    public Guid UserProfileId { get; set; }
    public Guid SkillId { get; set; }
    public string? AiCoachNote { get; set; }
    public DateTime RecordedAt { get; set; } = DateTime.UtcNow;

    // Navigation Properties
    public UserProfile UserProfile { get; set; } = null!;
    public Skill Skill { get; set; } = null!;
}