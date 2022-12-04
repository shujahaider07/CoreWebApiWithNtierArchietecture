using Microsoft.AspNetCore.Mvc;
using Model;
using Repository;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoreWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly Istudent stu;
        public StudentController(Istudent istudent)
        {
            this.stu = istudent;
        }


        [HttpGet]
        public async Task<IActionResult> GetStudents()
        {

            return Ok(await stu.GetStudents());

        }


        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetStudentsByid(int id)
        {

            return Ok(await stu.GetStudentsById(id));

        }




        [HttpPost]
        public async Task<IActionResult> AddStudnt(Students s)
        {

            //var add = await stu.Addstudents(s);
            //return CreatedAtAction(nameof(GetStudents), new { id = add.Id });
                try
                {
                    if (s == null)
                        return BadRequest();

                    var createdStudent = await stu.Addstudents(s);

                    return CreatedAtAction(nameof(GetStudents),
                        new { id = createdStudent.Id }, createdStudent);
                }
                catch (Exception)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError,
                        "Error creating new employee record");
                }
            }
        

        [HttpPut]
        public async Task<IActionResult> UpdateStd(Students s)
        {

            return Ok(await stu.updateStudent(s));


        }


        //[HttpDelete]
        //public IActionResult DelStd(int id)
        //{

        //    return Ok(stu.DeleteStudents(id));


        //}




    }
}
