using CourseManage.Data;
using CourseManage.Entities;
using CourseManage.Interfaces;
using CourseManage.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CourseManage.Controllers
{
    [Authorize(Roles = RoleName.Student)]
    public class StudentController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IStudentPathService _studentPath;
        private readonly IStudentQuizService _studentQuiz;
        private readonly IUserCourseService _userCourse;
        private readonly IDiscussionService _discussion;
        private readonly IFeedBackService _feedBack;
        private readonly ILessonService _lesson;
        private readonly ICourseService _courseService;
        public StudentController(UserManager<AppUser> userManager
            , IStudentPathService studentPath, IStudentQuizService studentQuiz
            , IUserCourseService userCourse, IDiscussionService discussion
            , IFeedBackService feedBack, ILessonService lesson
            ,ICourseService courseService)
        {
            _userManager = userManager;
            _studentPath = studentPath;
            _studentQuiz = studentQuiz;
            _userCourse = userCourse;
            _discussion = discussion;
            _feedBack = feedBack;
            _lesson = lesson;
            _courseService = courseService;
        }

        public async Task<IActionResult> Index()
        {
            // Lấy User ID một lần duy nhất
            var userId = _userManager.GetUserId(User);

            // Tải các dữ liệu cần thiết mà không lọc trong ThenInclude
            var studentPaths = await _studentPath.GetAllWithIncludesAsync(
                t=>t.Student,
                t=>t.Path
            );

            var studentPathsTask = studentPaths.Where(s => s.Student.UserId == userId);
            var userCourses = await _userCourse.GetAllWithIncludesAsync(
                t=>t.Course,
                t=>t.Course.Instructor,
                t=>t.Course.FeedBacks,
                t=>t.Student
            );


            var studentCoursesTask = userCourses
                .Where(t => t.Student.UserId == userId);

            var discussions = await _discussion.GetAllWithIncludesAsync(
                    d=>d.Student
                );

            var studentDiscussionsTask = discussions
                .Where(s => s.Student.UserId == userId);

            var studentQuizzes = await _studentQuiz.GetAllWithIncludesAsync(
                    s=>s.Quiz,
                    s=>s.Quiz.Course,
                    s=>s.Student
                );


            var studentQuizzesTask = studentQuizzes
                .Where(s => s.Student.UserId == userId);
            // Chờ tất cả các tác vụ hoàn thành
            // await Task.WhenAll(studentPathsTask, studentCoursesTask, studentDiscussionsTask, studentQuizzesTask);

            // Lọc phản hồi trong bộ nhớ sau khi tải dữ liệu
            var studentCourses = studentCoursesTask.Select(t => new
            {
                Course = t.Course,
                Feedback = t.Course.FeedBacks
                    .FirstOrDefault(f => f.Student.UserId == userId) // Lọc feedback của sinh viên hiện tại
            }).ToList();

            // Khởi tạo ViewModel với dữ liệu đã tải và đã lọc
            var model = new StudentIndexViewModel(
                studentQuizzesTask.ToList(),
                studentCourses.Select(sc => new StudentCourseViewModel
                {
                    CourseId = sc.Course.CourseId,
                    CourseName = sc.Course.Title,
                    InstructorName = sc.Course.Instructor.Name,
                    Course = sc.Course,
                    Feedback = sc.Feedback != null
                        ? new FeedbackViewModel
                        {
                            Comment = sc.Feedback.Feedback,
                            Rating = sc.Feedback.Rating.Value
                        }
                        : null
                }).ToList(),
                studentDiscussionsTask.ToList(),
                studentPathsTask.ToList()
            );

            return View(model);
        }


        public IActionResult Profile()
        {
            return View();
        }

        public IActionResult Mypath()
        {
            return View();
        }

        public async Task<IActionResult> Mycourse()
        {
            // Lấy User ID một lần duy nhất
            var userId = _userManager.GetUserId(User);

            var studentPaths = await _studentPath.GetAllWithIncludesAsync(
                t=>t.Student,
                t=>t.Path
                );
            
            // Tải các dữ liệu cần thiết mà không lọc trong ThenInclude
            var studentPathsTask = studentPaths
                .Where(t => t.Student.UserId == userId)
                .ToList();

            var userCourses = await _userCourse.GetAllWithIncludesAsync(
                    t=>t.Course,
                    t=>t.Course.Instructor,
                    t=>t.Course.Topic,
                    t=>t.Course.FeedBacks,
                    t=>t.Student
                );
            var studentCoursesTask = userCourses
                .Where(t => t.Student.UserId == userId)
                .ToList();

            // var studentDiscussionsTask = await _context.Discussions
            //     .Include(s => s.User)
            //     .Where(s => s.UserId == userId)
            //     .ToListAsync();

            var studentQuizzes = await _studentQuiz.GetAllWithIncludesAsync(
                s=>s.Quiz,
                s=>s.Quiz.Course,
                s=>s.Student
                );
            
            var studentQuizzesTask = studentQuizzes
                .Where(s => s.Student.UserId == userId)
                .ToList();

            // Chờ tất cả các tác vụ hoàn thành
            // await Task.WhenAll(studentPathsTask, studentCoursesTask, studentDiscussionsTask, studentQuizzesTask);

            // Lọc phản hồi trong bộ nhớ sau khi tải dữ liệu
            var studentCourses = studentCoursesTask.Select(t => new
            {
                Course = t.Course,
                Feedback = t.Course.FeedBacks
                    .FirstOrDefault(f => f.Student.UserId == userId) // Lọc feedback của sinh viên hiện tại
            }).ToList();

            // Khởi tạo ViewModel với dữ liệu đã tải và đã lọc
            var model = new StudentIndexViewModel(
                studentQuizzesTask,
                studentCourses.Select(sc => new StudentCourseViewModel
                {
                    CourseId = sc.Course.CourseId,
                    CourseName = sc.Course.Title,
                    InstructorName = sc.Course.Instructor.Name,
                    Course = sc.Course,
                    Feedback = sc.Feedback != null
                        ? new FeedbackViewModel
                        {
                            Comment = sc.Feedback.Feedback,
                            Rating = sc.Feedback.Rating.Value
                        }
                        : null
                }).ToList(),
                new List<Discussion>(),
                studentPathsTask
            );

            return View(model);
        }

        public IActionResult PathAssessment()
        {
            return View();
        }

        public IActionResult PathAssessmenetResult()
        {
            return View();
        }

        public IActionResult PathDetail()
        {
            return View();
        }

        public IActionResult QuizResult()
        {
            return View();
        }

        public IActionResult QuizResultDetail()
        {
            return View();
        }

        public async Task<IActionResult> TakeCourse(int? id)
        {
            if (id == null)
            {
                return BadRequest("Can not solve id");
            }

            var courses = await _courseService.GetAllWithIncludesAsync(
                c=>c.Instructor,
                c=>c.Chapters,
                c=>c.Chapters.Select(ch=>ch.Lessons)
                );
            
            var course = courses
                .FirstOrDefault(c => c.CourseId == id);
            if (course == null)
            {
                return BadRequest("Can't see course");
            }

            var feedbackswithoutwhere = await _feedBack.GetAllWithIncludesAsync(
                f=>f.Student
            );
            
            var feedbacks = feedbackswithoutwhere
                .Where(f => f.CourseId == course.CourseId)
                .Where(f => f.Rating.HasValue)
                .OrderByDescending(f => f.Created)
                .ToList();

            return View(Tuple.Create(course, feedbacks.AsEnumerable()));
        }

        public async Task<IActionResult> TakeLesson(int? id)
        {
            if (id == null)
            {
                return BadRequest("Can not solve id");
            }

            var lessons = await _lesson.GetAllWithIncludesAsync(
                l=>l.Chapter,
                l=>l.Chapter.Lessons,
                l=>l.Chapter.Course,
                l=>l.Chapter.Course.Instructor
                );
            
            
            var lesson = lessons
                .FirstOrDefault(l => l.LessonId == id);
            var discussions =  await _discussion.GetAllDiscussionAsync();
            var discussion = discussions
                .FirstOrDefault(d => d.LessonId == id);
            return View(Tuple.Create(lesson, discussion));
        }

        public IActionResult TakeQuiz()
        {
            return View();
        }
    }
}