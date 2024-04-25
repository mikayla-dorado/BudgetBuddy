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
public class SavingController : ControllerBase
{
    private BudgetBuddyDbContext _dbContext;

    public SavingController(BudgetBuddyDbContext context)
    {
        _dbContext = context;
    }

    //get savings
    [HttpGet]
    [Authorize]
    public IActionResult Get()
    {
        return Ok(_dbContext
        .Savings
        .Select (s => new SavingDTO
        {
            Id = s.Id,
            Name = s.Name,
            Amount = s.Amount,
            Date = s.Date,
            UserProfile = s.UserProfile
        }));
    }
}