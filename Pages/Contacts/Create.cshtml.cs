using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ContactManagement.Data;
using ContactManagement.Models;

namespace ContactManagement.Pages.Contacts
{
    public class CreateModel : PageModel
    {
        private readonly ContactManagement.Data.ContactManagementContext _context;

        public CreateModel(ContactManagement.Data.ContactManagementContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public ContactMD ContactMD { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.ContactMD == null || ContactMD == null)
            {
                return Page();
            }

            _context.ContactMD.Add(ContactMD);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
