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
using Tarjetas;

namespace ABM
{
    public partial class ClienteAbm : Form
    {
        private const int AGREGAR_CLIENTE = 0;
        private const int MODIFICAR_CLIENTE = 1;
        private const int DESHABILITAR_CLIENTE = 2;

        int operacionTipo;

        private Int32 clienteActivoIndex;
        private ClienteModel clienteActivo;
        private ClienteDao clienteDao;
        private CuentaDao cuentaDao;
        private ExtraDao extraDao;

        private CuentaAbm parentCuenta;
        private CuentaForm parentCuentaForm;

        private List<ClienteModel> clientes;

        public ClienteAbm(int operacionTipo, CuentaAbm parentCuenta)
        {
            init(operacionTipo);
            this.parentCuenta = parentCuenta;
            parentCuenta.Enabled = false;
        }

        public ClienteAbm(int operacionTipo, CuentaForm parentCuentaForm)
        {
            init(operacionTipo);
            this.parentCuentaForm = parentCuentaForm;
            parentCuentaForm.Enabled = false;
        }

        public ClienteAbm(int operacionTipo)
        {
            init(operacionTipo);
        }

        private void init(int operacionTipo) {

            this.operacionTipo = operacionTipo;
            InitializeComponent();

            this.clienteDao = new ClienteDao();
            this.cuentaDao = new CuentaDao();
            this.extraDao = new ExtraDao();
            this.clientes = clienteDao.getListado();

            fillClientsTable();
            fillDocTypes();

            //sets
            button3.Enabled = false;
            button4.Enabled = false;
            comboBox1.SelectedItem = comboBox1.Items[0];

            if (operacionTipo == 0)
            {
                elegir.Visible = false;
                buttonCancelar.Visible = false;
            }
            else if (operacionTipo == 1)
            {
                elegir.Visible = true;
                buttonCancelar.Visible = true;
                ControlBox = false;
                button2.Visible = false;
                button3.Visible = false;
                button4.Visible = false;
            }
        }


        //-----------------------------------------------------------------------------------------------------------------
        private void fillDocTypes()
        {
            KeyValuePair<UInt32, String> empty = new KeyValuePair<UInt32, String>(0,"");
            comboBox1.Items.Add(empty);
            TipoDocumentoDAO docDao = new TipoDocumentoDAO();

            foreach (TipoDocumentoModel tipo in docDao.getListado())
            {
                comboBox1.Items.Add(new KeyValuePair<Decimal, String>(tipo.id, tipo.nombre));
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
                                        cliente.apellido,
                                        cliente.nombre,
                                       (cliente.tipoDocumento != null)? cliente.tipoDocumento.nombre.ToString() : "",
                                       (cliente.nroDocumento != 0)? cliente.nroDocumento.ToString() : "",
                                        cliente.email,
                                       (cliente.nacimiento != null)? cliente.nacimiento.ToString() : "",
                                       (cliente.nacionalidad != null)? cliente.nacionalidad.nombre : "",
										cliente.direccionCalle,
									   (cliente.direccionNumeroCalle != 0)? cliente.direccionNumeroCalle.ToString() : "",
									   (cliente.direccionPiso != 0)? cliente.direccionPiso.ToString() : "",
                                        cliente.direccionDepto,
                                        cliente.localidad,
									   (cliente.pais != null)? cliente.pais.nombre : ""
                                        };
                dataGridView1.Rows.Add(row);
            }
            dataGridView1.PerformLayout();
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
        public void formResponseDisable()
        {
            clientes.Remove(clienteActivo);
            clienteActivo = null;
            clienteActivoIndex = 0;
            button3.Enabled = false;
            button4.Enabled = false;
            fillClientsTable();
        }
        //-----------------------------------------------------------------------------------------------------------------

        //Event Handler***
        //-----------------------------------------------------------------------------------------------------------------
        //Limpiar filtros
        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
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

            clientes = clienteDao.getClientsByFilters(filtros);
            fillClientsTable();
        }
        //-----------------------------------------------------------------------------------------------------------------

        //click en cliente
        //-----------------------------------------------------------------------------------------------------------------
        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
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
                elegir.Enabled = true;
            }
            catch (NullReferenceException errTarj)
            {
                elegir.Enabled = false;
            }
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

        //Dar de Baja Cliente o alta
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

        //-----------------------------------------------------------------------------------------------------------------
        //elegir un cliente
        private void elegir_Click(object sender, EventArgs e)
        {
            if (parentCuenta != null)
            {
                parentCuenta.formResponseCliente(clienteActivo);
                parentCuenta.Enabled = true;
            }
            if (parentCuentaForm != null)
            {
                parentCuentaForm.formResponseCliente(clienteActivo);
                parentCuentaForm.Enabled = true;
            }

            this.Close();
            this.Dispose();
            GC.Collect();
        }
        //-----------------------------------------------------------------------------------------------------------------

        //-----------------------------------------------------------------------------------------------------------------
        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            if (parentCuenta != null)
            {
                parentCuenta.Enabled = true;
            }
            if (parentCuentaForm != null)
            {
                parentCuentaForm.Enabled = true;
            }

            this.Close();
            this.Dispose();
            GC.Collect();
        }
        //-----------------------------------------------------------------------------------------------------------------
    }
}

