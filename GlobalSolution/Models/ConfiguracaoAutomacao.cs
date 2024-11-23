using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace GlobalSolution.Models
{
    [Table("CONFIGURACOES_AUTOMACAO")]
    public class ConfiguracaoAutomacao
    {
        [Key]
        [Column("ID_CONFIGURACAO")]
        public int Id { get; set; }

        [ForeignKey("Usuario")]
        [Column("ID_USUARIO")]
        public int UsuarioId { get; set; }

        [ForeignKey("Dispositivo")]
        [Column("ID_DISPOSITIVO")]
        public int DispositivoId { get; set; }

        [Required]
        [Column("CONDICAO_ATIVACAO")]
        [StringLength(200)]
        public string CondicaoAtivacao { get; set; }

        [Column("ACAO")]
        [StringLength(50)]
        public string Acao { get; set; }

        [Column("DATA_CRIACAO")]
        public DateTime DataCriacao { get; set; } = DateTime.Now;

        [JsonIgnore]
        public Usuario Usuario { get; set; }

        [JsonIgnore]
        public Dispositivo Dispositivo { get; set; }
    }
}
