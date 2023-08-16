using System;
using System.Collections.Generic;
using System.Linq;
using VendasApi.Entities;
using VendasApi.Models;
using VendasApi.Utils;

namespace VendasApi.Repositories
{
    public class SalesRepository
    {
        public Result GetById(int id)
        {
            if (DataCache.Sales is null)
                return new Result("Não existe venda realizada.");

            if(DataCache.Sales.TryGetValue(id, out var value))
            {
                return new Result(value);
            }
            else
            {
                return new Result("Registro não encontrado!");
            }
        }

        public Result GetAll()
        {
            if (DataCache.Sales is null || DataCache.Sales.Values.Count == 0)
                return new Result();

            return new Result(DataCache.Sales.Values);
        }

        public Result Add(Sales sales)
        {
            sales.Id = DataCache.Sales.Values.Count + 1;
            DataCache.Sales.TryAdd(sales.Id, sales);
            return new Result(sales);            
        }

        public Result UpdateStatus(int id, Utils.PaymentStatus paymentStatus)
        {
            if (DataCache.Sales.TryGetValue(id, out var value))
            {
                var newValue = value;
                newValue.PaymentStatus = paymentStatus;
                DataCache.Sales.TryUpdate(id, newValue, value);
                return new Result(newValue);
            }
            else
            {
                return new Result("Registro não encontrado!");
            }
        }

        public Employee GetEmployee(int id)
        {
            DataCache.Employees.TryGetValue(id, out var value);
            return value;
        }

        public void SubtractQuantity(int id, int quantity)
        {
            DataCache.Products[id].Quantity -= quantity;
        }

        public void UpdateItem(SalesItems item)
        {
            if(DataCache.Products.TryGetValue(item.Id, out var value))
            {
                item.Price = value.Price;
                item.Name = value.Name;
            }
        }

        public void UpdateEmployee(Employee employee)
        {
            if (DataCache.Employees.TryGetValue(employee.Id, out var value))
            {
                employee.Name = employee.Name ?? value.Name;
                employee.DocumentNumber = employee.DocumentNumber ?? value.DocumentNumber;
            }
        }

        public Result GetPaymentStatus()
        {
            List<Models.PaymentStatus> payments = new List<Models.PaymentStatus>();
            foreach (var status in Enum.GetValues<Utils.PaymentStatus>())
            {
                payments.Add(new Models.PaymentStatus()
                {
                    Id = status.GetId(),
                    Name = status.GetDescription()
                });
            }

            return new Result(payments);
        }
    }
}
