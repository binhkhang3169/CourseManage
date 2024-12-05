using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using Humanizer;
using Microsoft.AspNetCore.Identity;

namespace CourseManage.Entities{
    public class AppUser : IdentityUser
    {
        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<Instructor> Instructors { get; set; }
        public AppUser()
        {
            Instructors = new HashSet<Instructor>();
            Students = new List<Student>();
        }
    }
}
