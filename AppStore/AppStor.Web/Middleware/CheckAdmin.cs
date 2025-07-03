namespace AppStor.Web.Middleware
{

    public class CheckAdmin(RequestDelegate next)
    {
        public async Task InvokeAsync(HttpContext httpContext)
        {
           
            //string path = httpContext.Request.Path.ToString().ToLower().Trim();
            string path = (httpContext.Request.PathBase + httpContext.Request.Path).ToString().ToLower().Trim();
            
            if (path.Contains("/admin"))
            {
                string result = httpContext.User.FindFirst("IsAdmin")?.Value ?? "";
                if (!bool.TryParse(result, out bool isAdmin) || !isAdmin)
                   // httpContext.Response.Redirect("/Home/AccessDenied");
                httpContext.Response.Redirect(location: "/home/AccessDenied");
                else
                {
                    await next(httpContext);
                }

            }
            else
            {
                await next(httpContext);
            }

        }
            




        
    }
}
