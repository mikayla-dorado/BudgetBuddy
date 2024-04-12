namespace BudgetBuddy.Models.DTOs;

public class NotificationDTO
{
    public int Id { get; set; }
    public int BudgetItemId { get; set; }
    public BudgetItem BudgetItem { get; set; }
    public DateTime NotificationDate { get; set; }
    public bool IsSent { get; set; }
    public int? UserProfileId { get; set; }
    public UserProfile UserProfile { get; set; }
}