using System;
using VendasApi.Models;
using VendasApi.Utils;

namespace VendasApi.Repositories
{
    public class EmployeeRepository
    {
        public Result GetAll()
        {
            if (DataCache.Employees is null || DataCache.Employees.Count == 0)
                return new Result();

            return new Result(DataCache.Employees.Values);
        }
    }
}
