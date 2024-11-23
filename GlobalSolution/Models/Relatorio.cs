using GlobalSolution.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GlobalSolution.Models
{
    [Table("RELATORIOS")]
    public class Relatorio
    {
        [Key]
        [Column("ID_RELATORIO")]
        public int Id { get; set; }

        [ForeignKey("Usuario")]
        [Column("ID_USUARIO")]
        public int UsuarioId { get; set; }

        [Column("TIPO_RELATORIO")]
        [StringLength(50)]
        public string TipoRelatorio { get; set; }

        [Column("DATA_GERACAO")]
        public DateTime DataGeracao { get; set; } = DateTime.Now;

        [Column("RESUMO_CONSUMO")]
        [StringLength(1000)]
        public string ResumoConsumo { get; set; }

        public Usuario Usuario { get; set; }
    }
}
