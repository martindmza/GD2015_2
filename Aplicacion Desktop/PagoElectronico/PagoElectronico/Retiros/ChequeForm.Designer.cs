namespace Retiros
{
    partial class ChequeForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.clienteText = new System.Windows.Forms.Label();
            this.BancoText = new System.Windows.Forms.Label();
            this.ImporteText = new System.Windows.Forms.Label();
            this.cuentaText = new System.Windows.Forms.Label();
            this.FechaText = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(380, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Fecha:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Importe";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Banco:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(31, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Cliente:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(29, 125);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Cuenta:";
            // 
            // clienteText
            // 
            this.clienteText.AutoSize = true;
            this.clienteText.Location = new System.Drawing.Point(112, 38);
            this.clienteText.Name = "clienteText";
            this.clienteText.Size = new System.Drawing.Size(103, 13);
            this.clienteText.TabIndex = 0;
            this.clienteText.Text = "$$$$$$$$$$$$$$$$";
            // 
            // BancoText
            // 
            this.BancoText.AutoSize = true;
            this.BancoText.Location = new System.Drawing.Point(112, 67);
            this.BancoText.Name = "BancoText";
            this.BancoText.Size = new System.Drawing.Size(103, 13);
            this.BancoText.TabIndex = 0;
            this.BancoText.Text = "$$$$$$$$$$$$$$$$";
            // 
            // ImporteText
            // 
            this.ImporteText.AutoSize = true;
            this.ImporteText.Location = new System.Drawing.Point(112, 96);
            this.ImporteText.Name = "ImporteText";
            this.ImporteText.Size = new System.Drawing.Size(103, 13);
            this.ImporteText.TabIndex = 0;
            this.ImporteText.Text = "$$$$$$$$$$$$$$$$";
            // 
            // cuentaText
            // 
            this.cuentaText.AutoSize = true;
            this.cuentaText.Location = new System.Drawing.Point(112, 125);
            this.cuentaText.Name = "cuentaText";
            this.cuentaText.Size = new System.Drawing.Size(103, 13);
            this.cuentaText.TabIndex = 0;
            this.cuentaText.Text = "$$$$$$$$$$$$$$$$";
            // 
            // FechaText
            // 
            this.FechaText.AutoSize = true;
            this.FechaText.Location = new System.Drawing.Point(435, 41);
            this.FechaText.Name = "FechaText";
            this.FechaText.Size = new System.Drawing.Size(103, 13);
            this.FechaText.TabIndex = 0;
            this.FechaText.Text = "$$$$$$$$$$$$$$$$";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(206, 227);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(125, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Retirar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ChequeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 262);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.FechaText);
            this.Controls.Add(this.cuentaText);
            this.Controls.Add(this.ImporteText);
            this.Controls.Add(this.BancoText);
            this.Controls.Add(this.clienteText);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChequeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cheque";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label clienteText;
        private System.Windows.Forms.Label BancoText;
        private System.Windows.Forms.Label ImporteText;
        private System.Windows.Forms.Label cuentaText;
        private System.Windows.Forms.Label FechaText;
        private System.Windows.Forms.Button button1;
    }
}