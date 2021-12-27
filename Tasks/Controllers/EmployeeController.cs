using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task.Application.Dtos;
using Task.Application.Service;

namespace Tasks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class EmployeeController : ControllerBase
    {

        private readonly EmployeeServecis _EmployeeServecis;

        public EmployeeController(EmployeeServecis EmployeeServecis)
        {
            _EmployeeServecis = EmployeeServecis;
        }

        [HttpGet]
        
        public async Task<IActionResult> GetEmployees()
        {
            try
            {
                var Employees = await _EmployeeServecis.GetListEmployees();
                return Ok(new CJsonObject<List<EmployeeSimpleDto>>(Employees));

            }
            catch (Exception ex)
            {
                return Ok(new CJsonObject<bool>(false, ex.Message));

            }

        }
       [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            try
            {
                var EmployeeoReturn = await _EmployeeServecis.GetEmployeeById(id);
                return Ok(new CJsonObject<EmployeeFullDetailsDto>(EmployeeoReturn));
            }
            catch (Exception ex)
            {
                return Ok(new CJsonObject<bool>(false, ex.Message));

            }

        }

        [HttpPost("AddEmployee")]
        public async Task<IActionResult> AddEmployee(EmployeeAddRequest employeeAddRequest)
        {

            try
            {
                if (!ModelState.IsValid)
                {
                    return Ok(new CJsonObject<bool>(false, "The Model Is not Valid"));

                }
                var isValidUserName = _EmployeeServecis.IsValidateUserName(employeeAddRequest);
                if (!isValidUserName)
                    return Ok(new CJsonObject<bool>(false, "The UserName  Is not Valid"));

                var AddEmployee = await _EmployeeServecis.AddEmployee(employeeAddRequest);
                if (AddEmployee == RequestState.DepartementIdNotfound)
                {
                    return Ok(new CJsonObject<bool>(false, "The departement id Is not Valid"));

                }
                if (AddEmployee == RequestState.CountryIdNotFOUND)
                {
                    return Ok(new CJsonObject<bool>(false, "The country id Is not Valid "));

                }

                return Ok(new CJsonObject<bool>(true,"Employee Added"));
            }
            catch(Exception ex)
            {
                return Ok(new CJsonObject<bool>(false, ex.Message));

            }



        }

        [HttpPut("EditEmployee")]
        public async Task<IActionResult> EditEmployee(int id,EmployeeAddRequest employeeAddRequest)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Ok(new CJsonObject<bool>(false, "The Model Is not Valid"));

                }
                var isValidUserName = _EmployeeServecis.IsValidateUserName(employeeAddRequest);
                if (!isValidUserName)
                    return Ok(new CJsonObject<bool>(false, "The UserName  Is not Valid"));


                var EditEmployee = await _EmployeeServecis.EditEmployee(id, employeeAddRequest);
                if (EditEmployee == RequestState.DepartementIdNotfound)
                {
                    return Ok(new CJsonObject<bool>(false, "The departement id Is not Valid"));

                }
                if (EditEmployee == RequestState.CountryIdNotFOUND)
                {
                    return Ok(new CJsonObject<bool>(false, "The country id Is not Valid "));

                }
                if (EditEmployee == RequestState.NotFoundUser)
                {
                    return Ok(new CJsonObject<bool>(false, "The user id Is not Valid "));

                }



                return Ok(new CJsonObject<bool>(true, "Employee Updated"));
            }
            catch(Exception ex)
            {
                return Ok(new CJsonObject<bool>(false, ex.Message));

            }



        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            try
            {
                var DeleteEmployee = await _EmployeeServecis.DeleteEmployee(id);
                if (DeleteEmployee == RequestState.NotFoundUser)
                {
                    return Ok(new CJsonObject<bool>(false, "The user id Is not Valid "));

                }

                return Ok(new CJsonObject<bool>(true, "Employee deleted"));
            }
            catch (Exception ex)
            {
                return Ok(new CJsonObject<bool>(false, ex.Message));

            }



        }




    }
}
