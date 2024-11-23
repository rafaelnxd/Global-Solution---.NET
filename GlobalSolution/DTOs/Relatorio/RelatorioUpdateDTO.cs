using System.ComponentModel.DataAnnotations;

namespace GlobalSolution.DTOs.Relatorio
{
    public class RelatorioUpdateDTO
    {
        [Required]
        public int UsuarioId { get; set; }

        [Required]
        [StringLength(50)]
        public string TipoRelatorio { get; set; }

        [StringLength(1000)]
        public string ResumoConsumo { get; set; }
    }
}
