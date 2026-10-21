
namespace CareerPortal.Models;

public class RecruiterProfile
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int CompanyId { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    // Navigation Properties
    public User User { get; set; } = null!;
    public Company Company { get; set; } = null!;
    public ICollection<JobPosting> JobPostings { get; set; } = [];
}