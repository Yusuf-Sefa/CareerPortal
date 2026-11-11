
namespace CareerPortal.Models;

public class RecruiterProfile
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid CompanyId { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    // Navigation Properties
    public User User { get; set; } = null!;
    public Company Company { get; set; } = null!;
    public ICollection<JobPosting> JobPostings { get; set; } = [];
}