using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using ClienteSEDUINFO.Models;

namespace ClienteSEDUINFO.Services
{
    public class SEDUINFOClient
    {
        private readonly string _endpointUrl;
        private readonly HttpClient _httpClient;

        public SEDUINFOClient(string endpointUrl = "http://localhost:8080/SEDUINFO.asmx")
        {
            _endpointUrl = endpointUrl;
            _httpClient = new HttpClient();
        }
        public async Task<DatosAcademicos?> ObtenerDatosAcademicosAsync(string ci)
        {
            try
            {
                string soapEnvelope = $@"<?xml version=""1.0"" encoding=""utf-8""?>
<soap:Envelope xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"" 
               xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" 
               xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
    <soap:Body>
        <ObtenerDatosAcademicos xmlns=""http://tempuri.org/"">
            <ci>{ci}</ci>
        </ObtenerDatosAcademicos>
    </soap:Body>
</soap:Envelope>";

                var content = new StringContent(soapEnvelope, Encoding.UTF8, "text/xml");
                content.Headers.Add("SOAPAction", "http://tempuri.org/ISEDUINFOService/ObtenerDatosAcademicos");

                var response = await _httpClient.PostAsync(_endpointUrl, content);
                var responseContent = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"Error en la respuesta: {response.StatusCode}");
                }

                return ParseDatosAcademicos(responseContent);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener datos académicos: {ex.Message}", ex);
            }
        }
        public async Task<DatosTutor?> ObtenerDatosTutorAsync(string ci)
        {
            try
            {
                string soapEnvelope = $@"<?xml version=""1.0"" encoding=""utf-8""?>
<soap:Envelope xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"" 
               xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" 
               xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
    <soap:Body>
        <ObtenerDatosTutor xmlns=""http://tempuri.org/"">
            <ci>{ci}</ci>
        </ObtenerDatosTutor>
    </soap:Body>
</soap:Envelope>";

                var content = new StringContent(soapEnvelope, Encoding.UTF8, "text/xml");
                content.Headers.Add("SOAPAction", "http://tempuri.org/ISEDUINFOService/ObtenerDatosTutor");

                var response = await _httpClient.PostAsync(_endpointUrl, content);
                var responseContent = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"Error en la respuesta: {response.StatusCode}");
                }

                return ParseDatosTutor(responseContent);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener datos del tutor: {ex.Message}", ex);
            }
        }
        private DatosAcademicos? ParseDatosAcademicos(string xml)
        {
            try
            {
                XDocument doc = XDocument.Parse(xml);
                XNamespace ns = "http://tempuri.org/";

                var result = doc.Descendants(ns + "ObtenerDatosAcademicosResult").FirstOrDefault();
                if (result == null) return null;

                return new DatosAcademicos
                {
                    CI = result.Element(ns + "CI")?.Value ?? "",
                    Nombres = result.Element(ns + "Nombres")?.Value ?? "",
                    Apellidos = result.Element(ns + "Apellidos")?.Value ?? "",
                    Carrera = result.Element(ns + "Carrera")?.Value ?? "",
                    Semestre = int.Parse(result.Element(ns + "Semestre")?.Value ?? "0"),
                    Promedio = double.Parse(result.Element(ns + "Promedio")?.Value ?? "0")
                };
            }
            catch
            {
                return null;
            }
        }
        private DatosTutor? ParseDatosTutor(string xml)
        {
            try
            {
                XDocument doc = XDocument.Parse(xml);
                XNamespace ns = "http://tempuri.org/";

                var result = doc.Descendants(ns + "ObtenerDatosTutorResult").FirstOrDefault();
                if (result == null) return null;

                return new DatosTutor
                {
                    NombresEstudiante = result.Element(ns + "NombresEstudiante")?.Value ?? "",
                    TutorAsignado = result.Element(ns + "TutorAsignado")?.Value ?? "",
                    CorreoTutor = result.Element(ns + "CorreoTutor")?.Value ?? "",
                    TelefonoTutor = result.Element(ns + "TelefonoTutor")?.Value ?? ""
                };
            }
            catch
            {
                return null;
            }
        }
    }
}
