using GradeProject.Data;
using Microsoft.AspNetCore.Components;

namespace GradeProject.Services
{
    public interface INavigationService
    {
        public void Navigator(string id);
    }
    public class NavigationService : INavigationService
    {
        private readonly NavigationManager _navigationManager;

        public NavigationService(NavigationManager navigationManager)
        {
            this._navigationManager = navigationManager;
        }

        public void Navigator(string id)
        {
            switch (id)
            {
                case "intro":
                    _navigationManager.NavigateTo(UrlData.lectionUrlIntro);
                    break;
                case "instalation":
                    _navigationManager.NavigateTo(UrlData.lectionUrlInstalation);
                    break;
                case "firstprogram":
                    _navigationManager.NavigateTo(UrlData.lectionUrlFirstProgram);
                    break;
                case "variables":
                    _navigationManager.NavigateTo(UrlData.lectionUrlVariables);
                    break;
                case"operators":
                    _navigationManager.NavigateTo(UrlData.lectionUrlOperations);
                    break;
                default:
                    _navigationManager.NavigateTo(""); // Navigate to home or another page
                    break;
            }
        }
    }
}
