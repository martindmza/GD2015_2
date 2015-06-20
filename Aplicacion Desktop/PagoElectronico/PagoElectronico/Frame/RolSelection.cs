﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Models;

namespace Frame
{
    public partial class RolSelection : Form {

        private Frame parentFrame;

        public RolSelection(Frame parent)
        {
            this.parentFrame = parent;
            InitializeComponent();
            fillRolesList();
        }

        private void fillRolesList() {
            string[] filas = new string[Logins.Login.userLogued.roles.Count];
            int count = 0;
            foreach (RolModel rol in Logins.Login.userLogued.roles)
            {
                if (rol.habilitado)
                {
                    filas[count] = rol.nombre.ToString();
                    count++;
                }
            }
            listBox1.Items.AddRange(filas);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Logins.Login.rolSelected = Logins.Login.userLogued.roles[listBox1.SelectedIndex];
                parentFrame.enableMenu();
                parentFrame.setRolLogued();
                MdiParent.Enabled = true;
                this.Dispose();
                GC.Collect();
            }
            catch (Exception ern) { }
        }

        private void RolSelection_Load(object sender, EventArgs e)
        {
            parentFrame.disableMenu();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
            parentFrame.Dispose();
            GC.Collect();
        }
    }
}
