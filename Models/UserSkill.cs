
namespace CareerPortal.Models;

public class UserSkill
{
    public int UserProfileId { get; set; }
    public int SkillId { get; set; }

    // Navigation Properties
    public UserProfile UserProfile { get; set; } = null!;
    public Skill Skill { get; set; } = null!;
}