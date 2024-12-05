using System.Collections.Specialized;
using CourseManage.Interfaces;
using CourseManage.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Elfie.Serialization;
using Microsoft.EntityFrameworkCore;

namespace CourseManage.Controllers
{
    public class LessonsController : Controller
    {
        private readonly ILessonService _iLessonService;
        private readonly ICourseService _courseService;
        private readonly IChapterService _chapterService;
        
        public LessonsController(ILessonService iLessonService, ICourseService courseService,IChapterService chapterService)
        {
            _iLessonService = iLessonService;
            _courseService = courseService;
            _chapterService = chapterService;
        }
        [HttpGet("/Lessons/{id?}")]
        public async Task<IActionResult> Index(int? id)
        {
            if (id == null) 
                return NotFound();

            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Review", "Lessons", new { id });
            }

             
            var lesson = await _iLessonService.GetLessonByIdAsync(id.Value);
            if (lesson == null) 
                return NotFound();

            var courses = await _courseService.GetAllWithIncludesAsync(
                c=>c.Instructor
                );


            var course = courses.SingleOrDefault();
            if (course == null) 
                return NotFound();

            var chapters = await _chapterService.GetWithFilterAndIncludesAsync(
                ch=>ch.CourseId == course.CourseId,
                ch=>ch.Lessons
                );
            course.Chapters = chapters.ToList();
            var viewModel = new LessonViewModel
            {
                LessonName = lesson.Title,
                CourseTitle = course.Title,
                InstructorName = course.Instructor.Name,
                InstructorAvatar = course.Instructor.Avatar,
                UrlVideo = lesson.VideoUrl,
                Description = lesson.Description,
                Duration = TimeSpan.FromMinutes(lesson.EstimateTime).ToString(@"hh\:mm")
            };

            return View(viewModel);
        }

        public async Task<IActionResult> Review(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lesson = await _iLessonService.GetLessonByIdAsync(id.Value);
            if (lesson == null)
            {
                return NotFound();
            }

            var courses = await _courseService.GetAllWithIncludesAsync(
                c=>c.Instructor
                );

            
            var course = courses.FirstOrDefault();
            if (course == null)
                return NotFound();

            var chapters = await _chapterService.GetWithFilterAndIncludesAsync(
                ch=>ch.CourseId == course.CourseId,
                ch=>ch.Lessons
                );
            course.Chapters = chapters.ToList();
            LessonViewModel viewModel = new LessonViewModel
            {
                LessonName = lesson.Title,
                CourseTitle = course.Title,
                InstructorName = course.Instructor.Name,
                InstructorAvatar = course.Instructor.Avatar,
                UrlVideo = lesson.VideoUrl,
                Description = lesson.Description,
                Duration = TimeSpan.FromMinutes(lesson.EstimateTime).ToString(@"hh\:mm")
            }; if (lesson == null) return NotFound();
            return View(viewModel);
        }
    }
}
