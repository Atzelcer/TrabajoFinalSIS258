package rmi.servidor;

import java.rmi.Remote;
import java.rmi.RemoteException;

public interface InterfazCadena extends Remote {

    boolean guardarFrase(String frase) throws RemoteException;

    String convertirMayusculas() throws RemoteException;

    String duplicarEspacios(int veces) throws RemoteException;

    String concatenar(String extra) throws RemoteException;

    String obtenerCadena() throws RemoteException;
}
