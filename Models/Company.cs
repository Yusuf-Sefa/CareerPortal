
namespace CareerPortal.Models;

public class Company
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Location { get; set; }
    public string? Description { get; set; }

    // Navigation Properties
    public ICollection<RecruiterProfile> RecruiterProfiles { get; set; } = [];
    public ICollection<JobPosting> JobPostings { get; set; } = [];
}