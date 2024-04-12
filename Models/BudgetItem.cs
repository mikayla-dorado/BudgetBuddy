using BudgetBuddy.Models.DTOs;

namespace BudgetBuddy.Models;

public class BudgetItem
{
    public int Id { get; set;}
    public string Name { get; set;}
    public DateTime DueDate { get; set; }
    public decimal PlannedSpending { get; set;}
    public decimal ActualSpending { get; set;}
    public decimal RemainingBalance { get; set;}
    public int? UserProfileId { get; set; }
    public UserProfile UserProfile { get; set; }
}