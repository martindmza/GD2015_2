namespace Facturacion
{
    partial class FacturaForm
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
            this.buttonAcpetar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.importe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cuenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.fechaText = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.clienteText = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.totalText = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonAcpetar
            // 
            this.buttonAcpetar.Location = new System.Drawing.Point(524, 346);
            this.buttonAcpetar.Name = "buttonAcpetar";
            this.buttonAcpetar.Size = new System.Drawing.Size(88, 23);
            this.buttonAcpetar.TabIndex = 5;
            this.buttonAcpetar.Text = "Aceptar";
            this.buttonAcpetar.UseVisualStyleBackColor = true;
            this.buttonAcpetar.Click += new System.EventHandler(this.buttonAcpetar_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.Highlight;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(9, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(603, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "Operaciones a Facturar";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // fecha
            // 
            this.fecha.HeaderText = "Fecha";
            this.fecha.Name = "fecha";
            this.fecha.ReadOnly = true;
            // 
            // importe
            // 
            this.importe.HeaderText = "Importe";
            this.importe.Name = "importe";
            this.importe.ReadOnly = true;
            // 
            // tipo
            // 
            this.tipo.HeaderText = "Tipo";
            this.tipo.Name = "tipo";
            this.tipo.ReadOnly = true;
            // 
            // cuenta
            // 
            this.cuenta.HeaderText = "Cuenta";
            this.cuenta.Name = "cuenta";
            this.cuenta.ReadOnly = true;
            this.cuenta.Width = 160;
            // 
            // id
            // 
            this.id.HeaderText = "Código";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.cuenta,
            this.tipo,
            this.importe,
            this.fecha});
            this.dataGridView1.Enabled = false;
            this.dataGridView1.Location = new System.Drawing.Point(9, 74);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(603, 257);
            this.dataGridView1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(446, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Fecha:";
            // 
            // fechaText
            // 
            this.fechaText.AutoSize = true;
            this.fechaText.Location = new System.Drawing.Point(492, 27);
            this.fechaText.Name = "fechaText";
            this.fechaText.Size = new System.Drawing.Size(97, 13);
            this.fechaText.TabIndex = 6;
            this.fechaText.Text = "$$$$$$$$$$$$$$$";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 27);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Cliente:";
            // 
            // clienteText
            // 
            this.clienteText.AutoSize = true;
            this.clienteText.Location = new System.Drawing.Point(58, 27);
            this.clienteText.Name = "clienteText";
            this.clienteText.Size = new System.Drawing.Size(97, 13);
            this.clienteText.TabIndex = 6;
            this.clienteText.Text = "$$$$$$$$$$$$$$$";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 346);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Total:";
            // 
            // totalText
            // 
            this.totalText.AutoSize = true;
            this.totalText.Location = new System.Drawing.Point(58, 346);
            this.totalText.Name = "totalText";
            this.totalText.Size = new System.Drawing.Size(97, 13);
            this.totalText.TabIndex = 6;
            this.totalText.Text = "$$$$$$$$$$$$$$$";
            // 
            // FacturaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 384);
            this.Controls.Add(this.fechaText);
            this.Controls.Add(this.totalText);
            this.Controls.Add(this.clienteText);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonAcpetar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FacturaForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Factura";
            this.Leave += new System.EventHandler(this.FacturaForm_Leave);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonAcpetar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn importe;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn cuenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label fechaText;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label clienteText;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label totalText;

    }
}