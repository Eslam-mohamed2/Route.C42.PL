using Data_Access_Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_Business_Logic_Layer_.Interfaces
{
    internal interface IDepartmentRepository
    {
        IEnumerable<Department> GetAll();
        Department Get(int id);
        int Add(Department entity);
        int Update(Department entity);
        int Delete (Department entity);
    }
}
