using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Models;
using DAO;

namespace ABM
{
    public partial class RolForm : Form
    {
        private RolModel rol;
        private int operacionTipo;
        private RolDao rolDao;
        private RolAbm parent;

        public List<FuncionalidadModel> funcionalidades;

        public RolForm(int operacionTipo, RolModel rol, RolDao rolDao, RolAbm parent)
        {
            InitializeComponent();

            if (rol != null)
            {
                this.rol = rol;
                this.textBox1.Text = rol.nombre;
                this.funcionalidades = rol.funcionalidades;
                fillFunctionsTable();
            }
            else {
                this.funcionalidades = new List<FuncionalidadModel>();
            }

            this.operacionTipo = operacionTipo;
            this.rolDao = rolDao;
            this.parent = parent;

            switch (operacionTipo)
            {
                case 0:
                    this.button1.Enabled = false;
                    this.Text = "Crear Nuevo Rol";
                    break;
                case 1:
                    this.Text = "Modificar Rol";
                    break;
                case 2:
                    this.Text = "Dar de Baja Rol";
                    this.textBox1.Enabled = false;
                    this.buttonQuitar.Enabled = false;
                    this.buttonAgregar.Enabled = false;
                    break;
            }

            buttonQuitar.Enabled = false;
        }

        //-----------------------------------------------------------------------------------------------------------------
        private void fillFunctionsTable()
        {
            string[] filaFuncCont;

            dataGridView1.Rows.Clear();
            //cargo las funcionalidades que tiene el rol seleccionado
            foreach (FuncionalidadModel func in funcionalidades)
            {
                filaFuncCont = new String[] { func.nombre };
                dataGridView1.Rows.Add(filaFuncCont);
            }
        }
        //-----------------------------------------------------------------------------------------------------------------
        
        //-----------------------------------------------------------------------------------------------------------------
        public void setSeleccionado(FuncionalidadModel funcionalidad) {
            funcionalidades.Add(funcionalidad);
            fillFunctionsTable();
        }
        //-----------------------------------------------------------------------------------------------------------------

        //Event Handler***
        //-----------------------------------------------------------------------------------------------------------------
        //cancelar
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
            GC.Collect();
        }
        //-----------------------------------------------------------------------------------------------------------------

        //-----------------------------------------------------------------------------------------------------------------
        //aceptar
        private void button1_Click(object sender, EventArgs e)
        {
            switch (operacionTipo)
            {
                case 0:
                    RolModel newRol = new RolModel(textBox1.Text);
                    newRol.funcionalidades = funcionalidades;
                    rol = rolDao.createRol(newRol);
                    if(rol.id!=-1)
                        parent.formResponseAdd(newRol);
                    
                    break;
                case 1:
                    rol.nombre = textBox1.Text;
                    rol.funcionalidades = funcionalidades;
                    rolDao.updateRol(rol);
                    parent.formResponseUpdate(rol);
                    break;
                default:
                    this.rolDao.disableRol(rol);
                    parent.formResponseDisable();
                    break;
            }

            this.Close();
            this.Dispose();
            GC.Collect();
        }
        //-----------------------------------------------------------------------------------------------------------------

        //-----------------------------------------------------------------------------------------------------------------
        private void RolForm_Load(object sender, EventArgs e)
        {
            parent.Enabled = false;
            textBox1.Focus();
        }
        //-----------------------------------------------------------------------------------------------------------------

        //-----------------------------------------------------------------------------------------------------------------
        private void RolForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            parent.Enabled = true;
        }
        //-----------------------------------------------------------------------------------------------------------------

        //-----------------------------------------------------------------------------------------------------------------
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0)
            {
                button1.Enabled = false;
            }
            else {
                button1.Enabled = true;
            }
        }
        //-----------------------------------------------------------------------------------------------------------------

        //-----------------------------------------------------------------------------------------------------------------
        //agregar funcionalidad
        private void buttonAgregar_Click(object sender, EventArgs e)
        {
            Form f = new FuncionalidadesForm(this, funcionalidades);
            f.MdiParent = this.MdiParent;
            f.Show();
        }
        //-----------------------------------------------------------------------------------------------------------------

        //-----------------------------------------------------------------------------------------------------------------
        //quitar funcionalidad
        private void buttonQuitar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentCell.RowIndex != 0) {
                if (this.funcionalidades.Count == 1)
                {
                    buttonQuitar.Enabled = false;
                }
                int index = this.dataGridView1.CurrentCell.RowIndex;
                funcionalidades.RemoveAt(index);
                fillFunctionsTable();
            }
        }
        //-----------------------------------------------------------------------------------------------------------------

        //-----------------------------------------------------------------------------------------------------------------
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentCell.RowIndex == 0)
            {
                buttonQuitar.Enabled = false;
            }
            else {
                buttonQuitar.Enabled = true;
            }
        }
        //-----------------------------------------------------------------------------------------------------------------
    }
}
