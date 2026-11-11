
using Pgvector;

namespace CareerPortal.Models;

public class JobPosting
{
    public Guid Id { get; set; }
    public Guid RecruiterProfileId { get; set; }
    public Guid CompanyId { get; set; }
    public string? ExternalId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public Vector? JobEmbedding { get; set; }
    public bool IsActive { get; set; } = true;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    // Navigation Properties
    public RecruiterProfile RecruiterProfile { get; set; } = null!;
    public Company Company { get; set; } = null!;
    public ICollection<JobSkill> JobSkills { get; set; } = [];
}