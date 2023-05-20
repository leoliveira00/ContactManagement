using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ContactManagement.Data;
using ContactManagement.Models;

namespace ContactManagement.Pages.Contacts
{
    public class DeleteModel : PageModel
    {
        private readonly ContactManagement.Data.ContactManagementContext _context;

        public DeleteModel(ContactManagement.Data.ContactManagementContext context)
        {
            _context = context;
        }

        [BindProperty]
      public ContactMD ContactMD { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.ContactMD == null)
            {
                return NotFound();
            }

            var contactmd = await _context.ContactMD.FirstOrDefaultAsync(m => m.Id == id);

            if (contactmd == null)
            {
                return NotFound();
            }
            else 
            {
                ContactMD = contactmd;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.ContactMD == null)
            {
                return NotFound();
            }
            var contactmd = await _context.ContactMD.FindAsync(id);

            if (contactmd != null)
            {
                ContactMD = contactmd;
                _context.ContactMD.Remove(ContactMD);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
