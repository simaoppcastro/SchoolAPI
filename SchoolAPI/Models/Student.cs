using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolAPI.Models
{
    // struct or definition of every student
    public class Student
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
