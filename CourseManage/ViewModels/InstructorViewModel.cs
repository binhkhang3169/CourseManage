using CourseManage.Entities;

namespace CourseManage.ViewModels
{
    public class InstructorViewModel
    {
        public List<Entities.Course> Courses { get; set; }
        public List<Topic> Topics { get; set; }
    }
}
