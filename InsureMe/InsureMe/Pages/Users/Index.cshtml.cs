using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using InsureMe.Models;

namespace InsureMe.Pages.Users
{
    public class IndexModel : PageModel
    {
        private readonly InsureMe.Models.InsureMeContext _context;

        public IndexModel(InsureMe.Models.InsureMeContext context)
        {
            _context = context;
        }

        public IList<User> User { get;set; }

        public async Task OnGetAsync()
        {
            User = await _context.User.ToListAsync();
        }
    }
}
