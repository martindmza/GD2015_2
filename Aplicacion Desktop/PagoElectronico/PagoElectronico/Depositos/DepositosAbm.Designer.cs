namespace Depositos
{
    partial class DepositosAbm
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
            this.moneda = new System.Windows.Forms.Label();
            this.tc = new System.Windows.Forms.Label();
            this.importeText = new System.Windows.Forms.TextBox();
            this.tarjetaDeCreditoText = new System.Windows.Forms.TextBox();
            this.comboBoxMoneda = new System.Windows.Forms.ComboBox();
            this.aceptar = new System.Windows.Forms.Button();
            this.trigger2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cuentaText = new System.Windows.Forms.TextBox();
            this.trigger1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.clienteDestinoLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // importe
            // 
            this.importe.AutoSize = true;
            this.importe.Location = new System.Drawing.Point(80, 112);
            this.importe.Name = "importe";
            this.importe.Size = new System.Drawing.Size(45, 13);
            this.importe.TabIndex = 1;
            this.importe.Text = "Importe:";
            // 
            // moneda
            // 
            this.moneda.AutoSize = true;
            this.moneda.Location = new System.Drawing.Point(76, 140);
            this.moneda.Name = "moneda";
            this.moneda.Size = new System.Drawing.Size(49, 13);
            this.moneda.TabIndex = 1;
            this.moneda.Text = "Moneda:";
            // 
            // tc
            // 
            this.tc.AutoSize = true;
            this.tc.Location = new System.Drawing.Point(31, 169);
            this.tc.Name = "tc";
            this.tc.Size = new System.Drawing.Size(94, 13);
            this.tc.TabIndex = 1;
            this.tc.Text = "Tarjeta de Crédito:";
            // 
            // importeText
            // 
            this.importeText.Location = new System.Drawing.Point(131, 109);
            this.importeText.Name = "importeText";
            this.importeText.Size = new System.Drawing.Size(100, 20);
            this.importeText.TabIndex = 2;
            this.importeText.TextChanged += new System.EventHandler(this.requireds_TextChanged);
            this.importeText.Leave += new System.EventHandler(this.textBox1_Leave);
            // 
            // tarjetaDeCreditoText
            // 
            this.tarjetaDeCreditoText.Enabled = false;
            this.tarjetaDeCreditoText.Location = new System.Drawing.Point(131, 169);
            this.tarjetaDeCreditoText.Name = "tarjetaDeCreditoText";
            this.tarjetaDeCreditoText.Size = new System.Drawing.Size(121, 20);
            this.tarjetaDeCreditoText.TabIndex = 2;
            this.tarjetaDeCreditoText.TextChanged += new System.EventHandler(this.requireds_TextChanged);
            // 
            // comboBoxMoneda
            // 
            this.comboBoxMoneda.FormattingEnabled = true;
            this.comboBoxMoneda.Location = new System.Drawing.Point(131, 137);
            this.comboBoxMoneda.Name = "comboBoxMoneda";
            this.comboBoxMoneda.Size = new System.Drawing.Size(100, 21);
            this.comboBoxMoneda.TabIndex = 3;
            // 
            // aceptar
            // 
            this.aceptar.Location = new System.Drawing.Point(266, 210);
            this.aceptar.Name = "aceptar";
            this.aceptar.Size = new System.Drawing.Size(75, 23);
            this.aceptar.TabIndex = 4;
            this.aceptar.Text = "Confirmar";
            this.aceptar.UseVisualStyleBackColor = true;
            this.aceptar.Click += new System.EventHandler(this.aceptar_Click);
            // 
            // trigger2
            // 
            this.trigger2.Location = new System.Drawing.Point(258, 169);
            this.trigger2.Name = "trigger2";
            this.trigger2.Size = new System.Drawing.Size(22, 20);
            this.trigger2.TabIndex = 5;
            this.trigger2.Text = "...";
            this.trigger2.UseVisualStyleBackColor = true;
            this.trigger2.Click += new System.EventHandler(this.trigger2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(81, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Cuenta:";
            // 
            // cuentaText
            // 
            this.cuentaText.Enabled = false;
            this.cuentaText.Location = new System.Drawing.Point(131, 30);
            this.cuentaText.Name = "cuentaText";
            this.cuentaText.Size = new System.Drawing.Size(121, 20);
            this.cuentaText.TabIndex = 2;
            this.cuentaText.TextChanged += new System.EventHandler(this.requireds_TextChanged);
            // 
            // trigger1
            // 
            this.trigger1.Location = new System.Drawing.Point(258, 30);
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
            this.label2.Location = new System.Drawing.Point(81, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Cliente Destino:";
            this.label2.Visible = false;
            // 
            // clienteDestinoLabel
            // 
            this.clienteDestinoLabel.AutoSize = true;
            this.clienteDestinoLabel.Location = new System.Drawing.Point(168, 74);
            this.clienteDestinoLabel.Name = "clienteDestinoLabel";
            this.clienteDestinoLabel.Size = new System.Drawing.Size(103, 13);
            this.clienteDestinoLabel.TabIndex = 1;
            this.clienteDestinoLabel.Text = "$$$$$$$$$$$$$$$$";
            this.clienteDestinoLabel.Visible = false;
            // 
            // DepositosAbm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(353, 246);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.trigger1);
            this.Controls.Add(this.trigger2);
            this.Controls.Add(this.aceptar);
            this.Controls.Add(this.comboBoxMoneda);
            this.Controls.Add(this.cuentaText);
            this.Controls.Add(this.tarjetaDeCreditoText);
            this.Controls.Add(this.importeText);
            this.Controls.Add(this.tc);
            this.Controls.Add(this.moneda);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.clienteDestinoLabel);
            this.Controls.Add(this.importe);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DepositosAbm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nuevo Depósito";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label importe;
        private System.Windows.Forms.Label moneda;
        private System.Windows.Forms.Label tc;
        private System.Windows.Forms.TextBox importeText;
        private System.Windows.Forms.TextBox tarjetaDeCreditoText;
        private System.Windows.Forms.ComboBox comboBoxMoneda;
        private System.Windows.Forms.Button aceptar;
        private System.Windows.Forms.Button trigger2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox cuentaText;
        private System.Windows.Forms.Button trigger1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label clienteDestinoLabel;
    }
}