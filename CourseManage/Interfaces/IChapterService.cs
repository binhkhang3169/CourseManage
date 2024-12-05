using System.Linq.Expressions;
using CourseManage.Entities;

namespace CourseManage.Interfaces;

public interface IChapterService
{
    Task<IEnumerable<Chapter>> GetAllWithIncludesAsync(params Expression<Func<Chapter, object>>[] includes);
    Task<IEnumerable<Chapter>> GetWithFilterAndIncludesAsync(Expression<Func<Chapter, bool>> filter, params Expression<Func<Chapter, object>>[] includes);


    Task<IEnumerable<Chapter>> GetAllChapterAsync();
    Task<Chapter> GetChapterByIdAsync(int id); 
    Task CreateChapterAsync(Chapter chapter);
    Task<bool> UpdateChapterAsync(int id, Chapter chapter); 
    Task<bool> DeleteChapterAsync(int id);
}