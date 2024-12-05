using Microsoft.AspNetCore.Mvc;

namespace CourseManage.Controllers;

public class MessageController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}