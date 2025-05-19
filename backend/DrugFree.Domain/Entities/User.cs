using System.ComponentModel.DataAnnotations;

namespace DrugFree.Domain.Entities;

public class User : BaseEntity
{
    [Required]
    public string Email { get; set; } = null!;
    
    [Required]
    public string FullName { get; set; } = null!;
    
    public string? PhoneNumber { get; set; }
    
    [Required]
    public UserRole Role { get; set; }
    
    public bool IsApproved { get; set; }
    
    public string? FirebaseUid { get; set; }
    
    public string? ProfilePictureUrl { get; set; }
    
    // Navigation properties
    public ICollection<CourseEnrollment> CourseEnrollments { get; set; } = new List<CourseEnrollment>();
    public ICollection<SurveyResult> SurveyResults { get; set; } = new List<SurveyResult>();
    public ICollection<Consultation> Consultations { get; set; } = new List<Consultation>();
    public ICollection<ProgramParticipation> ProgramParticipations { get; set; } = new List<ProgramParticipation>();
}

public enum UserRole
{
    Guest,
    Member,
    Consultant,
    Staff,
    Manager,
    Admin
} 