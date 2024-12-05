using CourseManage.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CourseManage.Controllers
{
    public class PathController : Controller
    {
        private readonly IPathService _pathService;

        public PathController(IPathService pathService)
        {
            _pathService = pathService;
        }

        public async Task<IActionResult> Index()
        {
            var paths = await _pathService.GetAllWithIncludesAsync(
                p=>p.TypePath,
                p=>p.Courses,
                p=>p.Courses.Select(ch=>ch.Chapters),
                path => path.Courses.Select(c => c.Chapters.Select(ch => ch.Lessons))
            );
            
            return View(paths);
        }
        

        public async  Task<IActionResult> Detail(int? id)
        {
            if (id == null)
            {
                return BadRequest("Can't resolve id");
            }
            
            var paths = await _pathService.GetAllWithIncludesAsync(
                p=>p.TypePath,
                p=>p.Courses,
                p=>p.Courses.Select(ch=>ch.Chapters),
                p => p.Courses.Select(c => c.Chapters.Select(ch => ch.Lessons)),
                p=>p.Courses.Select(c=>c.Instructor)
            );
            
            var path = paths
                .FirstOrDefault(p => p.PathId == id);

            return View(path);
        }
    }
}
