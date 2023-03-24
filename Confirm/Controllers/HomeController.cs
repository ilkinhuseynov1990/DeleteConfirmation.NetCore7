using Confirm.Data;
using Confirm.Response;
using Microsoft.AspNetCore.Mvc;

namespace Confirm.Controllers
{

    public class HomeController : Controller
    {
        private AppDbContext  _context;
        public HomeController(AppDbContext context)
        {
           _context = context; 
        }
        [HttpGet]
        public IActionResult Index()
        {
            var Students = _context.
                students.
                ToList();
            return View(Students);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteStudent(int studentId)
        {
            var student = _context.
                students.
                FirstOrDefault(s=> s.Id== studentId);

            if (student == null)
            {

                return Json(new ResponseModel { Message="Not  Found" , StatusCode=404});
            }
            _context.students.Remove(student);
            await _context.SaveChangesAsync();
            return Json(new ResponseModel { StatusCode = 200 , Message= "Student successfully deleted"}) ;
        }
    }
}
