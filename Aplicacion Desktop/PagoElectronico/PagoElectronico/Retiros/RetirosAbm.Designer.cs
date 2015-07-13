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
            this.docTipo = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.saldoLabel = new System.Windows.Forms.Label();
            this.saldoText = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.bancoText = new System.Windows.Forms.TextBox();
            this.trigger2 = new System.Windows.Forms.Button();
            this.bancoLabel = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // importe
            // 
            this.importe.AutoSize = true;
            this.importe.Location = new System.Drawing.Point(30, 100);
            this.importe.Name = "importe";
            this.importe.Size = new System.Drawing.Size(45, 13);
            this.importe.TabIndex = 1;
            this.importe.Text = "Importe:";
            // 
            // importeText
            // 
            this.importeText.Location = new System.Drawing.Point(81, 97);
            this.importeText.Name = "importeText";
            this.importeText.Size = new System.Drawing.Size(121, 20);
            this.importeText.TabIndex = 2;
            this.importeText.TextChanged += new System.EventHandler(this.requireds_TextChanged);
            this.importeText.Leave += new System.EventHandler(this.textBox1_Leave);
            // 
            // aceptar
            // 
            this.aceptar.Location = new System.Drawing.Point(155, 302);
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
            this.label.Location = new System.Drawing.Point(6, 68);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(47, 13);
            this.label.TabIndex = 1;
            this.label.Text = "Número:";
            // 
            // dniText
            // 
            this.dniText.Location = new System.Drawing.Point(60, 65);
            this.dniText.Name = "dniText";
            this.dniText.Size = new System.Drawing.Size(121, 20);
            this.dniText.TabIndex = 2;
            this.dniText.TextChanged += new System.EventHandler(this.requireds_TextChanged);
            this.dniText.Leave += new System.EventHandler(this.textBox1_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(208, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "USD";
            // 
            // docTipo
            // 
            this.docTipo.FormattingEnabled = true;
            this.docTipo.Location = new System.Drawing.Point(60, 33);
            this.docTipo.Name = "docTipo";
            this.docTipo.Size = new System.Drawing.Size(121, 21);
            this.docTipo.TabIndex = 7;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dniText);
            this.groupBox1.Controls.Add(this.docTipo);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label);
            this.groupBox1.Location = new System.Drawing.Point(21, 164);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(209, 116);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Documento";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Tipo:";
            // 
            // saldoLabel
            // 
            this.saldoLabel.AutoSize = true;
            this.saldoLabel.Location = new System.Drawing.Point(39, 62);
            this.saldoLabel.Name = "saldoLabel";
            this.saldoLabel.Size = new System.Drawing.Size(37, 13);
            this.saldoLabel.TabIndex = 9;
            this.saldoLabel.Text = "Saldo:";
            this.saldoLabel.Visible = false;
            // 
            // saldoText
            // 
            this.saldoText.AutoSize = true;
            this.saldoText.Location = new System.Drawing.Point(80, 62);
            this.saldoText.Name = "saldoText";
            this.saldoText.Size = new System.Drawing.Size(91, 13);
            this.saldoText.TabIndex = 9;
            this.saldoText.Text = "$$$$$$$$$$$$$$";
            this.saldoText.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(35, 137);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Banco:";
            // 
            // bancoText
            // 
            this.bancoText.Enabled = false;
            this.bancoText.Location = new System.Drawing.Point(81, 134);
            this.bancoText.Multiline = true;
            this.bancoText.Name = "bancoText";
            this.bancoText.Size = new System.Drawing.Size(47, 20);
            this.bancoText.TabIndex = 11;
            this.bancoText.TextChanged += new System.EventHandler(this.requireds_TextChanged);
            // 
            // trigger2
            // 
            this.trigger2.Location = new System.Drawing.Point(134, 134);
            this.trigger2.Name = "trigger2";
            this.trigger2.Size = new System.Drawing.Size(22, 20);
            this.trigger2.TabIndex = 12;
            this.trigger2.Text = "...";
            this.trigger2.UseVisualStyleBackColor = true;
            this.trigger2.Click += new System.EventHandler(this.trigger2_Click);
            // 
            // bancoLabel
            // 
            this.bancoLabel.AutoSize = true;
            this.bancoLabel.Location = new System.Drawing.Point(162, 138);
            this.bancoLabel.Name = "bancoLabel";
            this.bancoLabel.Size = new System.Drawing.Size(91, 13);
            this.bancoLabel.TabIndex = 9;
            this.bancoLabel.Text = "$$$$$$$$$$$$$$";
            this.bancoLabel.Visible = false;
            // 
            // RetirosAbm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(271, 337);
            this.Controls.Add(this.trigger2);
            this.Controls.Add(this.bancoText);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.bancoLabel);
            this.Controls.Add(this.saldoText);
            this.Controls.Add(this.saldoLabel);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.trigger1);
            this.Controls.Add(this.aceptar);
            this.Controls.Add(this.cuentaText);
            this.Controls.Add(this.importeText);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.importe);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RetirosAbm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Retiro de Dinero";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
        private System.Windows.Forms.ComboBox docTipo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label saldoLabel;
        private System.Windows.Forms.Label saldoText;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox bancoText;
        private System.Windows.Forms.Button trigger2;
        private System.Windows.Forms.Label bancoLabel;
    }
}