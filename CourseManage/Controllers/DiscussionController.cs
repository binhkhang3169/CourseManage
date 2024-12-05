
using CourseManage.Data;
using CourseManage.Entities;
using CourseManage.ViewModels;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CourseManage.Controllers
{
    public class DiscussionController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public DiscussionController(AppDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult Index(int id)
        {
            var disc = _context.Discussions
                .Include(d => d.Student)
                .Include(d => d.DiscussionReplies)
                .Where(d => d.LessonId == id)
                .OrderByDescending(d => d.CreatedAt)
                .ToList();
            return View(disc);
        }

        public IActionResult Detail(int id)
        {
            var disc = _context.Discussions.Include(d => d.Student)
                .Include(d => d.DiscussionReplies
                    .OrderByDescending(r => r.CreatedAt))
                .ThenInclude(r => r.Student)
                .FirstOrDefault(d => d.DiscussionId == id);
            ViewDetailDiscussionModel viewDetailDiscussionModel = new ViewDetailDiscussionModel
            {
                Discussion = disc,
                TopUserDiscussions = GetTopDiscussionCreators(TimePeriod.ThisMonth)
            };
            return View(viewDetailDiscussionModel);
        }

        public IActionResult Ask()
        {
            return View();
        }

        public IActionResult Test()
        {
            return View();
        }

        [HttpPost]
        [Route("Discussion/PostCommentAsync")]
        public async Task<IActionResult> PostCommentAsync(int discussionId, string content)
        {
            // Get the currently logged-in user
            var user = await _userManager.GetUserAsync(User);
            //đổi userId thành StudentId hoặc IntructorId
            if (user == null)
            {
                return BadRequest();
            }

            var student = await _context.Students.FirstOrDefaultAsync(s => s.UserId == user.Id);

            if (student != null)
            {
                var rep = new DiscussionReply
                {
                    DiscussionId = discussionId,
                    Content = content,
                    StudentId = student.StudentId
                };

                _context.DiscussionReplies.Add(rep);
                _context.SaveChanges();

                // Return the necessary data for the AJAX response
                var result = new
                {
                    userName = student.Name,
                    userAvatar = Url.Content(student.Avatar), // Assuming you have an Avatar property on your User model
                    content = content
                };
                //await _discussionHub.SendComment(discussionId, result.userName, result.userAvatar, result.content);
                Console.WriteLine("\n---Post success---\n");

                return Json(result); // Return JSON data to the client-side
            }

            var intructor = await _context.Instructors.FirstOrDefaultAsync(i => i.UserId == user.Id);
            if (intructor == null)
            {
                return BadRequest();
            }

            var rep1 = new DiscussionReply
            {
                DiscussionId = discussionId,
                Content = content,
                InstructorId = intructor.InstructorId
            };

            _context.DiscussionReplies.Add(rep1);
            _context.SaveChanges();

            // Return the necessary data for the AJAX response
            var result1 = new
            {
                userName = intructor.Name,
                userAvatar = Url.Content(intructor.Avatar), // Assuming you have an Avatar property on your User model
                content = content
            };
            //await _discussionHub.SendComment(discussionId, result.userName, result.userAvatar, result.content);
            Console.WriteLine("\n---Post success---\n");

            return Json(result1); // Return JSON data to the client-side
        }

        public List<TopUserDiscussion> GetTopDiscussionCreators(TimePeriod period)
        {
            DateTime startDate;
            switch (period)
            {
                case TimePeriod.ThisMonth:
                    startDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                    break;
                case TimePeriod.ThisWeek:
                    startDate = DateTime.Now.AddDays(-(int)DateTime.Now
                        .DayOfWeek); // Beginning of the current week (Sunday)
                    break;
                case TimePeriod.ThisYear:
                    startDate = new DateTime(DateTime.Now.Year, 1, 1);
                    break;
                default:
                    throw new ArgumentException("Invalid time period specified.");
            }

            var topUsers = _context.Discussions
                .Include(d => d.Student)  // Bao gồm Student
                .Include(d => d.Instructor) // Bao gồm Instructor
                .Where(d => d.CreatedAt >= startDate)
                .GroupBy(d => d.UserId) // Sử dụng thuộc tính `UserId`
                .Select(g => new TopUserDiscussion
                {
                    UserId = g.Key, // `Key` là `UserId` của nhóm
                    DiscussionCount = g.Count()
                })
                .OrderByDescending(u => u.DiscussionCount)
                .Take(10) // Lấy top 10
                .ToList();

            return topUsers;
        }
    }

    public class TopUserDiscussion
    {
        public string UserId { get; set; }
        public int DiscussionCount { get; set; }
    }


    public enum TimePeriod
    {
        ThisMonth,
        ThisWeek,
        ThisYear
    }
}