using System.ComponentModel.DataAnnotations;

namespace GlobalSolution.DTOs.AlertaNotificacao
{
    public class AlertaNotificacaoCreateDTO
    {
        [Required]
        public int UsuarioId { get; set; }

        [Required]
        [StringLength(100)]
        public string TipoAlerta { get; set; }

        [StringLength(500)]
        public string Mensagem { get; set; }
    }
}
