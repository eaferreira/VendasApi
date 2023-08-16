using System;
using VendasApi.Models;
using VendasApi.Repositories;

namespace VendasApi.Services
{
    public class EmployeeService
    {
        protected readonly EmployeeRepository _repository;
        public EmployeeService()
        {
            _repository = new EmployeeRepository();
        }
        public Result GetAll()
        {
            return _repository.GetAll();
        }
    }
}
