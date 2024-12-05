using CourseManage.Entities;

namespace CourseManage.ViewModels
{
    public class CourseViewModel
    {
        public int CourseId { get; set; }
        public string Title { get; set; }
        public string InstructorName { get; set; } // To hold the instructor's name
        public string Description { get; set; }
        public string Thumbnail { get; set; }
        public Topic Topic { get; set; }

        public double? AverageRating { get; set; } = 0;

        // Add other properties as needed from the Course model
    }
}
