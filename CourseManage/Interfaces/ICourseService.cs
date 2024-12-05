using System.Linq.Expressions;
using CourseManage.Entities;

namespace CourseManage.Interfaces;

public interface ICourseService
{
    Task<IEnumerable<Entities.Course>> GetAllCourseAsync();
    Task<IEnumerable<Entities.Course>> GetAllWithIncludesAsync(params Expression<Func<Entities.Course, object>>[] includes);
    
    Task<IEnumerable<Entities.Course>> GetWithFilterAndIncludesAsync(Expression<Func<Entities.Course, bool>> filter, params Expression<Func<Entities.Course, object>>[] includes);

    
    Task<Entities.Course> GetCourseByIdAsync(int id); 
    Task CreateCourseAsync(Entities.Course course);
    Task<bool> UpdateCourseAsync(int id, Entities.Course course); 
    Task<bool> DeleteCourseAsync(int id);
}