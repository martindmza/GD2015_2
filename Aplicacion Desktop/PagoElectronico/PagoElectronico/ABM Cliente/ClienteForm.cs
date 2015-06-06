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
    public partial class ClienteForm : Form
    {
        private ClienteModel cliente;
        private int operacionTipo;
        private ClienteDao clienteDao;
        private ClienteAbm parent;

        public ClienteForm(int operacionTipo, ClienteModel cliente, ClienteDao clienteDao, ClienteAbm parent)
        {
            InitializeComponent();

            if (cliente != null)
            {
                this.cliente = cliente;
            }
            this.operacionTipo = operacionTipo;
            this.clienteDao = clienteDao;
            this.parent = parent;

            switch (operacionTipo)
            {
                case 0:
                    button3.Enabled = false;
                    this.Text = "Crear Nuevo Cliente";
                    break;
                case 1:
                    button3.Enabled = false;
                    fillData();
                    this.Text = "Modificar Cliente";
                    break;
                case 2:
                    button2.Enabled = false;
                    fillData();
                    this.Text = "Dar de Baja Cliente";
                    break;
            }

            textBox1.Enabled = false;
            
        }

        //-----------------------------------------------------------------------------------------------------------------
        private void fillData() {
            textBox1.Text = cliente.id.ToString();
            textBox2.Text = cliente.documentoNumero.ToString();
            textBox3.Text = cliente.apellido;
            textBox4.Text = cliente.nombre;

        }
        //-----------------------------------------------------------------------------------------------------------------


        //EVENT HANDLER***
        //cambian los campos de texto
        //-----------------------------------------------------------------------------------------------------------------
        private void requireds_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text.Length != 0 && textBox3.Text.Length != 0 &&
                textBox4.Text.Length != 0 && textBox6.Text.Length != 0)
            {
                button3.Enabled = true;
            }
            else {
                button3.Enabled = false;
            }
            
        }
        //-----------------------------------------------------------------------------------------------------------------
    }
}
