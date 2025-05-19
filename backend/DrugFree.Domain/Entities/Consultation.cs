using System.ComponentModel.DataAnnotations;

namespace DrugFree.Domain.Entities;

public class Consultation : BaseEntity
{
    public Guid MemberId { get; set; }
    public User Member { get; set; } = null!;
    
    public Guid ConsultantId { get; set; }
    public User Consultant { get; set; } = null!;
    
    [Required]
    public DateTime ScheduledAt { get; set; }
    
    public string? GoogleMeetLink { get; set; }
    
    public ConsultationStatus Status { get; set; }
    
    public string? ConsultantNotes { get; set; }
    
    public DateTime? ConfirmedAt { get; set; }
    
    public DateTime? CompletedAt { get; set; }
}

public enum ConsultationStatus
{
    Pending,
    Confirmed,
    Completed,
    Cancelled
} 