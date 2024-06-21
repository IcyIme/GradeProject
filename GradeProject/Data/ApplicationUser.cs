using GradeProject.Data.Models;
using Microsoft.AspNetCore.Identity;

namespace GradeProject.Data
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        //Profile data
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public int Score { get; set; }
        public string[]? CompletedLesson { get; set; }
        public string[]? CompletedQuiz { get; set; }
    }

}
