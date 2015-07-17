namespace ABM
{
    partial class CuentaForm
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
            this.clienteText = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.numero = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pais = new System.Windows.Forms.Label();
            this.paisText = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.moneda = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tipoCuenta = new System.Windows.Forms.ComboBox();
            this.apertura = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.cancelar = new System.Windows.Forms.Button();
            this.aceptar = new System.Windows.Forms.Button();
            this.estadoLabel = new System.Windows.Forms.Label();
            this.estadoText = new System.Windows.Forms.TextBox();
            this.clienteNameLabel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(64, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cliente:";
            // 
            // clienteText
            // 
            this.clienteText.Enabled = false;
            this.clienteText.Location = new System.Drawing.Point(112, 26);
            this.clienteText.Name = "clienteText";
            this.clienteText.Size = new System.Drawing.Size(90, 20);
            this.clienteText.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(208, 26);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(25, 20);
            this.button1.TabIndex = 2;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // numero
            // 
            this.numero.Enabled = false;
            this.numero.Location = new System.Drawing.Point(112, 84);
            this.numero.Name = "numero";
            this.numero.Size = new System.Drawing.Size(76, 20);
            this.numero.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(74, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "País:";
            // 
            // pais
            // 
            this.pais.Location = new System.Drawing.Point(0, 0);
            this.pais.Name = "pais";
            this.pais.Size = new System.Drawing.Size(100, 23);
            this.pais.TabIndex = 9;
            // 
            // paisText
            // 
            this.paisText.Enabled = false;
            this.paisText.Location = new System.Drawing.Point(112, 112);
            this.paisText.Name = "paisText";
            this.paisText.Size = new System.Drawing.Size(121, 20);
            this.paisText.TabIndex = 1;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(239, 112);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(25, 20);
            this.button2.TabIndex = 2;
            this.button2.Text = "...";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(57, 145);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Moneda:";
            // 
            // moneda
            // 
            this.moneda.FormattingEnabled = true;
            this.moneda.Location = new System.Drawing.Point(112, 142);
            this.moneda.Name = "moneda";
            this.moneda.Size = new System.Drawing.Size(121, 21);
            this.moneda.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(75, 203);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Tipo:";
            // 
            // tipoCuenta
            // 
            this.tipoCuenta.FormattingEnabled = true;
            this.tipoCuenta.Location = new System.Drawing.Point(112, 203);
            this.tipoCuenta.Name = "tipoCuenta";
            this.tipoCuenta.Size = new System.Drawing.Size(121, 21);
            this.tipoCuenta.TabIndex = 3;
            // 
            // apertura
            // 
            this.apertura.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.apertura.Location = new System.Drawing.Point(112, 174);
            this.apertura.Name = "apertura";
            this.apertura.Size = new System.Drawing.Size(121, 20);
            this.apertura.TabIndex = 4;
            this.apertura.Value = new System.DateTime(2015, 6, 10, 14, 55, 33, 0);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 176);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Fecha de Apertura:";
            // 
            // cancelar
            // 
            this.cancelar.Location = new System.Drawing.Point(202, 245);
            this.cancelar.Name = "cancelar";
            this.cancelar.Size = new System.Drawing.Size(75, 23);
            this.cancelar.TabIndex = 5;
            this.cancelar.Text = "Cancelar";
            this.cancelar.UseVisualStyleBackColor = true;
            this.cancelar.Click += new System.EventHandler(this.cancelar_Click);
            // 
            // aceptar
            // 
            this.aceptar.Location = new System.Drawing.Point(283, 245);
            this.aceptar.Name = "aceptar";
            this.aceptar.Size = new System.Drawing.Size(75, 23);
            this.aceptar.TabIndex = 5;
            this.aceptar.Text = "Aceptar";
            this.aceptar.UseVisualStyleBackColor = true;
            this.aceptar.Click += new System.EventHandler(this.aceptar_Click);
            // 
            // estadoLabel
            // 
            this.estadoLabel.AutoSize = true;
            this.estadoLabel.Location = new System.Drawing.Point(63, 58);
            this.estadoLabel.Name = "estadoLabel";
            this.estadoLabel.Size = new System.Drawing.Size(43, 13);
            this.estadoLabel.TabIndex = 6;
            this.estadoLabel.Text = "Estado:";
            // 
            // estadoText
            // 
            this.estadoText.Enabled = false;
            this.estadoText.Location = new System.Drawing.Point(112, 55);
            this.estadoText.Name = "estadoText";
            this.estadoText.Size = new System.Drawing.Size(121, 20);
            this.estadoText.TabIndex = 7;
            // 
            // clienteNameLabel
            // 
            this.clienteNameLabel.AutoSize = true;
            this.clienteNameLabel.Location = new System.Drawing.Point(239, 30);
            this.clienteNameLabel.Name = "clienteNameLabel";
            this.clienteNameLabel.Size = new System.Drawing.Size(91, 13);
            this.clienteNameLabel.TabIndex = 8;
            this.clienteNameLabel.Text = "$$$$$$$$$$$$$$";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(59, 87);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Número:";
            // 
            // CuentaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 273);
            this.ControlBox = false;
            this.Controls.Add(this.label5);
            this.Controls.Add(this.clienteNameLabel);
            this.Controls.Add(this.estadoText);
            this.Controls.Add(this.estadoLabel);
            this.Controls.Add(this.aceptar);
            this.Controls.Add(this.cancelar);
            this.Controls.Add(this.apertura);
            this.Controls.Add(this.tipoCuenta);
            this.Controls.Add(this.moneda);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.paisText);
            this.Controls.Add(this.numero);
            this.Controls.Add(this.clienteText);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pais);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CuentaForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "$$$$$$$$$$$$$$$";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox clienteText;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox numero;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label paisLabel;
        private System.Windows.Forms.TextBox paisText;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox moneda;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox tipoCuenta;
        private System.Windows.Forms.DateTimePicker apertura;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button cancelar;
        private System.Windows.Forms.Button aceptar;
        private System.Windows.Forms.Label estadoLabel;
        private System.Windows.Forms.TextBox estadoText;
        private System.Windows.Forms.Label clienteNameLabel;
        private System.Windows.Forms.Label pais;
        private System.Windows.Forms.Label label5;
    }
}