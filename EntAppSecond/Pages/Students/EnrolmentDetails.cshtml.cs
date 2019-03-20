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

        public async Task<IActionResult> OnGetAsync(string PPSNumber)
        {

            if (PPSNumber == null)
            {
                return RedirectToPage("/Students/ListStudents");
            }


            Student = await _db.Students.FindAsync(PPSNumber);
            Listdays = days();
            TotalCost = Cost();

            return Page();
        }




        [BindProperty]
        public string Listdays { get; set; }

        [BindProperty]
        public double TotalCost { get; set; }



        public string days()
        {
            int x = Student.DaysRequested;
            int[] primes = { 3, 5, 7, 11, 13 };
            IList<string> days = new List<string>();


            foreach (var n in primes)
            {
                if (x % n == 0)
                {
                    switch (n)
                    {
                        case 3:
                            days.Add("Monday");
                            break;
                        case 5:
                            days.Add("Tuesday");
                            break;
                        case 7:
                            days.Add("Wednesday");
                            break;
                        case 11:
                            days.Add("Thursday");
                            break;
                        case 13:
                            days.Add("Friday");
                            break;
                    }

                }
            }

            string all = string.Join(",", days.ToArray());
            x = 0;
            return all;

        }


        public double Cost()

        {

                int noOfDays = 0;
                int x = Student.DaysRequested;
                int y = Student.HoursRequested;
                double total = 0;
                int[] primes = { 3, 5, 7, 11, 13 };

                foreach (var n in primes)
                {
                    if (x % n == 0)
                    {
                        noOfDays++;
                    }
                }

                if (y == 1)
                {
                    total = noOfDays * 35;
                }
                else
                {
                    total = noOfDays * 20;
                }

                if (noOfDays > 3)
                {
                    total = total * 0.9;
                }



            return total;


        }
    }

}