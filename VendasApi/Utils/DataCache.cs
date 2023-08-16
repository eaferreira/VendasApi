using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Runtime.CompilerServices;
using VendasApi.Entities;
using VendasApi.Models;

namespace VendasApi.Utils
{
    public static class DataCache
    {
        public static ConcurrentDictionary<int, Sales> Sales { get; set; }
        public static ConcurrentDictionary<int, Product> Products { get; set; }
        public static ConcurrentDictionary<int, Category> Categories { get; set; }
        public static ConcurrentDictionary<int, Employee> Employees { get; set; }


        static DataCache()
        {
            Sales = new ConcurrentDictionary<int, Sales>();
            InitializeCategory();
            InitializeProduts();
            InitializeEmployee();
        }

        private static void InitializeEmployee()
        {
            Employees = new ConcurrentDictionary<int, Employee>()
            {
                [1] = new Employee()
                {
                    Id = 1,
                    Name = "Joaquim da Silva",
                    DocumentNumber = "12345678900"
                },
                [2] = new Employee()
                {
                    Id = 2,
                    Name = "Manoel Barbosa",
                    DocumentNumber = "00987654321"
                }
            };
        }

        private static void InitializeCategory()
        {
            if(Categories is null)
                Categories = new ConcurrentDictionary<int, Category>();

            foreach (var category in Enum.GetValues<ProductCategory>())
            {
                int key = category.GetId();
                Categories.TryAdd(key, new Category()
                {
                    Id = key,
                    Name = category.GetDescription()
                });
            }
        }

        private static void InitializeProduts()
        {
            Products = new ConcurrentDictionary<int, Product>()
            {
                [1] = new Product()
                {
                    Id = 1,
                    Name = "Robô Aspirador de Pó Smart 700",
                    CreatedDate = DateTime.Now,
                    Description = "O Robô Aspirador de Pó Smart 700 é equipado com Filtros de Alta Eficiência (HEPA), " +
                    "que é recomendado para alérgenos de mofo, poeira e ácaros. Além disso, é extremamente silencioso e causa pouquíssimos ruídos.",
                    Price = 1349.90,
                    Quantity = 188,
                    Category = Categories.TryGetValue(ProductCategory.Electronics.GetId(), out var value1) ? value1 : null
                },
                [2] = new Product()
                {
                    Id = 2,
                    Name = "Os meninos que enganavam nazistas",
                    CreatedDate = DateTime.Now,
                    Description = "Os meninos que enganavam nazistas conta a fantástica e emocionante epopeia de duas crianças " +
                    "judias durante a ocupação, narrada por Joseph, o mais jovem.",
                    Price = 29.12,
                    Quantity = 50,
                    Category = Categories.TryGetValue(ProductCategory.Books.GetId(), out var value2) ? value2 : null
                },
                [3] = new Product()
                {
                    Id = 3,
                    Name = "Detroit: Become Human",
                    CreatedDate = DateTime.Now,
                    Description = "Detroit: Become Human coloca o destino da humanidade e dos androides em suas mãos. " +
                    "Todas as suas escolhas afetam o resultado do jogo, com uma das narrativas mais intrinsecamente ramificadas já criadas.",
                    Price = 134.99,
                    Quantity = 250,
                    Category = Categories.TryGetValue(ProductCategory.Games.GetId(), out var value3) ? value3 : null
                }
            };
        }
    }
}
