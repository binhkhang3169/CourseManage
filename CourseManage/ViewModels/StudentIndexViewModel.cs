using CourseManage.Entities;

namespace CourseManage.ViewModels;

public class StudentIndexViewModel
{
    public List<StudentQuiz> StudentQuizzes { get; set; }
    public List<StudentCourseViewModel> StudentCourses { get; set; } // Đổi kiểu thành List<StudentCourseViewModel>
    public List<Discussion> StudentDiscussions { get; set; }
    public List<StudentPath> StudentPaths { get; set; }

    // Constructor
    public StudentIndexViewModel(
        List<StudentQuiz> studentQuizzes,
        List<StudentCourseViewModel> studentCourses, // Đổi kiểu của tham số này
        List<Discussion> studentDiscussions,
        List<StudentPath> studentPaths)
    {
        StudentQuizzes = studentQuizzes ?? throw new ArgumentNullException(nameof(studentQuizzes));
        StudentCourses = studentCourses ?? throw new ArgumentNullException(nameof(studentCourses));
        StudentDiscussions = studentDiscussions ?? throw new ArgumentNullException(nameof(studentDiscussions));
        StudentPaths = studentPaths ?? throw new ArgumentNullException(nameof(studentPaths));
    }
}