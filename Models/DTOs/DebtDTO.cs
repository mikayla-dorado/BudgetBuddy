namespace BudgetBuddy.Models.DTOs;

public class DebtDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Amount { get; set; }
    public DateTime DueDate { get; set;}
    public int UserProfileId { get; set; }
    public UserProfile UserProfile{ get; set; }
}