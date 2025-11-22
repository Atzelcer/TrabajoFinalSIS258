package servidor.monitoreo;

import java.io.IOException;
import java.net.ServerSocket;
import java.net.Socket;
import java.time.LocalTime;
import java.time.format.DateTimeFormatter;
import java.util.concurrent.atomic.AtomicInteger;

public class ServidorMonitoreo {
    private final int puerto;
    private boolean isRunning = false;
    private ServerSocket serverSocket;
    private final AtomicInteger clienteCount = new AtomicInteger(0);
    private static final DateTimeFormatter TIME_FORMAT = DateTimeFormatter.ofPattern("HH:mm:ss");

    public ServidorMonitoreo(int puerto) {
        this.puerto = puerto;
    }

    public void iniciar() {
        try {
            serverSocket = new ServerSocket(puerto);
            isRunning = true;

            System.out.println("╔═══════════════════════════════════════════╗");
            System.out.println("║   SERVIDOR DE MONITOREO DE SENSORES      ║");
            System.out.println("╚═══════════════════════════════════════════╝");
            System.out.println("Servidor iniciado en puerto " + puerto);
            System.out.println("Esperando conexiones de clientes...\n");

            while (isRunning) {
                try {
                    Socket clienteSocket = serverSocket.accept();

                    int clienteId = clienteCount.incrementAndGet();

                    System.out.println("[" + LocalTime.now().format(TIME_FORMAT) +
                            "] Nuevo cliente conectado: Cliente #" + clienteId);

                    Thread hiloCliente = new Thread(new ManejadorCliente(clienteSocket, clienteId));
                    hiloCliente.setDaemon(true);
                    hiloCliente.start();
                } catch (IOException e) {
                    if (isRunning) {
                        System.out.println("Error aceptando cliente: " + e.getMessage());
                    }
                }
            }
        } catch (IOException e) {
            System.out.println("Error al iniciar servidor: " + e.getMessage());
            e.printStackTrace();
        }
    }

    public void detener() {
        isRunning = false;
        try {
            if (serverSocket != null && !serverSocket.isClosed()) {
                serverSocket.close();
            }
            System.out.println("\nServidor detenido.");
        } catch (IOException e) {
            System.out.println("Error al detener servidor: " + e.getMessage());
        }
    }

    public static void main(String[] args) {
        ServidorMonitoreo servidor = new ServidorMonitoreo(5000);

        Runtime.getRuntime().addShutdownHook(new Thread(() -> {
            servidor.detener();
        }));

        servidor.iniciar();
    }
}
