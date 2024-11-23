using System.ComponentModel.DataAnnotations;

namespace GlobalSolution.DTOs.Dispositivo
{
    public class DispositivoUpdateDTO
    {
        [Required]
        [StringLength(100)]
        public string NomeDispositivo { get; set; }

        [Required]
        [StringLength(50)]
        public string TipoDispositivo { get; set; }

        [StringLength(100)]
        public string Localizacao { get; set; }

        [Required]
        public int UsuarioId { get; set; }
    }
}
