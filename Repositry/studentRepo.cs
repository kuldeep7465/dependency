using dependecy.infratecture;
using dependecy.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dependecy.Repositry
{
    public class studentRepo : Istudent
    {
        private readonly EmployeeContext _db;

        public studentRepo(EmployeeContext logger)
        {
            _db = logger;
        }
        public List<Employee> GetAll()
        {

            return _db.Employees.ToList();
        }

        public Employee GEtById(int Id)
        {
            return _db.Employees.FirstOrDefault(x => x.Id == Id);
        }
        public void Add(Employee Emp)
        {
            _db.Employees.Add(Emp);
            _db.SaveChanges();
        }
        public void Delete(int Id)
        {
            var d= _db.Employees.FirstOrDefault(x => x.Id == Id);
            _db.Employees.Remove(d);
            _db.SaveChanges();
           
        }

    }
}
