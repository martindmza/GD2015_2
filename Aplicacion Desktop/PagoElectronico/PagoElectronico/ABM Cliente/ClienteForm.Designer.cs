namespace ABM
{
    partial class ClienteForm
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
            this.docNumero = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.docTipo = new System.Windows.Forms.ComboBox();
            this.apellido = new System.Windows.Forms.TextBox();
            this.nombre = new System.Windows.Forms.TextBox();
            this.nacionalidadText = new System.Windows.Forms.TextBox();
            this.domNumero = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label21 = new System.Windows.Forms.Label();
            this.button6 = new System.Windows.Forms.Button();
            this.paisText = new System.Windows.Forms.TextBox();
            this.paislabel = new System.Windows.Forms.Label();
            this.domPiso = new System.Windows.Forms.TextBox();
            this.localidadText = new System.Windows.Forms.TextBox();
            this.domDepartamento = new System.Windows.Forms.TextBox();
            this.domCalle = new System.Windows.Forms.TextBox();
            this.email = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.id = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.nacimiento = new System.Windows.Forms.DateTimePicker();
            this.button4 = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.buttonTarjetas = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(89, 115);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Apellido:";
            // 
            // docNumero
            // 
            this.docNumero.Location = new System.Drawing.Point(140, 84);
            this.docNumero.Name = "docNumero";
            this.docNumero.Size = new System.Drawing.Size(122, 20);
            this.docNumero.TabIndex = 1;
            this.docNumero.Text = "34284430";
            this.docNumero.TextChanged += new System.EventHandler(this.requireds_TextChanged);
            this.docNumero.Leave += new System.EventHandler(this.docNumero_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(89, 144);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Nombre:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Tipo de documento:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 86);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(118, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Número de documento:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(97, 202);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "E-Mail:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(64, 231);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Nacionalidad:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(27, 33);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(33, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Calle:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(238, 33);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Número:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(30, 63);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(30, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "Piso:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(208, 63);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(77, 13);
            this.label10.TabIndex = 0;
            this.label10.Text = "Departamento:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(4, 94);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(56, 13);
            this.label11.TabIndex = 0;
            this.label11.Text = "Localidad:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(25, 173);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(111, 13);
            this.label13.TabIndex = 0;
            this.label13.Text = "Fecha de Nacimiento:";
            // 
            // docTipo
            // 
            this.docTipo.FormattingEnabled = true;
            this.docTipo.Location = new System.Drawing.Point(140, 54);
            this.docTipo.Name = "docTipo";
            this.docTipo.Size = new System.Drawing.Size(122, 21);
            this.docTipo.TabIndex = 0;
            // 
            // apellido
            // 
            this.apellido.Location = new System.Drawing.Point(140, 113);
            this.apellido.Name = "apellido";
            this.apellido.Size = new System.Drawing.Size(122, 20);
            this.apellido.TabIndex = 2;
            this.apellido.Text = "Amaya";
            this.apellido.TextChanged += new System.EventHandler(this.requireds_TextChanged);
            // 
            // nombre
            // 
            this.nombre.AcceptsReturn = true;
            this.nombre.Location = new System.Drawing.Point(140, 142);
            this.nombre.Name = "nombre";
            this.nombre.Size = new System.Drawing.Size(122, 20);
            this.nombre.TabIndex = 3;
            this.nombre.Text = "Martin";
            this.nombre.TextChanged += new System.EventHandler(this.requireds_TextChanged);
            // 
            // nacionalidadText
            // 
            this.nacionalidadText.Enabled = false;
            this.nacionalidadText.Location = new System.Drawing.Point(140, 229);
            this.nacionalidadText.Name = "nacionalidadText";
            this.nacionalidadText.Size = new System.Drawing.Size(122, 20);
            this.nacionalidadText.TabIndex = 6;
            this.nacionalidadText.TextChanged += new System.EventHandler(this.requireds_TextChanged);
            // 
            // domNumero
            // 
            this.domNumero.Location = new System.Drawing.Point(289, 30);
            this.domNumero.Name = "domNumero";
            this.domNumero.Size = new System.Drawing.Size(122, 20);
            this.domNumero.TabIndex = 1;
            this.domNumero.Tag = "";
            this.domNumero.Text = "123";
            this.domNumero.TextChanged += new System.EventHandler(this.requireds_TextChanged);
            this.domNumero.Leave += new System.EventHandler(this.domNumero_Leave);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label21);
            this.groupBox1.Controls.Add(this.button6);
            this.groupBox1.Controls.Add(this.paisText);
            this.groupBox1.Controls.Add(this.paislabel);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.domPiso);
            this.groupBox1.Controls.Add(this.localidadText);
            this.groupBox1.Controls.Add(this.domDepartamento);
            this.groupBox1.Controls.Add(this.domCalle);
            this.groupBox1.Controls.Add(this.domNumero);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Location = new System.Drawing.Point(9, 265);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(462, 128);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Domicilio";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(441, 91);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(11, 13);
            this.label21.TabIndex = 9;
            this.label21.Text = "*";
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(417, 92);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(24, 20);
            this.button6.TabIndex = 5;
            this.button6.Text = "...";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // paisText
            // 
            this.paisText.Enabled = false;
            this.paisText.Location = new System.Drawing.Point(289, 92);
            this.paisText.Name = "paisText";
            this.paisText.Size = new System.Drawing.Size(122, 20);
            this.paisText.TabIndex = 4;
            this.paisText.TextChanged += new System.EventHandler(this.requireds_TextChanged);
            // 
            // paislabel
            // 
            this.paislabel.AutoSize = true;
            this.paislabel.Location = new System.Drawing.Point(253, 94);
            this.paislabel.Name = "paislabel";
            this.paislabel.Size = new System.Drawing.Size(32, 13);
            this.paislabel.TabIndex = 3;
            this.paislabel.Text = "País:";
            // 
            // domPiso
            // 
            this.domPiso.Location = new System.Drawing.Point(64, 60);
            this.domPiso.Name = "domPiso";
            this.domPiso.Size = new System.Drawing.Size(122, 20);
            this.domPiso.TabIndex = 2;
            this.domPiso.Tag = "";
            this.domPiso.Text = "1";
            this.domPiso.TextChanged += new System.EventHandler(this.requireds_TextChanged);
            this.domPiso.Leave += new System.EventHandler(this.domPiso_Leave);
            // 
            // localidadText
            // 
            this.localidadText.Location = new System.Drawing.Point(64, 91);
            this.localidadText.Name = "localidadText";
            this.localidadText.Size = new System.Drawing.Size(122, 20);
            this.localidadText.TabIndex = 4;
            this.localidadText.Tag = "";
            this.localidadText.Text = "Haedo";
            this.localidadText.TextChanged += new System.EventHandler(this.requireds_TextChanged);
            // 
            // domDepartamento
            // 
            this.domDepartamento.AcceptsReturn = true;
            this.domDepartamento.Location = new System.Drawing.Point(289, 60);
            this.domDepartamento.Name = "domDepartamento";
            this.domDepartamento.Size = new System.Drawing.Size(122, 20);
            this.domDepartamento.TabIndex = 3;
            this.domDepartamento.Tag = "";
            this.domDepartamento.Text = "A";
            this.domDepartamento.TextChanged += new System.EventHandler(this.requireds_TextChanged);
            // 
            // domCalle
            // 
            this.domCalle.Location = new System.Drawing.Point(64, 30);
            this.domCalle.Name = "domCalle";
            this.domCalle.Size = new System.Drawing.Size(122, 20);
            this.domCalle.TabIndex = 0;
            this.domCalle.Text = "asdasd";
            this.domCalle.TextChanged += new System.EventHandler(this.requireds_TextChanged);
            // 
            // email
            // 
            this.email.AcceptsReturn = true;
            this.email.Location = new System.Drawing.Point(140, 200);
            this.email.Name = "email";
            this.email.Size = new System.Drawing.Size(122, 20);
            this.email.TabIndex = 5;
            this.email.Text = "m@gmail.com";
            this.email.TextChanged += new System.EventHandler(this.requireds_TextChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(9, 409);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 9;
            this.button2.Text = "Limpiar";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(396, 409);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 7;
            this.button3.Text = "Aceptar";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // id
            // 
            this.id.AcceptsReturn = true;
            this.id.AcceptsTab = true;
            this.id.Location = new System.Drawing.Point(140, 24);
            this.id.Name = "id";
            this.id.Size = new System.Drawing.Size(122, 20);
            this.id.TabIndex = 1;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(43, 27);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(93, 13);
            this.label17.TabIndex = 0;
            this.label17.Text = "Código de Cliente:";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(312, 409);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 8;
            this.button5.Text = "Cancelar";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // nacimiento
            // 
            this.nacimiento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.nacimiento.Location = new System.Drawing.Point(140, 170);
            this.nacimiento.Name = "nacimiento";
            this.nacimiento.Size = new System.Drawing.Size(122, 20);
            this.nacimiento.TabIndex = 4;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(268, 229);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(24, 20);
            this.button4.TabIndex = 6;
            this.button4.Text = "...";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(265, 57);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(11, 13);
            this.label12.TabIndex = 9;
            this.label12.Text = "*";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(265, 86);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(11, 13);
            this.label14.TabIndex = 9;
            this.label14.Text = "*";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(265, 113);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(11, 13);
            this.label15.TabIndex = 9;
            this.label15.Text = "*";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(265, 142);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(11, 13);
            this.label16.TabIndex = 9;
            this.label16.Text = "*";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(265, 200);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(11, 13);
            this.label18.TabIndex = 9;
            this.label18.Text = "*";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(295, 231);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(11, 13);
            this.label19.TabIndex = 9;
            this.label19.Text = "*";
            // 
            // buttonTarjetas
            // 
            this.buttonTarjetas.Location = new System.Drawing.Point(339, 227);
            this.buttonTarjetas.Name = "buttonTarjetas";
            this.buttonTarjetas.Size = new System.Drawing.Size(132, 23);
            this.buttonTarjetas.TabIndex = 10;
            this.buttonTarjetas.Text = "Tarjetas de Crédito";
            this.buttonTarjetas.UseVisualStyleBackColor = true;
            this.buttonTarjetas.Click += new System.EventHandler(this.buttonTarjetas_Click);
            // 
            // ClienteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(486, 442);
            this.ControlBox = false;
            this.Controls.Add(this.buttonTarjetas);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.nacimiento);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.docTipo);
            this.Controls.Add(this.email);
            this.Controls.Add(this.nacionalidadText);
            this.Controls.Add(this.nombre);
            this.Controls.Add(this.apellido);
            this.Controls.Add(this.id);
            this.Controls.Add(this.docNumero);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ClienteForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox docNumero;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox docTipo;
        private System.Windows.Forms.TextBox apellido;
        private System.Windows.Forms.TextBox nombre;
        private System.Windows.Forms.TextBox nacionalidadText;
        private System.Windows.Forms.TextBox domNumero;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox domPiso;
        private System.Windows.Forms.TextBox domCalle;
        private System.Windows.Forms.TextBox domDepartamento;
        private System.Windows.Forms.TextBox email;
        private System.Windows.Forms.TextBox localidadText;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox id;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.DateTimePicker nacimiento;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox paisText;
        private System.Windows.Forms.Label paislabel;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Button buttonTarjetas;
    }
}