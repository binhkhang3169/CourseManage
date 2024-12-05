using CourseManage.Data;
using CourseManage.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

public class ParentMenuViewComponent : ViewComponent
{
    private readonly AppDbContext _context;
    private readonly IMemoryCache _cache;

    public ParentMenuViewComponent(AppDbContext context, IMemoryCache cache)
    {
        _context = context;
        _cache = cache;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var cacheKey = "ParentMenuCache";

        if (!_cache.TryGetValue(cacheKey, out IEnumerable<ParentMenu> parentMenus))
        {
            parentMenus = await _context.ParentMenus
                .ToListAsync();

            var cacheEntryOptions = new MemoryCacheEntryOptions()
                .SetSlidingExpiration(TimeSpan.FromMinutes(5));

            _cache.Set(cacheKey, parentMenus, cacheEntryOptions);
        }

        return View("ParentMenu", parentMenus);
    }
}