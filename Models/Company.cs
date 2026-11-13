
namespace CareerPortal.Models;

public class Company
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Location { get; set; }
    public string? Description { get; set; }

    // Navigation Properties
    public ICollection<RecruiterProfile> RecruiterProfiles { get; set; } = [];
    public ICollection<JobPosting> JobPostings { get; set; } = [];

    public void UpdateDetails(string name, string? location, string? description)
    {
        Name = name.Trim();
        Location = string.IsNullOrWhiteSpace(location) ? null : location.Trim();
        Description = string.IsNullOrWhiteSpace(description) ? null : description.Trim();
    }

}