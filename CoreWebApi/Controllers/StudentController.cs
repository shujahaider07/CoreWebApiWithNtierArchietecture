using Microsoft.AspNetCore.Mvc;
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


        //[HttpGet]
        //public async Task<IActionResult> GetStudentsByid(int id)
        //{

        //    return Ok(await stu.GetStudentsById(id));

        //}


    }
}
