namespace Tarjetas
{
    partial class TarjetasForm
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
            this.buttonAceptar = new System.Windows.Forms.Button();
            this.buttonCancelar = new System.Windows.Forms.Button();
            this.numeroText = new System.Windows.Forms.TextBox();
            this.emisorText = new System.Windows.Forms.TextBox();
            this.trigger1 = new System.Windows.Forms.Button();
            this.emisionText = new System.Windows.Forms.DateTimePicker();
            this.vencimientoText = new System.Windows.Forms.DateTimePicker();
            this.codigoSeguridadText = new System.Windows.Forms.TextBox();
            this.emisorNameLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(82, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Número:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(88, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Emisor:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(82, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Emisión:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(61, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Vencimiento:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 144);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Código de Seguridad:";
            // 
            // buttonAceptar
            // 
            this.buttonAceptar.Location = new System.Drawing.Point(373, 186);
            this.buttonAceptar.Name = "buttonAceptar";
            this.buttonAceptar.Size = new System.Drawing.Size(75, 23);
            this.buttonAceptar.TabIndex = 1;
            this.buttonAceptar.Text = "Aceptar";
            this.buttonAceptar.UseVisualStyleBackColor = true;
            this.buttonAceptar.Click += new System.EventHandler(this.buttonAceptar_Click);
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.Location = new System.Drawing.Point(292, 186);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(75, 23);
            this.buttonCancelar.TabIndex = 1;
            this.buttonCancelar.Text = "Cancelar";
            this.buttonCancelar.UseVisualStyleBackColor = true;
            this.buttonCancelar.Click += new System.EventHandler(this.buttonCancelar_Click);
            // 
            // numeroText
            // 
            this.numeroText.Location = new System.Drawing.Point(135, 14);
            this.numeroText.MaxLength = 16;
            this.numeroText.Name = "numeroText";
            this.numeroText.Size = new System.Drawing.Size(149, 20);
            this.numeroText.TabIndex = 2;
            this.numeroText.TextChanged += new System.EventHandler(this.requireds_TextChanged);
            this.numeroText.Leave += new System.EventHandler(this.numeroText_Leave);
            // 
            // emisorText
            // 
            this.emisorText.AcceptsReturn = true;
            this.emisorText.Enabled = false;
            this.emisorText.Location = new System.Drawing.Point(135, 47);
            this.emisorText.Name = "emisorText";
            this.emisorText.Size = new System.Drawing.Size(79, 20);
            this.emisorText.TabIndex = 2;
            this.emisorText.TextChanged += new System.EventHandler(this.requireds_TextChanged);
            // 
            // trigger1
            // 
            this.trigger1.Location = new System.Drawing.Point(220, 46);
            this.trigger1.Name = "trigger1";
            this.trigger1.Size = new System.Drawing.Size(24, 20);
            this.trigger1.TabIndex = 3;
            this.trigger1.Text = "...";
            this.trigger1.UseVisualStyleBackColor = true;
            this.trigger1.Click += new System.EventHandler(this.trigger1_Click);
            // 
            // emisionText
            // 
            this.emisionText.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.emisionText.Location = new System.Drawing.Point(134, 78);
            this.emisionText.Name = "emisionText";
            this.emisionText.Size = new System.Drawing.Size(102, 20);
            this.emisionText.TabIndex = 4;
            this.emisionText.ValueChanged += new System.EventHandler(this.requireds_TextChanged);
            // 
            // vencimientoText
            // 
            this.vencimientoText.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.vencimientoText.Location = new System.Drawing.Point(134, 107);
            this.vencimientoText.Name = "vencimientoText";
            this.vencimientoText.Size = new System.Drawing.Size(102, 20);
            this.vencimientoText.TabIndex = 4;
            this.vencimientoText.ValueChanged += new System.EventHandler(this.requireds_TextChanged);
            // 
            // codigoSeguridadText
            // 
            this.codigoSeguridadText.Location = new System.Drawing.Point(134, 141);
            this.codigoSeguridadText.MaxLength = 3;
            this.codigoSeguridadText.Name = "codigoSeguridadText";
            this.codigoSeguridadText.Size = new System.Drawing.Size(51, 20);
            this.codigoSeguridadText.TabIndex = 2;
            this.codigoSeguridadText.TextChanged += new System.EventHandler(this.requireds_TextChanged);
            this.codigoSeguridadText.Leave += new System.EventHandler(this.validarNumeroSeguridad);
            // 
            // emisorNameLabel
            // 
            this.emisorNameLabel.AutoSize = true;
            this.emisorNameLabel.Location = new System.Drawing.Point(250, 50);
            this.emisorNameLabel.Name = "emisorNameLabel";
            this.emisorNameLabel.Size = new System.Drawing.Size(91, 13);
            this.emisorNameLabel.TabIndex = 5;
            this.emisorNameLabel.Text = "$$$$$$$$$$$$$$";
            // 
            // TarjetasForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(454, 221);
            this.ControlBox = false;
            this.Controls.Add(this.emisorNameLabel);
            this.Controls.Add(this.vencimientoText);
            this.Controls.Add(this.emisionText);
            this.Controls.Add(this.trigger1);
            this.Controls.Add(this.emisorText);
            this.Controls.Add(this.codigoSeguridadText);
            this.Controls.Add(this.numeroText);
            this.Controls.Add(this.buttonCancelar);
            this.Controls.Add(this.buttonAceptar);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "TarjetasForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TarjetasForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonAceptar;
        private System.Windows.Forms.Button buttonCancelar;
        private System.Windows.Forms.TextBox numeroText;
        private System.Windows.Forms.TextBox emisorText;
        private System.Windows.Forms.Button trigger1;
        private System.Windows.Forms.DateTimePicker emisionText;
        private System.Windows.Forms.DateTimePicker vencimientoText;
        private System.Windows.Forms.TextBox codigoSeguridadText;
        private System.Windows.Forms.Label emisorNameLabel;
    }
}