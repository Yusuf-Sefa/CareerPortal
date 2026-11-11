
namespace CareerPortal.Models;

public class UserSkill
{
    public Guid UserProfileId { get; set; }
    public Guid SkillId { get; set; }

    // Navigation Properties
    public UserProfile UserProfile { get; set; } = null!;
    public Skill Skill { get; set; } = null!;
}