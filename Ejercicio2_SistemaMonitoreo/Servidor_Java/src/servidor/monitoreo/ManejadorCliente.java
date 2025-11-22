package servidor.monitoreo;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.PrintWriter;
import java.net.Socket;
import java.time.LocalTime;
import java.time.format.DateTimeFormatter;

public class ManejadorCliente implements Runnable {
    private final Socket socket;
    private final int clienteId;
    private final ClienteEstado estadoCliente;
    private static final DateTimeFormatter TIME_FORMAT = DateTimeFormatter.ofPattern("HH:mm:ss");

    public ManejadorCliente(Socket socket, int clienteId) {
        this.socket = socket;
        this.clienteId = clienteId;
        this.estadoCliente = new ClienteEstado("Cliente#" + clienteId);
    }

    @Override
    public void run() {
        try (
                BufferedReader entrada = new BufferedReader(new InputStreamReader(socket.getInputStream()));
                PrintWriter salida = new PrintWriter(socket.getOutputStream(), true)) {
            String mensaje;
            while ((mensaje = entrada.readLine()) != null) {
                mensaje = mensaje.trim();

                System.out.println("[" + LocalTime.now().format(TIME_FORMAT) + "] " +
                        estadoCliente.getClienteId() + " → " + mensaje);

                String respuesta;
                if (mensaje.equalsIgnoreCase("reporte")) {
                    respuesta = estadoCliente.obtenerSensorCritico();

                    System.out.println("[" + LocalTime.now().format(TIME_FORMAT) + "] " +
                            estadoCliente.getClienteId() + " - Reporte: " + respuesta);
                } else if (mensaje.contains(":")) {
                    String[] partes = mensaje.split(":", 2);

                    if (partes.length == 2) {
                        String sensorId = partes[0].trim();
                        String estado = partes[1].toLowerCase().trim();

                        if (estado.equals("bajo") || estado.equals("medio") || estado.equals("alto")) {
                            estadoCliente.registrarEstado(sensorId, estado);
                            respuesta = estado + " OK";

                            System.out.println("[" + LocalTime.now().format(TIME_FORMAT) + "] " +
                                    estadoCliente.getClienteId() + " - Registrado: " + sensorId + " = " + estado);
                            System.out.println("    " + estadoCliente.obtenerResumen());
                        } else {
                            respuesta = "ERROR: Estado inválido (usar: bajo, medio, alto)";
                        }
                    } else {
                        respuesta = "ERROR: Formato inválido (usar: sensorID:estado)";
                    }
                } else {
                    respuesta = "ERROR: Comando no reconocido";
                }

                salida.println(respuesta);
            }
        } catch (IOException e) {
            System.out.println("[" + LocalTime.now().format(TIME_FORMAT) + "] Error con " +
                    estadoCliente.getClienteId() + ": " + e.getMessage());
        } finally {
            try {
                socket.close();
                System.out.println("[" + LocalTime.now().format(TIME_FORMAT) + "] " +
                        estadoCliente.getClienteId() + " desconectado");
            } catch (IOException e) {
                e.printStackTrace();
            }
        }
    }
}
