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

        private List<ClienteModel> clientes;

        public ClienteAbm()
        {
            InitializeComponent();

            this.clienteDao = new ClienteDao();
            this.cuentaDao = new CuentaDao();
            this.clientes = clienteDao.getClients();

            fillClientsTable();

            //sets
            button3.Enabled = false;
            button4.Enabled = false;
        }

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
                                        cliente.telefono.ToString(),
                                        cliente.nacimiento.ToString(),
                                        cliente.nacionalidadId.ToString(),
										cliente.direccionCalle.ToString(),
										cliente.direccionNumeroCalle.ToString(),
										cliente.direccionPiso.ToString(),
										cliente.direccionDepto.ToString(),
                                        cliente.localidadId.ToString(),
										cliente.paisId.ToString(),
										cliente.usuario.nombre.ToString(),
										cliente.habilitado.ToString()
                                        };
                dataGridView1.Rows.Add(row);
            }
        }
        //-----------------------------------------------------------------------------------------------------------------

        //-----------------------------------------------------------------------------------------------------------------
        private void fillClientesTableWithFilters() {
            
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
        
        //filtrar
        //-----------------------------------------------------------------------------------------------------------------
        private void button5_Click(object sender, EventArgs e)
        {
            fillClientesTableWithFilters();
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
            ClienteForm clienteForm = new ClienteForm(AGREGAR_CLIENTE, clienteActivo, clienteDao, null);
            clienteForm.MdiParent = this.MdiParent;
            clienteForm.Show();
        }
        //-----------------------------------------------------------------------------------------------------------------

        //Modificar Cliente
        //-----------------------------------------------------------------------------------------------------------------
        private void button3_Click(object sender, EventArgs e)
        {
            ClienteForm clienteForm = new ClienteForm(MODIFICAR_CLIENTE, clienteActivo, clienteDao, this);
            clienteForm.MdiParent = this.MdiParent;
            clienteForm.Show();
        }
        //-----------------------------------------------------------------------------------------------------------------

        //Dar de Baja Cliente
        //-----------------------------------------------------------------------------------------------------------------
        private void button4_Click(object sender, EventArgs e)
        {
            ClienteForm clienteForm = new ClienteForm(DESHABILITAR_CLIENTE, clienteActivo, clienteDao, this);
            clienteForm.MdiParent = this.MdiParent;
            clienteForm.Show();
        }
        //-----------------------------------------------------------------------------------------------------------------
    }
}
