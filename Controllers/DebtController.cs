using System.Text.Json;
using System.Xml.Linq;
using BudgetBuddy.Data;
using BudgetBuddy.Models;
using BudgetBuddy.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


[ApiController]
[Route("/api/[controller]")]
public class DebtController : ControllerBase
{
    private BudgetBuddyDbContext _dbContext;

    public DebtController(BudgetBuddyDbContext context)
    {
        _dbContext = context;
    }

    //get debts
    [HttpGet]
    [Authorize]
    public IActionResult Get()
    {
        return Ok(_dbContext
        .Debts
        .Select (d => new DebtDTO
        {
            Id = d.Id,
            Name = d.Name,
            Amount = d.Amount,
            DueDate = d.DueDate,
            UserProfile = d.UserProfile
        }));
    }

    //add/post debt
    [HttpPost]
    //[Authorize]
    public IActionResult PostDebt(Debt debt)
    {
        _dbContext.Debts.Add(debt);
        _dbContext.SaveChanges();
        return Created($"/debts/{debt.Id}", debt);
    }




}