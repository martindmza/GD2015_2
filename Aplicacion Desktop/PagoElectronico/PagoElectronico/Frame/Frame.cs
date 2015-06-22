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

namespace Frame
{
    public partial class Frame : Form
    {

        private const int OPERACION_TIPO_ABM = 0;
        private const int OPERACION_TIPO_SELECCION = 1;

        //______________________________________________________________________________________________________________________
        public Frame(Login parent)
        {
            UserModel usuario = Login.userLogued;
            if (usuario != null)
            {
                InitializeComponent();

                this.label1.Text = usuario.nombre;

                //Busco los roles activos del usuario
                usuario.getMisRoles();
                List<RolModel> rolesHabilitados = new List<RolModel>();
                foreach (RolModel rol in usuario.roles)
                {
                    if (rol.habilitado == true)
                    {
                        rolesHabilitados.Add(rol);
                    }
                }

                //si no tiene roles activos salir
                if (rolesHabilitados.Count == 0)
                {
                    MessageBox.Show("El usuario no tiene roles cargados o Habilitados");
                    this.Close();
                    this.Dispose();
                    GC.Collect();
                    parent.Show();
                }
                //Si tiene un rol activo entrar a la aplicacion directamente
                else if (rolesHabilitados.Count == 1)
                {
                    this.label4.Text = usuario.roles.First().nombre;
                    Login.rolSelected = usuario.roles.First();
                }
                //Si tiene más de un rol, muestra opciones de rol con el cual entrar
                else {
                        Form f = new RolSelection(this,rolesHabilitados);
                        f.MdiParent = this;
                        f.Show();
                }
            }
        }
        //______________________________________________________________________________________________________________________

        //---------------------------------------------------------------------------------------------------------------------
        public void setRolLogued() {
            try
            {
                this.label4.Text = Login.rolSelected.nombre;
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
        private void depósitosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form f = new DepositosAbm();
            f.MdiParent = this;
            f.Show();
        }
        //-----------------------------------------------------------------------------------------------------------------

        //-----------------------------------------------------------------------------------------------------------------
        private void retirosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form f = new RetirosAbm();
            f.MdiParent = this;
            f.Show();
        }
        //-----------------------------------------------------------------------------------------------------------------

        //-----------------------------------------------------------------------------------------------------------------
        private void transferenciasToolStripMenuItem_Click(object sender, EventArgs e)
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
        //-----------------------------------------------------------------------------------------------------------------
    }
}
