using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntAppSecond.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;

namespace EntAppSecond.Pages.Students
{
    public class CreateModel : PageModel
    {

        public enum Relationship
        {
            Mother,
            Father,
            Other,
        }

        public enum SelectedDays
        {
            Monday,
            Tuesday,
            Wednesday,
            Thursday,
            Friday
        }


        private readonly StudentContext _db;

        public CreateModel(StudentContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Student Student { get; set; } = new Student();

        public string Message { get; set; }


        public async Task<IActionResult> OnPostAsync()
        {

            if (ModelState.IsValid)
            {
                _db.Students.Add(Student);
                await _db.SaveChangesAsync();
                return RedirectToPage("ListStudents");
            }

            else
            {
                return Page();
            }
        }


        public void OnGet()
        {

        }
    }
}