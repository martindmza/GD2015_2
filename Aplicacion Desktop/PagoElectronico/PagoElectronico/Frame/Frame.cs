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

namespace Frame
{
    public partial class Frame : Form
    {

        //______________________________________________________________________________________________________________________
        public Frame()
        {
            InitializeComponent();
            this.label1.Text = Login.Login.userLogued.nombre;

            //Busco los roles del usuario
            try
            {
                Login.Login.userLogued.getRoles();
            }
            catch (Exception err2)
            {
                MessageBox.Show("El usuario se encontró pero no pudo crearse :" + err2);
            }

            if (Login.Login.userLogued.roles.Count == 0) {
                throw new UserRolNotFoundException("El usuario no tiene roles cargados");
            }

            //Si encuentra más de un rol, muestra opciones de rol con el cual entrar
            if (Login.Login.userLogued.roles.Count > 1) {
                Form abmroles = new RolSelection(this);
                abmroles.MdiParent = this;
                abmroles.Show();
            }
        }
        //______________________________________________________________________________________________________________________

        //---------------------------------------------------------------------------------------------------------------------
        public void setRolLogued() {
            try
            {
                this.label4.Text = Login.Login.rolSelected.nombre;
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
            Form abmroles = new ClienteAbm();
            abmroles.MdiParent = this;
            abmroles.Show();
        }
        //---------------------------------------------------------------------------------------------------------------------

        //---------------------------------------------------------------------------------------------------------------------
        private void rolesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form abmroles = new RolAbm();
            abmroles.MdiParent = this;
            abmroles.Show();
        }
        //---------------------------------------------------------------------------------------------------------------------        
    }
}
