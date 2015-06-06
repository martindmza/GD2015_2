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
        private const int DESHABILITAR_ROL = 2;

        private Int32 rolActivoIndex;
        private RolModel rolActivo;
        private RolDao rolDao;
        private FuncionalidadDao funcionalidadDao;

        private List<RolModel> roles;
        private List<FuncionalidadModel> funcionalidadesTodas;
        private List<FuncionalidadModel> funcionalidadesNoContenidas;

        public RolAbm() {

            this.rolDao = new RolDao();
            this.funcionalidadDao = new FuncionalidadDao();
            this.roles = rolDao.getRoles();
            this.funcionalidadesTodas = funcionalidadDao.getFuncionalidades();
            
            InitializeComponent();
            fillRolesTable();

            //sets
            button1.Enabled = false;
            button2.Enabled = false;
        }

        //-----------------------------------------------------------------------------------------------------------------
        private void fillRolesTable() {

            dataGridViewRoles.Rows.Clear();

            string[] row;
            foreach (RolModel rol in roles)
            {
                if (applyFilters(rol)) 
                {
                    row = new String[] {    rol.id.ToString(),
                                            rol.nombre.ToString(),
                                            rol.habilitado.ToString()
                                            };

                    dataGridViewRoles.Rows.Add(row);
                }
            }
        }
        //-----------------------------------------------------------------------------------------------------------------

        //-----------------------------------------------------------------------------------------------------------------
        private void fillFunctionsTable()
        {
            string[] filaFuncCont;
            string[] filaFuncDisp;

            dataGridView1.Rows.Clear();
            dataGridView2.Rows.Clear();

            //cargo las funcionalidades que tiene el rol seleccionado y las quito de la lista de todas las funcionalidades
            foreach (FuncionalidadModel func in rolActivo.funcionalidades)
            {
                filaFuncCont = new String[] { func.nombre };
                dataGridView1.Rows.Add(filaFuncCont);
                this.funcionalidadesNoContenidas.Remove(func);
            }

            //cargo las funcionalidades que no tiene el rol seleccionado
            foreach (FuncionalidadModel func in this.funcionalidadesNoContenidas)
            {
                if (!rolActivo.funcionalidades.Exists(i => i.id == func.id))
                {
                    filaFuncDisp = new String[] { func.nombre };
                    dataGridView2.Rows.Add(filaFuncDisp);
                }
            }
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
            fillRolesTable();
         }
        //-----------------------------------------------------------------------------------------------------------------

        //-----------------------------------------------------------------------------------------------------------------
        public void formResponseDisable()
        {
            roles[rolActivoIndex].habilitado = false;
            fillRolesTable();
        }
        //-----------------------------------------------------------------------------------------------------------------

        //-----------------------------------------------------------------------------------------------------------------
        public bool applyFilters(RolModel rol)
        {
            bool response = true;
            //id

            if (textBox1.Text.Length != 0)
            {
                if ( ! textBox1.Text.ToLower().Contains(rol.id.ToString()))
                {
                    response = false;
                }
            }

            //nombre
            if (textBox2.Text.Length != 0)
            {
                if (!textBox2.Text.ToLower().Contains(rol.nombre.ToLower()))
                {
                    response = false;
                }
            }
            return response;


        }
        //-----------------------------------------------------------------------------------------------------------------


        //Event Handler***
        //cuando selecciono un nuevo rol
        //-----------------------------------------------------------------------------------------------------------------
        private void dataGridViewRoles_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e) {

            funcionalidadesNoContenidas = funcionalidadesTodas;
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

            button1.Enabled = true;
            button2.Enabled = true;
            fillFunctionsTable();
        }
        //-----------------------------------------------------------------------------------------------------------------

        //-----------------------------------------------------------------------------------------------------------------
        //quitar funcionalidad
        private void button6_Click(object sender, EventArgs e)
        {
            if (this.rolActivo.funcionalidades.Count == 1)
            {
                this.button6.Enabled = false;
            }
            this.button5.Enabled = true;
            int index = this.dataGridView1.CurrentCell.RowIndex;
            this.rolActivo.funcionalidades.RemoveAt(index);
            fillFunctionsTable();
        }
        //-----------------------------------------------------------------------------------------------------------------

        //-----------------------------------------------------------------------------------------------------------------
        //agregar funcionalidad
        private void button5_Click(object sender, EventArgs e)
        {
            if (this.dataGridView2.Rows.Count == 1)
            {
                this.button5.Enabled = false;
            }
            this.button6.Enabled = true;
            int index = this.dataGridView2.CurrentCell.RowIndex;
            this.rolActivo.funcionalidades.Add(funcionalidadesTodas[index]);
            fillFunctionsTable();
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

        //deshabilitar Rol
        //-----------------------------------------------------------------------------------------------------------------
        private void button2_Click(object sender, EventArgs e)
        {
            RolForm rolForm = new RolForm(DESHABILITAR_ROL, rolActivo, rolDao, this);
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
        //accept
        private void button7_Click(object sender, EventArgs e)
        {
            rolDao.RolAbmChanges(roles);
            MessageBox.Show("changes succesfull");
            this.Close();
            this.Dispose();
            GC.Collect();
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
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            fillRolesTable();
        }
        //-----------------------------------------------------------------------------------------------------------------
    }
}