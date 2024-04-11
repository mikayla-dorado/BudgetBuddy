using BudgetBuddy.Models.DTOs;

namespace BudgetBuddy.Models;

public class Notification
{
    public int Id { get; set; }
    public int BillId { get; set; }
    public Bill Bill { get; set; }
    public DateTime NotificationDate { get; set; }
    public bool IsSent { get; set; }
    public int? UserProfileId { get; set; }
    public UserProfile UserProfile { get; set; }
}