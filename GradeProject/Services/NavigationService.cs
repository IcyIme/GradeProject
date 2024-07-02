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
                case "loopandif":
                    _navigationManager.NavigateTo(UrlData.lectionUrlLoop);
                    break;
                case "methods":
                    _navigationManager.NavigateTo(UrlData.lectionUrlMethods);
                    break;
                case "parameters":
                    _navigationManager.NavigateTo(UrlData.lectionUrlParameters);
                    break;
                case "recursion":
                    _navigationManager.NavigateTo(UrlData.lectionUrlRecursion);
                    break;
                case "array":
                    _navigationManager.NavigateTo(UrlData.lectionUrlArray);
                    break;
                case "datatypes":
                    _navigationManager.NavigateTo(UrlData.lectionUrlDataTypes);
                    break;
                default:
                    _navigationManager.NavigateTo(""); // Navigate to home or another page
                    break;
            }
        }
    }
}
