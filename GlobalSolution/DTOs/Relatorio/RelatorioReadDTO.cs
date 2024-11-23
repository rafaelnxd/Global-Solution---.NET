using System;

namespace GlobalSolution.DTOs.Relatorio
{
    public class RelatorioReadDTO
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public string TipoRelatorio { get; set; }
        public DateTime DataGeracao { get; set; }
        public string ResumoConsumo { get; set; }
    }
}
