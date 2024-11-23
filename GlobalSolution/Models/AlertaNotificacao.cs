using GlobalSolution.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GlobalSolution.Models
{
    [Table("ALERTAS_NOTIFICACOES")]
    public class AlertaNotificacao
    {
        [Key]
        [Column("ID_ALERTA")]
        public int Id { get; set; }

        [ForeignKey("Usuario")]
        [Column("ID_USUARIO")]
        public int UsuarioId { get; set; }

        [Required]
        [Column("TIPO_ALERTA")]
        [StringLength(100)]
        public string TipoAlerta { get; set; }

        [Column("MENSAGEM")]
        [StringLength(500)]
        public string Mensagem { get; set; }

        [Required]
        [Column("DATA_HORA")]
        public DateTime DataHora { get; set; } = DateTime.Now;

        public Usuario Usuario { get; set; }
    }
}
