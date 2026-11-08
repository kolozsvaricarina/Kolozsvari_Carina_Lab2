using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Kolozsvari_Carina_Lab2.Models;

namespace Kolozsvari_Carina_Lab2.Pages.BorrowingPages;

public class EditModel : PageModel
{
    private readonly Kolozsvari_Carina_Lab2Context _context;

    public EditModel(Kolozsvari_Carina_Lab2Context context)
    {
        _context = context;
    }

    [BindProperty]
    public Borrowing Borrowing { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        Borrowing = await _context.Borrowing
            .Include(b => b.Book)
            .Include(b => b.Member)
            .FirstOrDefaultAsync(m => m.ID == id);

        if (Borrowing is null)
        {
            return NotFound();
        }

        ViewData["MemberID"] = new SelectList(_context.Member, "ID", "FullName");
        ViewData["BookID"] = new SelectList(_context.Book, "ID", "Title");

        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            ViewData["MemberID"] = new SelectList(_context.Member, "ID", "FullName");
            ViewData["BookID"] = new SelectList(_context.Book, "ID", "Title");
            return Page();
        }

        _context.Attach(Borrowing).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!BorrowingExists(Borrowing.ID))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return RedirectToPage("./Index");
    }

    private bool BorrowingExists(int id)
    {
        return _context.Borrowing.Any(e => e.ID == id);
    }
}