using System;
using System.Linq;
using VendasApi.Entities;
using VendasApi.Models;
using VendasApi.Repositories;
using VendasApi.Utils;

namespace VendasApi.Services
{
    public class SalesService
    {
        protected readonly SalesRepository _repository;
        public SalesService()
        {
            _repository = new SalesRepository();
        }
        public Result GetById(int id)
        {
            return _repository.GetById(id);
        }
        public Result Add(Sales sales)
        {
            if (!sales.Items.IsNullOrEmpty())
            {
                if (sales.Employee is null || sales.Employee.Id == 0)
                    return new Result("Não foi possível validar vendedor. Verifique a lista de vendedores realizando 'GET Employee', id é o único dado obrigatório");

                foreach (var item in sales.Items)
                {
                    if (item.Id == 0)
                        return new Result($"Não foi possível validar produto {item.Name}. Verifique a lista de Produtos realizando 'GET Products', id é o único dado obrigatório");

                    if (item.Quantity == 0)
                        return new Result($"Verifique quantidade produto {item.Name}");

                    _repository.UpdateItem(item);
                    _repository.SubtractQuantity(item.Id, item.Quantity);
                }

                _repository.UpdateEmployee(sales.Employee);
                sales.TotalAmount = sales.Items.Sum(x => x.Price * x.Quantity);
                sales.PaymentStatus = Utils.PaymentStatus.Pending;

                return _repository.Add(sales);
            }
            else
            {
                return new Result("Não foi possível validar a venda. Por favor, verifique os itens.");
            }
        }

        public Result UpdateStatus(Sales sales)
        {
            var result = _repository.GetById(sales.Id);

            if (result.IsError || result.Value is null)
                return result;

            bool authorized = false;
            var valueStatus = (result.Value as Sales).PaymentStatus;
            switch (valueStatus)
            {
                case Utils.PaymentStatus.Approved:
                    authorized = new[] { Utils.PaymentStatus.Shipped, Utils.PaymentStatus.Canceled }.Contains(sales.PaymentStatus);
                    break;
                case Utils.PaymentStatus.Pending:
                    authorized = new[] {     Utils.PaymentStatus.Approved, Utils.PaymentStatus.Canceled }.Contains(sales.PaymentStatus);
                    break;
                case Utils.PaymentStatus.Shipped:
                    authorized = sales.PaymentStatus.Equals(Utils.PaymentStatus.Delivered);
                    break;
            }

            if(authorized)
            {
                return _repository.UpdateStatus(sales.Id, sales.PaymentStatus);
            }
            else
            {
                return new Result($"Não é possível alterar o status de {valueStatus.GetDescription()} para {sales.PaymentStatus.GetDescription()}. " +
                    $"Verifique as regras:{Environment.NewLine}" +
                    $"De pendente para aprovado ou cancelado;{Environment.NewLine}" +
                    $"De aprovado para enviado ou cancelado;{Environment.NewLine}" +
                    $"De enviado para entregue.{Environment.NewLine}{Environment.NewLine}" +
                    $"Status: 0 - Aprovado; 1 - Aguardando; 2 - Enviado; 3 - Entregue; 4 - Cancelado");
            }
        }

        public Result GetAll()
        {
            return _repository.GetAll();
        }

        public Result GetPaymentStatus()
        {
            return _repository.GetPaymentStatus();
        }
    }
}
