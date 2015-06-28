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

namespace Frame
{
    public partial class RolSelection : Form {

        private Frame parentFrame;
        private List<RolModel> rolesHabilitados;

        public RolSelection(Frame parent,List<RolModel> rolesHabilitados)
        {
            this.parentFrame = parent;
            this.rolesHabilitados = rolesHabilitados;
            InitializeComponent();
            fillRolesList();
            button1.Enabled = false;
        }

        private void fillRolesList() {
            string[] filas = new string[rolesHabilitados.Count];
            int count = 0;
            foreach (RolModel rol in rolesHabilitados)
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
                parentFrame.setRolLogued(rolesHabilitados[listBox1.SelectedIndex]);
                parentFrame.enableMenu();
                MdiParent.Enabled = true;
                this.Dispose();
                GC.Collect();
            }
            catch (NullReferenceException ern) {
                MessageBox.Show("No seleccionó un rol");
            }
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


        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != null)
            {
                button1.Enabled = true;
            }
            else {
                button1.Enabled = false;
            }
        }
    }
}
