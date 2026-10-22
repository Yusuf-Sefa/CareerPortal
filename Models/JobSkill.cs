
namespace CareerPortal.Models;

public class JobSkill
{
    public int JobPostingId { get; set; }
    public int SkillId { get; set; }

    // Navigation Properties
    public JobPosting JobPosting { get; set; } = null!;
    public Skill Skill { get; set; } = null!;
}