using BLL_Business_Logic_Layer_.Interfaces;
using Data_Access_Layer.Data;
using Data_Access_Layer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_Business_Logic_Layer_.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly ApplicationDbContext _DbContext;

        public DepartmentRepository(ApplicationDbContext dbContext) // Ask CLR for Crearting Oject from al Application DbContext
        {
            _DbContext = dbContext;
        }

        public int Add(Department entity)
        {
            _DbContext.Departments.Add(entity);
            return _DbContext.SaveChanges();
        }

        public int Delete(Department entity)
        {
            _DbContext.Departments.Remove(entity);
            return _DbContext.SaveChanges();
        }

        public Department Get(int id)
        {
            //return _DbContext.Departments.Find(id);
            return _DbContext.Find<Department>(id); // EF Core 3.1 New Feature
            ///var Department = _DbContext.Departments.Local.Where(D => D.Id == id).FirstOrDefault();
            ///if (Department == null)
            ///    _DbContext.Departments.Where(D => D.Id == id).FirstOrDefault();
            ///return Department;
        }

        public IEnumerable<Department> GetAll()
        {
            return _DbContext.Departments.AsNoTracking().ToList()
;        }

        public int Update(Department entity)
        {
            _DbContext.Departments.Update(entity);
            return _DbContext.SaveChanges();
        }
    }
}
