using System.ComponentModel.DataAnnotations;

namespace GlobalSolution.DTOs
{
    public class ConfiguracaoAutomacaoUpdateDTO
    {
        [Required]
        public int UsuarioId { get; set; }

        [Required]
        public int DispositivoId { get; set; }

        [Required]
        [StringLength(200)]
        public string CondicaoAtivacao { get; set; }

        [StringLength(50)]
        public string Acao { get; set; }
    }
}
