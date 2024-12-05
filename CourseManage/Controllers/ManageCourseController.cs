
using CourseManage.Data;
using CourseManage.Entities;
using CourseManage.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace CourseManage.Controllers
{
    [Authorize(Roles = RoleName.Instructor)]
    public class ManageCourseController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ICourseService _courseService;
        private readonly IPlatformService _platformService;
        private readonly ITopicService _topicService;
        private readonly IPathService _pathService;
        private readonly IInstructorService _instructorService;

        public ManageCourseController(UserManager<AppUser> userManager
            , ICourseService courseService, IPlatformService platformService
            , ITopicService topicService, IPathService pathService
            , IInstructorService instructorService)
        {
            _userManager = userManager;
            _courseService = courseService;
            _platformService = platformService;
            _topicService = topicService;
            _pathService = pathService;
            _instructorService = instructorService;
        }

        // GET: ManageCourse
        public async Task<IActionResult> Index()
        {
            var userId = _userManager.GetUserId(User);
            Console.WriteLine(userId);

            var courses = await _courseService.GetWithFilterAndIncludesAsync(
                c => c.Instructor.UserId.Equals(userId),
                c => c.Instructor,
                c => c.Platform,
                c => c.Topic,
                c => c.Path
            );

            return View(courses);
        }

        // GET: ManageCourse/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courses = await _courseService.GetWithFilterAndIncludesAsync(
                c => c.CourseId == id,
                c => c.Instructor,
                c => c.Platform,
                c => c.Topic,
                c => c.Path
            );

            var course = courses
                .FirstOrDefault();

            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        // GET: ManageCourse/Create
        public async Task<IActionResult> Create()
        {
            ViewData["PlatformId"] = new SelectList(await _platformService.GetAllPlatformAsync(), "PlatformId", "Name");
            ViewData["TopicId"] = new SelectList(await _topicService.GetAllTopicAsync(), "TopicId", "Name");

            // Lấy tên Path để hiển thị trong danh sách chọn
            ViewData["PathId"] = new SelectList(await _pathService.GetAllPathAsync(), "PathId", "Name");
            ViewData["Difficulty"] = new SelectList(new List<dynamic>
            {
                new { Value = 0, Text = "Beginner" },
                new { Value = 1, Text = "Intermediate" }
            }, "Value", "Text");
            return View();
        }

        // POST: ManageCourse/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("CourseId,Title,Description,TrailerUrl,TopicId,PlatformId,Thumbnail,PathId,DifficultCourse")]
            Entities.Course course)
        {
            var userId = _userManager.GetUserId(User);
            var instructors = await _instructorService.GetAllInstructorAsync();
            var instructor = instructors
                .FirstOrDefault(i => i.UserId.Equals(userId));

            if (instructor == null)
            {
                return BadRequest("Không phải role để tạo");
            }

            course.InstructorId = instructor.InstructorId;
            course.Date = DateTime.Now;

            await _courseService.CreateCourseAsync(course);
            return RedirectToAction(nameof(Index));
        }

        // GET: ManageCourse/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courses = await _courseService.GetWithFilterAndIncludesAsync(
                c => c.CourseId == id,
                c => c.Path
            );

            var course = courses.FirstOrDefault();
            if (course == null)
            {
                return NotFound();
            }

            ViewData["PlatformId"] = new SelectList(await _platformService.GetAllPlatformAsync(), "PlatformId", "Name",
                course.PlatformId);
            ViewData["TopicId"] =
                new SelectList(await _topicService.GetAllTopicAsync(), "TopicId", "Name", course.TopicId);
            ViewData["PathId"] = new SelectList(await _pathService.GetAllPathAsync(), "PathId", "Name", course.PathId);
            ViewData["Difficulty"] = new SelectList(new List<dynamic>
            {
                new { Value = 0, Text = "Beginner" },
                new { Value = 1, Text = "Intermediate" }
            }, "Value", "Text", course.DifficultCourse.HasValue ? (int)course.DifficultCourse : 0);

            return View(course);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,
            [Bind(
                "CourseId,Title,Description,TrailerUrl,InstructorId,TopicId,PlatformId,Thumbnail,Date,PathId,DifficultCourse")]
            Entities.Course course)
        {
            if (id != course.CourseId)
            {
                return NotFound();
            }

            var userId = _userManager.GetUserId(User);
            var instructors = await _instructorService.GetAllInstructorAsync();
            var instructor = instructors
                .FirstOrDefault(i => i.UserId.Equals(userId));
            if (instructor == null)
            {
                return BadRequest("Không phải role để tạo");
            }

            course.InstructorId = instructor.InstructorId;
            try
            {
                await _courseService.UpdateCourseAsync(id, course);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await CourseExists(course.CourseId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: ManageCourse/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courses = await _courseService.GetWithFilterAndIncludesAsync(
                c=>c.CourseId == id,
                c => c.Instructor,
                c => c.Platform,
                c => c.Topic
            );

            var course = courses
                .FirstOrDefault();
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        // POST: ManageCourse/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _courseService.DeleteCourseAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> CourseExists(int id)
        {
            var course = await _courseService.GetCourseByIdAsync(id);
            return course == null;
        }
    }
}