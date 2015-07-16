namespace Tarjetas
{
    partial class TarjetasAbm
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.numero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Emisor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.emision = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vencimiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonQuitar = new System.Windows.Forms.Button();
            this.buttonModificar = new System.Windows.Forms.Button();
            this.buttonAgregar = new System.Windows.Forms.Button();
            this.buttonBuscar = new System.Windows.Forms.Button();
            this.numeroText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonCancelar = new System.Windows.Forms.Button();
            this.buttonElegir = new System.Windows.Forms.Button();
            this.buttonCerrar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.numero,
            this.Emisor,
            this.emision,
            this.vencimiento});
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView1.Location = new System.Drawing.Point(12, 43);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(585, 301);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseClick);
            // 
            // numero
            // 
            this.numero.HeaderText = "Número";
            this.numero.Name = "numero";
            this.numero.ReadOnly = true;
            this.numero.Width = 160;
            // 
            // Emisor
            // 
            this.Emisor.HeaderText = "Emisor";
            this.Emisor.Name = "Emisor";
            this.Emisor.ReadOnly = true;
            // 
            // emision
            // 
            this.emision.HeaderText = "Fecha de Emisión";
            this.emision.Name = "emision";
            this.emision.ReadOnly = true;
            this.emision.Width = 140;
            // 
            // vencimiento
            // 
            this.vencimiento.HeaderText = "Fecha de Vencimiento";
            this.vencimiento.Name = "vencimiento";
            this.vencimiento.ReadOnly = true;
            this.vencimiento.Width = 140;
            // 
            // buttonQuitar
            // 
            this.buttonQuitar.Location = new System.Drawing.Point(359, 350);
            this.buttonQuitar.Name = "buttonQuitar";
            this.buttonQuitar.Size = new System.Drawing.Size(75, 23);
            this.buttonQuitar.TabIndex = 2;
            this.buttonQuitar.Text = "Desasociar";
            this.buttonQuitar.UseVisualStyleBackColor = true;
            this.buttonQuitar.Click += new System.EventHandler(this.buttonQuitar_Click);
            // 
            // buttonModificar
            // 
            this.buttonModificar.Location = new System.Drawing.Point(440, 350);
            this.buttonModificar.Name = "buttonModificar";
            this.buttonModificar.Size = new System.Drawing.Size(75, 23);
            this.buttonModificar.TabIndex = 2;
            this.buttonModificar.Text = "Modificar";
            this.buttonModificar.UseVisualStyleBackColor = true;
            this.buttonModificar.Click += new System.EventHandler(this.buttonModificar_Click);
            // 
            // buttonAgregar
            // 
            this.buttonAgregar.Location = new System.Drawing.Point(521, 350);
            this.buttonAgregar.Name = "buttonAgregar";
            this.buttonAgregar.Size = new System.Drawing.Size(75, 23);
            this.buttonAgregar.TabIndex = 2;
            this.buttonAgregar.Text = "Agregar";
            this.buttonAgregar.UseVisualStyleBackColor = true;
            this.buttonAgregar.Click += new System.EventHandler(this.buttonAgregar_Click);
            // 
            // buttonBuscar
            // 
            this.buttonBuscar.Location = new System.Drawing.Point(239, 17);
            this.buttonBuscar.Name = "buttonBuscar";
            this.buttonBuscar.Size = new System.Drawing.Size(75, 20);
            this.buttonBuscar.TabIndex = 3;
            this.buttonBuscar.Text = "Buscar";
            this.buttonBuscar.UseVisualStyleBackColor = true;
            this.buttonBuscar.Click += new System.EventHandler(this.buttonBuscar_Click);
            // 
            // numeroText
            // 
            this.numeroText.Location = new System.Drawing.Point(169, 17);
            this.numeroText.MaxLength = 4;
            this.numeroText.Name = "numeroText";
            this.numeroText.Size = new System.Drawing.Size(62, 20);
            this.numeroText.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Número:";
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.Location = new System.Drawing.Point(440, 350);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(75, 23);
            this.buttonCancelar.TabIndex = 6;
            this.buttonCancelar.Text = "Cancelar";
            this.buttonCancelar.UseVisualStyleBackColor = true;
            this.buttonCancelar.Click += new System.EventHandler(this.buttonCancelar_Click);
            // 
            // buttonElegir
            // 
            this.buttonElegir.Location = new System.Drawing.Point(521, 350);
            this.buttonElegir.Name = "buttonElegir";
            this.buttonElegir.Size = new System.Drawing.Size(75, 23);
            this.buttonElegir.TabIndex = 6;
            this.buttonElegir.Text = "Elegir";
            this.buttonElegir.UseVisualStyleBackColor = true;
            this.buttonElegir.Click += new System.EventHandler(this.buttonElegir_Click);
            // 
            // buttonCerrar
            // 
            this.buttonCerrar.Location = new System.Drawing.Point(12, 350);
            this.buttonCerrar.Name = "buttonCerrar";
            this.buttonCerrar.Size = new System.Drawing.Size(75, 23);
            this.buttonCerrar.TabIndex = 7;
            this.buttonCerrar.Text = "Cerrar";
            this.buttonCerrar.UseVisualStyleBackColor = true;
            this.buttonCerrar.Visible = false;
            this.buttonCerrar.Click += new System.EventHandler(this.buttonCerrar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(65, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "XXXX-XXXX-XXXX-";
            // 
            // TarjetasAbm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(610, 381);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonCerrar);
            this.Controls.Add(this.buttonElegir);
            this.Controls.Add(this.buttonCancelar);
            this.Controls.Add(this.buttonBuscar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numeroText);
            this.Controls.Add(this.buttonAgregar);
            this.Controls.Add(this.buttonModificar);
            this.Controls.Add(this.buttonQuitar);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TarjetasAbm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mis Tarjetas de Crédito";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button buttonQuitar;
        private System.Windows.Forms.Button buttonModificar;
        private System.Windows.Forms.Button buttonAgregar;
        private System.Windows.Forms.Button buttonBuscar;
        private System.Windows.Forms.TextBox numeroText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn numero;
        private System.Windows.Forms.DataGridViewTextBoxColumn Emisor;
        private System.Windows.Forms.DataGridViewTextBoxColumn emision;
        private System.Windows.Forms.DataGridViewTextBoxColumn vencimiento;
        private System.Windows.Forms.Button buttonCancelar;
        private System.Windows.Forms.Button buttonElegir;
        private System.Windows.Forms.Button buttonCerrar;
        private System.Windows.Forms.Label label2;
    }
}