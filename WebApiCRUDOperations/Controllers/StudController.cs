using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiCRUDOperations.App_Start;
using WebApiCRUDOperations.Models;

namespace WebApiCRUDOperations.Controllers
{
    public class StudController : ApiController
    {
        [HttpGet]
        [Route("findStudent")]
        public HttpResponseMessage Get(int id)
        {
            Student student = new Student();
            using (var context = new SchoolEntities())
            {
                student = context.Students.Where(s => s.StudentId == id).FirstOrDefault();
            }
            if (student == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, id);
            }
            return Request.CreateResponse(HttpStatusCode.OK, student);
        }


        [Route("CheckStudent")]
        public IHttpActionResult GetStudent(int id)
        {
            Student student = new Student();
            using (var context = new SchoolEntities())
            {
                student = context.Students.Where(s => s.StudentId == id).FirstOrDefault();
            }
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        private HttpResponseMessage OK(Student student)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [Route("CustomStudent")]
        public IHttpActionResult GetStudentUsingCustom(int id)
        {
            Student student = new Student();
            using (var context = new SchoolEntities())
            {
                student = context.Students.Where(s => s.StudentId == id).FirstOrDefault();
            }
            if (student == null)
            {
                return new App_Start.CustomResult("NOT FOUND", "NOT FOUND", Request, HttpStatusCode.NotFound);
            }
            return new CustomResult(student.FirstName,student.LastName, Request, HttpStatusCode.Found);
        }
    }
}
