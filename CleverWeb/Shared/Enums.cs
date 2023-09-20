using System.ComponentModel.DataAnnotations;

namespace CleverWeb.Shared
{
    public enum Enums
    {
       
    }

    public enum TipoProduto
    {
        [Display(Name = "Produto Venda")]
        ProdutoVenda,
        [Display(Name = "Produto Locação")]
        ProdutoLocacao,
        [Display(Name = "Matéria Prima")]
        MateriaPrima,
        [Display(Name = "Serviço")]
        Servico,
        Kit,
        Imobilizado
    }
}
