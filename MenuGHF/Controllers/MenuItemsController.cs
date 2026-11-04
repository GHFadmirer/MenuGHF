
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MenuGHF.Models;
using MenuGHF.Data;

public class MenuItemsController : Controller
{
    private readonly MenuContext _context;

    public MenuItemsController(MenuContext context)
    {
        _context = context;
    }

    // GET: MENUITEMS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.MenuItems.ToListAsync());
    }

    // GET: MENUITEMS/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var menuitem = await _context.MenuItems
            .FirstOrDefaultAsync(m => m.Id == id);
        if (menuitem == null)
        {
            return NotFound();
        }

        return View(menuitem);
    }

    // GET: MENUITEMS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: MENUITEMS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Nome,Preco")] MenuItem menuitem)
    {
        if (ModelState.IsValid)
        {
            _context.Add(menuitem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(menuitem);
    }

    // GET: MENUITEMS/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var menuitem = await _context.MenuItems.FindAsync(id);
        if (menuitem == null)
        {
            return NotFound();
        }
        return View(menuitem);
    }

    // POST: MENUITEMS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("Id,Nome,Preco")] MenuItem menuitem)
    {
        if (id != menuitem.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(menuitem);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MenuItemExists(menuitem.Id))
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
        return View(menuitem);
    }

    // GET: MENUITEMS/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var menuitem = await _context.MenuItems
            .FirstOrDefaultAsync(m => m.Id == id);
        if (menuitem == null)
        {
            return NotFound();
        }

        return View(menuitem);
    }

    // POST: MENUITEMS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var menuitem = await _context.MenuItems.FindAsync(id);
        if (menuitem != null)
        {
            _context.MenuItems.Remove(menuitem);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool MenuItemExists(int? id)
    {
        return _context.MenuItems.Any(e => e.Id == id);
    }
}
