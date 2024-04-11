using BudgetBuddy.Models.DTOs;

namespace BudgetBuddy.Models;

public class Paycheck
{
    public int Id { get; set; }
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }
    public int? UserProfileId { get; set; }
    public UserProfile UserProfile { get; set; }
}