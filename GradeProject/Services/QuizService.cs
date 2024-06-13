using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using GradeProject.Data;

namespace GradeProject.Services
{
    public interface IQuizService
    {
        Task AddQuiz(string quizName);
        Task<bool> IsQuizAvailable(string quizId);
    }

    public class QuizService : IQuizService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly AuthenticationStateProvider _authenticationStateProvider;

        public QuizService(
            UserManager<ApplicationUser> userManager,
            AuthenticationStateProvider authenticationStateProvider)
        {
            _userManager = userManager;
            _authenticationStateProvider = authenticationStateProvider;
        }

        public async Task AddQuiz(string quizName)
        {
            var authState = await _authenticationStateProvider.GetAuthenticationStateAsync();
            var user = authState.User;

            if (user?.Identity?.Name != null)
            {
                var applicationUser = await _userManager.FindByNameAsync(user.Identity.Name);

                if (applicationUser != null)
                {
                    // Check if the quiz has already been completed
                    bool hasCompletedQuiz = applicationUser.CompletedQuiz != null && applicationUser.CompletedQuiz.Contains(quizName);

                    // If quiz hasn't been completed yet, add it to CompletedQuiz
                    if (!hasCompletedQuiz)
                    {
                        var updatedQuizzes = applicationUser.CompletedQuiz?.ToList() ?? new List<string>();
                        updatedQuizzes.Add(quizName);
                        applicationUser.CompletedQuiz = updatedQuizzes.ToArray();
                        await _userManager.UpdateAsync(applicationUser);
                    }
                }
            }
        }

        public async Task<bool> IsQuizAvailable(string quizId)
        {
            var authState = await _authenticationStateProvider.GetAuthenticationStateAsync();
            var user = authState.User;

            if (user.Identity.IsAuthenticated)
            {
                var currentUser = await _userManager.GetUserAsync(user);
                if (currentUser != null && currentUser.CompletedQuiz != null)
                {
                    // Check if the current quiz is in the completed quiz list
                    if (currentUser.CompletedQuiz.Contains(quizId))
                    {
                        return false; // Quiz is completed, hence unavailable
                    }
                }
            }

            return true; // Quiz is available
        }
    }
}
