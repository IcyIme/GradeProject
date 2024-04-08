namespace GradeProject.Data.Models
{
    public class DailyScorePoint
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int Score { get; set; }

        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}
