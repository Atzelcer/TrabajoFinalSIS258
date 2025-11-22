package rmi.servidor;

import java.rmi.RemoteException;
import java.rmi.server.UnicastRemoteObject;

public class ImplementacionCadena extends UnicastRemoteObject implements InterfazCadena {

    private String cadenaGeneral;

    public ImplementacionCadena() throws RemoteException {
        super();
        this.cadenaGeneral = "";
        System.out.println("[INFO] Objeto remoto creado. Cadena inicial: \"" + cadenaGeneral + "\"");
    }

    @Override
    public synchronized boolean guardarFrase(String frase) throws RemoteException {
        if (frase == null) {
            System.out.println("[ERROR] Intento de guardar frase nula");
            return false;
        }

        String anterior = this.cadenaGeneral;
        this.cadenaGeneral = frase;

        System.out.println("═══════════════════════════════════════════");
        System.out.println("[OPERACIÓN] guardarFrase()");
        System.out.println("[ANTERIOR]  \"" + anterior + "\"");
        System.out.println("[NUEVO]     \"" + this.cadenaGeneral + "\"");
        System.out.println("═══════════════════════════════════════════");

        return true;
    }

    @Override
    public synchronized String convertirMayusculas() throws RemoteException {
        System.out.println("═══════════════════════════════════════════");
        System.out.println("[OPERACIÓN] convertirMayusculas()");
        System.out.println("[ORIGINAL]  \"" + this.cadenaGeneral + "\"");

        String resultado = this.cadenaGeneral.toUpperCase();
        this.cadenaGeneral = resultado;

        System.out.println("[RESULTADO] \"" + resultado + "\"");
        System.out.println("═══════════════════════════════════════════");

        return resultado;
    }

    @Override
    public synchronized String duplicarEspacios(int veces) throws RemoteException {
        if (veces < 0) {
            System.out.println("[ERROR] Número de veces negativo: " + veces);
            return this.cadenaGeneral;
        }

        System.out.println("═══════════════════════════════════════════");
        System.out.println("[OPERACIÓN] duplicarEspacios(" + veces + ")");
        System.out.println("[ORIGINAL]  \"" + this.cadenaGeneral + "\"");
        String espacios = " ".repeat(veces);
        String resultado = this.cadenaGeneral.replace(" ", " " + espacios);
        this.cadenaGeneral = resultado;

        System.out.println("[RESULTADO] \"" + resultado + "\"");
        System.out.println("═══════════════════════════════════════════");

        return resultado;
    }

    @Override
    public synchronized String concatenar(String extra) throws RemoteException {
        if (extra == null) {
            extra = "";
        }

        System.out.println("═══════════════════════════════════════════");
        System.out.println("[OPERACIÓN] concatenar()");
        System.out.println("[ORIGINAL]  \"" + this.cadenaGeneral + "\"");
        System.out.println("[CONCATENA] \"" + extra + "\"");

        String resultado = this.cadenaGeneral + extra;
        this.cadenaGeneral = resultado;

        System.out.println("[RESULTADO] \"" + resultado + "\"");
        System.out.println("═══════════════════════════════════════════");

        return resultado;
    }

    @Override
    public synchronized String obtenerCadena() throws RemoteException {
        System.out.println("[INFO] Consultando cadena actual: \"" + this.cadenaGeneral + "\"");
        return this.cadenaGeneral;
    }
}
