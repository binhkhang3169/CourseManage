using CourseManage.Entities;
using CourseManage.Interfaces;

namespace CourseManage.Services;

public class BlogPostService:IBlogPostService
{
    private readonly IUnitOfWork _unitOfWork;

    public BlogPostService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    
    public async Task<IEnumerable<BlogPost>> GetAllBlogPostAsync()
    {
        return await _unitOfWork.BlogPosts.GetAllAsync();
    }

    public async Task<BlogPost> GetBlogPostByIdAsync(int id)
    {
        return await _unitOfWork.BlogPosts.GetByIdAsync(id);
    }

    public async Task CreateBlogPostAsync(BlogPost blogPost)
    {
        await _unitOfWork.BlogPosts.AddAsync(blogPost);
        await _unitOfWork.SaveAsync();
    }

    public async Task<bool> UpdateBlogPostAsync(int id, BlogPost blogPost)
    {
        var existingBlogPost = await _unitOfWork.BlogPosts.GetByIdAsync(id);
        if (existingBlogPost == null)
        {
            return false;
        }
        await _unitOfWork.BlogPosts.UpdateAsync(blogPost);
        await _unitOfWork.SaveAsync();
        return true;
    }

    public async Task<bool> DeleteBlogPostAsync(int id)
    {
        var existingBlogPost = await _unitOfWork.BlogPosts.GetByIdAsync(id);
        if (existingBlogPost == null)
            return false;

        await _unitOfWork.Answers.DeleteAsync(id);
        await _unitOfWork.SaveAsync();
        return true;
        
    }
}