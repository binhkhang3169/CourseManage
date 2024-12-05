
using CourseManage.Data;
using CourseManage.Entities;
using CourseManage.Interfaces;

namespace CourseManage.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public IGenericRepository<Answer> Answers { get; }
        public IGenericRepository<BlogPost> BlogPosts { get; }
        public IGenericRepository<Chapter> Chapters { get; }
        public IGenericRepository<Entities.Course> Courses { get; }
        public IGenericRepository<Discussion> Discussions { get; }
        public IGenericRepository<DiscussionReply> DiscussionReplies { get; }
        public IGenericRepository<FeedBack> FeedBacks { get; }
        public IGenericRepository<Instructor> Instructors { get; }
        public IGenericRepository<LearningOutcomes> LearningOutcomes { get; }
        public IGenericRepository<Lesson> Lessons { get; }
        public IGenericRepository<Menu> Menus { get; }
        public IGenericRepository<ParentMenu> ParentMenus { get; }
        public IGenericRepository<Entities.Path> Paths { get; }
        public IGenericRepository<PaymentInformation> PaymentInformations { get; }
        public IGenericRepository<Platform> Platforms { get; }
        public IGenericRepository<Question> Questions { get; }
        public IGenericRepository<Quiz> Quizzes { get; }
        public IGenericRepository<StudentPath> StudentPaths { get; }
        public IGenericRepository<Student> Students { get; }
        public IGenericRepository<StudentQuiz> StudentQuizzes { get; }
        public IGenericRepository<Subscription> Subscriptions { get; }
        public IGenericRepository<SubscriptionType> SubscriptionTypes { get; }
        public IGenericRepository<Topic> Topics { get; }
        public IGenericRepository<TypePath> TypePaths { get; }
        public IGenericRepository<UserCourse> UserCourses { get; }
        public IGenericRepository<UserLesson> UserLessons { get; }
        public IGenericRepository<ViewCourse> ViewCourses { get; }

        public UnitOfWork(AppDbContext context)
        {
            _context = context;

            Answers = new GenericRepository<Answer>(_context);
            BlogPosts = new GenericRepository<BlogPost>(_context);
            Chapters = new GenericRepository<Chapter>(_context);
            Courses = new GenericRepository<Entities.Course>(_context);
            Discussions = new GenericRepository<Discussion>(_context);
            DiscussionReplies = new GenericRepository<DiscussionReply>(_context);
            FeedBacks = new GenericRepository<FeedBack>(_context);
            Instructors = new GenericRepository<Instructor>(_context);
            LearningOutcomes = new GenericRepository<LearningOutcomes>(_context);
            Lessons = new GenericRepository<Lesson>(_context);
            Menus = new GenericRepository<Menu>(_context);
            ParentMenus = new GenericRepository<ParentMenu>(_context);
            Paths = new GenericRepository<Entities.Path>(_context);
            PaymentInformations = new GenericRepository<PaymentInformation>(_context);
            Platforms = new GenericRepository<Platform>(_context);
            Questions = new GenericRepository<Question>(_context);
            Quizzes = new GenericRepository<Quiz>(_context);
            StudentPaths = new GenericRepository<StudentPath>(_context);
            Students = new GenericRepository<Student>(_context);
            StudentQuizzes = new GenericRepository<StudentQuiz>(_context);
            Subscriptions = new GenericRepository<Subscription>(_context);
            SubscriptionTypes = new GenericRepository<SubscriptionType>(_context);
            Topics = new GenericRepository<Topic>(_context);
            TypePaths = new GenericRepository<TypePath>(_context);
            UserCourses = new GenericRepository<UserCourse>(_context);
            UserLessons = new GenericRepository<UserLesson>(_context);
            ViewCourses = new GenericRepository<ViewCourse>(_context);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
