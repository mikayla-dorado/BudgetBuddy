namespace BudgetBuddy.Models.DTOs;

public class BudgetDTO
{
    public int Id { get; set; }
    public decimal PlannedSpending { get; set; }
    public decimal ActualSpending { get; set; }
    public decimal RemainingBalance { get; set; }
    public int? UserProfileId { get; set; }
    public UserProfile UserProfile { get; set; }
}