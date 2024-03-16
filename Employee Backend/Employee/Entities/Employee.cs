using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Employee.Entities
{
    public class Employee:IEntityBase
    {
        public int ID { get; set; }
        public string Code { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string Email { get; set; }
        public double MobileNumber { get; set; }
        public string city { get; set; }
    }
}