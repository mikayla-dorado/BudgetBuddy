namespace BudgetBuddy.Models.DTOs;

public class PaycheckDTO
{
    public int Id { get; set; }
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }
    public int? UserProfileId { get; set; }
    public UserProfile UserProfile { get; set; }
}