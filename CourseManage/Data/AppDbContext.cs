using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.CodeAnalysis.Scripting.Hosting;
using CourseManage.Entities;

namespace CourseManage.Data
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                var tableName = entityType.GetTableName();
                if (tableName.StartsWith("AspNet"))
                {
                    entityType.SetTableName(tableName.Substring(6));
                }
            }


            modelBuilder.Entity<ParentMenu>().HasData(
                new ParentMenu
                {
                    Id = 1,
                    Name = "Student",
                    Link = "sm_student",
                    Meta = "student",
                    Hide = false,
                    Order = 1,
                    DateBegin = DateTime.Now,
                    Icon = "school",
                    Span = "Student"
                },
                new ParentMenu
                {
                    Id = 2,
                    Name = "Instructor",
                    Link = "sm_instructor",
                    Meta = "instructor",
                    Hide = false,
                    Order = 2,
                    DateBegin = DateTime.Now,
                    Icon = "format_shapes",
                    Span = "Instructor"
                },
                new ParentMenu
                {
                    Id = 3,
                    Name = "Apps",
                    Link = "sm_apps",
                    Meta = "apps",
                    Hide = false,
                    Order = 3,
                    DateBegin = DateTime.Now,
                    Icon = "apps",
                    Span = "Apps"
                },
                new ParentMenu
                {
                    Id = 4,
                    Name = "Messaging",
                    Link = "sm_messaging",
                    Meta = "messaging",
                    Hide = false,
                    Order = 4,
                    DateBegin = DateTime.Now,
                    Icon = "message",
                    Span = "Messaging"
                },
                new ParentMenu
                {
                    Id = 5,
                    Name = "Account",
                    Link = "sm_account",
                    Meta = "account",
                    Hide = false,
                    Order = 5,
                    DateBegin = DateTime.Now,
                    Icon = "account_box",
                    Span = "Account"
                }
            );

            modelBuilder.Entity<Menu>().HasData(
                new Menu
                {
                    Id = 1,
                    ParentMenuId = 1, // Student
                    Name = "Home",
                    Link = "",
                    Icon = "home",
                    Span = "Home",
                    Meta = "home_meta",
                    Hide = false,
                    Order = 1,
                    Badge = ""
                },
                new Menu
                {
                    Id = 2,
                    ParentMenuId = 1,
                    Name = "Browse Courses",
                    Link = "courses",
                    Icon = "local_library",
                    Span = "Browse Courses",
                    Meta = "courses_meta",
                    Hide = false,
                    Order = 2,
                    Badge = ""
                },
                new Menu
                {
                    Id = 3,
                    ParentMenuId = 1,
                    Name = "Browse Paths",
                    Link = "paths",
                    Icon = "style",
                    Span = "Browse Paths",
                    Meta = "paths_meta",
                    Hide = false,
                    Order = 3,
                    Badge = ""
                },
                new Menu
                {
                    Id = 4,
                    ParentMenuId = 1,
                    Name = "Student Dashboard",
                    Link = "student/dashboard",
                    Icon = "account_box",
                    Span = "Student Dashboard",
                    Meta = "dashboard_meta",
                    Hide = false,
                    Order = 4,
                    Badge = ""
                },
                new Menu
                {
                    Id = 5,
                    ParentMenuId = 1,
                    Name = "My Courses",
                    Link = "student/mycourse",
                    Icon = "search",
                    Span = "My Courses",
                    Meta = "my_courses_meta",
                    Hide = false,
                    Order = 5,
                    Badge = ""
                },
                new Menu
                {
                    Id = 6,
                    ParentMenuId = 1,
                    Name = "My Paths",
                    Link = "student/mypath",
                    Icon = "timeline",
                    Span = "My Paths",
                    Meta = "my_paths_meta",
                    Hide = false,
                    Order = 6,
                    Badge = ""
                },
                new Menu
                {
                    Id = 7,
                    ParentMenuId = 1,
                    Name = "Path Details",
                    Link = "student/pathdetail",
                    Icon = "change_history",
                    Span = "Path Details",
                    Meta = "path_details_meta",
                    Hide = false,
                    Order = 7,
                    Badge = ""
                }, new Menu
                {
                    Id = 8,
                    ParentMenuId = 1, // Student
                    Name = "Course Preview",
                    Link = "student/courseprview",
                    Icon = "face",
                    Span = "Course Preview",
                    Meta = "course_preview_meta",
                    Hide = false,
                    Order = 8,
                    Badge = ""
                },
                new Menu
                {
                    Id = 9,
                    ParentMenuId = 1,
                    Name = "Lesson Preview",
                    Link = "student/lesson",
                    Icon = "panorama_fish_eye",
                    Span = "Lesson Preview",
                    Meta = "lesson_preview_meta",
                    Hide = false,
                    Order = 9,
                    Badge = ""
                },
                new Menu
                {
                    Id = 10,
                    ParentMenuId = 1,
                    Name = "Take Course",
                    Link = "student/takecourse",
                    Icon = "class",
                    Span = "Take Course",
                    Meta = "take_course_meta",
                    Hide = false,
                    Order = 10,
                    Badge = "PRO"
                },
                new Menu
                {
                    Id = 11,
                    ParentMenuId = 1,
                    Name = "Take Lesson",
                    Link = "student/takelesson",
                    Icon = "import_contacts",
                    Span = "Take Lesson",
                    Meta = "take_lesson_meta",
                    Hide = false,
                    Order = 11,
                    Badge = ""
                },
                new Menu
                {
                    Id = 12,
                    ParentMenuId = 1,
                    Name = "Take Quiz",
                    Link = "student/takequiz",
                    Icon = "dvr",
                    Span = "Take Quiz",
                    Meta = "take_quiz_meta",
                    Hide = false,
                    Order = 12,
                    Badge = ""
                },
                new Menu
                {
                    Id = 13,
                    ParentMenuId = 1,
                    Name = "My Quizzes",
                    Link = "student/quizresults",
                    Icon = "poll",
                    Span = "My Quizzes",
                    Meta = "my_quizzes_meta",
                    Hide = false,
                    Order = 13,
                    Badge = ""
                },
                new Menu
                {
                    Id = 14,
                    ParentMenuId = 1,
                    Name = "Quiz Result",
                    Link = "student/quizresultdetails",
                    Icon = "live_help",
                    Span = "Quiz Result",
                    Meta = "quiz_result_meta",
                    Hide = false,
                    Order = 14,
                    Badge = ""
                },
                new Menu
                {
                    Id = 15,
                    ParentMenuId = 1,
                    Name = "Skill Assessment",
                    Link = "student/pathassessment",
                    Icon = "layers",
                    Span = "Skill Assessment",
                    Meta = "skill_assessment_meta",
                    Hide = false,
                    Order = 15,
                    Badge = ""
                },
                new Menu
                {
                    Id = 16,
                    ParentMenuId = 1,
                    Name = "Skill Result",
                    Link = "student/pathassessmentresul",
                    Icon = "assignment_turned_in",
                    Span = "Skill Result",
                    Meta = "skill_result_meta",
                    Hide = false,
                    Order = 16,
                    Badge = ""
                },

                // Instructor Menu Items
                new Menu
                {
                    Id = 17,
                    ParentMenuId = 2, // Instructor
                    Name = "Instructor Dashboard",
                    Link = "instructor",
                    Icon = "school",
                    Span = "Instructor Dashboard",
                    Meta = "instructor_dashboard_meta",
                    Hide = false,
                    Order = 1,
                    Badge = ""
                },
                new Menu
                {
                    Id = 18,
                    ParentMenuId = 2,
                    Name = "Manage Courses",
                    Link = "instructor/mycourses",
                    Icon = "import_contacts",
                    Span = "Manage Courses",
                    Meta = "manage_courses_meta",
                    Hide = false,
                    Order = 2,
                    Badge = ""
                },
                new Menu
                {
                    Id = 19,
                    ParentMenuId = 2,
                    Name = "Manage Quizzes",
                    Link = "instructor/quizz",
                    Icon = "help",
                    Span = "Manage Quizzes",
                    Meta = "manage_quizzes_meta",
                    Hide = false,
                    Order = 3,
                    Badge = ""
                },
                new Menu
                {
                    Id = 20,
                    ParentMenuId = 2,
                    Name = "Earnings",
                    Link = "instructor/earnings",
                    Icon = "trending_up",
                    Span = "Earnings",
                    Meta = "earnings_meta",
                    Hide = false,
                    Order = 4,
                    Badge = ""
                },
                new Menu
                {
                    Id = 21,
                    ParentMenuId = 2,
                    Name = "Statement",
                    Link = "instructor/statement",
                    Icon = "receipt",
                    Span = "Statement",
                    Meta = "statement_meta",
                    Hide = false,
                    Order = 5,
                    Badge = ""
                },
                new Menu
                {
                    Id = 22,
                    ParentMenuId = 2,
                    Name = "Edit Course",
                    Link = "instructor/editcourse",
                    Icon = "post_add",
                    Span = "Edit Course",
                    Meta = "edit_course_meta",
                    Hide = false,
                    Order = 6,
                    Badge = ""
                },
                new Menu
                {
                    Id = 23,
                    ParentMenuId = 2,
                    Name = "Edit Quiz",
                    Link = "instructor/editquiz",
                    Icon = "format_shapes",
                    Span = "Edit Quiz",
                    Meta = "edit_quiz_meta",
                    Hide = false,
                    Order = 7,
                    Badge = ""
                },

                // Account Menu Items
                new Menu
                {
                    Id = 24,
                    ParentMenuId = 5, // Account
                    Name = "Pricing",
                    Link = "pricing.html",
                    Icon = "",
                    Span = "Pricing",
                    Meta = "pricing_meta",
                    Hide = false,
                    Order = 1,
                    Badge = ""
                },
                new Menu
                {
                    Id = 25,
                    ParentMenuId = 5,
                    Name = "Login",
                    Link = "login.html",
                    Icon = "",
                    Span = "Login",
                    Meta = "login_meta",
                    Hide = false,
                    Order = 2,
                    Badge = ""
                },
                new Menu
                {
                    Id = 26,
                    ParentMenuId = 5,
                    Name = "Signup",
                    Link = "signup.html",
                    Icon = "",
                    Span = "Signup",
                    Meta = "signup_meta",
                    Hide = false,
                    Order = 3,
                    Badge = ""
                },
                new Menu
                {
                    Id = 27,
                    ParentMenuId = 5,
                    Name = "Payment",
                    Link = "signup-payment.html",
                    Icon = "",
                    Span = "Payment",
                    Meta = "payment_meta",
                    Hide = false,
                    Order = 4,
                    Badge = ""
                },
                new Menu
                {
                    Id = 28,
                    ParentMenuId = 5,
                    Name = "Reset Password",
                    Link = "reset-password.html",
                    Icon = "",
                    Span = "Reset Password",
                    Meta = "reset_password_meta",
                    Hide = false,
                    Order = 5,
                    Badge = ""
                },
                new Menu
                {
                    Id = 29,
                    ParentMenuId = 5,
                    Name = "Change Password",
                    Link = "change-password.html",
                    Icon = "",
                    Span = "Change Password",
                    Meta = "change_password_meta",
                    Hide = false,
                    Order = 6,
                    Badge = ""
                },
                new Menu
                {
                    Id = 30,
                    ParentMenuId = 5,
                    Name = "Edit Account",
                    Link = "edit-account.html",
                    Icon = "",
                    Span = "Edit Account",
                    Meta = "edit_account_meta",
                    Hide = false,
                    Order = 7,
                    Badge = ""
                },
                new Menu
                {
                    Id = 31,
                    ParentMenuId = 5,
                    Name = "Profile & Privacy",
                    Link = "edit-account-profile.html",
                    Icon = "",
                    Span = "Profile & Privacy",
                    Meta = "profile_privacy_meta",
                    Hide = false,
                    Order = 8,
                    Badge = ""
                },
                new Menu
                {
                    Id = 32,
                    ParentMenuId = 5,
                    Name = "Email Notifications",
                    Link = "edit-account-notifications.html",
                    Icon = "",
                    Span = "Email Notifications",
                    Meta = "email_notifications_meta",
                    Hide = false,
                    Order = 9,
                    Badge = ""
                },
                new Menu
                {
                    Id = 33,
                    ParentMenuId = 5,
                    Name = "Account Password",
                    Link = "edit-account-password.html",
                    Icon = "",
                    Span = "Account Password",
                    Meta = "account_password_meta",
                    Hide = false,
                    Order = 10,
                    Badge = ""
                },
                new Menu
                {
                    Id = 34,
                    ParentMenuId = 5,
                    Name = "Subscription",
                    Link = "billing.html",
                    Icon = "",
                    Span = "Subscription",
                    Meta = "subscription_meta",
                    Hide = false,
                    Order = 11,
                    Badge = ""
                },
                new Menu
                {
                    Id = 35,
                    ParentMenuId = 5,
                    Name = "Upgrade Account",
                    Link = "billing-upgrade.html",
                    Icon = "",
                    Span = "Upgrade Account",
                    Meta = "upgrade_account_meta",
                    Hide = false,
                    Order = 12,
                    Badge = ""
                }, new Menu
                {
                    Id = 38,
                    ParentMenuId = 5, // Account
                    Name = "Invoice",
                    Link = "billing-invoice.html",
                    Icon = "",
                    Span = "Invoice",
                    Meta = "invoice_meta",
                    Hide = false,
                    Order = 8,
                    Badge = ""
                },
                // Messaging Menu Items
                new Menu
                {
                    Id = 39,
                    ParentMenuId = 4, // Messaging
                    Name = "Messages",
                    Link = "messages.html",
                    Icon = "",
                    Span = "Messages",
                    Meta = "messages_meta",
                    Hide = false,
                    Order = 1,
                    Badge = ""
                },
                new Menu
                {
                    Id = 40,
                    ParentMenuId = 4, // Messaging
                    Name = "Email",
                    Link = "email.html",
                    Icon = "",
                    Span = "Email",
                    Meta = "email_meta",
                    Hide = false,
                    Order = 2,
                    Badge = ""
                }
            );

            // modelBuilder.Entity<Course>()
            //     .HasOne(c => c.Instructor)
            //     .WithMany(u => u.CoursesInstructed)
            //     .HasForeignKey(c => c.InstructorId);
            //
            // modelBuilder.Entity<FeedBack>()
            //     .HasOne(f => f.User)
            //     .WithMany(f=> f.FeedBacks)
            //     .HasForeignKey(f => f.UserId);
            modelBuilder.Entity<Student>()
                .HasOne(s => s.AppUser)
                .WithMany(s => s.Students)
                .HasForeignKey(s => s.UserId);
            modelBuilder.Entity<Instructor>()
                .HasOne(i => i.AppUser)
                .WithOne()
                .HasForeignKey<Instructor>(i => i.UserId);
        }

        public DbSet<ParentMenu> ParentMenus { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<Chapter> Chapters { get; set; }
        public DbSet<CourseManage.Entities.Course> Courses { get; set; }
        public DbSet<DiscussionReply> DiscussionReplies { get; set; }
        public DbSet<Discussion> Discussions { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Platform> Platforms { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<SubscriptionType> SubscriptionTypes { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<UserCourse> UserCourses { get; set; }
        public DbSet<UserLesson> UserLessons { get; set; }
        public DbSet<PaymentInformation> PaymentInformations { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<FeedBack> FeedBacks { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Entities.Path> Paths { get; set; }
        public DbSet<TypePath> TypePaths { get; set; }
        public DbSet<StudentPath> StudentPaths { get; set; }
        public DbSet<Quiz> Quizzes { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<StudentQuiz> StudentQuizzes { get; set; }
        public DbSet<LearningOutcomes> LearningOutcomesEnumerable { get; set; }
    }
}