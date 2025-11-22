using System;

namespace PronosticoDemandaCliente.Models
{
    public class Pronostico
    {
        public int Id { get; set; }
        public string Fecha { get; set; } = string.Empty;
        public int CantidadEstimada { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public override string ToString()
        {
            return $"ID: {Id} | Fecha: {Fecha} | Cantidad: {CantidadEstimada}";
        }
    }

    public class ApiResponse<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public T? Data { get; set; }
    }

    public class GraphQLResponse<T>
    {
        public T? Data { get; set; }
        public List<GraphQLError>? Errors { get; set; }
    }

    public class GraphQLError
    {
        public string Message { get; set; } = string.Empty;
    }

    public class PronosticosData
    {
        public List<Pronostico>? Pronosticos { get; set; }
    }

    public class PronosticoData
    {
        public Pronostico? Pronostico { get; set; }
    }

    public class CrearPronosticoData
    {
        public Pronostico? CrearPronostico { get; set; }
    }

    public class ActualizarPronosticoData
    {
        public Pronostico? ActualizarPronostico { get; set; }
    }
}
