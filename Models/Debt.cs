using BudgetBuddy.Models.DTOs;

namespace BudgetBuddy.Models;

public class Debt
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Amount { get; set; }
    public DateTime DueDate { get; set;}
    public int UserProfileId { get; set; }
    public UserProfile UserProfile{ get; set; }
}