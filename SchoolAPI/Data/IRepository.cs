using SchoolAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolAPI.Data
{
    public interface IRepository
    {

        // obrigamos a que estes metodos sejam implementados onde esta interface for implementada
        // por exemplo no Repository
        List<Student> GetAllStudents();

        Student GetStudentById(int id);

        bool AddStudent(Student student);

        Student UpdateStudent(int id, Student newStudent);

        bool DeleteStudent(int id);

    }
}
