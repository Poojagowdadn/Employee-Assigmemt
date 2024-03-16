using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Employee.Configuration
{
    public class Employee
    {
        public class EmployeeConfig : EntityBaseConfiguration<Entities.Employee>
        {
            public EmployeeConfig()
            {
                Property(c => c.Code).IsOptional();
                Property(c => c.firstName).IsOptional();
                Property(c => c.lastName).IsOptional();
                Property(c => c.Email).IsOptional();
                Property(c => c.MobileNumber).IsOptional();
                Property(c => c.city).IsOptional();


            }
        }
    }
}