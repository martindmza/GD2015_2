namespace PagoElectronico.Listados
{
    partial class FormEstadistico
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
            this.cbListado = new System.Windows.Forms.ComboBox();
            this.btnListar = new System.Windows.Forms.Button();
            this.dgTablaResultado = new System.Windows.Forms.DataGridView();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.cbTrimestre = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgTablaResultado)).BeginInit();
            this.SuspendLayout();
            // 
            // cbListado
            // 
            this.cbListado.FormattingEnabled = true;
            this.cbListado.Items.AddRange(new object[] {
            "Clientes que alguna de sus cuentas fueron inhabilitadas por no pagar los costos d" +
                "e transaccion",
            "Cliente con mayor cantidad de comisiones facturadas en todas sus cuentas propias",
            "Clientes con mayor cantidad de transacciones realizadas entre cuentas propias",
            "Paises con mayor cantidad de movimientos tanto ingresos como egresos",
            "Total facturado para los distintas tipos de cuentas"});
            this.cbListado.Location = new System.Drawing.Point(12, 63);
            this.cbListado.Name = "cbListado";
            this.cbListado.Size = new System.Drawing.Size(568, 21);
            this.cbListado.TabIndex = 1;
            // 
            // btnListar
            // 
            this.btnListar.Location = new System.Drawing.Point(629, 61);
            this.btnListar.Name = "btnListar";
            this.btnListar.Size = new System.Drawing.Size(108, 23);
            this.btnListar.TabIndex = 2;
            this.btnListar.Text = "Listar Seleccion";
            this.btnListar.UseVisualStyleBackColor = true;
            this.btnListar.Click += new System.EventHandler(this.btnListar_Click);
            // 
            // dgTablaResultado
            // 
            this.dgTablaResultado.AllowUserToAddRows = false;
            this.dgTablaResultado.AllowUserToDeleteRows = false;
            this.dgTablaResultado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgTablaResultado.Location = new System.Drawing.Point(12, 99);
            this.dgTablaResultado.Name = "dgTablaResultado";
            this.dgTablaResultado.ReadOnly = true;
            this.dgTablaResultado.Size = new System.Drawing.Size(725, 254);
            this.dgTablaResultado.TabIndex = 3;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "yyyy";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(332, 27);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.ShowUpDown = true;
            this.dateTimePicker1.Size = new System.Drawing.Size(63, 20);
            this.dateTimePicker1.TabIndex = 4;
            // 
            // cbTrimestre
            // 
            this.cbTrimestre.FormattingEnabled = true;
            this.cbTrimestre.Items.AddRange(new object[] {
            "1er trimestre",
            "2do trimestre",
            "3er trimestre"});
            this.cbTrimestre.Location = new System.Drawing.Point(414, 26);
            this.cbTrimestre.Name = "cbTrimestre";
            this.cbTrimestre.Size = new System.Drawing.Size(166, 21);
            this.cbTrimestre.TabIndex = 5;
            // 
            // FormEstadistico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(749, 365);
            this.Controls.Add(this.cbTrimestre);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.dgTablaResultado);
            this.Controls.Add(this.btnListar);
            this.Controls.Add(this.cbListado);
            this.Name = "FormEstadistico";
            this.Text = "Listado Estadístico";
            ((System.ComponentModel.ISupportInitialize)(this.dgTablaResultado)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbListado;
        private System.Windows.Forms.Button btnListar;
        private System.Windows.Forms.DataGridView dgTablaResultado;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.ComboBox cbTrimestre;
    }
}