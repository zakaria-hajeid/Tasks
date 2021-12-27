using System;
using System.Collections.Generic;
using System.Text;
using Task.percestance.DataContext;
using Task.percestance.Models;
using Task.percestance.Abstractions;
using AutoMapper;
using System.Threading.Tasks;
using Task.Application.Dtos;
using System.Linq;
using System.Text.RegularExpressions;

namespace Task.Application.Service
{
  public  class EmployeeServecis
    {
        private readonly DataContext _context;
        private readonly IEmployee _repo;
        private readonly ICountry _Countryrepo;
        private readonly IDepartement _Departementrepo;
        private readonly IMapper _mapper;

        public EmployeeServecis(DataContext context, IEmployee repo, IMapper mapper, ICountry Countryrepo, IDepartement Departementrepo)
        {
            _context = context;
            _repo = repo;
            _mapper = mapper;
            _Countryrepo = Countryrepo;
            _Departementrepo = Departementrepo;

        }

        public async Task<List<EmployeeSimpleDto>> GetListEmployees()
        {
           
                var Employees = await _repo.GetAll();

                var ListEmployees = _mapper.Map<List<EmployeeSimpleDto>>(Employees);
                return ListEmployees;
           
           
        }

        public async Task<EmployeeFullDetailsDto> GetEmployeeById(int id)
        {
            var EmployeeDetails = await _repo.GetById(id);

            var ListEmployeesToReturn = _mapper.Map<EmployeeFullDetailsDto>(EmployeeDetails);
            return ListEmployeesToReturn;
        }
        public async Task<RequestState> AddEmployee(EmployeeAddRequest employeeAddRequest)
        {

            
            var departement = await _Departementrepo.GetById(employeeAddRequest.DepartmentID);
            var country = await _Countryrepo.GetById(employeeAddRequest.country);

            if (departement == null)
            {
                return RequestState.DepartementIdNotfound;

            }
            if (country == null)
            {
                return RequestState.CountryIdNotFOUND;

            }
            Employee EmployeeAdd = new Employee()
            {
                Salary = employeeAddRequest.Salary,
                FullName = employeeAddRequest.PhoneNumber,
                country = employeeAddRequest.country,
                DepartmentID = employeeAddRequest.DepartmentID,
                PhoneNumber = employeeAddRequest.PhoneNumber
            };
            await _repo.Add(EmployeeAdd);

             await _repo.save();
            return RequestState.sucsses;
        }

        public async Task<RequestState> EditEmployee(int id,EmployeeAddRequest employeeEditRequest)
        {
            var departement = await _Departementrepo.GetById(employeeEditRequest.DepartmentID);
            var country = await _Countryrepo.GetById(employeeEditRequest.country);

            if (departement == null)
            {
                return RequestState.DepartementIdNotfound;

            }
            if ( country == null)
            {
                return RequestState.CountryIdNotFOUND;

            }
            var EmployeeToEdit = await _repo.GetById(id);
            if (EmployeeToEdit != null)
            {

                EmployeeToEdit.Salary = employeeEditRequest.Salary;
                EmployeeToEdit.FullName = employeeEditRequest.FullName;
                EmployeeToEdit.country = employeeEditRequest.country;
                EmployeeToEdit.DepartmentID = employeeEditRequest.DepartmentID;
                EmployeeToEdit.PhoneNumber = employeeEditRequest.PhoneNumber;




                _repo.Update(EmployeeToEdit);

                 await _repo.save();
                return RequestState.sucsses;
            }
            else
                return RequestState.NotFoundUser;


        }

        public async Task<RequestState> DeleteEmployee(int id)
        {

            var EmployeeToSelete = await _repo.GetById(id);
            if (EmployeeToSelete != null)
            {
                _repo.Delete(EmployeeToSelete.Id);

                 await _repo.save();
                return RequestState.sucsses;

            }
            else
            {
                return RequestState.NotFoundUser;

            }

        }

        public bool IsValidateUserName(EmployeeAddRequest model)
        {
            Regex emailValid = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Regex PhonelValid = new Regex("^[0-9]+$");
            bool phoneValid = false;
            bool emailvalid = false;
            if (PhonelValid.IsMatch(model.FullName))
            {
                if (model.FullName.Length >= 6 && model.FullName.Length <= 12)
                    phoneValid = true;
            }

            if (emailValid.IsMatch(model.FullName))
            {
                emailvalid = true;

            }
            if (phoneValid || emailvalid)
                return true;
            else
                return false;

        }








    }
}
