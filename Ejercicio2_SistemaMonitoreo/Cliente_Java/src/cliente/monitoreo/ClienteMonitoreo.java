package cliente.monitoreo;

import javax.swing.*;
import java.awt.*;
import java.awt.event.*;
import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.PrintWriter;
import java.net.Socket;
import java.time.LocalTime;
import java.time.format.DateTimeFormatter;

public class ClienteMonitoreo extends JFrame {
    private JTextField txtServidor;
    private JSpinner spinPuerto;
    private JTextField txtSensorId;
    private JComboBox<String> cboEstado;
    private JTextArea txtLog;
    private JLabel lblEstado;
    private JButton btnConectar;
    private JButton btnDesconectar;
    private JButton btnEnviarEstado;
    private JButton btnReporte;
    private JPanel grpEnvio;

    private Socket socket;
    private BufferedReader entrada;
    private PrintWriter salida;
    private boolean conectado = false;

    private static final DateTimeFormatter TIME_FORMAT = DateTimeFormatter.ofPattern("HH:mm:ss");

    public ClienteMonitoreo() {
        setTitle("Cliente de Monitoreo de Sensores");
        setSize(700, 600);
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        setLocationRelativeTo(null);

        initComponents();
        agregarLog("Sistema iniciado. Listo para conectar al servidor.");

        addWindowListener(new WindowAdapter() {
            @Override
            public void windowClosing(WindowEvent e) {
                if (conectado) {
                    desconectar();
                }
            }
        });
    }

    private void initComponents() {
        JPanel mainPanel = new JPanel();
        mainPanel.setLayout(new BoxLayout(mainPanel, BoxLayout.Y_AXIS));
        mainPanel.setBorder(BorderFactory.createEmptyBorder(10, 10, 10, 10));

        JPanel panelConexion = new JPanel();
        panelConexion.setBorder(BorderFactory.createTitledBorder("Conexión al Servidor"));
        panelConexion.setLayout(new GridBagLayout());
        GridBagConstraints gbc = new GridBagConstraints();
        gbc.insets = new Insets(5, 5, 5, 5);
        gbc.fill = GridBagConstraints.HORIZONTAL;

        gbc.gridx = 0;
        gbc.gridy = 0;
        panelConexion.add(new JLabel("Servidor:"), gbc);

        gbc.gridx = 1;
        gbc.weightx = 1.0;
        txtServidor = new JTextField("localhost", 15);
        panelConexion.add(txtServidor, gbc);

        gbc.gridx = 2;
        gbc.weightx = 0;
        panelConexion.add(new JLabel("Puerto:"), gbc);

        gbc.gridx = 3;
        spinPuerto = new JSpinner(new SpinnerNumberModel(5000, 1024, 65535, 1));
        spinPuerto.setPreferredSize(new Dimension(80, 25));
        panelConexion.add(spinPuerto, gbc);

        gbc.gridx = 0;
        gbc.gridy = 1;
        panelConexion.add(new JLabel("Estado:"), gbc);

        gbc.gridx = 1;
        lblEstado = new JLabel("Desconectado");
        lblEstado.setForeground(Color.RED);
        lblEstado.setFont(lblEstado.getFont().deriveFont(Font.BOLD));
        panelConexion.add(lblEstado, gbc);

        gbc.gridx = 2;
        gbc.gridwidth = 2;
        JPanel panelBotones = new JPanel(new FlowLayout(FlowLayout.RIGHT));
        btnConectar = new JButton("Conectar");
        btnDesconectar = new JButton("Desconectar");
        btnDesconectar.setEnabled(false);
        panelBotones.add(btnConectar);
        panelBotones.add(btnDesconectar);
        panelConexion.add(panelBotones, gbc);

        mainPanel.add(panelConexion);

        grpEnvio = new JPanel();
        grpEnvio.setBorder(BorderFactory.createTitledBorder("Envío de Datos"));
        grpEnvio.setLayout(new GridBagLayout());
        grpEnvio.setEnabled(false);
        gbc = new GridBagConstraints();
        gbc.insets = new Insets(5, 5, 5, 5);
        gbc.fill = GridBagConstraints.HORIZONTAL;

        gbc.gridx = 0;
        gbc.gridy = 0;
        grpEnvio.add(new JLabel("Sensor ID:"), gbc);

        gbc.gridx = 1;
        gbc.weightx = 1.0;
        txtSensorId = new JTextField(15);
        grpEnvio.add(txtSensorId, gbc);

        gbc.gridx = 2;
        gbc.weightx = 0;
        grpEnvio.add(new JLabel("Estado:"), gbc);

        gbc.gridx = 3;
        cboEstado = new JComboBox<>(new String[] { "bajo", "medio", "alto" });
        grpEnvio.add(cboEstado, gbc);

        gbc.gridx = 0;
        gbc.gridy = 1;
        gbc.gridwidth = 4;
        JPanel panelBotonesEnvio = new JPanel(new FlowLayout(FlowLayout.CENTER));
        btnEnviarEstado = new JButton("Enviar Estado");
        btnReporte = new JButton("Solicitar Reporte");
        panelBotonesEnvio.add(btnEnviarEstado);
        panelBotonesEnvio.add(btnReporte);
        grpEnvio.add(panelBotonesEnvio, gbc);

        setComponentesEnvioHabilitados(false);
        mainPanel.add(grpEnvio);

        JPanel panelLog = new JPanel(new BorderLayout());
        panelLog.setBorder(BorderFactory.createTitledBorder("Log de Actividad"));
        txtLog = new JTextArea(15, 50);
        txtLog.setEditable(false);
        txtLog.setFont(new Font("Monospaced", Font.PLAIN, 12));
        JScrollPane scrollPane = new JScrollPane(txtLog);
        panelLog.add(scrollPane, BorderLayout.CENTER);
        mainPanel.add(panelLog);

        add(mainPanel);

        btnConectar.addActionListener(e -> conectar());
        btnDesconectar.addActionListener(e -> desconectar());
        btnEnviarEstado.addActionListener(e -> enviarEstado());
        btnReporte.addActionListener(e -> solicitarReporte());
    }

