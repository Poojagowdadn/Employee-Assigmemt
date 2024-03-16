using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Employee.Models
{
    public class Employee:Baseparam
    {
        public int ID { get; set; }
        public string Code { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string Email { get; set; }
        public double MobileNumber { get; set; }
        public string city { get; set; }
        public Employee.Data.Entities.Employee ToEntity
        {
            get
            {
                return new Employee.Data.Entities.Employee
                {
                    ID = ID,
                    Code = Code,
                    firstName = firstName,
                    lastName = lastName,
                    Email = Email,
                    MobileNumber = MobileNumber,
                    city = city,

                };
            }
        }
        public static Employee.Data.ViewModels.Employee FromEntity(Employee.Data.Entities.Employee record)
        {
            return new Employee.Data.ViewModels.Employee
            {
                ID = record.ID,
                Code = record.Code,
                firstName = record.firstName,
                lastName = record.lastName,
                Email = record.Email,
                MobileNumber = record.MobileNumber,
                city = record.city,
            };
        }
    }
}