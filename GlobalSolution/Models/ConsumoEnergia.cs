using GlobalSolution.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GlobalSolution.Models
{
    [Table("CONSUMO_ENERGIA")]
    public class ConsumoEnergia
    {
        [Key]
        [Column("ID_CONSUMO")]
        public int Id { get; set; }

        [ForeignKey("Dispositivo")]
        [Column("ID_DISPOSITIVO")]
        public int DispositivoId { get; set; }

        [Required]
        [Column("DATA_HORA")]
        public DateTime DataHora { get; set; } = DateTime.Now;

        [Required]
        [Column("CONSUMO_ENERGIA_KWH")]
        [StringLength(50)]
        public string ConsumoEnergiaKwh { get; set; }

        [Column("STATUS")]
        [StringLength(50)]
        public string Status { get; set; }

        public Dispositivo Dispositivo { get; set; }
    }
}
