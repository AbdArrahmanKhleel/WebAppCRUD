using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAppCRUD.Data;
using WebAppCRUD.Models;

namespace WebAppCRUD.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly DbCtxCRUD _context;

        public EmployeeController(DbCtxCRUD context)
        {
            _context = context;
        }
        public IActionResult Index()
        {

            return View(_context.Employees.Include(x=>x.Department).OrderBy(x=>x.EmployeeName).ToList());
        }

        public IActionResult Create()
        {
            ViewBag.Departments=_context.Departments.OrderBy(x=>x.DepartmentName).ToList();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Employee model)
        {
            UploadImg(model);

            if (ModelState.IsValid)
            {
                _context.Employees.Add(model);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        

        public IActionResult Edit(int id)
        {
            ViewBag.Departments = _context.Departments.OrderBy(x => x.DepartmentName).ToList();

            var Reuslt = _context.Employees.Find(id);
            return View("Create",Reuslt);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Employee model)
        {
            UploadImg(model);

            if (!ModelState.IsValid)
            {
            ViewBag.Departments = _context.Departments.OrderBy(x => x.DepartmentName).ToList();
            return View(model);
            }
            else
            {
                _context.Employees.Update(model);
                _context.SaveChanges();
               return RedirectToAction(nameof(Index));
            }


        }

        public IActionResult Delete(int? id)
        {
            var Reuslt = _context.Employees.Find(id);
            if(Reuslt != null)
            {
                _context.Employees.Remove(Reuslt);
                _context.SaveChanges();
                
            }
            return RedirectToAction(nameof(Index));
        }
        private void UploadImg(Employee model)
        {
            var file = HttpContext.Request.Form.Files;
            if (file.Count() > 0)
            {//@"wwwroot/"
                /// upload img
                string ImageName = Guid.NewGuid().ToString() + Path.GetExtension(file[0].FileName);
                var filestream = new FileStream(Path.Combine(@"wwwroot/", "imgs", ImageName), FileMode.Create);
                file[0].CopyTo(filestream);
                model.ImgUser = ImageName;
            }
            else if (model.ImgUser == null && model.EmployeeId == null)
            {
                // not upload img and creat new employee
                model.ImgUser = "images.jpg";
            }
            else
            {
                //edit
                model.ImgUser = model.ImgUser;
            }
        }
    }
}
