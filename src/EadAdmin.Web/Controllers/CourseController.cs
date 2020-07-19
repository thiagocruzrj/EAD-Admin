using EadAdmin.Domain.Courses;
using EadAdmin.Web.Utils;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace EadAdmin.Web.Controllers
{
    public class CourseController : Controller
    {
        public IActionResult Index()
        {
            var courses = new List<CourseDto>();

            return View("Index", PaginatedList<CourseDto>.Create(courses, Request));
        }

        public IActionResult New()
        {
            return View("NowOrEdit", new CourseDto());
        }

        [HttpPost]
        public IActionResult Salvar(CourseDto model)
        {
            return Ok();
        }
    }
}