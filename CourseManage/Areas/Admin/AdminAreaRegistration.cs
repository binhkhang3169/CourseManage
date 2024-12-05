

namespace Course.Web.Areas.Admin
{
    public class AdminAreaRegistration
    {
        public static void RegisterArea(IEndpointRouteBuilder endpoints)
        {
            endpoints.MapAreaControllerRoute(
                name: "Admin_default",
                areaName: "Admin",
                pattern: "Admin/{controller=Home}/{action=Index}/{id?}");
        }
    }

}
