using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
using PronosticoDemandaCliente.Models;

namespace PronosticoDemandaCliente.Services
{
    public class GraphQLService
    {
        private readonly GraphQLHttpClient _client;

        public GraphQLService(string endpoint = "http://localhost:8000/graphql")
        {
            _client = new GraphQLHttpClient(endpoint, new NewtonsoftJsonSerializer());
        }

        public async Task<List<Pronostico>> ObtenerTodosAsync()
        {
            try
            {
                var request = new GraphQLRequest
                {
                    Query = @"
                        query {
                            pronosticos {
                                id
                                fecha
                                cantidadEstimada
                                created_at
                                updated_at
                            }
                        }"
                };

                var response = await _client.SendQueryAsync<PronosticosData>(request);

                if (response.Errors != null && response.Errors.Length > 0)
                {
                    throw new Exception($"GraphQL Error: {response.Errors[0].Message}");
                }

                return response.Data?.Pronosticos ?? new List<Pronostico>();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener pronósticos: {ex.Message}");
            }
        }

        public async Task<Pronostico?> ObtenerPorIdAsync(int id)
        {
            try
            {
                var request = new GraphQLRequest
                {
                    Query = @"
                        query($id: ID!) {
                            pronostico(id: $id) {
                                id
                                fecha
                                cantidadEstimada
                                created_at
                                updated_at
                            }
                        }",
                    Variables = new { id = id.ToString() }
                };

                var response = await _client.SendQueryAsync<PronosticoData>(request);

                if (response.Errors != null && response.Errors.Length > 0)
                {
                    throw new Exception($"GraphQL Error: {response.Errors[0].Message}");
                }

                return response.Data?.Pronostico;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener pronóstico: {ex.Message}");
            }
        }

        public async Task<Pronostico?> CrearAsync(string fecha, int cantidadEstimada)
        {
            try
            {
                var request = new GraphQLRequest
                {
                    Query = @"
                        mutation($fecha: String!, $cantidadEstimada: Int!) {
                            crearPronostico(fecha: $fecha, cantidadEstimada: $cantidadEstimada) {
                                id
                                fecha
                                cantidadEstimada
                                created_at
                                updated_at
                            }
                        }",
                    Variables = new
                    {
                        fecha = fecha,
                        cantidadEstimada = cantidadEstimada
                    }
                };

                var response = await _client.SendMutationAsync<CrearPronosticoData>(request);

                if (response.Errors != null && response.Errors.Length > 0)
                {
                    throw new Exception($"GraphQL Error: {response.Errors[0].Message}");
                }

                return response.Data?.CrearPronostico;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al crear pronóstico: {ex.Message}");
            }
        }

        public async Task<Pronostico?> ActualizarAsync(int id, string fecha, int cantidadEstimada)
        {
            try
            {
                var request = new GraphQLRequest
                {
                    Query = @"
                        mutation($id: ID!, $fecha: String, $cantidadEstimada: Int) {
                            actualizarPronostico(id: $id, fecha: $fecha, cantidadEstimada: $cantidadEstimada) {
                                id
                                fecha
                                cantidadEstimada
                                created_at
                                updated_at
                            }
                        }",
                    Variables = new
                    {
                        id = id.ToString(),
                        fecha = fecha,
                        cantidadEstimada = cantidadEstimada
                    }
                };

                var response = await _client.SendMutationAsync<ActualizarPronosticoData>(request);

                if (response.Errors != null && response.Errors.Length > 0)
                {
                    throw new Exception($"GraphQL Error: {response.Errors[0].Message}");
                }

                return response.Data?.ActualizarPronostico;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al actualizar pronóstico: {ex.Message}");
            }
        }

        public async Task<bool> EliminarAsync(int id)
        {
            try
            {
                var request = new GraphQLRequest
                {
                    Query = @"
                        mutation($id: ID!) {
                            eliminarPronostico(id: $id) {
                                id
                            }
                        }",
                    Variables = new { id = id.ToString() }
                };

                var response = await _client.SendMutationAsync<dynamic>(request);

                if (response.Errors != null && response.Errors.Length > 0)
                {
                    throw new Exception($"GraphQL Error: {response.Errors[0].Message}");
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al eliminar pronóstico: {ex.Message}");
            }
        }
    }
}
