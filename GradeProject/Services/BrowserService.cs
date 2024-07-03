using Microsoft.JSInterop;

namespace GradeProject.Services
{
    public class BrowserService
    {
        public static async Task<int> GetInnerWidth(IJSRuntime _JS)
        {
            return await _JS.InvokeAsync<int>("getInnerWidth");
        }
    }
}
