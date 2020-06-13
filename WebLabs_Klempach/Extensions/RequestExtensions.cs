using Microsoft.AspNetCore.Http;

namespace WebLabs_Klempach.Extensions
{
    public static class RequestExtensions
    {
        public static bool IsAjaxRequest(this HttpRequest request)
        {
            return request
                .Headers["x-requested-with"]
                .Equals("XMLHttpRequest");
        }
    }
}
