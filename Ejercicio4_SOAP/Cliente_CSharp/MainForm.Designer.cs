namespace ClienteSEDUINFO
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.GroupBox grpConsulta;
        private System.Windows.Forms.Label lblCI;
        private System.Windows.Forms.TextBox txtCI;
        private System.Windows.Forms.Button btnDatosAcademicos;
        private System.Windows.Forms.Button btnDatosTutor;
        private System.Windows.Forms.GroupBox grpResultados;
        private System.Windows.Forms.TextBox txtResultados;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.PictureBox picLogo;

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
            this.lblTitulo = new System.Windows.Forms.Label();
            this.grpConsulta = new System.Windows.Forms.GroupBox();
            this.btnDatosTutor = new System.Windows.Forms.Button();
            this.btnDatosAcademicos = new System.Windows.Forms.Button();
            this.txtCI = new System.Windows.Forms.TextBox();
            this.lblCI = new System.Windows.Forms.Label();
            this.grpResultados = new System.Windows.Forms.GroupBox();
            this.txtResultados = new System.Windows.Forms.TextBox();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.grpConsulta.SuspendLayout();
            this.grpResultados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.SuspendLayout();

            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblTitulo.Location = new System.Drawing.Point(170, 20);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(470, 32);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "SEDUINFO - Sistema de Datos Universitarios";

            this.grpConsulta.Controls.Add(this.btnDatosTutor);
            this.grpConsulta.Controls.Add(this.btnDatosAcademicos);
            this.grpConsulta.Controls.Add(this.txtCI);
            this.grpConsulta.Controls.Add(this.lblCI);
            this.grpConsulta.Location = new System.Drawing.Point(20, 120);
            this.grpConsulta.Name = "grpConsulta";
            this.grpConsulta.Size = new System.Drawing.Size(760, 120);
            this.grpConsulta.TabIndex = 1;
            this.grpConsulta.TabStop = false;
            this.grpConsulta.Text = "Consulta de Estudiante";

            this.btnDatosTutor.BackColor = System.Drawing.Color.LightGreen;
            this.btnDatosTutor.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnDatosTutor.Location = new System.Drawing.Point(390, 45);
            this.btnDatosTutor.Name = "btnDatosTutor";
            this.btnDatosTutor.Size = new System.Drawing.Size(180, 50);
            this.btnDatosTutor.TabIndex = 3;
            this.btnDatosTutor.Text = "🎓 Datos del Tutor";
            this.btnDatosTutor.UseVisualStyleBackColor = false;
            this.btnDatosTutor.Click += new System.EventHandler(this.btnDatosTutor_Click);

            this.btnDatosAcademicos.BackColor = System.Drawing.Color.LightBlue;
            this.btnDatosAcademicos.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnDatosAcademicos.Location = new System.Drawing.Point(390, 45);
            this.btnDatosAcademicos.Name = "btnDatosAcademicos";
            this.btnDatosAcademicos.Size = new System.Drawing.Size(180, 50);
            this.btnDatosAcademicos.TabIndex = 2;
            this.btnDatosAcademicos.Text = "📚 Datos Académicos";
            this.btnDatosAcademicos.UseVisualStyleBackColor = false;
            this.btnDatosAcademicos.Click += new System.EventHandler(this.btnDatosAcademicos_Click);

            this.txtCI.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtCI.Location = new System.Drawing.Point(140, 55);
            this.txtCI.MaxLength = 10;
            this.txtCI.Name = "txtCI";
            this.txtCI.PlaceholderText = "Ej: 12345678";
            this.txtCI.Size = new System.Drawing.Size(200, 29);
            this.txtCI.TabIndex = 1;

            this.lblCI.AutoSize = true;
            this.lblCI.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblCI.Location = new System.Drawing.Point(30, 58);
            this.lblCI.Name = "lblCI";
            this.lblCI.Size = new System.Drawing.Size(104, 20);
            this.lblCI.TabIndex = 0;
            this.lblCI.Text = "CI Estudiante:";

            this.grpResultados.Controls.Add(this.txtResultados);
            this.grpResultados.Location = new System.Drawing.Point(20, 250);
            this.grpResultados.Name = "grpResultados";
            this.grpResultados.Size = new System.Drawing.Size(760, 280);
            this.grpResultados.TabIndex = 2;
            this.grpResultados.TabStop = false;
            this.grpResultados.Text = "Resultados";

            this.txtResultados.BackColor = System.Drawing.Color.White;
            this.txtResultados.Font = new System.Drawing.Font("Consolas", 10F);
            this.txtResultados.Location = new System.Drawing.Point(15, 25);
            this.txtResultados.Multiline = true;
            this.txtResultados.Name = "txtResultados";
            this.txtResultados.ReadOnly = true;
            this.txtResultados.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtResultados.Size = new System.Drawing.Size(730, 240);
            this.txtResultados.TabIndex = 0;

            this.picLogo.BackColor = System.Drawing.Color.Transparent;
            this.picLogo.Location = new System.Drawing.Point(30, 20);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(80, 80);
            this.picLogo.TabIndex = 3;
            this.picLogo.TabStop = false;

            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 550);
            this.Controls.Add(this.picLogo);
            this.Controls.Add(this.grpResultados);
            this.Controls.Add(this.grpConsulta);
            this.Controls.Add(this.lblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SEDUINFO - Cliente";
            this.grpConsulta.ResumeLayout(false);
            this.grpConsulta.PerformLayout();
            this.grpResultados.ResumeLayout(false);
            this.grpResultados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
