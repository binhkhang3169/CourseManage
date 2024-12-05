using System.Linq.Expressions;
using CourseManage.Entities;
using CourseManage.Interfaces;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;

namespace CourseManage.Services;

public class ChapterService:IChapterService
{
    private readonly IUnitOfWork _unitOfWork;

    public ChapterService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Chapter>> GetWithFilterAndIncludesAsync(Expression<Func<Chapter, bool>> filter, params Expression<Func<Chapter, object>>[] includes)
    {
        return await _unitOfWork.Chapters.GetWithFilterAndIncludesAsync(filter, includes);
    }

    public async Task<IEnumerable<Chapter>> GetAllWithIncludesAsync(params Expression<Func<Chapter, object>>[] includes)
    {
        return await _unitOfWork.Chapters.GetAllWithIncludesAsync(includes);
    }

    public async Task<IEnumerable<Chapter>> GetAllChapterAsync()
    {
        return await _unitOfWork.Chapters.GetAllAsync();
    }

    public async Task<Chapter> GetChapterByIdAsync(int id)
    {
        return await _unitOfWork.Chapters.GetByIdAsync(id);
    }

    public async Task CreateChapterAsync(Chapter chapter)
    {
        await _unitOfWork.Chapters.AddAsync(chapter);
        await _unitOfWork.SaveAsync();
    }

    public async Task<bool> UpdateChapterAsync(int id, Chapter chapter)
    {
        var existingChapter = await _unitOfWork.Chapters.GetByIdAsync(id);
        if (existingChapter == null)
            return false;

        await _unitOfWork.Chapters.UpdateAsync(chapter);
        await _unitOfWork.SaveAsync();
        return true;
    }

    public async Task<bool> DeleteChapterAsync(int id)
    {
        var existingChapter = await _unitOfWork.Chapters.GetByIdAsync(id);
        if (existingChapter == null)
            return false;
        await _unitOfWork.Chapters.DeleteAsync(id);
        await _unitOfWork.SaveAsync();
        return true;
    }
    
    
}