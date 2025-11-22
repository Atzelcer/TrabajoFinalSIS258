using ServidorSOAP.Data;
using ServidorSOAP.Models;

namespace ServidorSOAP.Services
{
    public class SEDUINFOService : ISEDUINFOService
    {
        public DatosAcademicos? ObtenerDatosAcademicos(string ci)
        {
            Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] Solicitud: ObtenerDatosAcademicos(CI={ci})");

            if (string.IsNullOrWhiteSpace(ci))
            {
                Console.WriteLine("  [ERROR] CI vacío o nulo");
                return null;
            }

            var estudiante = EstudiantesRepository.BuscarPorCI(ci);

            if (estudiante == null)
            {
                Console.WriteLine($"  [WARN] Estudiante no encontrado");
                return null;
            }

            var datos = new DatosAcademicos
            {
                CI = estudiante.CI,
                Nombres = estudiante.Nombres,
                Apellidos = estudiante.Apellidos,
                Carrera = estudiante.Carrera,
                Semestre = estudiante.Semestre,
                Promedio = estudiante.Promedio
            };

            Console.WriteLine($"  [OK] Datos encontrados: {estudiante.Nombres} {estudiante.Apellidos}");
            return datos;
        }
        public DatosTutor? ObtenerDatosTutor(string ci)
        {
            Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] Solicitud: ObtenerDatosTutor(CI={ci})");

            if (string.IsNullOrWhiteSpace(ci))
            {
                Console.WriteLine("  [ERROR] CI vacío o nulo");
                return null;
            }

            var estudiante = EstudiantesRepository.BuscarPorCI(ci);

            if (estudiante == null)
            {
                Console.WriteLine($"  [WARN] Estudiante no encontrado");
                return null;
            }

            var datos = new DatosTutor
            {
                NombresEstudiante = $"{estudiante.Nombres} {estudiante.Apellidos}",
                TutorAsignado = estudiante.TutorAsignado,
                CorreoTutor = estudiante.CorreoTutor,
                TelefonoTutor = estudiante.TelefonoTutor
            };

            Console.WriteLine($"  [OK] Tutor: {estudiante.TutorAsignado}");
            return datos;
        }
    }
}
