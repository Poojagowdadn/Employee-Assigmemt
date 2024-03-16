using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Employee.Bussiness
{
    public class Employee
    {
        public static List<Employee.Data.Entities.Employee> All(string connName = "")
        {
            Repository.CompanyContext db = DbConnect.GetDb(string.Empty);
            var result = db.EmployeeSet.ToList() != null ? db.EmployeeSet.OrderByDescending(c => c.ID).AsQueryable().ToList() : throw new Exception("The List is Empty");

        }

        public static Employee.Data.ViewModels.Employee Addupdate(Employee.Data.ViewModels.Employee record)
        {
            {
                if (record != null)
                {
                    Repository.CompanyContext db = DbConnect.GetDb(record.ConnName);
                    if (record.ID == 0) //Add
                    {
                        var recX = db.EmployeeSet.Where(c => c.ID == record.ID).AsQueryable().FirstOrDefault();
                        if (recX != null)
                            throw new Exception("Duplicate record found.");


                        var rec = record.ToEntity;

                        db.EmployeeSet.Add(rec);
                        db.Commit();
                        record = Employee.Data.ViewModels.Employee.FromEntity(rec);

                    }
                    else //Update
                    {
                        var recX = db.EmployeeSet.Where(c => c.firstName == record.firstName && c.ID != record.ID).AsQueryable().FirstOrDefault();
                        var old = db.EmployeeSet.Where(c => c.ID == record.ID).AsQueryable().FirstOrDefault();
                        if (old != null)
                        {
                            db.Entry(old).State = System.Data.Entity.EntityState.Detached;
                            var rec = record.ToEntity;
                            db.Entry(rec).State = System.Data.Entity.EntityState.Modified;
                            db.Commit();
                            record = Employee.Data.ViewModels.Employee.FromEntity(rec);

                        }
                    }
                }
                return record;
            }
        }

        public static void Delete(int Id, string connName = "")
        {
            if (Id == 0)
                throw new Exception("Invalid ID to delete Item record.");
            Repository.CompanyContext db = DbConnect.GetDb(connName);
            var old = db.EmployeeSet.Where(c => c.ID == Id).AsQueryable().FirstOrDefault();
            if (old != null)
            {
                db.Entry(old).State = System.Data.Entity.EntityState.Deleted;
                db.Commit();
            }
            else
                throw new Exception(string.Format("There is no such record to delete."));
        }


        public static ViewModels.Employee Get(int id)
        {
            Employee.Data.ViewModels.Guage.Employee record = new Employee.Data.ViewModels.Guage.Employee();
            if (id > 0)
            {
                Repository.CompanyContext db = DbConnect.GetDb(string.Empty);
                var rec = db.EmployeeSet.Where(c => c.ID == id).AsQueryable().FirstOrDefault();
                if (rec != null && rec.ID == id)
                {
                    record = Employee.Data.ViewModels.Employee.FromEntity(rec);
                }

            }
            return record;
        }
    }
}