using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Course.Model;
using Microsoft.AspNetCore.Authorization;

namespace Course.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetCourseController : ControllerBase
    {
        [Authorize]
        [Route("GetCourses")]
        public IActionResult getCourse()
        {
            //var course = new Courses(1,"Machine Learning",499);
            return Ok();
        }
    }
}
