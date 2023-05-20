using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ContactManagement.Data;
using ContactManagement.Models;

namespace ContactManagement.Pages.Contacts
{
    public class EditModel : PageModel
    {
        private readonly ContactManagement.Data.ContactManagementContext _context;

        public EditModel(ContactManagement.Data.ContactManagementContext context)
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

            var contactmd =  await _context.ContactMD.FirstOrDefaultAsync(m => m.Id == id);
            if (contactmd == null)
            {
                return NotFound();
            }
            ContactMD = contactmd;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(ContactMD).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContactMDExists(ContactMD.Id))
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

        private bool ContactMDExists(int id)
        {
          return (_context.ContactMD?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
