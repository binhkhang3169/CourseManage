using CourseManage.Controllers;
using CourseManage.Entities;

namespace CourseManage.ViewModels
{
    public class ViewDetailDiscussionModel
    {
        public Discussion Discussion { get; set; }
        public List<TopUserDiscussion> TopUserDiscussions { get; set; }
    }
}
