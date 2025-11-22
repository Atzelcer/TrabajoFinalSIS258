package rmi.cliente;

import rmi.servidor.InterfazCadena;
import java.rmi.registry.LocateRegistry;
import java.rmi.registry.Registry;
import java.util.Scanner;

public class ClienteRMI {

    private static final String SERVIDOR = "localhost";
    private static final int PUERTO = 1099;
    private static final String NOMBRE_SERVICIO = "ServicioCadenas";

    private InterfazCadena servicioRemoto;
    private Scanner scanner;

    public ClienteRMI() {
        scanner = new Scanner(System.in);
    }

    public boolean conectar() {
        try {
            System.out.println("[INFO] Conectando al servidor RMI...");
            System.out.println("       Servidor: " + SERVIDOR);
            System.out.println("       Puerto: " + PUERTO);
            System.out.println("       Servicio: " + NOMBRE_SERVICIO);

            Registry registro = LocateRegistry.getRegistry(SERVIDOR, PUERTO);
            servicioRemoto = (InterfazCadena) registro.lookup(NOMBRE_SERVICIO);

            System.out.println("\n Conexión establecida exitosamente\n");
            return true;

        } catch (Exception e) {
            System.err.println("\n Error al conectar con el servidor:");
            System.err.println("   " + e.getMessage());
            System.err.println("\nAsegúrese de que el servidor esté ejecutándose.");
            return false;
        }
    }

    public void mostrarMenu() {
        System.out.println("\n╔═══════════════════════════════════════════╗");
        System.out.println("║  SISTEMA RMI - MANEJO DE CADENAS         ║");
        System.out.println("╚═══════════════════════════════════════════╝");
        System.out.println("  1. Guardar frase");
        System.out.println("  2. Convertir a mayúsculas");
        System.out.println("  3. Duplicar espacios");
        System.out.println("  4. Concatenar texto");
        System.out.println("  5. Ver cadena actual");
        System.out.println("  6. Salir");
        System.out.println("═══════════════════════════════════════════");
        System.out.print("Seleccione una opción: ");
    }

    public void ejecutarOpcion(int opcion) {
        try {
            switch (opcion) {
                case 1:
                    guardarFrase();
                    break;
                case 2:
                    convertirMayusculas();
                    break;
                case 3:
                    duplicarEspacios();
                    break;
                case 4:
                    concatenar();
                    break;
                case 5:
                    verCadenaActual();
                    break;
                case 6:
                    System.out.println("\n ¡Hasta luego!");
                    System.exit(0);
                    break;
                default:
                    System.out.println("\n Opción inválida. Por favor intente nuevamente.");
            }
        } catch (Exception e) {
            System.err.println("\n Error al ejecutar operación:");
            System.err.println("   " + e.getMessage());
        }
    }

    private void guardarFrase() throws Exception {
        System.out.print("\nIngrese la frase a guardar: ");
        scanner.nextLine();
        String frase = scanner.nextLine();

        boolean exito = servicioRemoto.guardarFrase(frase);

        if (exito) {
            System.out.println("\n Frase guardada exitosamente");
        } else {
            System.out.println("\n Error al guardar la frase");
        }
    }

    private void convertirMayusculas() throws Exception {
        System.out.println("\n[Invocando convertirMayusculas()...]");
        String resultado = servicioRemoto.convertirMayusculas();

        System.out.println("\n Resultado:");
        System.out.println("  \"" + resultado + "\"");
    }

    private void duplicarEspacios() throws Exception {
        System.out.print("\n¿Cuántas veces duplicar los espacios?: ");
        int veces = scanner.nextInt();

        if (veces < 0) {
            System.out.println("\n El número debe ser positivo");
            return;
        }

        System.out.println("\n[Invocando duplicarEspacios(" + veces + ")...]");
        String resultado = servicioRemoto.duplicarEspacios(veces);

        System.out.println("\n Resultado:");
        System.out.println("  \"" + resultado + "\"");
    }

    private void concatenar() throws Exception {
        System.out.print("\nIngrese el texto a concatenar: ");
        scanner.nextLine();
        String extra = scanner.nextLine();

        System.out.println("\n[Invocando concatenar(\"" + extra + "\")...]");
        String resultado = servicioRemoto.concatenar(extra);

        System.out.println("\n Resultado:");
        System.out.println("  \"" + resultado + "\"");
    }

    private void verCadenaActual() throws Exception {
        String cadena = servicioRemoto.obtenerCadena();

        System.out.println("\n Cadena actual en el servidor:");
        System.out.println("  \"" + cadena + "\"");
    }

    public void iniciar() {
        System.out.println("╔═══════════════════════════════════════════╗");
        System.out.println("║                                           ║");
        System.out.println("║      CLIENTE RMI - MANEJO DE CADENAS     ║");
        System.out.println("║                                           ║");
        System.out.println("╚═══════════════════════════════════════════╝\n");

        if (!conectar()) {
            return;
        }

        while (true) {
            try {
                mostrarMenu();
                int opcion = scanner.nextInt();
                ejecutarOpcion(opcion);

                System.out.println("\nPresione Enter para continuar...");
                System.in.read();

            } catch (Exception e) {
                System.err.println("\n Error: " + e.getMessage());
                scanner.nextLine();
            }
        }
    }

    public static void main(String[] args) {
        ClienteRMI cliente = new ClienteRMI();
        cliente.iniciar();
    }
}
