using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CourseManage.Data;
using CourseManage.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;


namespace CourseManage.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ParentMenusController : Controller
    {
        private readonly AppDbContext _context;

        public ParentMenusController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Admin/ParentMenus
        public async Task<IActionResult> Index()
        {
            return View(await _context.ParentMenus.ToListAsync());
        }

        // GET: Admin/ParentMenus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parentMenu = await _context.ParentMenus
                .FirstOrDefaultAsync(m => m.Id == id);
            if (parentMenu == null)
            {
                return NotFound();
            }

            return View(parentMenu);
        }

        // GET: Admin/ParentMenus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/ParentMenus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Link,Meta,Hide,Order,DateBegin,Icon,Span")] ParentMenu parentMenu)
        {
            if (ModelState.IsValid)
            {
                _context.Add(parentMenu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(parentMenu);
        }

        // GET: Admin/ParentMenus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parentMenu = await _context.ParentMenus.FindAsync(id);
            if (parentMenu == null)
            {
                return NotFound();
            }
            return View(parentMenu);
        }

        // POST: Admin/ParentMenus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Link,Meta,Hide,Order,DateBegin,Icon,Span")] ParentMenu parentMenu)
        {
            if (id != parentMenu.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(parentMenu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ParentMenuExists(parentMenu.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(parentMenu);
        }

        // GET: Admin/ParentMenus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parentMenu = await _context.ParentMenus
                .FirstOrDefaultAsync(m => m.Id == id);
            if (parentMenu == null)
            {
                return NotFound();
            }

            return View(parentMenu);
        }

        // POST: Admin/ParentMenus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var parentMenu = await _context.ParentMenus.FindAsync(id);
            if (parentMenu != null)
            {
                _context.ParentMenus.Remove(parentMenu);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ParentMenuExists(int id)
        {
            return _context.ParentMenus.Any(e => e.Id == id);
        }
    }
}
