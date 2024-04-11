namespace BudgetBuddy.Models.DTOs;

public class NotificationDTO
{
    public int Id { get; set; }
    public int BillId { get; set; }
    public Bill Bill { get; set; }
    public DateTime NotificationDate { get; set; }
    public bool IsSent { get; set; }
    public int? UserProfileId { get; set; }
    public UserProfile UserProfile { get; set; }
}