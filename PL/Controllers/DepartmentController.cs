using BLL_Business_Logic_Layer_.Interfaces;
using BLL_Business_Logic_Layer_.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace PL.Controllers
{
    // Inhertiance : DepartmentController is a Controller 
    // Compoosition : DepartmentController has a DepartmentRepository 

    public class DepartmentController : Controller
    {
        private readonly IDepartmentRepository _departmentsRepo; // NUll
        //public IDepartmentRepository DepartmentRepo { get; }

        public DepartmentController(IDepartmentRepository departmentRepo)
        {
            _departmentsRepo = departmentRepo;
            //_departmentsRepo = /*new DepartmentRepository();*/
        }


        public IActionResult Index()
        {
            var departments = _departmentsRepo.GetAll();
            return View(departments);
        }
    }
}
