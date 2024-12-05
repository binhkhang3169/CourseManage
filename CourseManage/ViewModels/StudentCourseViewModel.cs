namespace CourseManage.ViewModels
{
    public class StudentCourseViewModel
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public string InstructorName { get; set; }
        public Entities.Course Course { get; set; }
        public FeedbackViewModel Feedback { get; set; }
    }

    public class FeedbackViewModel
    {
        public string? Comment { get; set; }
        public int Rating { get; set; }
    }
}