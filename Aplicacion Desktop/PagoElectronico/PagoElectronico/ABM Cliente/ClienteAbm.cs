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
    public partial class ClienteAbm : Form
    {
        private const int AGREGAR_CLIENTE = 0;
        private const int MODIFICAR_CLIENTE = 1;
        private const int DESHABILITAR_CLIENTE = 2;

        private Int32 clienteActivoIndex;
        private ClienteModel clienteActivo;
        private ClienteDao clienteDao;
        private CuentaDao cuentaDao;
        private ExtraDao extraDao;

        private List<ClienteModel> clientes;

        public ClienteAbm()
        {
            InitializeComponent();

            this.clienteDao = new ClienteDao();
            this.cuentaDao = new CuentaDao();
            this.extraDao = new ExtraDao();
            this.clientes = clienteDao.getClients();

            fillClientsTable();
            fillDocTypes();

            //sets
            button3.Enabled = false;
            button4.Enabled = false;
        }
        //-----------------------------------------------------------------------------------------------------------------
        private void fillDocTypes()
        {
            KeyValuePair<int, string> firstTipo = new KeyValuePair<int,string>();
            foreach (KeyValuePair<int, string> tipo in extraDao.getDocTypes())
            {
                if (comboBox1.Items.Count == 0) {
                    firstTipo = tipo;
                }
                comboBox1.Items.Add(tipo);
            }
            comboBox1.DisplayMember = "Value";
            comboBox1.ValueMember = "Key";
        }
        //-----------------------------------------------------------------------------------------------------------------

        //-----------------------------------------------------------------------------------------------------------------
        private void fillClientsTable() {

            dataGridView1.Rows.Clear();

            string[] row;
            foreach (ClienteModel cliente in clientes)
            {
                row = new String[] {    cliente.id.ToString(),
                                        cliente.apellido.ToString(),
                                        cliente.nombre.ToString(),
                                        cliente.documentoTipo.ToString(),
                                        cliente.documentoNumero.ToString(),
                                        cliente.email.ToString(),
                                        cliente.nacimiento.ToString(),
                                        cliente.nacionalidadId.ToString(),
										cliente.direccionCalle.ToString(),
										cliente.direccionNumeroCalle.ToString(),
										cliente.direccionPiso.ToString(),
										cliente.direccionDepto.ToString(),
                                        cliente.localidadId.ToString(),
										cliente.paisId.ToString(),
										cliente.habilitado.ToString()
                                        };
                dataGridView1.Rows.Add(row);
            }
        }
        //-----------------------------------------------------------------------------------------------------------------



        //Event Handler***
        //Limpiar filtros
        //-----------------------------------------------------------------------------------------------------------------
        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            checBox1.Checked = false;
        }
        //-----------------------------------------------------------------------------------------------------------------

        //-----------------------------------------------------------------------------------------------------------------
        public void formResponseAdd(ClienteModel cliente)
        {
            clientes.Add(cliente);
            fillClientsTable();
        }
        //-----------------------------------------------------------------------------------------------------------------

        //-----------------------------------------------------------------------------------------------------------------
        public void formResponseUpdate(ClienteModel cliente)
        {
            clientes[clienteActivoIndex] = cliente;
            fillClientsTable();
        }
        //-----------------------------------------------------------------------------------------------------------------

        //-----------------------------------------------------------------------------------------------------------------
        public void formResponseDisable(ClienteModel cliente)
        {
            clientes[clienteActivoIndex] = cliente;
            fillClientsTable();
        }
        //-----------------------------------------------------------------------------------------------------------------

        //filtrar
        //-----------------------------------------------------------------------------------------------------------------
        private void button5_Click(object sender, EventArgs e)
        {
            ClienteFiltros filtros = new ClienteFiltros();

            if (textBox1.Text.Length != 0)
            {
                filtros.nombre = textBox1.Text;
            }
            if (textBox2.Text.Length != 0)
            {
                filtros.apellido = textBox2.Text;
            }
            if (textBox3.Text.Length != 0)
            {
                filtros.email = textBox3.Text;
            }
            //tipo de documento
            if (comboBox1.SelectedItem != null)
            {
                String[] result = comboBox1.SelectedItem.ToString().Split(',');
                String[] valueString = result[0].Split('[');
                UInt32 value = UInt32.Parse(valueString[1]);
                filtros.documentoTipo = value;
            }
            //nro de documento
            if (textBox4.Text.Length != 0)
            {
                filtros.documentoNumero = UInt64.Parse(textBox4.Text);
            }
            if (checBox1.Checked)
            {
                filtros.habilitado = true;
            }
            MessageBox.Show(filtros.ToString());
            clientes = clienteDao.getClientsByFilters(filtros);
            fillClientsTable();
        }
        //-----------------------------------------------------------------------------------------------------------------

        //click en cliente
        //-----------------------------------------------------------------------------------------------------------------
        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int filaActiva = this.dataGridView1.CurrentCell.RowIndex;
            String idClienteActivo = dataGridView1.Rows[filaActiva].Cells[0].Value.ToString();

            int count = 0;
            foreach (ClienteModel cliente in clientes)
            {
                if (idClienteActivo.Equals(cliente.id.ToString()))
                {
                    clienteActivo = cliente;
                    clienteActivoIndex = count;
                    break;
                }
                count++;
            }

            button3.Enabled = true;
            button4.Enabled = true;
        }
        //-----------------------------------------------------------------------------------------------------------------

        //Agregar Cliente
        //-----------------------------------------------------------------------------------------------------------------
        private void button2_Click(object sender, EventArgs e)
        {
            ClienteForm clienteForm = new ClienteForm(AGREGAR_CLIENTE, null, clienteDao, this, extraDao);
            clienteForm.MdiParent = this.MdiParent;
            clienteForm.Show();
        }
        //-----------------------------------------------------------------------------------------------------------------

        //Modificar Cliente
        //-----------------------------------------------------------------------------------------------------------------
        private void button3_Click(object sender, EventArgs e)
        {
            ClienteForm clienteForm = new ClienteForm(MODIFICAR_CLIENTE, clienteActivo, clienteDao, this, extraDao);
            clienteForm.MdiParent = this.MdiParent;
            clienteForm.Show();
        }
        //-----------------------------------------------------------------------------------------------------------------

        //Dar de Baja Cliente
        //-----------------------------------------------------------------------------------------------------------------
        private void button4_Click(object sender, EventArgs e)
        {
            ClienteForm clienteForm = new ClienteForm(DESHABILITAR_CLIENTE, clienteActivo, clienteDao, this, extraDao);
            clienteForm.MdiParent = this.MdiParent;
            clienteForm.Show();
        }
        //-----------------------------------------------------------------------------------------------------------------

        //-----------------------------------------------------------------------------------------------------------------
        private void textBox4_Leave(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox4.Text, "[^0-9]"))
            {
                MessageBox.Show("Ingrese solo numeros por favor");
                textBox4.Text = "";
            }
        }
        //-----------------------------------------------------------------------------------------------------------------
    }
}
