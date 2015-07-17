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
        private String EXCEPTION_MESSAGE = "No se pudo completar la operación";
        private RolModel rol;
        private int operacionTipo;
        private RolDao rolDao;
        private RolAbm parent;

        private Int32 funcActivoIndex;
        private FuncionalidadModel funcionalidadActiva;

        public List<FuncionalidadModel> funcionalidades = new List<FuncionalidadModel>();

        public RolForm(int operacionTipo, RolModel rol, RolDao rolDao, RolAbm parent)
        {
            InitializeComponent();

            this.funcionalidades = new List<FuncionalidadModel>();
            if (rol != null)
            {
                this.rol = rol;
                this.textBox1.Text = rol.nombre;

                foreach (FuncionalidadModel f in rol.funcionalidades)
                {
                    this.funcionalidades.Add( (FuncionalidadModel) f.Clone());
                }
                fillFunctionsTable();
            }

            this.operacionTipo = operacionTipo;
            this.rolDao = rolDao;
            this.parent = parent;

            switch (operacionTipo)
            {
                case 0:
                    this.Text = "Crear Nuevo Rol";
                   // panel1.Visible = false;
                    //this.Size = new Size(286, 140);
                    //button1.Location = new Point(181, 60);
                    //button2.Location = new Point(100, 60);
                    checkBox1.Visible = false;
                    break;
                case 1:
                    this.Text = "Modificar Rol";
                    if (!rol.habilitado)
                    {
                        checkBox1.Visible = true;
                    }
                    else {
                        checkBox1.Visible = false;
                    }
                    break;
                case 2:
                    this.Text = "Dar de Alta Rol";
                    this.textBox1.Enabled = false;
                    this.buttonQuitar.Enabled = false;
                    this.buttonAgregar.Enabled = false;
                    this.button1.Text = "Dar de Alta";
                    break;
                default:
                    this.Text = "Dar de Baja Rol";
                    checkBox1.Visible = false;
                    this.textBox1.Enabled = false;
                    this.buttonQuitar.Enabled = false;
                    this.buttonAgregar.Enabled = false;
                    this.button1.Text = "Dar de baja";
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

            if (puedeAceptar())
            {

                Respuesta respuesta;

                switch (operacionTipo)
                {
                    //crear el rol
                    case 0:
                        rol = new RolModel(textBox1.Text);
                        rol.funcionalidades = funcionalidades;
                        try
                        {
                            respuesta = rolDao.createRol(rol);
                            MessageBox.Show(respuesta.mensaje);
                            if (respuesta.codigo > 0)
                            {
                                rol.id = respuesta.codigo;
                                parent.formResponseAdd(rol);
                                this.Close();
                                this.Dispose();
                                GC.Collect();
                            }
                        }
                        catch (Exception er)
                        {
                            MessageBox.Show(EXCEPTION_MESSAGE);
                        }
                        break;
                    //modificar el rol
                    case 1:
                        Boolean activar = false;

                        rol.nombre = textBox1.Text;
                        rol.funcionalidades = funcionalidades;

                        if (rol.habilitado == false && checkBox1.Checked)
                        {
                            rol.habilitado = true;
                            activar = true;
                        }

                        try
                        {
                            respuesta = rolDao.updateRol(rol, activar);
                            MessageBox.Show(respuesta.mensaje);
                            if (respuesta.codigo > 0)
                            {
                                parent.formResponseUpdate(rol);
                                this.Close();
                                this.Dispose();
                                GC.Collect();
                            }
                        }
                        catch (Exception er)
                        {
                            MessageBox.Show(EXCEPTION_MESSAGE);
                        }
                        break;
                    //dar de alta el rol
                    case 2:
                        try
                        {
                            respuesta = rolDao.enableRol(rol);
                            MessageBox.Show(respuesta.mensaje);
                            if (respuesta.codigo > 0)
                            {
                                rol.habilitado = true;
                                parent.formResponseUpdate(rol);
                                this.Close();
                                this.Dispose();
                                GC.Collect();
                            }
                        }
                        catch (Exception er)
                        {
                            MessageBox.Show(EXCEPTION_MESSAGE);
                        }
                        break;
                    //dar de baja el rol
                    default:
                        try
                        {
                            respuesta = rolDao.disableRol(rol);
                            MessageBox.Show(respuesta.mensaje);
                            if (respuesta.codigo > 0)
                            {
                                rol.habilitado = false;
                                parent.formResponseUpdate(rol);
                                this.Close();
                                this.Dispose();
                                GC.Collect();
                            }
                        }
                        catch (Exception er)
                        {
                            MessageBox.Show(EXCEPTION_MESSAGE);
                        }
                        break;
                }
            }
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
            try
            {
                if (this.funcionalidades.Count == 1)
                {
                    buttonQuitar.Enabled = false;
                }
                int index = this.dataGridView1.CurrentCell.RowIndex;
                funcionalidades.RemoveAt(index);
                fillFunctionsTable();
            }
            catch (NullReferenceException err) {
                buttonQuitar.Enabled = false;
            }
        }
        //-----------------------------------------------------------------------------------------------------------------

        //-----------------------------------------------------------------------------------------------------------------
        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                int filaActiva = this.dataGridView1.CurrentCell.RowIndex;
                String idActivo = dataGridView1.Rows[filaActiva].Cells[0].Value.ToString();

                int count = 0;
                foreach (FuncionalidadModel f in funcionalidades)
                {
                    if (idActivo.Equals(rol.id.ToString()))
                    {
                        funcionalidadActiva = f;
                        funcActivoIndex = count;
                        break;
                    }
                    count++;
                }

                if (operacionTipo == 1)
                {
                    buttonQuitar.Enabled = true;
                }
            }
            catch (NullReferenceException err)
            {
                buttonQuitar.Enabled = false;
            }
        }
        //-----------------------------------------------------------------------------------------------------------------

        //-----------------------------------------------------------------------------------------------------------------
        private Boolean puedeAceptar() {

            if (textBox1.Text.Trim().Length == 0) {
                MessageBox.Show("Debe insertar un Nombre para el Rol ");
                return false;
            }
            if (funcionalidades.Count == 0)
            {
                MessageBox.Show("Debe insertar Funcionalidades");
                return false;
            }

            return true;
        }
        //-----------------------------------------------------------------------------------------------------------------
    }
}
