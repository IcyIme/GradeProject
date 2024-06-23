// Interfaces/IForumService.cs

using GradeProject.Data;
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
}

public class ForumService : IForumService
{
    private readonly ApplicationDbContext _context;

    public ForumService(ApplicationDbContext context)
    {
        _context = context;
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

}