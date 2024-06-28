// Interfaces/IForumService.cs

using GradeProject.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

public interface IForumService
{
    Task<List<ForumRoom>> GetRoomsAsync();
    Task<ForumRoom> GetRoomAsync(int roomId);
    Task<int> CreateRoomAsync(ForumRoom room);
    Task<int> AddCommentAsync(ForumComment comment);
    Task<bool> CanManageRoomAsync(int roomId, string userId);
    Task<int> CreateRoomAsync(ForumRoom room, string ownerId);
    Task<bool> DeleteRoomAsync(int roomId);
    Task<List<ForumRoom>> GetRoomsCreatedByUserAsync(string userId);
    Task DeleteCommentAsync(int commentId);
    Task<string> GetUserNameAsync(string userId);
    Task<bool> IsUserAdmin(string userId);
}

public class ForumService : IForumService
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public ForumService(ApplicationDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        _context = context;
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public async Task<List<ForumRoom>> GetRoomsAsync()
    {
        return await _context.ForumRooms.Include(r => r.Comments).ToListAsync();
    }

    public async Task<ForumRoom> GetRoomAsync(int roomId)
    {
        return await _context.ForumRooms.Include(r => r.Comments).FirstOrDefaultAsync(r => r.Id == roomId);
    }

    public async Task<int> CreateRoomAsync(ForumRoom room)
    {
        _context.ForumRooms.Add(room);
        await _context.SaveChangesAsync();
        return room.Id;
    }

    public async Task<int> AddCommentAsync(ForumComment comment)
    {
        _context.ForumComments.Add(comment);
        await _context.SaveChangesAsync();
        return comment.Id;
    }

    public async Task<bool> CanManageRoomAsync(int roomId, string userId)
    {
        var room = await _context.ForumRooms.FindAsync(roomId);
        return room.OwnerId == userId;
    }
    // Services/ForumService.cs
    public async Task<int> CreateRoomAsync(ForumRoom room, string ownerId)
    {
        room.OwnerId = ownerId;
        _context.ForumRooms.Add(room);
        await _context.SaveChangesAsync();
        return room.Id;
    }
    public async Task<bool> DeleteRoomAsync(int roomId)
    {
        var room = await _context.ForumRooms.FindAsync(roomId);

        if (room != null)
        {
            _context.ForumRooms.Remove(room);
            await _context.SaveChangesAsync();
            return true;
        }

        return false;
    }

    public async Task<List<ForumRoom>> GetRoomsCreatedByUserAsync(string userId)
    {
        return await _context.ForumRooms
            .Where(room => room.OwnerId == userId)
            .ToListAsync();
    }

    public async Task DeleteCommentAsync(int commentId)
    {
        var comment = await _context.ForumComments.FindAsync(commentId);
        if (comment != null)
        {
            _context.ForumComments.Remove(comment);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<string> GetUserNameAsync(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);
        return user?.UserName;
    }

    public async Task<bool> IsUserAdmin(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);
        if (user == null)
        {
            return false;
        }
        return await _userManager.IsInRoleAsync(user, "Admin");
    }

}