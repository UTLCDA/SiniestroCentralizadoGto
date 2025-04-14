namespace Siniestro.Servidor.Dtos
{
    public class AjustadorDto
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? ApellidoPaterno { get; set; }
        public string? ApellidoMaterno { get; set; }
        public string? Telefono { get; set; }
        public string? Correo { get; set; }
        public string NumeroEmpleado { get; set; } = null!;
        public string? Carro { get; set; }
        public string? Matricula { get; set; }
        public string? Estado { get; set; }

        public string? NombreCompleto { get; set; } 

    }
}
