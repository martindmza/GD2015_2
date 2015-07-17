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
    public partial class RolAbm : Form {

        private const int AGREGAR_ROL = 0;
        private const int MODIFICAR_ROL = 1;
        private const int HABILITAR_ROL = 2;
        private const int DESHABILITAR_ROL = 3;

        private Int32 rolActivoIndex;
        private RolModel rolActivo;
        private RolDao rolDao;
        private ClienteForm parent;

        private List<RolModel> roles;
        private Decimal idFilter;

        public RolAbm() {

            this.rolDao = new RolDao();
            this.roles = rolDao.getListado();
            
            InitializeComponent();
            fillRolesTable();

            //sets
            button1.Enabled = false;
            button2.Enabled = false;
            buttonElegir.Visible = false;
            buttonCancelar.Visible = false;
        }

        public RolAbm(ClienteForm parent)
        {
            this.parent = parent;
            this.parent.Enabled = false;
            this.rolDao = new RolDao();
            this.roles = rolDao.getListado();

            InitializeComponent();
            fillRolesTable();

            //sets
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            buttonElegir.Visible = true;
            buttonCancelar.Visible = true;
            buttonElegir.Enabled = false;
            ControlBox = false;
        }

        //-----------------------------------------------------------------------------------------------------------------
        private void fillRolesTable() {

            dataGridViewRoles.Rows.Clear();

            string[] row;
            foreach (RolModel rol in roles)
            {
                String estado = "No Activo";
                if (rol.habilitado) {
                    estado = "Activo";
                }

                row = new String[] {    rol.id.ToString(),
                                        rol.nombre.ToString(),
                                        estado
                                        };

                dataGridViewRoles.Rows.Add(row);
            }
            dataGridViewRoles.PerformLayout();
        }
        //-----------------------------------------------------------------------------------------------------------------

        //-----------------------------------------------------------------------------------------------------------------
        public void formResponseAdd(RolModel rol) {
            roles.Add(rol);
            fillRolesTable();
        }
        //-----------------------------------------------------------------------------------------------------------------

        //-----------------------------------------------------------------------------------------------------------------
        public void formResponseUpdate(RolModel rol)
        {
            roles[rolActivoIndex] = rol;

            if (!rol.habilitado) {
                button2.Enabled = false;
            }

            fillRolesTable();
         }
        //-----------------------------------------------------------------------------------------------------------------


        //Event Handler***
        //cuando selecciono un nuevo rol
        //-----------------------------------------------------------------------------------------------------------------
        private void dataGridViewRoles_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e) {
            try{
                int filaActiva = this.dataGridViewRoles.CurrentCell.RowIndex;
                String idRolActivo = dataGridViewRoles.Rows[filaActiva].Cells[0].Value.ToString();

                int count = 0;
                foreach (RolModel rol in roles) {
                    if (idRolActivo.Equals(rol.id.ToString()))
                    {
                        rolActivo = rol;
                        rolActivoIndex = count;
                        break;
                    }
                    count++;
                }

                if (!rolActivo.habilitado)
                {
                    button2.Enabled = false;
                }
                else {
                    button2.Enabled = true;
                }

                button1.Enabled = true;                
                buttonElegir.Enabled = true;
            } catch (NullReferenceException err) {
                button1.Enabled = true;
                button2.Enabled = true;
            }
        }
        //-----------------------------------------------------------------------------------------------------------------
       

        //-----------------------------------------------------------------------------------------------------------------
        //agregar nuevo Rol
        private void button3_Click(object sender, EventArgs e)
        {
            RolForm rolForm = new RolForm(AGREGAR_ROL, null, rolDao,this);                            
            rolForm.MdiParent = this.MdiParent;
            rolForm.Show();
        }
        //-----------------------------------------------------------------------------------------------------------------

        //deshabilitar o habilitar Rol
        //-----------------------------------------------------------------------------------------------------------------
        private void button2_Click(object sender, EventArgs e)
        {
            int ACTION = HABILITAR_ROL;
            if (rolActivo.habilitado)
            {
                ACTION = DESHABILITAR_ROL;
            }
            RolForm rolForm = new RolForm(ACTION, rolActivo, rolDao, this);
            rolForm.MdiParent = this.MdiParent;
            rolForm.Show();
        }
        //-----------------------------------------------------------------------------------------------------------------

        //Modificar Rol
        //-----------------------------------------------------------------------------------------------------------------
        private void button1_Click(object sender, EventArgs e)
        {
            RolForm rolForm = new RolForm(MODIFICAR_ROL, rolActivo, rolDao, this);
            rolForm.MdiParent = this.MdiParent;
            rolForm.Show();
        }
        //-----------------------------------------------------------------------------------------------------------------

        //-----------------------------------------------------------------------------------------------------------------
        private void button8_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
            GC.Collect();
        }
        //-----------------------------------------------------------------------------------------------------------------

        //-----------------------------------------------------------------------------------------------------------------
        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            rolActivo = null;
            rolActivoIndex = 0;
            button1.Enabled = false;
            button2.Enabled = false;
            roles = rolDao.getRolesByFilters(idFilter,textBox2.Text);
            fillRolesTable();
        }
        //-----------------------------------------------------------------------------------------------------------------

        //-----------------------------------------------------------------------------------------------------------------
        //Validar si se ingeso un numero
        private void textBox1_Leave(object sender, EventArgs e)
        {
            idFilter = 0;
            if (textBox1.Text.Length != 0)
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(textBox1.Text, "[^0-9]"))
                {
                    MessageBox.Show("Ingrese solo numeros");
                    textBox1.Text = "";
                }
                else {
                    try
                    {
                        idFilter = Decimal.Parse(textBox1.Text);
                        if (idFilter <= 0)
                        {
                            MessageBox.Show("No puede buscar un código negativo");
                            textBox1.Text = "";
                        }
                    }
                    catch (FormatException erf)
                    {
                        MessageBox.Show("Ingrese un número válido");
                    }
                }
            }
        }
        //-----------------------------------------------------------------------------------------------------------------

        //-----------------------------------------------------------------------------------------------------------------
        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }
        //-----------------------------------------------------------------------------------------------------------------

        //-----------------------------------------------------------------------------------------------------------------
        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            parent.Enabled = true;
            this.Close();
            this.Dispose();
            GC.Collect();
        }
        //-----------------------------------------------------------------------------------------------------------------

        //-----------------------------------------------------------------------------------------------------------------
        private void buttonElegir_Click(object sender, EventArgs e)
        {
            parent.setRol(rolActivo);
            parent.Enabled = true;
            this.Close();
            this.Dispose();
            GC.Collect();
        }
        //-----------------------------------------------------------------------------------------------------------------
    }
}