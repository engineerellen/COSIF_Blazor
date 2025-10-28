using System.ComponentModel.DataAnnotations;

namespace COSIF.Domain.Entities
{
    public class MovimentoManual
    {
        [Range(1,12)]
        public byte DatMes { get; set; }

        [Range(1900, 9999)]
        public short DatAno { get; set; }

        public long NumLancamento { get; set; }

        [Required, StringLength(4, MinimumLength = 4)]
        public string CodProduto { get; set; } = null!;

        [Required, StringLength(11)]
        public string CodCosif { get; set; } = null!;

        [Required]
        public decimal ValValor { get; set; }

        [Required, StringLength(50)]
        public string DesDescricao { get; set; } = null!;

        public DateTime DatMovimento { get; set; }

        [Required, StringLength(15)]
        public string CodUsuario { get; set; } = null!;

        public string? DesProduto { get; set; }
    }
}