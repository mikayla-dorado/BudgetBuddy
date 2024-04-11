using BudgetBuddy.Models.DTOs;

namespace BudgetBuddy.Models;

public class Saving
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }
    public int? UserProfileId { get; set; }
    public UserProfile UserProfile { get; set; }
}