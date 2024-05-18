using Microsoft.AspNetCore.Components;
using GradeProject.Services;
using System.Threading.Tasks;

namespace GradeProject.Pages
{
    public class LearnPageBase : ComponentBase
    {
        [Inject]
        protected NavigationManager NavigationManager { get; set; }

        [Inject]
        protected ILessonService LessonService { get; set; }

        [Inject]
        protected IQuizService QuizService { get; set; }

        protected bool IsQuizAvailable { get; private set; }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            await LoadQuizAvailability(GetLessonName());
        }

        protected virtual string GetLessonName()
        {
            return "default";
        }

        private async Task LoadQuizAvailability(string lessonName)
        {
            await LessonService.AddLesson(lessonName);
            IsQuizAvailable = await QuizService.IsQuizAvailable(lessonName);
        }

        protected void NavigateToQuiz(string quizUrl)
        {
            NavigationManager.NavigateTo(quizUrl);
        }

        protected void NavigateToNextLesson(string nextLessonUrl)
        {
            NavigationManager.NavigateTo(nextLessonUrl);
        }
    }
}