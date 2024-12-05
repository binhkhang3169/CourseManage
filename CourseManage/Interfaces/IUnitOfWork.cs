using CourseManage.Entities;

namespace CourseManage.Interfaces;

public interface IUnitOfWork : IDisposable
{
    Task SaveAsync();

    IGenericRepository<Answer> Answers { get; }
    IGenericRepository<BlogPost> BlogPosts { get; }
    IGenericRepository<Chapter> Chapters { get; }
    IGenericRepository<Entities.Course> Courses { get; }
    IGenericRepository<Discussion> Discussions { get; }
    IGenericRepository<DiscussionReply> DiscussionReplies { get; }
    IGenericRepository<FeedBack> FeedBacks { get; }
    IGenericRepository<Instructor> Instructors { get; }
    IGenericRepository<LearningOutcomes> LearningOutcomes { get; }
    IGenericRepository<Lesson> Lessons { get; }
    IGenericRepository<Menu> Menus { get; }
    IGenericRepository<ParentMenu> ParentMenus { get; }
    IGenericRepository<Entities.Path> Paths { get; }
    IGenericRepository<PaymentInformation> PaymentInformations { get; }
    IGenericRepository<Platform> Platforms { get; }
    IGenericRepository<Question> Questions { get; }
    IGenericRepository<Quiz> Quizzes { get; }
    IGenericRepository<StudentPath> StudentPaths { get; }
    IGenericRepository<Student> Students { get; }
    IGenericRepository<StudentQuiz> StudentQuizzes { get; }
    IGenericRepository<Subscription> Subscriptions { get; }
    IGenericRepository<SubscriptionType> SubscriptionTypes { get; }
    IGenericRepository<Topic> Topics { get; }
    IGenericRepository<TypePath> TypePaths { get; }
    IGenericRepository<UserCourse> UserCourses { get; }
    IGenericRepository<UserLesson> UserLessons { get; }
    IGenericRepository<ViewCourse> ViewCourses { get; }
}