using System.ComponentModel.DataAnnotations;

namespace COSIF.Domain.Entities
{
    public class Produto
    {
        [Required, StringLength(4)]
        public string CodProduto { get; set; }

        [Required, StringLength(30)]
        public string DesProduto { get; set; }

        [Required, RegularExpression("[AI]")]
        public string StaStatus { get; set; }
    }
}