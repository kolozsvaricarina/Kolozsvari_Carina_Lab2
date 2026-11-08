using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Kolozsvari_Carina_Lab2.Models;

namespace Kolozsvari_Carina_Lab2.Pages.Borrowings;

public class IndexModel : PageModel
{
    private readonly Kolozsvari_Carina_Lab2Context _context;

    public IndexModel(Kolozsvari_Carina_Lab2Context context)
    {
        _context = context;
    }

    public IList<Borrowing> Borrowing { get; set; } = default!;

    public async Task OnGetAsync()
    {
        if (_context.Borrowing != null)
        {
            Borrowing = await _context.Borrowing
                .Include(b => b.Book)
                .ThenInclude(b => b.Author)
                .Include(b => b.Member)
                .ToListAsync();
        }
    }
}
