using System;

namespace GlobalSolution.DTOs.ConsumoEnergia
{
    public class ConsumoEnergiaReadDTO
    {
        public int Id { get; set; }
        public int DispositivoId { get; set; }
        public DateTime DataHora { get; set; }
        public string ConsumoEnergiaKwh { get; set; }
        public string Status { get; set; }
    }
}
