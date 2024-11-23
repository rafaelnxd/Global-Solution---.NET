namespace GlobalSolution.DTOs.Dispositivo
{
    public class DispositivoReadDTO
    {
        public int Id { get; set; }
        public string NomeDispositivo { get; set; }
        public string TipoDispositivo { get; set; }
        public string Localizacao { get; set; }
        public int UsuarioId { get; set; }
    }
}
