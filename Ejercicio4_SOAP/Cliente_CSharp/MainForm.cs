using System;
using System.Windows.Forms;
using ClienteSEDUINFO.Services;
using ClienteSEDUINFO.Models;

namespace ClienteSEDUINFO
{
    public partial class MainForm : Form
    {
        private readonly SEDUINFOClient _soapClient;

        public MainForm()
        {
            InitializeComponent();
            _soapClient = new SEDUINFOClient();

            btnDatosAcademicos.Location = new System.Drawing.Point(390, 45);
            btnDatosTutor.Location = new System.Drawing.Point(580, 45);

            txtResultados.Text = "Ingrese un CI y seleccione una opción para consultar...";
        }
        private async void btnDatosAcademicos_Click(object sender, EventArgs e)
        {
            string ci = txtCI.Text.Trim();

            if (string.IsNullOrEmpty(ci))
            {
                MessageBox.Show("Por favor ingrese el CI del estudiante",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                txtResultados.Text = "Consultando datos académicos...\r\n";
                btnDatosAcademicos.Enabled = false;
                btnDatosTutor.Enabled = false;

                var datos = await _soapClient.ObtenerDatosAcademicosAsync(ci);

                if (datos == null)
                {
                    txtResultados.Text = "No se encontró ningún estudiante con ese CI";
                    MessageBox.Show("No se encontró ningún estudiante con ese CI",
                        "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }


                txtResultados.Text = "╔══════════════════════════════════════════════════╗\r\n" +
                                    "║         DATOS ACADÉMICOS DEL ESTUDIANTE          ║\r\n" +
                                    "╚══════════════════════════════════════════════════╝\r\n\r\n" +
                                    $"CI:              {datos.CI}\r\n" +
                                    $"Nombres:         {datos.Nombres}\r\n" +
                                    $"Apellidos:       {datos.Apellidos}\r\n" +
                                    $"Carrera:         {datos.Carrera}\r\n" +
                                    $"Semestre:        {datos.Semestre}\r\n" +
                                    $"Promedio:        {datos.Promedio:F2}\r\n";
            }
            catch (Exception ex)
            {
                txtResultados.Text = $" Error: {ex.Message}";
                MessageBox.Show($"Error al consultar datos: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnDatosAcademicos.Enabled = true;
                btnDatosTutor.Enabled = true;
            }
        }
        private async void btnDatosTutor_Click(object sender, EventArgs e)
        {
            string ci = txtCI.Text.Trim();

            if (string.IsNullOrEmpty(ci))
            {
                MessageBox.Show("Por favor ingrese el CI del estudiante",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                txtResultados.Text = "Consultando datos del tutor...\r\n";
                btnDatosAcademicos.Enabled = false;
                btnDatosTutor.Enabled = false;

                var datos = await _soapClient.ObtenerDatosTutorAsync(ci);

                if (datos == null)
                {
                    txtResultados.Text = "No se encontró ningún estudiante con ese CI";
                    MessageBox.Show("No se encontró ningún estudiante con ese CI",
                        "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }


                txtResultados.Text = "╔══════════════════════════════════════════════════╗\r\n" +
                                    "║           DATOS DEL TUTOR ASIGNADO               ║\r\n" +
                                    "╚══════════════════════════════════════════════════╝\r\n\r\n" +
                                    $"Estudiante:      {datos.NombresEstudiante}\r\n\r\n" +
                                    $"Tutor:           {datos.TutorAsignado}\r\n" +
                                    $"Correo:          {datos.CorreoTutor}\r\n" +
                                    $"Teléfono:        {datos.TelefonoTutor}\r\n";
            }
            catch (Exception ex)
            {
                txtResultados.Text = $"Error: {ex.Message}";
                MessageBox.Show($"Error al consultar datos: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnDatosAcademicos.Enabled = true;
                btnDatosTutor.Enabled = true;
            }
        }
    }
}
