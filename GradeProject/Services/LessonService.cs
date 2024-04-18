using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GradeProject.Data;

namespace GradeProject.Services
{
    public interface ILessonService
    {
        Task AddLesson(string lesson);
    }

    public class LessonService : ILessonService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly AuthenticationStateProvider _authenticationStateProvider;

        public LessonService(UserManager<ApplicationUser> userManager, AuthenticationStateProvider authenticationStateProvider)
        {
            _userManager = userManager;
            _authenticationStateProvider = authenticationStateProvider;
        }

        public async Task AddLesson(string lesson)
        {
            var authState = await _authenticationStateProvider.GetAuthenticationStateAsync();
            var user = authState.User;

            if (user?.Identity?.Name != null)
            {
                var applicationUser = await _userManager.FindByNameAsync(user.Identity.Name);

                if (applicationUser != null)
                {
                    // Check if the "intro" lesson has already been completed
                    bool hasCompletedIntro = applicationUser.CompletedLesson != null && applicationUser.CompletedLesson.Contains(lesson);

                    // If "intro" lesson hasn't been completed yet, add it to CompletedLesson
                    if (!hasCompletedIntro)
                    {
                        var updatedLessons = applicationUser.CompletedLesson?.ToList() ?? new List<string>();
                        updatedLessons.Add(lesson);
                        applicationUser.CompletedLesson = updatedLessons.ToArray();
                        await _userManager.UpdateAsync(applicationUser);
                    }
                }
            }
        }
    }
}