using System;

namespace GlobalSolution.DTOs.ConfiguracaoAutomacao
{
    public class ConfiguracaoAutomacaoReadDTO
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public int DispositivoId { get; set; }
        public string CondicaoAtivacao { get; set; }
        public string Acao { get; set; }
        public DateTime DataCriacao { get; set; }
    }
}
