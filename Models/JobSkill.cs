
namespace CareerPortal.Models;

public class JobSkill
{
    public Guid JobPostingId { get; set; }
    public Guid SkillId { get; set; }

    // Navigation Properties
    public JobPosting JobPosting { get; set; } = null!;
    public Skill Skill { get; set; } = null!;
}