using System.ServiceModel;
using ServidorSOAP.Models;

namespace ServidorSOAP.Services
{
    [ServiceContract]
    public interface ISEDUINFOService
    {
        [OperationContract]
        DatosAcademicos? ObtenerDatosAcademicos(string ci);
        [OperationContract]
        DatosTutor? ObtenerDatosTutor(string ci);
    }
}
