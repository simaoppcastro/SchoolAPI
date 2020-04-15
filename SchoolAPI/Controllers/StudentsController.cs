using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolAPI.Models;
using SchoolAPI.Data;

namespace SchoolAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        // readonly
        private readonly IDateTime _dateTime;
        private readonly IRepository _repository;

        // definir o constructor
        // injeção de dependencias
        public StudentsController(IDateTime dateTime, IRepository repository)
        {
            // dateTime fica disponivel para usar 
            _dateTime = dateTime;
            _repository = repository;
        }

        // GET: api/students
        [HttpGet]
        public IEnumerable<Student> GetAllStudents()
        {
            // return Repository.Instance.GetAllStudents();
            return _repository.GetAllStudents();
        }

        // GET: api/students/:id
        [HttpGet("{id}")]
        public IActionResult GetStudent(int id) 
        {
            // var student = students.FirstOrDefault(s => s.Id == id);     // procura pelo ID passado (expressão lambda)
            // var student = Repository.Instance.GetStudentById(id);
            var student = _repository.GetStudentById(id);  
            if (student == null)
            {
                string strResult = String.Format("{0}: Student no Found...", _dateTime.Now);
                // return NotFound("No Student Found...");
                return NotFound(strResult);
            }
            
            return Ok(student);
        }

        // to add a new student
        // POST: api/students
        [HttpPost]
        public IActionResult PostStudent(Student student)
        {
            /*
            // NUMBER
            // <Student> devido ao cast, mas não era necessário
            var entityNumber = students.ToList<Student>().Exists(s => s.Number == student.Number);
            if (entityNumber)
            {
                // return StatusCode(StatusCodes.Status406NotAcceptable);
                return Forbid("Student with a given number already exists!");
            }

            // NAME
            var entityName = students.ToList<Student>().Exists(s => s.Email == student.Email);
            if (entityName)
            {
                // return StatusCode(StatusCodes.Status406NotAcceptable);
                return Forbid("Student with a given number already exists!");
            }
            */

            // if (!Repository.Instance.AddStudent(student)){
            if (!_repository.AddStudent(student)){
                return NotFound("Student already exists...");
            }

            return StatusCode(StatusCodes.Status201Created);
        }

        // to update a student by ID
        // PUT: api/students/:id
        [HttpPut("{id}")]
        public IActionResult PutStudent(int id, Student student)
        {
            // não é obrigatorio o [FromBody]a ntes de "Student"
            // var newStudent = Repository.Instance.UpdateStudent(id, student);
            var newStudent = _repository.UpdateStudent(id, student);
            if (newStudent != null)
                return Ok(newStudent);
               
            return NotFound("Cannot update student...");
        }

        // to delete a student by ID
        // DELETE: api/students/:id
        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            // if (Repository.Instance.DeleteStudent(id))
            if (_repository.DeleteStudent(id))
            {
                return Ok("Student deleted...");
            }

            return NotFound("Student not found...");
        }

    }
}