using CourseManage.Data;
using CourseManage.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

public class MenuViewComponent : ViewComponent
{
    private readonly AppDbContext _context;
    private readonly IMemoryCache _cache;
    private readonly UserManager<AppUser> _userManager;


    public MenuViewComponent(AppDbContext context, IMemoryCache cache, UserManager<AppUser> userManager)
    {
        _context = context;
        _cache = cache;
        _userManager = userManager;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var user = await _userManager.GetUserAsync(HttpContext.User);
        if (user == null)
        {
            return View("Menu", Enumerable.Empty<ParentMenu>());
        }

        var roles = await _userManager.GetRolesAsync(user);
        var userRole = roles.FirstOrDefault();

        var cacheKey = $"MenuCache_{userRole}";

        if (!_cache.TryGetValue(cacheKey, out IEnumerable<ParentMenu> menus))
        {
            if (userRole == RoleName.Student)
            {
                menus = await _context.ParentMenus
                    .Include(pm => pm.Menus)
                    .Where(pm => pm.Name != "Instructor")
                    .ToListAsync();
            }
            else
            {
                menus = await _context.ParentMenus
                    .Include(pm => pm.Menus)
                    .Where(pm => pm.Name != "Student")
                    .ToListAsync();
            }

            var cacheEntryOptions = new MemoryCacheEntryOptions()
                .SetSlidingExpiration(TimeSpan.FromMinutes(5));

            _cache.Set(cacheKey, menus, cacheEntryOptions);
        }

        return View("Menu", menus);
    }
}