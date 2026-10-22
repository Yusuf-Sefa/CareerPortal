
namespace CareerPortal.Models;

public class UserExperience
{
    public int Id { get; set; }
    public int UserProfileId { get; set; }
    public string CompanyName { get; set; } = string.Empty;
    public string Position { get; set; } = string.Empty;
    public string? Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }

    // Navigation Property
    public UserProfile UserProfile { get; set; } = null!;
}