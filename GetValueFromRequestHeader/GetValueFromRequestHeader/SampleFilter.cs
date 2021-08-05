using Microsoft.AspNetCore.Mvc.Filters;

namespace GetValueFromRequestHeader
{
    public class SampleFilter : IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var headers = context.HttpContext.Request.Headers;
            headers.TryGetValue("one", out var one);
            headers.TryGetValue("two,", out var two);
            headers.TryGetValue("three,", out var three);

            System.Diagnostics.Debug.WriteLine($"header one :{one}");
            System.Diagnostics.Debug.WriteLine($"header two :{two}");
            System.Diagnostics.Debug.WriteLine($"header three :{three}");
            System.Diagnostics.Debug.WriteLine($"header one :{headers["one"]}");
            System.Diagnostics.Debug.WriteLine($"header two :{headers["two"]}");
            System.Diagnostics.Debug.WriteLine($"header three :{headers["three"]}");
        }
    }
}
