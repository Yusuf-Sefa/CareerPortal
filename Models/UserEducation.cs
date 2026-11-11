
namespace CareerPortal.Models;

public class UserEducation
{
    public Guid Id { get; set; }
    public Guid UserProfileId { get; set; }
    public string Institution { get; set; } = string.Empty;
    public string Degree { get; set; } = string.Empty;
    public string FieldOfStudy { get; set; } = string.Empty;
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }

    // Navigation Property
    public UserProfile UserProfile { get; set; } = null!;
}