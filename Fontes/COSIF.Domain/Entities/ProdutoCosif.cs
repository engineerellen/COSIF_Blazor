using System.ComponentModel.DataAnnotations;

namespace COSIF.Domain.Entities
{
    public class ProdutoCosif
    {
        [Required, StringLength(11)]
        public string CodCosif { get; set; }


        [Required, StringLength(4)]
        public string CodProduto { get; set; }


        [Required, StringLength(6)]
        public string CodClassificacao { get; set; }


        [Required, RegularExpression("[AI]")]
        public string StaStatus { get; set; }
    }
}