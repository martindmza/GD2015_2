using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Includes;
using ABM;
using MyExceptions;
using Depositos;
using Retiros;
using Transferencias;
using Facturacion;
using Tarjetas;
using Models;
using Logins;
using DAO;
using PagoElectronico.Listados;

namespace Frame
{
    public partial class Frame : Form
    {

        private const int OPERACION_TIPO_ABM = 0;
        private const int OPERACION_TIPO_SELECCION = 1;

        //______________________________________________________________________________________________________________________
        public Frame(Login parent)
        {
            UserModel usuario = UsuarioSingleton.getInstance().getUsuario();
            if (usuario != null)
            {
                InitializeComponent();

                this.label1.Text = usuario.nombre;

                //Busco los roles activos del usuario
                usuario.getMisRoles(true);
               
                //si no tiene roles activos salir
                if (usuario.roles.Count == 0)
                {
                    MessageBox.Show("El usuario no tiene roles cargados o Habilitados");
                    this.Close();
                    this.Dispose();
                    GC.Collect();
                    parent.Show();
                }
                //Si tiene un rol activo entrar a la aplicacion directamente
                else if (usuario.roles.Count == 1)
                {
                    UsuarioSingleton.getInstance().setRol(usuario.roles.First());
                    setRolLogued(UsuarioSingleton.getInstance().getRol());
                    enableMenu();
                }
                //Si tiene más de un rol, muestra opciones de rol con el cual entrar
                else
                {
                    Form f = new RolSelection(this, usuario.roles);
                    f.MdiParent = this;
                    f.Show();
                }

            }
            else {
                MessageBox.Show("No se registrado un usuario válido");
                this.Close();
                this.Dispose();
                GC.Collect();
            }            

        }
        //______________________________________________________________________________________________________________________

        //---------------------------------------------------------------------------------------------------------------------
        public void setRolLogued(RolModel rol) {
            try
            {
                Logins.Login.rolSelected = rol;
                this.label4.Text = Login.rolSelected.nombre;
                rol.funcionalidades = new FuncionalidadDao().getFuncionalidades(rol.id, true);
            }
            catch (NullReferenceException e) {
                MessageBox.Show("No se seleccionó ningún rol" + e);
            }
        }
        //---------------------------------------------------------------------------------------------------------------------

        //---------------------------------------------------------------------------------------------------------------------
        public void enableMenu()
        {
            this.menuStrip1.Enabled = true;
            List <ToolStripMenuItem> operaciones = new List<ToolStripMenuItem>();
            operaciones.Add(rolesToolStripMenuItem);
            operaciones.Add(usuariosToolStripMenuItem1);
            operaciones.Add(clientesToolStripMenuItem);
            operaciones.Add(cuentasToolStripMenuItem1);
            operaciones.Add(depositoToolStripMenuItem);
            operaciones.Add(retiroToolStripMenuItem);
            operaciones.Add(transferenciaToolStripMenuItem);
            operaciones.Add(facturacionDeCostosToolStripMenuItem);
            operaciones.Add(tarjetasToolStripMenuItem);
            operaciones.Add(consultaDeSaldosToolStripMenuItem);
            operaciones.Add(estadisticasToolStripMenuItem);
            operaciones.Add(abmsToolStripMenuItem);
            operaciones.Add(movimientosToolStripMenuItem);
            int index = 1;
            foreach (ToolStripMenuItem o in operaciones)
            {
                if (Login.rolSelected.funcionalidades.Exists(i => i.id == index))
                {
                    o.Visible = true;
                }
                index++;
            }

        }
        //---------------------------------------------------------------------------------------------------------------------

        //---------------------------------------------------------------------------------------------------------------------
        public void disableMenu()
        {
            this.menuStrip1.Enabled = false;
        }
        //---------------------------------------------------------------------------------------------------------------------


        //Event Handler
        //****
        //---------------------------------------------------------------------------------------------------------------------
        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form f = new ClienteAbm(OPERACION_TIPO_ABM);
            f.MdiParent = this;
            f.Show();
        }
        //-----------------------------------------------------------------------------------------------------------------

        //-----------------------------------------------------------------------------------------------------------------
        private void rolesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form f = new RolAbm();
            f.MdiParent = this;
            f.Show();
        }
        //-----------------------------------------------------------------------------------------------------------------

        //-----------------------------------------------------------------------------------------------------------------
        private void cuentasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form f = new CuentaAbm();
            f.MdiParent = this;
            f.Show();
        }
        //-----------------------------------------------------------------------------------------------------------------
        
        //-----------------------------------------------------------------------------------------------------------------
        private void depositoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form f = new DepositosAbm();
            f.MdiParent = this;
            f.Show();
        }
        //-----------------------------------------------------------------------------------------------------------------

        //-----------------------------------------------------------------------------------------------------------------
        private void retiroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form f = new RetirosAbm();
            f.MdiParent = this;
            f.Show();
        }
        //-----------------------------------------------------------------------------------------------------------------

        //-----------------------------------------------------------------------------------------------------------------
        private void transferenciaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form f = new TransferenciaAbm();
            f.MdiParent = this;
            f.Show();
        }
        //-----------------------------------------------------------------------------------------------------------------
        
        //-----------------------------------------------------------------------------------------------------------------
        private void facturaciónDeCostosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form f = new FacturacionAbm();
            f.MdiParent = this;
            f.Show();
        }
        //-----------------------------------------------------------------------------------------------------------------

        //-----------------------------------------------------------------------------------------------------------------
        private void tarjetasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form f = new TarjetasAbm();
            f.MdiParent = this;
            f.Show();
        }
        //-----------------------------------------------------------------------------------------------------------------

        //-----------------------------------------------------------------------------------------------------------------
        private void consultaDeSaldosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form f = new ConsultaDeSaldos();
            f.MdiParent = this;
            f.Show();
        }

        private void usuariosToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void estadisticasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form f = new FormEstadistico();
            f.MdiParent = this;
            f.Show();
        }
        //-----------------------------------------------------------------------------------------------------------------
    }
}
