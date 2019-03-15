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
    public class ListStudentsModel : PageModel
    {

        public enum Weekdays
        {
            Monday,
            Tuesday,
            Wednesday,
            Thursday,
            friday,
        }

        [BindProperty]
        public IList<string> Listdays { get; set; }

        [BindProperty]
        public IList<double> TotalCost { get; set; }

        private readonly StudentContext _db;

        public ListStudentsModel(StudentContext db)
        {
            _db = db;
        }

        public IList<Student> Students { get; private set; }

        public async Task OnGetAsync()
        {
            Students = await _db.Students.AsNoTracking().ToListAsync();
            Listdays = days();
            TotalCost = Cost();
        }


        public IList<string> days()
        {
            List<string> listdays = new List<string>();

            foreach ( Student student in Students)
            {

                int x = Convert.ToInt32(@student.DaysRequested.ToString());
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
                listdays.Add(all);
            }

            return listdays;
        }


        public IList<double> Cost()

        {
            List<double> cost = new List<double>();

            foreach (Student student in Students)
            {

                int noOfDays = 0;
                int x = Convert.ToInt32(@student.DaysRequested.ToString());
                int y = Convert.ToInt32(@student.HoursRequested.ToString());
                double total = 0;
                int[] primes = { 3, 5, 7, 11, 13 };

                foreach (var n in primes)
                {
                    if (x % n == 0)
                    {
                        noOfDays++;
                    }
                }

                if (y == 1) {
                        total = noOfDays * 35;
                    } else {
                        total = noOfDays * 20;
                    }

                if (noOfDays > 3)
                    {
                        total = total * 0.9;
                    }

               cost.Add(total);
            }

            return cost;


        }
    }
}