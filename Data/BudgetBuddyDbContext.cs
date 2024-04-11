using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using BudgetBuddy.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Components.Routing;
using Npgsql;

namespace BudgetBuddy.Data;
public class BudgetBuddyDbContext : IdentityDbContext<IdentityUser>
{
    private readonly IConfiguration _configuration;
    public DbSet<UserProfile> UserProfiles { get; set; }
    public DbSet<Saving> Savings { get; set; }
    public DbSet<Debt> Debts { get; set; }
    public DbSet<Paycheck> Paychecks { get; set; }
    public DbSet<Budget> Budgets { get; set; }
    public DbSet<Notification> Notifications { get; set; }
    public DbSet<Bill> Bills { get; set; } 


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
            new Saving {Id = 1, Name = "Christmas", Amount = 100.00M, Date = new DateTime(2024, 4, 15), UserProfileId = 1}
        });
        modelBuilder.Entity<Debt>().HasData(new Debt[]
        {
            new Debt {Id = 1, Name = "School", Amount = 250.00M, DueDate = new DateTime(2024, 4, 24), UserProfileId = 1}
        });
        modelBuilder.Entity<Paycheck>().HasData(new Paycheck[]
        {
            new Paycheck {Id = 1, Amount = 1200.00M, Date = new DateTime(2024, 04, 08), UserProfileId = 1}
        });
          modelBuilder.Entity<Budget>().HasData(new Budget[]
        {
            new Budget {Id = 1, PlannedSpending = 50.00M, ActualSpending = 45.00M, RemainingBalance = 5.00M, UserProfileId = 1}
        });
         modelBuilder.Entity<Notification>().HasData(new Notification[]
        {
            new Notification {Id = 1, BillId = 1, NotificationDate = new DateTime(2024, 5, 23), IsSent = false, UserProfileId = 1}
        });
         modelBuilder.Entity<Bill>().HasData(new Bill[]
        {
            new Bill {Id = 1, Name = "Water", Amount = 50.00M, DueDate = new DateTime(2024, 5, 14), IsPaid = false, UserProfileId = 1}
        });
    }
}