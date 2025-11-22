using System;
using System.Collections.Generic;
using System.Windows.Forms;
using PronosticoDemandaCliente.Models;
using PronosticoDemandaCliente.Services;

namespace PronosticoDemandaCliente
{
    public partial class MainForm : Form
    {
        private RestService? _restService;
        private GraphQLService? _graphQLService;

        public MainForm()
        {
            InitializeComponent();
            _restService = new RestService();
            _graphQLService = new GraphQLService();
        }

        private void MostrarMensaje(string mensaje, bool esError = false)
        {
            txtResultado.Text = $"[{DateTime.Now:HH:mm:ss}] {mensaje}";
            txtResultado.ForeColor = esError ? System.Drawing.Color.Red : System.Drawing.Color.Green;
        }

        private async void btnListar_Click(object sender, EventArgs e)
        {
            try
            {
                List<Pronostico> pronosticos;

                if (rbREST.Checked)
                {
                    MostrarMensaje("Obteniendo pronósticos via REST...");
                    pronosticos = await _restService!.ObtenerTodosAsync();
                }
                else
                {
                    MostrarMensaje("Obteniendo pronósticos via GraphQL...");
                    pronosticos = await _graphQLService!.ObtenerTodosAsync();
                }

                dgvPronosticos.DataSource = null;
                dgvPronosticos.DataSource = pronosticos;
                MostrarMensaje($"Se encontraron {pronosticos.Count} pronósticos");
            }
            catch (Exception ex)
            {
                MostrarMensaje($"Error: {ex.Message}", true);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnObtener_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtId.Text))
            {
                MessageBox.Show("Por favor ingrese un ID", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int id = int.Parse(txtId.Text);
                Pronostico? pronostico;

                if (rbREST.Checked)
                {
                    MostrarMensaje($"Obteniendo pronóstico {id} via REST...");
                    pronostico = await _restService!.ObtenerPorIdAsync(id);
                }
                else
                {
                    MostrarMensaje($"Obteniendo pronóstico {id} via GraphQL...");
                    pronostico = await _graphQLService!.ObtenerPorIdAsync(id);
                }

                if (pronostico != null)
                {
                    var lista = new List<Pronostico> { pronostico };
                    dgvPronosticos.DataSource = null;
                    dgvPronosticos.DataSource = lista;

                    txtFecha.Text = pronostico.Fecha;
                    numCantidad.Value = pronostico.CantidadEstimada;

                    MostrarMensaje("Pronóstico encontrado exitosamente");
                }
                else
                {
                    MostrarMensaje("Pronóstico no encontrado", true);
                }
            }
            catch (Exception ex)
            {
                MostrarMensaje($"Error: {ex.Message}", true);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnCrear_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFecha.Text))
            {
                MessageBox.Show("Por favor ingrese la fecha", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string fecha = txtFecha.Text;
                int cantidad = (int)numCantidad.Value;
                Pronostico? pronostico;

                if (rbREST.Checked)
                {
                    MostrarMensaje("Creando pronóstico via REST...");
                    pronostico = await _restService!.CrearAsync(fecha, cantidad);
                }
                else
                {
                    MostrarMensaje("Creando pronóstico via GraphQL...");
                    pronostico = await _graphQLService!.CrearAsync(fecha, cantidad);
                }

                if (pronostico != null)
                {
                    MostrarMensaje($"Pronóstico creado exitosamente. ID: {pronostico.Id}");
                    btnListar_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                MostrarMensaje($"Error: {ex.Message}", true);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnActualizar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtId.Text))
            {
                MessageBox.Show("Por favor ingrese el ID del pronóstico a actualizar",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtFecha.Text))
            {
                MessageBox.Show("Por favor ingrese la fecha", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int id = int.Parse(txtId.Text);
                string fecha = txtFecha.Text;
                int cantidad = (int)numCantidad.Value;
                Pronostico? pronostico;

                if (rbREST.Checked)
                {
                    MostrarMensaje($"Actualizando pronóstico {id} via REST...");
                    pronostico = await _restService!.ActualizarAsync(id, fecha, cantidad);
                }
                else
                {
                    MostrarMensaje($"Actualizando pronóstico {id} via GraphQL...");
                    pronostico = await _graphQLService!.ActualizarAsync(id, fecha, cantidad);
                }

                if (pronostico != null)
                {
                    MostrarMensaje("Pronóstico actualizado exitosamente");
                    btnListar_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                MostrarMensaje($"Error: {ex.Message}", true);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtId.Text))
            {
                MessageBox.Show("Por favor ingrese el ID del pronóstico a eliminar",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var resultado = MessageBox.Show(
                "¿Está seguro de eliminar este pronóstico?",
                "Confirmación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (resultado == DialogResult.No)
                return;

            try
            {
                int id = int.Parse(txtId.Text);
                bool exito;

                if (rbREST.Checked)
                {
                    MostrarMensaje($"Eliminando pronóstico {id} via REST...");
                    exito = await _restService!.EliminarAsync(id);
                }
                else
                {
                    MostrarMensaje($"Eliminando pronóstico {id} via GraphQL...");
                    exito = await _graphQLService!.EliminarAsync(id);
                }

                if (exito)
                {
                    MostrarMensaje("Pronóstico eliminado exitosamente");
                    txtId.Clear();
                    txtFecha.Clear();
                    numCantidad.Value = 0;
                    btnListar_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                MostrarMensaje($"Error: {ex.Message}", true);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvPronosticos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPronosticos.SelectedRows.Count > 0)
            {
                var pronostico = dgvPronosticos.SelectedRows[0].DataBoundItem as Pronostico;
                if (pronostico != null)
                {
                    txtId.Text = pronostico.Id.ToString();
                    txtFecha.Text = pronostico.Fecha;
                    numCantidad.Value = pronostico.CantidadEstimada;
                }
            }
        }
    }
}
