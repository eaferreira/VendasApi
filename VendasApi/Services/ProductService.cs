using System;
using VendasApi.Models;
using VendasApi.Repositories;
using VendasApi.Utils;

namespace VendasApi.Services
{
    public class ProductService
    {
        protected readonly ProductRepository _repository;
        public ProductService()
        {
            _repository = new ProductRepository();
        }
        public Result GetAll()
        {
            return _repository.GetAll();
        }

        public Result GetCategories()
        {
            return _repository.GetCategories();
        }
    }
}