using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GlobalSolution.Models
{
    [Table("USUARIO_TD")]
    public class Usuario
    {
        [Key]
        [Column("ID_USUARIO")]
        public int Id { get; set; }

        [Required]
        [Column("NOME")]
        [StringLength(100)]
        public string Nome { get; set; }

        [Required]
        [Column("EMAIL")]
        [StringLength(100)]
        public string Email { get; set; }

        [Required]
        [Column("TIPO_CONTA")]
        [StringLength(50)]
        public string TipoConta { get; set; }

        [Column("DATA_REGISTRO")]
        public DateTime DataRegistro { get; set; } = DateTime.Now;

        // Navigation Properties
        public ICollection<Dispositivo> Dispositivos { get; set; }
        public ICollection<AlertaNotificacao> AlertasNotificacoes { get; set; }
        public ICollection<Relatorio> Relatorios { get; set; }
    }
}
