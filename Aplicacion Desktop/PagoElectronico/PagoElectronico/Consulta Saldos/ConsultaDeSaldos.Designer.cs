namespace ABM
{
    partial class ConsultaDeSaldos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.buttonBuscar = new System.Windows.Forms.Button();
            this.cuentaText = new System.Windows.Forms.TextBox();
            this.labelPropietario = new System.Windows.Forms.Label();
            this.labelPropietarioText = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabDepositos = new System.Windows.Forms.TabPage();
            this.dataGridViewDepositos = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Depositante = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.importe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Moneda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tarjeta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabRetiros = new System.Windows.Forms.TabPage();
            this.dataGridViewRetiros = new System.Windows.Forms.DataGridView();
            this.id2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.importe2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Moneda2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cheque = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.banco2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabTransferencias = new System.Windows.Forms.TabPage();
            this.dataGridViewTransferencias = new System.Windows.Forms.DataGridView();
            this.labelSaldo = new System.Windows.Forms.Label();
            this.labelSaldoText = new System.Windows.Forms.Label();
            this.id3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cuentaOrigen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.destino = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.importe3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.moneda3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1.SuspendLayout();
            this.tabDepositos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDepositos)).BeginInit();
            this.tabRetiros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRetiros)).BeginInit();
            this.tabTransferencias.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTransferencias)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cuenta:";
            // 
            // buttonBuscar
            // 
            this.buttonBuscar.Location = new System.Drawing.Point(198, 10);
            this.buttonBuscar.Name = "buttonBuscar";
            this.buttonBuscar.Size = new System.Drawing.Size(75, 23);
            this.buttonBuscar.TabIndex = 1;
            this.buttonBuscar.Text = "Buscar";
            this.buttonBuscar.UseVisualStyleBackColor = true;
            this.buttonBuscar.Click += new System.EventHandler(this.buttonBuscar_Click);
            // 
            // cuentaText
            // 
            this.cuentaText.Enabled = false;
            this.cuentaText.Location = new System.Drawing.Point(65, 12);
            this.cuentaText.Name = "cuentaText";
            this.cuentaText.Size = new System.Drawing.Size(127, 20);
            this.cuentaText.TabIndex = 2;
            // 
            // labelPropietario
            // 
            this.labelPropietario.AutoSize = true;
            this.labelPropietario.Location = new System.Drawing.Point(292, 15);
            this.labelPropietario.Name = "labelPropietario";
            this.labelPropietario.Size = new System.Drawing.Size(60, 13);
            this.labelPropietario.TabIndex = 3;
            this.labelPropietario.Text = "Propietario:";
            this.labelPropietario.Visible = false;
            // 
            // labelPropietarioText
            // 
            this.labelPropietarioText.AutoSize = true;
            this.labelPropietarioText.Location = new System.Drawing.Point(358, 15);
            this.labelPropietarioText.Name = "labelPropietarioText";
            this.labelPropietarioText.Size = new System.Drawing.Size(97, 13);
            this.labelPropietarioText.TabIndex = 3;
            this.labelPropietarioText.Text = "$$$$$$$$$$$$$$$";
            this.labelPropietarioText.Visible = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabDepositos);
            this.tabControl1.Controls.Add(this.tabRetiros);
            this.tabControl1.Controls.Add(this.tabTransferencias);
            this.tabControl1.Location = new System.Drawing.Point(12, 51);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(664, 366);
            this.tabControl1.TabIndex = 4;
            // 
            // tabDepositos
            // 
            this.tabDepositos.Controls.Add(this.dataGridViewDepositos);
            this.tabDepositos.Location = new System.Drawing.Point(4, 22);
            this.tabDepositos.Name = "tabDepositos";
            this.tabDepositos.Padding = new System.Windows.Forms.Padding(3);
            this.tabDepositos.Size = new System.Drawing.Size(656, 340);
            this.tabDepositos.TabIndex = 0;
            this.tabDepositos.Text = "Depósitos";
            this.tabDepositos.UseVisualStyleBackColor = true;
            // 
            // dataGridViewDepositos
            // 
            this.dataGridViewDepositos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDepositos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.Depositante,
            this.importe,
            this.Moneda,
            this.Tarjeta,
            this.Fecha});
            this.dataGridViewDepositos.Location = new System.Drawing.Point(6, 6);
            this.dataGridViewDepositos.Name = "dataGridViewDepositos";
            this.dataGridViewDepositos.Size = new System.Drawing.Size(643, 328);
            this.dataGridViewDepositos.TabIndex = 0;
            // 
            // id
            // 
            this.id.HeaderText = "Id";
            this.id.Name = "id";
            // 
            // Depositante
            // 
            this.Depositante.HeaderText = "Depositante";
            this.Depositante.Name = "Depositante";
            // 
            // importe
            // 
            this.importe.HeaderText = "Importe";
            this.importe.Name = "importe";
            // 
            // Moneda
            // 
            this.Moneda.HeaderText = "Moneda";
            this.Moneda.Name = "Moneda";
            // 
            // Tarjeta
            // 
            this.Tarjeta.HeaderText = "Tarjeta";
            this.Tarjeta.Name = "Tarjeta";
            // 
            // Fecha
            // 
            this.Fecha.HeaderText = "Fecha";
            this.Fecha.Name = "Fecha";
            // 
            // tabRetiros
            // 
            this.tabRetiros.Controls.Add(this.dataGridViewRetiros);
            this.tabRetiros.Location = new System.Drawing.Point(4, 22);
            this.tabRetiros.Name = "tabRetiros";
            this.tabRetiros.Padding = new System.Windows.Forms.Padding(3);
            this.tabRetiros.Size = new System.Drawing.Size(656, 340);
            this.tabRetiros.TabIndex = 1;
            this.tabRetiros.Text = "Retiros";
            this.tabRetiros.UseVisualStyleBackColor = true;
            // 
            // dataGridViewRetiros
            // 
            this.dataGridViewRetiros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewRetiros.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id2,
            this.importe2,
            this.Moneda2,
            this.fecha2,
            this.cheque,
            this.banco2});
            this.dataGridViewRetiros.Location = new System.Drawing.Point(6, 6);
            this.dataGridViewRetiros.Name = "dataGridViewRetiros";
            this.dataGridViewRetiros.Size = new System.Drawing.Size(644, 328);
            this.dataGridViewRetiros.TabIndex = 0;
            // 
            // id2
            // 
            this.id2.HeaderText = "Id";
            this.id2.Name = "id2";
            // 
            // importe2
            // 
            this.importe2.HeaderText = "Importe";
            this.importe2.Name = "importe2";
            // 
            // Moneda2
            // 
            this.Moneda2.HeaderText = "Moneda";
            this.Moneda2.Name = "Moneda2";
            // 
            // fecha2
            // 
            this.fecha2.HeaderText = "Fecha";
            this.fecha2.Name = "fecha2";
            // 
            // cheque
            // 
            this.cheque.HeaderText = "Cheque";
            this.cheque.Name = "cheque";
            // 
            // banco2
            // 
            this.banco2.HeaderText = "Banco";
            this.banco2.Name = "banco2";
            // 
            // tabTransferencias
            // 
            this.tabTransferencias.Controls.Add(this.dataGridViewTransferencias);
            this.tabTransferencias.Location = new System.Drawing.Point(4, 22);
            this.tabTransferencias.Name = "tabTransferencias";
            this.tabTransferencias.Size = new System.Drawing.Size(656, 340);
            this.tabTransferencias.TabIndex = 2;
            this.tabTransferencias.Text = "Transferencias";
            this.tabTransferencias.UseVisualStyleBackColor = true;
            // 
            // dataGridViewTransferencias
            // 
            this.dataGridViewTransferencias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTransferencias.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id3,
            this.cuentaOrigen,
            this.destino,
            this.importe3,
            this.moneda3,
            this.fecha3});
            this.dataGridViewTransferencias.Location = new System.Drawing.Point(6, 6);
            this.dataGridViewTransferencias.Name = "dataGridViewTransferencias";
            this.dataGridViewTransferencias.Size = new System.Drawing.Size(647, 331);
            this.dataGridViewTransferencias.TabIndex = 0;
            // 
            // labelSaldo
            // 
            this.labelSaldo.AutoSize = true;
            this.labelSaldo.Location = new System.Drawing.Point(482, 15);
            this.labelSaldo.Name = "labelSaldo";
            this.labelSaldo.Size = new System.Drawing.Size(37, 13);
            this.labelSaldo.TabIndex = 3;
            this.labelSaldo.Text = "Saldo:";
            this.labelSaldo.Visible = false;
            // 
            // labelSaldoText
            // 
            this.labelSaldoText.AutoSize = true;
            this.labelSaldoText.Location = new System.Drawing.Point(525, 15);
            this.labelSaldoText.Name = "labelSaldoText";
            this.labelSaldoText.Size = new System.Drawing.Size(97, 13);
            this.labelSaldoText.TabIndex = 3;
            this.labelSaldoText.Text = "$$$$$$$$$$$$$$$";
            this.labelSaldoText.Visible = false;
            // 
            // id3
            // 
            this.id3.HeaderText = "Id";
            this.id3.Name = "id3";
            // 
            // cuentaOrigen
            // 
            this.cuentaOrigen.HeaderText = "Origen";
            this.cuentaOrigen.Name = "cuentaOrigen";
            // 
            // destino
            // 
            this.destino.HeaderText = "Destino";
            this.destino.Name = "destino";
            // 
            // importe3
            // 
            this.importe3.HeaderText = "Importe";
            this.importe3.Name = "importe3";
            // 
            // moneda3
            // 
            this.moneda3.HeaderText = "Moneda";
            this.moneda3.Name = "moneda3";
            // 
            // fecha3
            // 
            this.fecha3.HeaderText = "Fecha";
            this.fecha3.Name = "fecha3";
            // 
            // ConsultaDeSaldos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 429);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.labelSaldoText);
            this.Controls.Add(this.labelPropietarioText);
            this.Controls.Add(this.labelSaldo);
            this.Controls.Add(this.labelPropietario);
            this.Controls.Add(this.cuentaText);
            this.Controls.Add(this.buttonBuscar);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConsultaDeSaldos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ConsultaDeSaldos";
            this.tabControl1.ResumeLayout(false);
            this.tabDepositos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDepositos)).EndInit();
            this.tabRetiros.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRetiros)).EndInit();
            this.tabTransferencias.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTransferencias)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonBuscar;
        private System.Windows.Forms.TextBox cuentaText;
        private System.Windows.Forms.Label labelPropietario;
        private System.Windows.Forms.Label labelPropietarioText;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabDepositos;
        private System.Windows.Forms.TabPage tabRetiros;
        private System.Windows.Forms.TabPage tabTransferencias;
        private System.Windows.Forms.DataGridView dataGridViewDepositos;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Depositante;
        private System.Windows.Forms.DataGridViewTextBoxColumn importe;
        private System.Windows.Forms.DataGridViewTextBoxColumn Moneda;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tarjeta;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.Label labelSaldo;
        private System.Windows.Forms.Label labelSaldoText;
        private System.Windows.Forms.DataGridView dataGridViewRetiros;
        private System.Windows.Forms.DataGridViewTextBoxColumn id2;
        private System.Windows.Forms.DataGridViewTextBoxColumn importe2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Moneda2;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha2;
        private System.Windows.Forms.DataGridViewTextBoxColumn cheque;
        private System.Windows.Forms.DataGridViewTextBoxColumn banco2;
        private System.Windows.Forms.DataGridView dataGridViewTransferencias;
        private System.Windows.Forms.DataGridViewTextBoxColumn id3;
        private System.Windows.Forms.DataGridViewTextBoxColumn cuentaOrigen;
        private System.Windows.Forms.DataGridViewTextBoxColumn destino;
        private System.Windows.Forms.DataGridViewTextBoxColumn importe3;
        private System.Windows.Forms.DataGridViewTextBoxColumn moneda3;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha3;
    }
}