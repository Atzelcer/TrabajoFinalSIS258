package servidor.monitoreo;

import java.util.HashMap;
import java.util.Map;

public class ClienteEstado {
    private final String clienteId;
    private final Map<String, String> sensores;

    public ClienteEstado(String clienteId) {
        this.clienteId = clienteId;
        this.sensores = new HashMap<>();
    }

    public void registrarEstado(String sensorId, String estado) {
        sensores.put(sensorId, estado);
    }

    public String obtenerSensorCritico() {
        if (sensores.isEmpty()) {
            return "Sin sensores registrados";
        }

        int bajo = 0, medio = 0, alto = 0;

        for (String estado : sensores.values()) {
            switch (estado) {
                case "bajo":
                    bajo++;
                    break;
                case "medio":
                    medio++;
                    break;
                case "alto":
                    alto++;
                    break;
            }
        }

        String critico;
        if (alto > 0) {
            critico = "alto";
        } else if (medio > 0) {
            critico = "medio";
        } else {
            critico = "bajo";
        }

        return String.format("Total: %d sensores - Bajo: %d, Medio: %d, Alto: %d - Critico: %s",
                sensores.size(), bajo, medio, alto, critico);
    }

    public String obtenerResumen() {
        return String.format("Sensores registrados: %d", sensores.size());
    }

    public String getClienteId() {
        return clienteId;
    }
}
