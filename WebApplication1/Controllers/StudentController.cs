using Microsoft.AspNetCore.Mvc;
using Repository;
using Common.Models;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        //---using dependency injection ---
        private readonly IStudentRepository _studentRepository ;
        //private readonly ITeacherRepository _teacherRepository;
        public StudentController(IStudentRepository studentrep)
        {
            _studentRepository = studentrep;
            //_teacherRepository = teacherRepository;
        }

        [HttpGet]
        [Route("GetAllStudents")]
        public async Task<ActionResult<List<Student>>> Get()
        {
            return await _studentRepository.GetStudents();
        }
        [HttpPost]
        [Route("AddStudent")]
        public async Task AddStudent(Student student)
        {
             await _studentRepository.AddStudent(student);
        }
        [HttpPut]
        [Route("UpdateStudent")]
        public async Task UpdateStudent(Student student)
        {
            await _studentRepository.UpdateStudent(student);
        }
        [HttpDelete]
        [Route("DeleteStudent")]
        public async Task DeleteStudent(int id)
        {
            await _studentRepository.DeleteStudent(id);
        }






        /* --- using constructor for class---
          private readonly StudentRepository _studentRepository;

        public StudentController()
        {
            _studentRepository =  new StudentRepository();
        }
        */

        /*
        [HttpGet]
        [Route("GetData")]
        public ActionResult GetAllStudent()
        {
            var students = _studentRepository.GetData();
            return Ok(students);
        }

        /*[HttpGet("GetByID")]
        public ActionResult GetById(int id)
        {
            var studentName = _studentRepository.GetById(id);
            if (studentName == "BOUNDS EXCEEDED")
            {
                return NotFound();
            }
            return Ok(studentName);
        }
        

        [HttpGet("GetByName")]
        public ActionResult GetByName(string name)
        {
            var result = _studentRepository.GetByName(name);
            if (result == "Absent")
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("GetByStart")]
        public ActionResult GetByStart(char st)
        {
            var result = _studentRepository.GetByStart(st);
            if (result == null )
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("GetIfContains")]
        public ActionResult GetIfContains(char st)
        {
            var result = _studentRepository.GetByMatch(st);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpGet("GetAllTeachers")]
        public ActionResult GetAllTeachers()
        {
            var teachers = _teacherRepository.GetAll();
            return Ok(teachers);
        }
        [HttpGet("GetByTeacherName")]
        public ActionResult GetByTeacherName(string name)
        {
            var result = _teacherRepository.GetByName(name);
            if (result == "Absent")
            {
                return NotFound();
            }
            return Ok(result);
        }
        */


    }
}





/*namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController: ControllerBase
    {
        private string[] studentNames = new[] 
            {
                "John",
                "Jane",
                "Alice",
                "Bob",
                "Eve"
            };

        [HttpGet]
        [Route("GetAllStudent")]

        public string[] GetAllStudent()
        {
            return studentNames;
        }

        [HttpGet( "GetByID")]
        public string GetById(int id)
        {
            // Assume here we have a list of student names where the index is used as ID
            

            if (id >= 0 && id < studentNames.Length)
            {
                return studentNames[id];
            }
            else
            {
                return "BOUNDS EXCEEDED";
            }
        }
        [HttpGet("GetByName")]
        public string GetByName(string name)
        {
            
            for(int i = 0; i < studentNames.Length; i++)
            {
                if (studentNames[i] == name)
                {
              
                    return "Present";
                    
                }
           

            }
            return "Absent";
        }

        

    }
}*/
