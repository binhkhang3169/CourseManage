using System.Linq.Expressions;
using CourseManage.Entities;

namespace CourseManage.Interfaces;

public interface IUserCourseService
{
    Task<IEnumerable<UserCourse>> GetAllWithIncludesAsync(params Expression<Func<UserCourse, object>>[] includes);

    Task<IEnumerable<UserCourse>> GetAllUserCourseAsync();
    Task<UserCourse> GetUserCourseByIdAsync(int id); 
    Task CreateUserCourseAsync(UserCourse userCourse);
    Task<bool> UpdateUserCourseAsync(int id, UserCourse userCourse); 
    Task<bool> DeleteUserCourseAsync(int id);
}