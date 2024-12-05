
using CourseManage.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CourseManage.Controllers
{
    public class InstructorController : Controller
    {
        private readonly IInstructorService _instructorService;
        
        public InstructorController(IInstructorService instructorService)
        {
            _instructorService = instructorService;
        }

        public async Task<IActionResult> Index()
        {
            var instructors = await _instructorService.GetAllWithIncludesAsync(
                i=>i.CoursesInstructed,
                i=>i.AppUser,
                i=>i.PrimaryTopic
                );
            
            return View(instructors);
        }

        public async Task<IActionResult> Profile(int? id)
        {
            if (id == null)
            {
                return BadRequest("Can not solve id");
            }
            var instructors = await _instructorService.GetAllWithIncludesAsync(
                i=>i.CoursesInstructed,
                i=>i.AppUser,
                i=>i.PrimaryTopic
            );

            var instructor = instructors.Where(i=>i.InstructorId == id).FirstOrDefault();
            
            if (instructor == null)
            {
                return NotFound();
            }
            return View(instructor);

        }

        public IActionResult Earning()
        {
            return View();
        }

        public IActionResult Statement()
        {
            return View();
        }
    }
}
