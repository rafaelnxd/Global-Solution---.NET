using System;

namespace GlobalSolution.DTOs.Usuario
{
    public class UsuarioReadDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string TipoConta { get; set; }
        public DateTime DataRegistro { get; set; }
    }
}
