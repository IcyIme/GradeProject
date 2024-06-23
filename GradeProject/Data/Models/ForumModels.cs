// ForumRoom.cs

using System.ComponentModel.DataAnnotations;

public class ForumRoom
{
    [Key]
    public int Id { get; set; }
    public string Title { get; set; }
    public string OwnerId { get; set; } // Vlastník miestnosti (UserId)
    public string Detail { get; set; }
    public List<ForumComment> Comments { get; set; }
}

// ForumComment.cs
public class ForumComment
{
    [Key]
    public int Id { get; set; }
    public string Content { get; set; }
    public int RoomId { get; set; } // Referencia na miestnosť
    public string UserId { get; set; } // Autor komentára
    public bool IsOwner { get; set; } // Ak je užívateľ vlastníkom miestnosti
}