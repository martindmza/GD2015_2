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

        public RolForm(int operacionTipo, RolModel rol, RolDao rolDao, RolAbm parent)
        {
            InitializeComponent();

            if (rol != null)
            {
                this.rol = rol;
                this.textBox1.Text = rol.nombre;
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
                    this.button1.Enabled = false;
                    this.Text = "Modificar Rol";
                    break;
                case 2:
                    this.Text = "Dar de Baja Rol";
                    this.textBox1.Enabled = false;
                    break;
            }
        }
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
                    rol = rolDao.createRol(newRol);
                    parent.formResponseAdd(newRol);
                    break;
                case 1:
                    rol.nombre = textBox1.Text;
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
    }
}
