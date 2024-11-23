using System;

namespace GlobalSolution.DTOs.AlertaNotificacao
{
    public class AlertaNotificacaoReadDTO
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public string TipoAlerta { get; set; }
        public string Mensagem { get; set; }
        public DateTime DataHora { get; set; }
    }
}
