using Course.Model;
using Course.utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Net.Http.Headers;
using System.Net;
using Course.Business;
using FileHelpers;
using Microsoft.AspNetCore.Authorization;

namespace Course.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoureCreationController : ControllerBase
    {
        private static IWebHostEnvironment _webHostEnvironment;

        public CoureCreationController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        [HttpPost]
        [RequestFormLimits(MultipartBodyLengthLimit = 409715200)]
        [RequestSizeLimit(409715200)]
        [Route("trainer/UploadFile/{id:int}")]
        public JsonResult Upload([FromForm] IFormFile file, [FromForm] IFormFile thumbnail, int id)
        {
            try
            {
                int b = id;
                // getting file original name
                string FileName = file.FileName;
                string thumbnailName = thumbnail.FileName;


                // combining GUID to create unique name before saving in wwwroot
                string uniqueFileName = Guid.NewGuid().ToString() + "_" + FileName;
                string uniquethumbnailName = Guid.NewGuid().ToString() + "_" + thumbnailName;

                string halfpath = "Uploads/" + uniqueFileName;
                string thumbnailhalfpath = "Uploads/" + uniquethumbnailName;
                // getting full path inside wwwroot/images
                var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot",halfpath);
                var thumbnailpath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot",thumbnailhalfpath);

                // copying file
                file.CopyTo(new FileStream(imagePath, FileMode.Create));
                thumbnail.CopyTo(new FileStream(thumbnailpath, FileMode.Create));
                CoursesBO cBo = new CoursesBO();
                string res = cBo.UpdateCourseURL(id, halfpath,thumbnailhalfpath);
                Success sc = new Success();
                try
                {
                    int courseIdres = int.Parse(res);
                    
                    sc.id = 1;
                    sc.message = "Uploaded Successfully";
                    return new JsonResult(sc);
                }
                catch
                {
                    sc.id = 0;
                    sc.message = "Invalid course Id";
                    return new JsonResult(sc);
                }
            }
            catch (Exception ex)
            {
                Success sc = new Success();
                sc.id = 0;
                sc.message = "Unable to upload a file";
                return new JsonResult(sc);
            }
        }
        [HttpGet]
        [Route("getcourses/{trainerId:int}")]
        public JsonResult GetCourse(int trainerId)
        {
            CoursesBO cb = new CoursesBO();
            return new JsonResult(cb.GetCourses(trainerId));
        }
        [HttpPost]
        [Route("course/createcourse")]
        public JsonResult CreateCourse(Courses course)
        {
            if (course == null)
            {
                Error err = new Error();
                err.errId = 1;
                err.msg = "Invalid Input";
                return  new JsonResult(err);
            }
            else
            {
                CoursesBO cBo = new CoursesBO();
                string id = cBo.CreateCourse(course);
                try
                {
                    course.CourseID = int.Parse(id);
                    return new JsonResult(course);
                }
                catch(Exception ex)
                {
                    Error err = new Error();
                    err.errId = 0;
                    err.msg = "Course Name Exist";
                    return new JsonResult(err);
                }
            }
        }
        [HttpPost]
        [Authorize]
        [Route("course/createquiz/{id:int}")]
        public JsonResult CreateQuizz(Quiz[] quiz,int id)
        {
            CoursesBO cb = new CoursesBO();
            if(cb.AddQuiz(quiz,id))
            {
                Success sc = new Success();
                sc.id = 1;
                sc.message = "Success";
                return new JsonResult (sc);
            }
            else
            {
                Error sc = new Error();
                sc.errId = 0;
                sc.msg = "Something went wrong";
                return new JsonResult(sc);
            }
        }
        [HttpGet]
        [Authorize]
        [Route("course/getQuiz/{id:int}")]
        public IEnumerable<Quiz> GetQuiz(int id)
        {
            CoursesBO cb = new CoursesBO();
            Quiz[] abc= cb.GetQuiz(id);
            return abc;
        }
    }
}
