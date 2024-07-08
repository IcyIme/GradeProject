using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using GradeProject.Data;

public class UserProfileService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IDbContextFactory<ApplicationDbContext> _contextFactory;

    public UserProfileService(UserManager<ApplicationUser> userManager, IDbContextFactory<ApplicationDbContext> contextFactory)
    {
        _userManager = userManager;
        _contextFactory = contextFactory;
    }

    public async Task<ApplicationUser> GetUserProfileAsync(string userId, ClaimsPrincipal user)
    {
        ApplicationUser applicationUser = null;

        if (!string.IsNullOrEmpty(userId))
        {
            applicationUser = await _userManager.FindByIdAsync(userId);
        }
        else if (user?.Identity?.Name != null)
        {
            applicationUser = await _userManager.FindByNameAsync(user.Identity.Name);
        }

        return applicationUser;
    }

    public async Task<int> GetLeaderboardPositionAsync(int score)
    {
        using var context = _contextFactory.CreateDbContext();
        var allUsers = await context.Users.OrderByDescending(u => u.Score).ToListAsync();
        var position = allUsers.FindIndex(u => u.Score == score) + 1;
        return position;
    }

    public async Task UpdateStatusAsync(ApplicationUser user, string status)
    {
        using var context = _contextFactory.CreateDbContext();
        var userToUpdate = await context.Users.FirstOrDefaultAsync(u => u.Id == user.Id);

        if (userToUpdate != null)
        {
            userToUpdate.Status = status;
            await context.SaveChangesAsync();
        }
        else
        {
            throw new InvalidOperationException($"User with ID '{user.Id}' not found.");
        }
    }

    public string GetPronouns(string gender)
    {
        return gender switch
        {
            "Male" => "On/Jeho",
            "Female" => "Ona/Jej",
            "PreferNotToSay" => "Oni/Ich",
            _ => "none"
        };
    }
}
