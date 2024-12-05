using System.Linq.Expressions;
using CourseManage.Entities;

namespace CourseManage.Interfaces;

public interface IFeedBackService
{

    Task<IEnumerable<FeedBack>> GetAllFeedBackAsync();
    Task<FeedBack> GetFeedBackByIdAsync(int id); 
    Task<IEnumerable<FeedBack>> GetAllWithIncludesAsync(params Expression<Func<FeedBack, object>>[] includes);

    Task CreateFeedBackAsync(FeedBack feedBack);
    Task<bool> UpdateFeedBackAsync(int id, FeedBack feedBack); 
    Task<bool> DeleteFeedBackAsync(int id);
}