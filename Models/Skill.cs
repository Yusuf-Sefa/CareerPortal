
namespace CareerPortal.Models;

public class Skill
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;

    // Navigation Properties
    public ICollection<UserSkill> UserSkills { get; set; } = [];
    public ICollection<JobSkill> JobSkills { get; set; } = [];
}