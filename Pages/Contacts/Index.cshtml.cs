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
    public class IndexModel : PageModel
    {
        private readonly ContactManagement.Data.ContactManagementContext _context;

        public IndexModel(ContactManagement.Data.ContactManagementContext context)
        {
            _context = context;
        }

        public IList<ContactMD> ContactMD { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.ContactMD != null)
            {
                ContactMD = await _context.ContactMD.ToListAsync();
            }
        }
    }
}
