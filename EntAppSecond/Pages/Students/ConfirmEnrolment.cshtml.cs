using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntAppSecond.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EntAppSecond.Pages.Students
{
    public class ConfirmEnrolmentModel : PageModel
    {

        private readonly StudentContext _db;

        public ConfirmEnrolmentModel(StudentContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Student Student { get; set; }

        public async Task<IActionResult> OnGetAsync(string PPSNumber)
        {
            Student = await _db.Students.FindAsync(PPSNumber);

            if (Student == null)
            {
                return NotFound();
            }
            return Page();
        }

        public IList<Student> Students { get; private set; }


    }
}