    private void setComponentesEnvioHabilitados(boolean habilitado) {
        txtSensorId.setEnabled(habilitado);
        cboEstado.setEnabled(habilitado);
        btnEnviarEstado.setEnabled(habilitado);
        btnReporte.setEnabled(habilitado);
    }

    private void agregarLog(String mensaje) {
        SwingUtilities.invokeLater(() -> {
            String timestamp = LocalTime.now().format(TIME_FORMAT);
            txtLog.append("[" + timestamp + "] " + mensaje + "\n");
            txtLog.setCaretPosition(txtLog.getDocument().getLength());
        });
    }

    private void conectar() {
        try {
            String servidor = txtServidor.getText().trim();
            int puerto = (Integer) spinPuerto.getValue();

            if (servidor.isEmpty()) {
                JOptionPane.showMessageDialog(this,
                        "Por favor ingrese la dirección del servidor",
                        "Advertencia",
                        JOptionPane.WARNING_MESSAGE);
                return;
            }

            agregarLog("Conectando a " + servidor + ":" + puerto + "...");

            socket = new Socket(servidor, puerto);
            entrada = new BufferedReader(new InputStreamReader(socket.getInputStream()));
            salida = new PrintWriter(socket.getOutputStream(), true);
            conectado = true;

            lblEstado.setText("Conectado");
            lblEstado.setForeground(Color.GREEN);
            btnConectar.setEnabled(false);
            btnDesconectar.setEnabled(true);
            setComponentesEnvioHabilitados(true);
            txtServidor.setEnabled(false);
            spinPuerto.setEnabled(false);

            agregarLog("Conectado exitosamente al servidor");
        } catch (IOException e) {
            agregarLog("Error al conectar: " + e.getMessage());
            JOptionPane.showMessageDialog(this,
                    "Error al conectar: " + e.getMessage(),
                    "Error",
                    JOptionPane.ERROR_MESSAGE);
        }
    }

    private void desconectar() {
        try {
            conectado = false;
            if (entrada != null)
                entrada.close();
            if (salida != null)
                salida.close();
            if (socket != null)
                socket.close();

            lblEstado.setText("Desconectado");
            lblEstado.setForeground(Color.RED);
            btnConectar.setEnabled(true);
            btnDesconectar.setEnabled(false);
            setComponentesEnvioHabilitados(false);
            txtServidor.setEnabled(true);
            spinPuerto.setEnabled(true);

            agregarLog("Desconectado del servidor");
        } catch (IOException e) {
            agregarLog("Error al desconectar: " + e.getMessage());
        }
    }

    private void enviarEstado() {
        if (!conectado || salida == null) {
            JOptionPane.showMessageDialog(this,
                    "No hay conexión con el servidor",
                    "Advertencia",
                    JOptionPane.WARNING_MESSAGE);
            return;
        }

        String sensorId = txtSensorId.getText().trim();
        if (sensorId.isEmpty()) {
            JOptionPane.showMessageDialog(this,
                    "Por favor ingrese el ID del sensor",
                    "Advertencia",
                    JOptionPane.WARNING_MESSAGE);
            return;
        }

        String estado = (String) cboEstado.getSelectedItem();

        try {
            String mensaje = sensorId + ":" + estado;
            agregarLog("→ Enviando: " + mensaje);

            salida.println(mensaje);

            String respuesta = entrada.readLine();
            agregarLog("← Respuesta: " + respuesta);
        } catch (IOException e) {
            agregarLog("Error: " + e.getMessage());
            JOptionPane.showMessageDialog(this,
                    "Error al enviar datos: " + e.getMessage(),
                    "Error",
                    JOptionPane.ERROR_MESSAGE);
            desconectar();
        }
    }

    private void solicitarReporte() {
        if (!conectado || salida == null) {
            JOptionPane.showMessageDialog(this,
                    "No hay conexión con el servidor",
                    "Advertencia",
                    JOptionPane.WARNING_MESSAGE);
            return;
        }

        try {
            agregarLog("→ Solicitando reporte...");

            salida.println("reporte");

            String respuesta = entrada.readLine();
            agregarLog("← Reporte: " + respuesta);

            JOptionPane.showMessageDialog(this,
                    respuesta,
                    "Reporte del Servidor",
                    JOptionPane.INFORMATION_MESSAGE);
        } catch (IOException e) {
            agregarLog("Error: " + e.getMessage());
            JOptionPane.showMessageDialog(this,
                    "Error al solicitar reporte: " + e.getMessage(),
                    "Error",
                    JOptionPane.ERROR_MESSAGE);
            desconectar();
        }
    }

    public static void main(String[] args) {
        SwingUtilities.invokeLater(() -> {
            try {
                UIManager.setLookAndFeel(UIManager.getSystemLookAndFeelClassName());
            } catch (Exception e) {
                e.printStackTrace();
            }

            ClienteMonitoreo cliente = new ClienteMonitoreo();
            cliente.setVisible(true);
        });
    }
}
