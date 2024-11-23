using System.ComponentModel.DataAnnotations;

namespace GlobalSolution.DTOs.Usuario
{
    public class UsuarioUpdateDTO
    {
        [Required]
        [StringLength(100)]
        public string Nome { get; set; }

        [Required]
        [StringLength(100)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(50)]
        public string TipoConta { get; set; }
    }
}
