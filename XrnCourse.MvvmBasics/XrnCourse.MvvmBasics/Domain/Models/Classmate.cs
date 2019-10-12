using System;

namespace XrnCourse.MvvmBasics.Domain.Models
{
    public class Classmate
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public DateTime Birthdate { get; set; }
    }

}
