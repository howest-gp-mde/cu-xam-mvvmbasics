using System;

namespace XrnCourse.MvvmBasics.ViewModels
{
    public class ClassmateViewModel
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public DateTime BirthDate { get; set; }

        public int Age
        {
            get
            {
                int age = DateTime.Now.Year - BirthDate.Year;
                if (BirthDate > DateTime.Now.AddYears(-age)) age--; //adjust for leap year
                return age;
            }
        }
    }
}
