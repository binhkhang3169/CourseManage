using CourseManage.Entities;

namespace CourseManage.Interfaces;

public interface IUserLessonService
{
    Task<IEnumerable<UserLesson>> GetAllUserLessonAsync();
    Task<UserLesson> GetUserLessonByIdAsync(int id); 
    Task CreateUserLessonAsync(UserLesson userLesson);
    Task<bool> UpdateUserLessonAsync(int id, UserLesson userLesson); 
    Task<bool> DeleteUserLessonAsync(int id);
}