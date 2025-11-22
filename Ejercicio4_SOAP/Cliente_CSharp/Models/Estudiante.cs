using System;

namespace ClienteSEDUINFO.Models
{
    public class DatosAcademicos
    {
        public string CI { get; set; } = string.Empty;
        public string Nombres { get; set; } = string.Empty;
        public string Apellidos { get; set; } = string.Empty;
        public string Carrera { get; set; } = string.Empty;
        public int Semestre { get; set; }
        public double Promedio { get; set; }
    }
    public class DatosTutor
    {
        public string NombresEstudiante { get; set; } = string.Empty;
        public string TutorAsignado { get; set; } = string.Empty;
        public string CorreoTutor { get; set; } = string.Empty;
        public string TelefonoTutor { get; set; } = string.Empty;
    }
}
