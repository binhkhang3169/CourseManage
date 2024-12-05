using CourseManage.Entities;

namespace CourseManage.Interfaces;

public interface IBlogPostService
{
    Task<IEnumerable<BlogPost>> GetAllBlogPostAsync();
    Task<BlogPost> GetBlogPostByIdAsync(int id); 
    Task CreateBlogPostAsync(BlogPost blogPost);
    Task<bool> UpdateBlogPostAsync(int id, BlogPost blogPost); 
    Task<bool> DeleteBlogPostAsync(int id);
}