using System.ComponentModel.DataAnnotations;

namespace GlobalSolution.DTOs.ConsumoEnergia
{
    public class ConsumoEnergiaCreateDTO
    {
        [Required]
        public int DispositivoId { get; set; }

        [Required]
        [StringLength(50)]
        public string ConsumoEnergiaKwh { get; set; }

        [StringLength(50)]
        public string Status { get; set; }
    }
}
