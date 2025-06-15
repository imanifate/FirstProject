namespace AppStor.Web.Middleware
{

    public class CheckAdmin(RequestDelegate  next)
    {
        public async Task InvokeAsync(HttpContext httpContext)
        {
            string path = httpContext.Request.Path.ToString().ToLower().Trim();
            if (path.StartsWith("/admin"))
            {
                string result = httpContext.User.FindFirst("IsAdmin")?.Value ?? "";
                if (string.IsNullOrEmpty(result) || bool.Parse(result) == false)
                    httpContext.Response.Redirect("/Home/AccessDenied");
            }
            await next(httpContext);
        }
    }
}
