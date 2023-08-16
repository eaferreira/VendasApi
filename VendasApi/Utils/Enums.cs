using System.ComponentModel;

namespace VendasApi.Utils
{
    public enum PaymentStatus 
    {
        [Description("Aprovado")]
        Approved,

        [Description("Aguardando")]
        Pending,

        [Description("Enviado")]
        Shipped,

        [Description("Entregue")]
        Delivered,

        [Description("Cancelado")]
        Canceled
    }
    public enum ProductCategory
    {
        [Description("Eletrônicos")]
        Electronics = 1,

        [Description("Alimentos")]
        Food,

        [Description("Livros")]
        Books,

        [Description("Automotivo")]
        Automotive,

        [Description("Esportes")]
        Sports,

        [Description("Jogos")]
        Games
    }

}
