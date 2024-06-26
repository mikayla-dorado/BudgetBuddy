using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using BudgetBuddy.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Components.Routing;
using Npgsql;
using Microsoft.AspNetCore.Authorization.Infrastructure;

namespace BudgetBuddy.Data;
public class BudgetBuddyDbContext : IdentityDbContext<IdentityUser>
{
    private readonly IConfiguration _configuration;
    public DbSet<UserProfile> UserProfiles { get; set; }
    public DbSet<Saving> Savings { get; set; }
    public DbSet<Debt> Debts { get; set; }
    public DbSet<Paycheck> Paychecks { get; set; }
    public DbSet<Notification> Notifications { get; set; }
    public DbSet<BudgetItem> BudgetItems { get; set; } 


    public BudgetBuddyDbContext(DbContextOptions<BudgetBuddyDbContext> context, IConfiguration config) : base(context)
    {
        _configuration = config;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
        {
            Id = "c3aaeb97-d2ba-4a53-a521-4eea61e59b35",
            Name = "Admin",
            NormalizedName = "admin"
        });

        modelBuilder.Entity<IdentityUser>().HasData(new IdentityUser
        {
            Id = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
            UserName = "Administrator",
            Email = "admina@strator.comx",
            PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, _configuration["AdminPassword"])
        });

        modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
        {
            RoleId = "c3aaeb97-d2ba-4a53-a521-4eea61e59b35",
            UserId = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f"
        });
        modelBuilder.Entity<UserProfile>().HasData(new UserProfile
        {
            Id = 1,
            IdentityUserId = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
            FirstName = "Mikayla",
            LastName = "Dorado",
            Email = "admina@strator.comx",
            Address = "444 Main Street",
        });
        modelBuilder.Entity<Saving>().HasData(new Saving[]
        {
            new Saving {Id = 1, Name = "Christmas", Amount = 100.00M, Date = new DateTime(2024, 4, 15), UserProfileId = 1},
            new Saving {Id = 2, Name = "Vacation", Amount = 100.00M, Date = new DateTime(2024, 4, 15), UserProfileId = 1},
            new Saving {Id = 3, Name = "Emergency", Amount = 100.00M, Date = new DateTime(2024, 4, 15), UserProfileId = 1},
            new Saving {Id = 4, Name = "Wedding", Amount = 100.00M, Date = new DateTime(2024, 4, 15), UserProfileId = 1}
        });
        modelBuilder.Entity<Debt>().HasData(new Debt[]
        {
            new Debt {Id = 1, Name = "School", Amount = 250.00M, DueDate = new DateTime(2024, 4, 24), UserProfileId = 1},
            new Debt {Id = 2, Name = "Car", Amount = 150.00M, DueDate = new DateTime(2024, 4, 24), UserProfileId = 1},
            new Debt {Id = 3, Name = "Mortgage", Amount = 1500.00M, DueDate = new DateTime(2024, 4, 20), UserProfileId = 1},
        });
        modelBuilder.Entity<Paycheck>().HasData(new Paycheck[]
        {
            new Paycheck {Id = 1, Amount = 1200.00M, Date = new DateTime(2024, 04, 07), UserProfileId = 1},
            new Paycheck {Id = 2, Amount = 1200.00M, Date = new DateTime(2024, 04, 14), UserProfileId = 1},
            new Paycheck {Id = 3, Amount = 1200.00M, Date = new DateTime(2024, 04, 21), UserProfileId = 1},
            new Paycheck {Id = 4, Amount = 1200.00M, Date = new DateTime(2024, 04, 28), UserProfileId = 1}
        });
         modelBuilder.Entity<Notification>().HasData(new Notification[]
        {
            new Notification {Id = 1, BudgetItemId = 1, NotificationDate = new DateTime(2024, 5, 23), IsSent = false, UserProfileId = 1}
        });
         modelBuilder.Entity<BudgetItem>().HasData(new BudgetItem[]
        {
            new BudgetItem {Id = 1, Name = "Groceries", PlannedSpending = 50.00M, ActualSpending = 45.00M, RemainingBalance = 5.00M, DueDate = new DateTime(2024, 05, 06), UserProfileId = 1}
        });
    }
}