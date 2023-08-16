using System;
using VendasApi.Models;
using VendasApi.Utils;

namespace VendasApi.Repositories
{
    public class ProductRepository
    {
        public Result GetAll()
        {
            if (DataCache.Products is null || DataCache.Products.Values.Count == 0)
                return new Result();

            return new Result(DataCache.Products.Values);
        }

        public Result GetCategories()
        {
            if(DataCache.Categories is null || DataCache.Categories.Values.Count == 0)
                return new Result();

            return new Result(DataCache.Categories.Values);
        }
    }
}
