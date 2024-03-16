using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;

namespace Employee.Controllers
{
    public class EmployeeController 
    {
        // GET: Employee
       


        [HttpPost]
        public IHttpActionResult addUpdateEmployee(Employee.Data.ViewModels.Employee record)
        {
            try
            {
                var result = Employee.Data.Business.Employee.Addupdate(record);
                return Ok(result);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "addUpdateEmployee", record.AppUserId);
                return BadRequest(ex.Message);
            }

        }


        [HttpGet]
        public IHttpActionResult AllEmployeeList()
        {
            try
            {
                var result = Employee.Data.Business.Employee.All();
                return Ok(result);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "AllEmployeeList");
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete]
        public IHttpActionResult EmployeeRecordDelete(int id)
        {
            try
            {
                Employee.Data.Business.Employee.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "EmployeeRecordDelete");
                return BadRequest(ex.Message);
            }

        }

        [HttpGet]
        public IHttpActionResult EmployeeRecordGet(int id)
        {
            try
            {
                var rec = Employee.Data.Business.Employee.Get(id);
                return Ok(rec);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "EmployeeRecordGet");
                return BadRequest(ex.Message);
            }
        }


    }
}