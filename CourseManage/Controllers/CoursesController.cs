
using CourseManage.Interfaces;
using CourseManage.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CourseManage.Controllers
{
    public class CoursesController : Controller
    {
        private readonly ICourseService _courseService;
        private readonly IFeedBackService _feedBackService;
        private readonly IChapterService _chapterService;

        public CoursesController(ICourseService iCourseService, IFeedBackService iFeedBackService,IChapterService iChapterService)
        {
            _courseService = iCourseService;
            _feedBackService = iFeedBackService;
            _chapterService = iChapterService;
        }

        public async Task<ActionResult> Index()
        {
            // Eager loading Instructor (AppUser) with the Courses
            var courses = await _courseService.GetAllWithIncludesAsync(
                c => c.Instructor,
                c => c.Topic,
                c => c.UserCourses
            );
            var feedbacks = await _feedBackService.GetAllFeedBackAsync();

            foreach (var course in courses)
            {
                // Calculate the average rating, handling null values correctly
                course.AverageRating = feedbacks
                    .Where(f => f.CourseId == course.CourseId)
                    .Where(f => f.Rating.HasValue)
                    .Average(f => (double?)f.Rating) ?? 0; // Defaults to 0 if no ratings exist
            }

            var viewModel = courses.Select(c => new CourseViewModel
            {
                Topic = c.Topic,
                CourseId = c.CourseId,
                Title = c.Title,
                // Add other properties as needed
                Description = c.Description,
                Thumbnail = c.Thumbnail,
                InstructorName = c.Instructor.Name,
                AverageRating = c.AverageRating
                // ... other properties
            });

            return View(viewModel);
        }

        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null)
            {
                return BadRequest("Can not solve id");
            }

            var courses = await _courseService.GetAllWithIncludesAsync(
                c=>c.Instructor
                );
            var course = courses
                .FirstOrDefault(c => c.CourseId == id);
            if (course == null)
            {
                return BadRequest("Can't see course");
            }

            var chapters = await _chapterService.GetWithFilterAndIncludesAsync(
                ch=>ch.CourseId==course.CourseId,
                ch=>ch.Lessons
            );
            course.Chapters = chapters.ToList();
            var feedbacks = await _feedBackService.GetAllWithIncludesAsync(
                f => f.Student);
            var feedback = feedbacks
                .Where(f => f.CourseId == course.CourseId)
                .Where(f => f.Rating.HasValue)
                .OrderByDescending(f => f.Created);

            return View(Tuple.Create(course, feedback.AsEnumerable()));
        }

        public async Task<IActionResult> Student(int? id)
        {
            if (id == null)
            {
                return BadRequest("Can not solve id");
            }

            var courses = await _courseService.GetAllWithIncludesAsync(
                c=>c.Topic,
                c=>c.Instructor
            );
            
            var course = courses
                .FirstOrDefault(c => c.CourseId == id);
            if (course == null)
            {
                return NotFound();
            }

            var chapters = await _chapterService.GetWithFilterAndIncludesAsync(
                ch=>ch.CourseId == course.CourseId,
                ch=>ch.Lessons
                );

            course.Chapters = chapters.ToList();

            var feedbacks = await _feedBackService.GetAllWithIncludesAsync();
            
            var feedback = feedbacks
                .Where(f => f.CourseId == course.CourseId);

            return View(Tuple.Create(course, feedback.AsEnumerable()));
        }

        public async Task<IActionResult> Trailer(int? id)
        {
            if (id == null)
            {
                return BadRequest("Can not solve id");
            }

            var courses = await _courseService.GetAllWithIncludesAsync(
                c=>c.Topic,
                c=>c.Instructor
                );

            var course = courses
                .FirstOrDefault(c => c.CourseId == id);
            if (course == null)
            {
                return NotFound();
            }
            var chapters = await _chapterService.GetWithFilterAndIncludesAsync(
                ch=>ch.CourseId == course.CourseId,
                ch=>ch.Lessons
            );

            course.Chapters = chapters.ToList();

            var feedbacks = await _feedBackService.GetAllFeedBackAsync();
            
            var feedback = feedbacks
                .Where(f => f.CourseId == course.CourseId).ToList();

            return View(Tuple.Create(course, feedback.AsEnumerable()));
        }
    }
}