using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using static EntAppSecond.Pages.Students.CreateModel;

namespace EntAppSecond.Models
{
    public class Student
    {
        [Key]
        [Display(Name = "First Name")]
        [Required(ErrorMessage = "Please enter a First Name")]
        [MinLength(2, ErrorMessage = "First Name must contain at least two characters")]
        public string ChildFirstNAme { get; set; }


        //[Required]
        //[DisplayName("Surname")]
        //[MinLength(3, ErrorMessage = "Surname Name must contain at least three characters")]
        //public string ChildSurname { get; set; }

        //[Key]
        //[Required(ErrorMessage = "Please Enter a valid PPS Number")]
        //[RegularExpression(@"(s|S)\d{7}", ErrorMessage = "Not an valid PPS Number")]
        //public string PPSNumber { get; set; } = "";

        //[Required]
        //[DataType(DataType.Date)]
        //public DateTime DateOfBirth { get; set; }

        //[Required(ErrorMessage = "Please Select your childs gender")]
        //public string Gender { get; set; }



        //[Display(Name = "First Name")]
        //[Required(ErrorMessage = "Please enter a First Name")]
        //[MinLength (2, ErrorMessage = "First Name must contain at least two characters")]
        //public string FirstName { get; set; } = "";

        //[Required]
        //[DisplayName("Second Name")]
        //[MinLength(3, ErrorMessage = "First Name must contain at least three characters")]
        //public string SecondName { get; set; } = "";

        //[Required(ErrorMessage = "Please Select your relation to the child")]
        //public Relationship Guardian { get; set; }

        ///*use area for this*/
        //[Required(ErrorMessage = "Please enter your address")]
        //public string Address { get; set; }

        //[Required]
        //[Display(Name = "Mobile Phone Number")]
        //[RegularExpression(@"^(\D?)(\d{2,5})?\D?\d{2,3}(\D?)(\D?)\d{7}", ErrorMessage = "Not a Valid Mobile Number, please check and try again")]
        //[DataType(DataType.PhoneNumber)]
        //public string PhoneMobile { get; set; }

        
        //[DataType(DataType.PhoneNumber)]
        //public string PhoneSecond { get; set; }

        //[DataType(DataType.PhoneNumber)]
        //public string PhoneThird { get; set; }

        //[DataType(DataType.PhoneNumber)]
        //public string FirstEmailAddress { get; set; }

        //[Required (ErrorMessage = "Please enter an email address")]
        //[DataType(DataType.EmailAddress)]
        //public string SecondEmailAddress { get; set; }


        [Required (ErrorMessage = "Please select the days you with your child to attend")]
        public string DaysRequested { get; set; }

        [Required(ErrorMessage = "Please Select Partime of Full time option")]
        public bool HoursRequested { get; set; }

        //[Required(ErrorMessage = "Please Select a Startdate for your child")]
        //public DateTime StartDate { get; set; }





    }
}
