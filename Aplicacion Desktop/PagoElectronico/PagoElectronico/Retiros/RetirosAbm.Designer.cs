namespace Retiros
{
    partial class RetirosAbm
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
            this.label1 = new System.Windows.Forms.Label();
            this.cuentaText = new System.Windows.Forms.TextBox();
            this.trigger1 = new System.Windows.Forms.Button();
            this.label = new System.Windows.Forms.Label();
            this.dniText = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.clienteDestinoLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // importe
            // 
            this.importe.AutoSize = true;
            this.importe.Location = new System.Drawing.Point(30, 97);
            this.importe.Name = "importe";
            this.importe.Size = new System.Drawing.Size(45, 13);
            this.importe.TabIndex = 1;
            this.importe.Text = "Importe:";
            // 
            // importeText
            // 
            this.importeText.Location = new System.Drawing.Point(81, 94);
            this.importeText.Name = "importeText";
            this.importeText.Size = new System.Drawing.Size(121, 20);
            this.importeText.TabIndex = 2;
            this.importeText.TextChanged += new System.EventHandler(this.requireds_TextChanged);
            this.importeText.Leave += new System.EventHandler(this.textBox1_Leave);
            // 
            // aceptar
            // 
            this.aceptar.Location = new System.Drawing.Point(164, 174);
            this.aceptar.Name = "aceptar";
            this.aceptar.Size = new System.Drawing.Size(75, 23);
            this.aceptar.TabIndex = 4;
            this.aceptar.Text = "Confirmar";
            this.aceptar.UseVisualStyleBackColor = true;
            this.aceptar.Click += new System.EventHandler(this.aceptar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Cuenta:";
            // 
            // cuentaText
            // 
            this.cuentaText.Enabled = false;
            this.cuentaText.Location = new System.Drawing.Point(81, 26);
            this.cuentaText.Name = "cuentaText";
            this.cuentaText.Size = new System.Drawing.Size(121, 20);
            this.cuentaText.TabIndex = 2;
            this.cuentaText.TextChanged += new System.EventHandler(this.requireds_TextChanged);
            // 
            // trigger1
            // 
            this.trigger1.Location = new System.Drawing.Point(208, 26);
            this.trigger1.Name = "trigger1";
            this.trigger1.Size = new System.Drawing.Size(22, 20);
            this.trigger1.TabIndex = 5;
            this.trigger1.Text = "...";
            this.trigger1.UseVisualStyleBackColor = true;
            this.trigger1.Click += new System.EventHandler(this.trigger1_Click);
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(10, 133);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(65, 13);
            this.label.TabIndex = 1;
            this.label.Text = "Documento:";
            // 
            // dniText
            // 
            this.dniText.Location = new System.Drawing.Point(81, 131);
            this.dniText.Name = "dniText";
            this.dniText.Size = new System.Drawing.Size(121, 20);
            this.dniText.TabIndex = 2;
            this.dniText.TextChanged += new System.EventHandler(this.requireds_TextChanged);
            this.dniText.Leave += new System.EventHandler(this.textBox1_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Propietario:";
            this.label2.Visible = false;
            // 
            // clienteDestinoLabel
            // 
            this.clienteDestinoLabel.AutoSize = true;
            this.clienteDestinoLabel.Location = new System.Drawing.Point(81, 62);
            this.clienteDestinoLabel.Name = "clienteDestinoLabel";
            this.clienteDestinoLabel.Size = new System.Drawing.Size(103, 13);
            this.clienteDestinoLabel.TabIndex = 1;
            this.clienteDestinoLabel.Text = "$$$$$$$$$$$$$$$$";
            this.clienteDestinoLabel.Visible = false;
            // 
            // RetirosAbm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(251, 209);
            this.Controls.Add(this.trigger1);
            this.Controls.Add(this.aceptar);
            this.Controls.Add(this.cuentaText);
            this.Controls.Add(this.dniText);
            this.Controls.Add(this.importeText);
            this.Controls.Add(this.label);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.clienteDestinoLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.importe);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RetirosAbm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Retiro de Dinero";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label importe;
        private System.Windows.Forms.TextBox importeText;
        private System.Windows.Forms.Button aceptar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox cuentaText;
        private System.Windows.Forms.Button trigger1;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.TextBox dniText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label clienteDestinoLabel;
    }
}