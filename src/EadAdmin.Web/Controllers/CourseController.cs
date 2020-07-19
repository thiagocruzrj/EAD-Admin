using EadAdmin.Domain.Courses;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace EadAdmin.Web.Controllers
{
    public class CourseController : Controller
    {
        public IActionResult Index()
        {
            var courses = new List<CourseDto>();
        }
    }
}
