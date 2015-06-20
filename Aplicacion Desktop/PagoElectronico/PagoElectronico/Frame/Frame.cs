﻿using System;
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
        public Frame()
        {
            UserModel usuario = Login.userLogued;
            if (usuario != null)
            {
                InitializeComponent();

                this.label1.Text = usuario.nombre;
                //Busco los roles del usuario
                usuario.getMisRoles();
                if (usuario.roles.Count == 0)
                {
                    throw new UserRolNotFoundException("El usuario no tiene roles cargados");
                }
                //Si encuentra más de un rol, muestra opciones de rol con el cual entrar
                if (usuario.roles.Count > 1)
                {
                    Form abmroles = new RolSelection(this);
                    abmroles.MdiParent = this;
                    abmroles.Show();
                }
                else if (usuario.roles.Count == 1)
                {
                    this.label4.Text = usuario.roles.First().nombre;
                }
            }
            return;
            
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
