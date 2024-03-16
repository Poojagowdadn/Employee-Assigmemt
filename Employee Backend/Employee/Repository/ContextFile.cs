using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Employee.Repository
{
    public class ContextFile
    {

        public DbSet<Employee> EmployeeSet { get; set; }


        modelBuilder.Configurations.Add(new EmployeeConfig());
    }
}