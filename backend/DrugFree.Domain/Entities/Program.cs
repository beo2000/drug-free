using System.ComponentModel.DataAnnotations;

namespace DrugFree.Domain.Entities;

public class Program : BaseEntity
{
    [Required]
    public string Title { get; set; } = null!;
    
    public string? Description { get; set; }
    
    [Required]
    public DateTime StartDate { get; set; }
    
    [Required]
    public DateTime EndDate { get; set; }
    
    public string? Location { get; set; }
    
    public string? ThumbnailUrl { get; set; }
    
    public Guid ManagerId { get; set; }
    public User Manager { get; set; } = null!;
    
    // Navigation properties
    public ICollection<ProgramParticipation> Participations { get; set; } = new List<ProgramParticipation>();
}

public class ProgramParticipation : BaseEntity
{
    public Guid UserId { get; set; }
    public User User { get; set; } = null!;
    
    public Guid ProgramId { get; set; }
    public Program Program { get; set; } = null!;
    
    public bool HasCheckedIn { get; set; }
    
    public DateTime? CheckInTime { get; set; }
    
    public Guid? PreSurveyResultId { get; set; }
    public SurveyResult? PreSurveyResult { get; set; }
    
    public Guid? PostSurveyResultId { get; set; }
    public SurveyResult? PostSurveyResult { get; set; }
} 