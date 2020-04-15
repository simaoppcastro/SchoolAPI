using SchoolAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolAPI.Data
{
    public class Repository : IRepository
    {
        // private static Repository instance = null;

        List<Student> students = new List<Student>(); 

        // constructor
        // private Repository()
        public Repository()
        {
            // interface


            students.Add(new Student
            {
                Id = 1,
                Number = "a19434",
                Name = "Pedro Ribeiro",
                Email = "a19434@alunos.uminho.pt"
            });

            students.Add(new Student
            {
                Id = 2,
                Number = "a19444",
                Name = "Nuno Cardoso",
                Email = "a19444@alunos.uminho.pt"
            });

            students.Add(new Student
            {
                Id = 3,
                Number = "a19450",
                Name = "David Novais",
                Email = "a19450@alunos.uminho.pt"
            });
        }

        // já nao é usado (passou a usar-se Singleton)
        // sendo private isto dá erro
        // Repository rep1 = new Repository();

        /*public static Repository Instance
        {
            get 
            {
                // auto increment the instance
                if (instance == null)
                {
                    instance = new Repository();
                }    

                return instance;
            }
        }*/

        // method to return all the students
        public List<Student> GetAllStudents()
        {
            return students;
        }

        // method to return a student identified/specified by ID
        public Student GetStudentById(int id)
        {
            return students.FirstOrDefault(s => s.Id == id);
        }

        // method to add a student 
        // first see if exists, if not, add the student
        public bool AddStudent(Student student)
        {
            if (students.Exists(x => x.Id == student.Id || x.Number == student.Number || x.Email == student.Email))
            {
                return false;
            }    

            students.Add(student);

            return true;
        }

        // method to update a specified student by id
        public Student UpdateStudent(int id, Student newStudent)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            if (student != null)
            {
                // verificar se já existe cada um dos dados
                student.Name = newStudent.Name;
                // TODO: verificar se já existe o student com o novo numero
                student.Number = newStudent.Number;
                // TODO: verificar se já existe o student com o novo email
                student.Email = newStudent.Email;

                return student;
            }

            return null;  
        }

        // method to delete student specified by ID
        public bool DeleteStudent(int id)
        {
            // search in the students by the student.id
            // if exists, delete, else return false
            var student = students.FirstOrDefault(s => s.Id == id);
            if (student != null)
            {
                students.Remove(student);
                return true;
            }

            return false;
        }
    }
}
