using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GradeProject.Data;

namespace GradeProject.Services
{
    public interface IQuizService
    {
        public Task AddQuiz(string QuizName);
    }

    public class QuizService : IQuizService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly AuthenticationStateProvider _authenticationStateProvider;

        public QuizService(UserManager<ApplicationUser> userManager, AuthenticationStateProvider authenticationStateProvider)
        {
            _userManager = userManager;
            _authenticationStateProvider = authenticationStateProvider;
        }

        public async Task AddQuiz(string QuizName)
        {
            var authState = await _authenticationStateProvider.GetAuthenticationStateAsync();
            var user = authState.User;

            if (user?.Identity?.Name != null)
            {
                var applicationUser = await _userManager.FindByNameAsync(user.Identity.Name);

                if (applicationUser != null)
                {
                    // Check if the "intro" lesson has already been completed
                    bool hasCompletedIntro = applicationUser.CompletedQuiz != null && applicationUser.CompletedQuiz.Contains(QuizName);

                    // If "intro" lesson hasn't been completed yet, add it to CompletedQuiz
                    if (!hasCompletedIntro)
                    {
                        var updatedLessons = applicationUser.CompletedQuiz?.ToList() ?? new List<string>();
                        updatedLessons.Add(QuizName);
                        applicationUser.CompletedQuiz = updatedLessons.ToArray();
                        await _userManager.UpdateAsync(applicationUser);
                    }
                }
            }
        }
    }
}
