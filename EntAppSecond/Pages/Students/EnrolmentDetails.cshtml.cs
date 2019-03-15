using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntAppSecond.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace EntAppSecond.Pages.Students
{
    public class EnrolmentDetailsModel : PageModel
    {

        private readonly StudentContext _db;

        public EnrolmentDetailsModel(StudentContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Student Student { get; set; }

        public async Task<IActionResult> OnGetAsync(string pps)
        {
            Student = await _db.Students.FindAsync(pps);

            if (Student == null)
            {
                return NotFound();
            }
            return Page();
        }


        public IList<Student> Students { get; private set; }

    }

}