using SoapCore;
using ServidorSOAP.Services;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.UseUrls("http://localhost:8080");

builder.Services.AddSoapCore();
builder.Services.AddSingleton<ISEDUINFOService, SEDUINFOService>();

var app = builder.Build();

app.UseSoapEndpoint<ISEDUINFOService>(
    "/SEDUINFO.asmx",
    new SoapEncoderOptions(),
    SoapSerializer.XmlSerializer
);

Console.WriteLine("╔═══════════════════════════════════════════════╗");
Console.WriteLine("║                                               ║");
Console.WriteLine("║        SERVICIO SOAP - SEDUINFO               ║");
Console.WriteLine("║    Sistema de Datos Universitarios           ║");
Console.WriteLine("║                                               ║");
Console.WriteLine("╚═══════════════════════════════════════════════╝");
Console.WriteLine();
Console.WriteLine("Servidor SOAP iniciado exitosamente");
Console.WriteLine($"Endpoint: http://localhost:8080/SEDUINFO.asmx");
Console.WriteLine($"WSDL: http://localhost:8080/SEDUINFO.asmx?WSDL");
Console.WriteLine();
Console.WriteLine("Métodos disponibles:");
Console.WriteLine("  • ObtenerDatosAcademicos(string ci)");
Console.WriteLine("  • ObtenerDatosTutor(string ci)");
Console.WriteLine();
Console.WriteLine("Presione Ctrl+C para detener el servidor");
Console.WriteLine("════════════════════════════════════════════════");
Console.WriteLine();

app.Run();
