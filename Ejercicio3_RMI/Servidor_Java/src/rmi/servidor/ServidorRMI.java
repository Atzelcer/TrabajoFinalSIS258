package rmi.servidor;

import java.rmi.registry.LocateRegistry;
import java.rmi.registry.Registry;

public class ServidorRMI {

    private static final int PUERTO = 1099;
    private static final String NOMBRE_SERVICIO = "ServicioCadenas";

    public static void main(String[] args) {
        try {
            imprimirBanner();

            System.out.println("[1/3] Creando objeto remoto...");
            ImplementacionCadena objetoRemoto = new ImplementacionCadena();
            System.out.println("      Objeto remoto creado exitosamente");

            System.out.println("\n[2/3] Iniciando registro RMI en puerto " + PUERTO + "...");
            Registry registro = LocateRegistry.createRegistry(PUERTO);
            System.out.println("      Registro RMI iniciado");

            System.out.println("\n[3/3] Registrando servicio '" + NOMBRE_SERVICIO + "'...");
            registro.rebind(NOMBRE_SERVICIO, objetoRemoto);
            System.out.println("      Servicio registrado exitosamente");

            System.out.println("\n╔═══════════════════════════════════════════════╗");
            System.out.println("║   SERVIDOR RMI INICIADO CORRECTAMENTE        ║");
            System.out.println("╚═══════════════════════════════════════════════╝");
            System.out.println("\n Servidor escuchando en puerto: " + PUERTO);
            System.out.println(" Nombre del servicio: " + NOMBRE_SERVICIO);
            System.out.println(" Esperando invocaciones de clientes...\n");
            System.out.println("Presione Ctrl+C para detener el servidor\n");
            Thread.currentThread().join();

        } catch (Exception e) {
            System.err.println("Error en el servidor RMI:");
            System.err.println("   " + e.getMessage());
            e.printStackTrace();
        }
    }

    private static void imprimirBanner() {
        System.out.println("╔═══════════════════════════════════════════════╗");
        System.out.println("║                                               ║");
        System.out.println("║     SERVIDOR RMI - MANEJO DE CADENAS         ║");
        System.out.println("║                                               ║");
        System.out.println("║  Métodos disponibles:                        ║");
        System.out.println("║  • guardarFrase(String)                      ║");
        System.out.println("║  • convertirMayusculas()                     ║");
        System.out.println("║  • duplicarEspacios(int)                     ║");
        System.out.println("║  • concatenar(String)                        ║");
        System.out.println("║                                               ║");
        System.out.println("╚═══════════════════════════════════════════════╝");
        System.out.println();
    }
}
