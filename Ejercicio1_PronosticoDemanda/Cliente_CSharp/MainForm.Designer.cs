namespace PronosticoDemandaCliente
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.GroupBox grpTipoAPI;
        private System.Windows.Forms.RadioButton rbREST;
        private System.Windows.Forms.RadioButton rbGraphQL;
        private System.Windows.Forms.GroupBox grpOperaciones;
        private System.Windows.Forms.Button btnListar;
        private System.Windows.Forms.Button btnObtener;
        private System.Windows.Forms.Button btnCrear;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.GroupBox grpDatos;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.TextBox txtFecha;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.NumericUpDown numCantidad;
        private System.Windows.Forms.DataGridView dgvPronosticos;
        private System.Windows.Forms.TextBox txtResultado;
        private System.Windows.Forms.Label lblResultado;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.grpTipoAPI = new System.Windows.Forms.GroupBox();
            this.rbGraphQL = new System.Windows.Forms.RadioButton();
            this.rbREST = new System.Windows.Forms.RadioButton();
            this.grpOperaciones = new System.Windows.Forms.GroupBox();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnCrear = new System.Windows.Forms.Button();
            this.btnObtener = new System.Windows.Forms.Button();
            this.btnListar = new System.Windows.Forms.Button();
            this.grpDatos = new System.Windows.Forms.GroupBox();
            this.numCantidad = new System.Windows.Forms.NumericUpDown();
            this.txtFecha = new System.Windows.Forms.TextBox();
            this.txtId = new System.Windows.Forms.TextBox();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.lblId = new System.Windows.Forms.Label();
            this.dgvPronosticos = new System.Windows.Forms.DataGridView();
            this.lblResultado = new System.Windows.Forms.Label();
            this.txtResultado = new System.Windows.Forms.TextBox();
            this.grpTipoAPI.SuspendLayout();
            this.grpOperaciones.SuspendLayout();
            this.grpDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCantidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPronosticos)).BeginInit();
            this.SuspendLayout();

            this.grpTipoAPI.Controls.Add(this.rbGraphQL);
            this.grpTipoAPI.Controls.Add(this.rbREST);
            this.grpTipoAPI.Location = new System.Drawing.Point(12, 12);
            this.grpTipoAPI.Name = "grpTipoAPI";
            this.grpTipoAPI.Size = new System.Drawing.Size(200, 80);
            this.grpTipoAPI.TabIndex = 0;
            this.grpTipoAPI.TabStop = false;
            this.grpTipoAPI.Text = "Tipo de API";

            this.rbGraphQL.AutoSize = true;
            this.rbGraphQL.Location = new System.Drawing.Point(20, 50);
            this.rbGraphQL.Name = "rbGraphQL";
            this.rbGraphQL.Size = new System.Drawing.Size(73, 19);
            this.rbGraphQL.TabIndex = 1;
            this.rbGraphQL.Text = "GraphQL";
            this.rbGraphQL.UseVisualStyleBackColor = true;

            this.rbREST.AutoSize = true;
            this.rbREST.Checked = true;
            this.rbREST.Location = new System.Drawing.Point(20, 25);
            this.rbREST.Name = "rbREST";
            this.rbREST.Size = new System.Drawing.Size(51, 19);
            this.rbREST.TabIndex = 0;
            this.rbREST.TabStop = true;
            this.rbREST.Text = "REST";
            this.rbREST.UseVisualStyleBackColor = true;

            this.grpOperaciones.Controls.Add(this.btnEliminar);
            this.grpOperaciones.Controls.Add(this.btnActualizar);
            this.grpOperaciones.Controls.Add(this.btnCrear);
            this.grpOperaciones.Controls.Add(this.btnObtener);
            this.grpOperaciones.Controls.Add(this.btnListar);
            this.grpOperaciones.Location = new System.Drawing.Point(230, 12);
            this.grpOperaciones.Name = "grpOperaciones";
            this.grpOperaciones.Size = new System.Drawing.Size(550, 80);
            this.grpOperaciones.TabIndex = 1;
            this.grpOperaciones.TabStop = false;
            this.grpOperaciones.Text = "Operaciones";

            this.btnEliminar.Location = new System.Drawing.Point(440, 30);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(100, 35);
            this.btnEliminar.TabIndex = 4;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);

            this.btnActualizar.Location = new System.Drawing.Point(330, 30);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(100, 35);
            this.btnActualizar.TabIndex = 3;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);

            this.btnCrear.Location = new System.Drawing.Point(220, 30);
            this.btnCrear.Name = "btnCrear";
            this.btnCrear.Size = new System.Drawing.Size(100, 35);
            this.btnCrear.TabIndex = 2;
            this.btnCrear.Text = "Crear";
            this.btnCrear.UseVisualStyleBackColor = true;
            this.btnCrear.Click += new System.EventHandler(this.btnCrear_Click);

            this.btnObtener.Location = new System.Drawing.Point(110, 30);
            this.btnObtener.Name = "btnObtener";
            this.btnObtener.Size = new System.Drawing.Size(100, 35);
            this.btnObtener.TabIndex = 1;
            this.btnObtener.Text = "Obtener por ID";
            this.btnObtener.UseVisualStyleBackColor = true;
            this.btnObtener.Click += new System.EventHandler(this.btnObtener_Click);

            this.btnListar.Location = new System.Drawing.Point(10, 30);
            this.btnListar.Name = "btnListar";
            this.btnListar.Size = new System.Drawing.Size(90, 35);
            this.btnListar.TabIndex = 0;
            this.btnListar.Text = "Listar Todos";
            this.btnListar.UseVisualStyleBackColor = true;
            this.btnListar.Click += new System.EventHandler(this.btnListar_Click);

            this.grpDatos.Controls.Add(this.numCantidad);
            this.grpDatos.Controls.Add(this.txtFecha);
            this.grpDatos.Controls.Add(this.txtId);
            this.grpDatos.Controls.Add(this.lblCantidad);
            this.grpDatos.Controls.Add(this.lblFecha);
            this.grpDatos.Controls.Add(this.lblId);
            this.grpDatos.Location = new System.Drawing.Point(12, 100);
            this.grpDatos.Name = "grpDatos";
            this.grpDatos.Size = new System.Drawing.Size(768, 80);
            this.grpDatos.TabIndex = 2;
            this.grpDatos.TabStop = false;
            this.grpDatos.Text = "Datos del Pronóstico";

            this.numCantidad.Location = new System.Drawing.Point(570, 35);
            this.numCantidad.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            this.numCantidad.Name = "numCantidad";
            this.numCantidad.Size = new System.Drawing.Size(180, 23);
            this.numCantidad.TabIndex = 5;

            this.txtFecha.Location = new System.Drawing.Point(290, 35);
            this.txtFecha.Name = "txtFecha";
            this.txtFecha.PlaceholderText = "DD-MM-YY";
            this.txtFecha.Size = new System.Drawing.Size(180, 23);
            this.txtFecha.TabIndex = 4;

            this.txtId.Location = new System.Drawing.Point(80, 35);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(100, 23);
            this.txtId.TabIndex = 3;

            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Location = new System.Drawing.Point(490, 38);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(58, 15);
            this.lblCantidad.TabIndex = 2;
            this.lblCantidad.Text = "Cantidad:";

            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(230, 38);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(41, 15);
            this.lblFecha.TabIndex = 1;
            this.lblFecha.Text = "Fecha:";

            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(20, 38);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(21, 15);
            this.lblId.TabIndex = 0;
            this.lblId.Text = "ID:";

            this.dgvPronosticos.AllowUserToAddRows = false;
            this.dgvPronosticos.AllowUserToDeleteRows = false;
            this.dgvPronosticos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPronosticos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPronosticos.Location = new System.Drawing.Point(12, 190);
            this.dgvPronosticos.MultiSelect = false;
            this.dgvPronosticos.Name = "dgvPronosticos";
            this.dgvPronosticos.ReadOnly = true;
            this.dgvPronosticos.RowTemplate.Height = 25;
            this.dgvPronosticos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPronosticos.Size = new System.Drawing.Size(768, 200);
            this.dgvPronosticos.TabIndex = 3;

            this.lblResultado.AutoSize = true;
            this.lblResultado.Location = new System.Drawing.Point(12, 400);
            this.lblResultado.Name = "lblResultado";
            this.lblResultado.Size = new System.Drawing.Size(62, 15);
            this.lblResultado.TabIndex = 4;
            this.lblResultado.Text = "Resultado:";

            this.txtResultado.BackColor = System.Drawing.Color.White;
            this.txtResultado.Location = new System.Drawing.Point(12, 420);
            this.txtResultado.Multiline = true;
            this.txtResultado.Name = "txtResultado";
            this.txtResultado.ReadOnly = true;
            this.txtResultado.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtResultado.Size = new System.Drawing.Size(768, 80);
            this.txtResultado.TabIndex = 5;

            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 511);
            this.Controls.Add(this.txtResultado);
            this.Controls.Add(this.lblResultado);
            this.Controls.Add(this.dgvPronosticos);
            this.Controls.Add(this.grpDatos);
            this.Controls.Add(this.grpOperaciones);
            this.Controls.Add(this.grpTipoAPI);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pronóstico de Demanda - Cliente";
            this.grpTipoAPI.ResumeLayout(false);
            this.grpTipoAPI.PerformLayout();
            this.grpOperaciones.ResumeLayout(false);
            this.grpDatos.ResumeLayout(false);
            this.grpDatos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCantidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPronosticos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
