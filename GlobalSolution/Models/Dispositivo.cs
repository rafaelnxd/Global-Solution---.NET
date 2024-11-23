using GlobalSolution.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GlobalSolution.Models
{
    [Table("DISPOSITIVOS")]
    public class Dispositivo
    {
        [Key]
        [Column("ID_DISPOSITIVO")]
        public int Id { get; set; }

        [Required]
        [Column("NOME_DISPOSITIVO")]
        [StringLength(100)]
        public string NomeDispositivo { get; set; }

        [Required]
        [Column("TIPO_DISPOSITIVO")]
        [StringLength(50)]
        public string TipoDispositivo { get; set; }

        [Column("LOCALIZACAO")]
        [StringLength(100)]
        public string Localizacao { get; set; }

        [ForeignKey("Usuario")]
        [Column("ID_USUARIO")]
        public int UsuarioId { get; set; }

        public Usuario Usuario { get; set; }

        // Navigation Properties
        public ICollection<ConsumoEnergia> ConsumosEnergia { get; set; }
        public ICollection<ConfiguracaoAutomacao> ConfiguracoesAutomacao { get; set; }
    }
}
