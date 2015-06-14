namespace Transferencias
{
    partial class TransferenciaAbm
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
            this.importe = new System.Windows.Forms.Label();
            this.importeText = new System.Windows.Forms.TextBox();
            this.aceptar = new System.Windows.Forms.Button();
            this.cuentaOrigenText = new System.Windows.Forms.TextBox();
            this.trigger1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.clienteDestinoLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.cuentaDestinoText = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.saldoLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // importe
            // 
            this.importe.AutoSize = true;
            this.importe.Location = new System.Drawing.Point(67, 186);
            this.importe.Name = "importe";
            this.importe.Size = new System.Drawing.Size(45, 13);
            this.importe.TabIndex = 1;
            this.importe.Text = "Importe:";
            // 
            // importeText
            // 
            this.importeText.Location = new System.Drawing.Point(118, 183);
            this.importeText.Name = "importeText";
            this.importeText.Size = new System.Drawing.Size(121, 20);
            this.importeText.TabIndex = 2;
            this.importeText.TextChanged += new System.EventHandler(this.requireds_TextChanged);
            this.importeText.Leave += new System.EventHandler(this.textBox1_Leave);
            // 
            // aceptar
            // 
            this.aceptar.Location = new System.Drawing.Point(190, 246);
            this.aceptar.Name = "aceptar";
            this.aceptar.Size = new System.Drawing.Size(75, 23);
            this.aceptar.TabIndex = 4;
            this.aceptar.Text = "Confirmar";
            this.aceptar.UseVisualStyleBackColor = true;
            this.aceptar.Click += new System.EventHandler(this.aceptar_Click);
            // 
            // cuentaOrigenText
            // 
            this.cuentaOrigenText.Enabled = false;
            this.cuentaOrigenText.Location = new System.Drawing.Point(116, 27);
            this.cuentaOrigenText.Name = "cuentaOrigenText";
            this.cuentaOrigenText.Size = new System.Drawing.Size(121, 20);
            this.cuentaOrigenText.TabIndex = 2;
            this.cuentaOrigenText.TextChanged += new System.EventHandler(this.requireds_TextChanged);
            // 
            // trigger1
            // 
            this.trigger1.Location = new System.Drawing.Point(243, 26);
            this.trigger1.Name = "trigger1";
            this.trigger1.Size = new System.Drawing.Size(22, 20);
            this.trigger1.TabIndex = 5;
            this.trigger1.Text = "...";
            this.trigger1.UseVisualStyleBackColor = true;
            this.trigger1.Click += new System.EventHandler(this.trigger1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(49, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Propietario:";
            this.label2.Visible = false;
            // 
            // clienteDestinoLabel
            // 
            this.clienteDestinoLabel.AutoSize = true;
            this.clienteDestinoLabel.Location = new System.Drawing.Point(115, 128);
            this.clienteDestinoLabel.Name = "clienteDestinoLabel";
            this.clienteDestinoLabel.Size = new System.Drawing.Size(103, 13);
            this.clienteDestinoLabel.TabIndex = 1;
            this.clienteDestinoLabel.Text = "$$$$$$$$$$$$$$$$";
            this.clienteDestinoLabel.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Cuenta Origen:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Cuenta Destino:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(243, 95);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(22, 20);
            this.button1.TabIndex = 5;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.trigger2_Click);
            // 
            // cuentaDestinoText
            // 
            this.cuentaDestinoText.Enabled = false;
            this.cuentaDestinoText.Location = new System.Drawing.Point(116, 96);
            this.cuentaDestinoText.Name = "cuentaDestinoText";
            this.cuentaDestinoText.Size = new System.Drawing.Size(121, 20);
            this.cuentaDestinoText.TabIndex = 2;
            this.cuentaDestinoText.TextChanged += new System.EventHandler(this.requireds_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(72, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Saldo:";
            this.label4.Visible = false;
            // 
            // saldoLabel
            // 
            this.saldoLabel.AutoSize = true;
            this.saldoLabel.Location = new System.Drawing.Point(115, 59);
            this.saldoLabel.Name = "saldoLabel";
            this.saldoLabel.Size = new System.Drawing.Size(103, 13);
            this.saldoLabel.TabIndex = 1;
            this.saldoLabel.Text = "$$$$$$$$$$$$$$$$";
            this.saldoLabel.Visible = false;
            // 
            // TransferenciaAbm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(285, 285);
            this.Controls.Add(this.cuentaDestinoText);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cuentaOrigenText);
            this.Controls.Add(this.trigger1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.aceptar);
            this.Controls.Add(this.importeText);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.saldoLabel);
            this.Controls.Add(this.clienteDestinoLabel);
            this.Controls.Add(this.importe);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TransferenciaAbm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Transferencias de Dinero";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label importe;
        private System.Windows.Forms.TextBox importeText;
        private System.Windows.Forms.Button aceptar;
        private System.Windows.Forms.TextBox cuentaOrigenText;
        private System.Windows.Forms.Button trigger1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label clienteDestinoLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox cuentaDestinoText;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label saldoLabel;
    }
}