using System.Collections.Generic;
using System.Linq;
using ServidorSOAP.Models;

namespace ServidorSOAP.Data
{
    public static class EstudiantesRepository
    {
        private static List<Estudiante> _estudiantes;

        static EstudiantesRepository()
        {
            InicializarDatos();
        }
        private static void InicializarDatos()
        {
            _estudiantes = new List<Estudiante>
            {
                new Estudiante
                {
                    CI = "12345678",
                    Nombres = "Juan Carlos",
                    Apellidos = "Pérez Gómez",
                    Carrera = "Ingeniería de Sistemas",
                    Semestre = 6,
                    Promedio = 85.5,
                    TutorAsignado = "Dr. Roberto Sánchez",
                    CorreoTutor = "roberto.sanchez@universidad.edu",
                    TelefonoTutor = "+591 78901234"
                },
                new Estudiante
                {
                    CI = "87654321",
                    Nombres = "María Elena",
                    Apellidos = "López Rodríguez",
                    Carrera = "Ingeniería Industrial",
                    Semestre = 7,
                    Promedio = 92.3,
                    TutorAsignado = "Ing. Patricia Morales",
                    CorreoTutor = "patricia.morales@universidad.edu",
                    TelefonoTutor = "+591 79012345"
                },
                new Estudiante
                {
                    CI = "11223344",
                    Nombres = "Carlos Alberto",
                    Apellidos = "Ruiz Martínez",
                    Carrera = "Ingeniería Civil",
                    Semestre = 5,
                    Promedio = 78.9,
                    TutorAsignado = "Arq. Luis Fernández",
                    CorreoTutor = "luis.fernandez@universidad.edu",
                    TelefonoTutor = "+591 70123456"
                },
                new Estudiante
                {
                    CI = "55667788",
                    Nombres = "Ana Sofía",
                    Apellidos = "Torres Jiménez",
                    Carrera = "Ingeniería Electrónica",
                    Semestre = 8,
                    Promedio = 88.7,
                    TutorAsignado = "Dr. Miguel Vargas",
                    CorreoTutor = "miguel.vargas@universidad.edu",
                    TelefonoTutor = "+591 71234567"
                },
                new Estudiante
                {
                    CI = "99887766",
                    Nombres = "Pedro José",
                    Apellidos = "Ramírez Castro",
                    Carrera = "Ingeniería Informática",
                    Semestre = 4,
                    Promedio = 81.2,
                    TutorAsignado = "Lic. Carmen Ortiz",
                    CorreoTutor = "carmen.ortiz@universidad.edu",
                    TelefonoTutor = "+591 72345678"
                },
                new Estudiante
                {
                    CI = "44556677",
                    Nombres = "Laura Patricia",
                    Apellidos = "Mendoza Silva",
                    Carrera = "Ingeniería Química",
                    Semestre = 6,
                    Promedio = 90.1,
                    TutorAsignado = "Dr. Fernando Díaz",
                    CorreoTutor = "fernando.diaz@universidad.edu",
                    TelefonoTutor = "+591 73456789"
                }
            };

            Console.WriteLine($"[INFO] Repositorio inicializado con {_estudiantes.Count} estudiantes");
        }
        public static Estudiante? BuscarPorCI(string ci)
        {
            return _estudiantes.FirstOrDefault(e => e.CI == ci);
        }
        public static List<Estudiante> ObtenerTodos()
        {
            return _estudiantes;
        }
    }
}
