namespace Practica_Final.Resultado
{
    public class ResultadoBase
    {
        public int StatusCode { get; set; }
        public bool Ok { get; set; }
        public string? Error { get; set; }
        public string? MensajeInfo { get; set; }
        public object? Resultado { get; set; }
    }
}
