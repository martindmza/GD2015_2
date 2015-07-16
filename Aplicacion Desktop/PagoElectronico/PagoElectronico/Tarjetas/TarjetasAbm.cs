using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DAO;
using Models;
using Logins;
using ABM;
using Depositos;

namespace Tarjetas
{
    public partial class TarjetasAbm : Form
    {
        private const int AGREGAR = 0;
        private const int MODIFICAR = 1;
        private const int DESHABILITAR = 2;

        private TarjetaDeCreditoDao dao;
        private List<TarjetaDeCreditoModel> tarjetas = new List<TarjetaDeCreditoModel>();
        private Int32 tarjetaActivoIndex;
        private TarjetaDeCreditoModel tarjetaActiva;

        private ClienteModel cliente;
        private ClienteForm parentClienteForm;
        private DepositosAbm parentDepositos;

        public TarjetasAbm()
        {
            init();
        }

        public TarjetasAbm(ClienteForm parentClienteForm,ClienteModel cliente)
        {
            this.cliente = cliente;
            init();
            this.buttonCerrar.Visible = true;
            this.parentClienteForm = parentClienteForm;
            this.parentClienteForm.Enabled = false;
            ControlBox = false;
        }

        public TarjetasAbm(DepositosAbm parentDepositos)
        {
            initToSelect();
            this.parentDepositos = parentDepositos;
            this.parentDepositos.Enabled = false;
        }

        //-----------------------------------------------------------------------------------------------------------------
        private void init()
        {
            InitializeComponent();

            dao = new TarjetaDeCreditoDao();
            if (cliente == null) {
                UserModel usuario = UsuarioSingleton.getInstance().getUsuario();
                cliente = new ClienteDao().getClienteByUser(usuario);
            }

            if (cliente != null)
            {
                tarjetas = dao.getListadoByCliente(cliente);
            }

            else
            {
                buttonBuscar.Enabled = false;
            }
            fillData();

            buttonElegir.Visible = false;
            buttonCancelar.Visible = false;
            buttonQuitar.Enabled = false;
            buttonModificar.Enabled = false;
        }
        //-----------------------------------------------------------------------------------------------------------------

        //-----------------------------------------------------------------------------------------------------------------
        private void initToSelect()
        {
            InitializeComponent();

          
            dao = new TarjetaDeCreditoDao();
            UserModel usuario = UsuarioSingleton.getInstance().getUsuario();
            cliente = usuario.cliente;
            if (cliente != null)
            {
                tarjetas = dao.getListadoByCliente(cliente);
            }
            else
            {
                buttonBuscar.Enabled = false;
            }
            fillData();

            this.Text = "Seleccionar una Cuenta";

            buttonElegir.Visible = true;
            buttonElegir.Enabled = false;
            buttonCancelar.Visible = true;
            buttonQuitar.Visible = false;
            buttonModificar.Visible = false;
            buttonAgregar.Visible = false;
            ControlBox = false;
        }
        //-----------------------------------------------------------------------------------------------------------------

        //-----------------------------------------------------------------------------------------------------------------
        private void fillData()
        {
            dataGridView1.Rows.Clear();

            string[] row;
            foreach (TarjetaDeCreditoModel tarjeta in tarjetas)
            {
                row = new String[] {    tarjeta.numero.ToString(),
                                        (tarjeta.emisor != null)? tarjeta.emisor.nombre : "",
                                        tarjeta.emision.ToShortDateString(),
                                        tarjeta.vencimiento.ToShortDateString()
                                        };
                dataGridView1.Rows.Add(row);
            }
        }
        //-----------------------------------------------------------------------------------------------------------------

        //-----------------------------------------------------------------------------------------------------------------
        public void formResponseAdd(TarjetaDeCreditoModel tarjeta)
        {
            tarjetas.Add(tarjeta);
            fillData();
        }
        //-----------------------------------------------------------------------------------------------------------------

        //-----------------------------------------------------------------------------------------------------------------
        public void formResponseUpdate(TarjetaDeCreditoModel tarjeta)
        {
            tarjetas[tarjetaActivoIndex] = tarjeta;
            fillData();
        }
        //-----------------------------------------------------------------------------------------------------------------

        //-----------------------------------------------------------------------------------------------------------------
        public void formResponseDisable(TarjetaDeCreditoModel tarjeta)
        {
            tarjetas.Remove(tarjeta);
            tarjetaActiva = null;
            tarjetaActivoIndex = 0;
            buttonModificar.Enabled = false;
            buttonQuitar.Enabled = false;
            fillData();
        }
        //-----------------------------------------------------------------------------------------------------------------

        //Event Handler***
        //-----------------------------------------------------------------------------------------------------------------
        private void buttonAgregar_Click(object sender, EventArgs e)
        {
            Form f = new TarjetasForm(AGREGAR, this, null,cliente);
            f.MdiParent = this.MdiParent;
            f.Show();
        }
        //-----------------------------------------------------------------------------------------------------------------

        //-----------------------------------------------------------------------------------------------------------------
        private void buttonModificar_Click(object sender, EventArgs e)
        {
            Form f = new TarjetasForm(MODIFICAR, this, tarjetaActiva,cliente);
            f.MdiParent = this.MdiParent;
            f.Show();
        }
        //-----------------------------------------------------------------------------------------------------------------

        //-----------------------------------------------------------------------------------------------------------------
        private void buttonQuitar_Click(object sender, EventArgs e)
        {
            Form f = new TarjetasForm(DESHABILITAR, this, tarjetaActiva,cliente);
            f.MdiParent = this.MdiParent;
            f.Show();
        }
        //-----------------------------------------------------------------------------------------------------------------


        //-----------------------------------------------------------------------------------------------------------------
        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                int filaActiva = this.dataGridView1.CurrentCell.RowIndex;
                String numTarjetaActiva = dataGridView1.Rows[filaActiva].Cells[0].Value.ToString();

                int count = 0;
                foreach (TarjetaDeCreditoModel t in tarjetas)
                {
                    if (numTarjetaActiva.Equals(t.numero.ToString()))
                    {
                        tarjetaActiva = t;
                        tarjetaActivoIndex = count;
                        break;
                    }
                    count++;
                }

                buttonElegir.Enabled = true;
                buttonModificar.Enabled = true;
                buttonQuitar.Enabled = true;
            }
            catch (NullReferenceException errTarj)
            {
                buttonElegir.Enabled = false;
                buttonModificar.Enabled = false;
                buttonQuitar.Enabled = false;
            }
        }
        //-----------------------------------------------------------------------------------------------------------------

        //-----------------------------------------------------------------------------------------------------------------
        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(numeroText.Text, "[^0-9]"))
                {
                    MessageBox.Show("Ingrese solo números");
                }
                else {
                    String numero = numeroText.Text;
                    if (numero.Trim().Length == 0)
                    {
                        tarjetas = dao.getListadoByCliente(cliente);
                    }
                    else {
                        tarjetas = dao.getTarjetasByClienteAndNumero(cliente, numero);
                    }
                }
            }
            catch (NullReferenceException eru) { }
            catch (Exception erg) { }
            fillData();
        }
        //-----------------------------------------------------------------------------------------------------------------

        //-----------------------------------------------------------------------------------------------------------------
        private void buttonElegir_Click(object sender, EventArgs e)
        {
            if (parentDepositos != null)
            {
                parentDepositos.formResponseTarjeta(tarjetaActiva);
                parentDepositos.Enabled = true;
            }

            this.Close();
            this.Dispose();
            GC.Collect();
        }
        //-----------------------------------------------------------------------------------------------------------------

        //-----------------------------------------------------------------------------------------------------------------
        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            if (parentDepositos != null)
            {
                parentDepositos.Enabled = true;
            }

            this.Close();
            this.Dispose();
            GC.Collect();
        }
        //-----------------------------------------------------------------------------------------------------------------

        //-----------------------------------------------------------------------------------------------------------------
        private void buttonCerrar_Click(object sender, EventArgs e)
        {
            if (parentClienteForm != null)
            {
                parentClienteForm.Enabled = true;
            }

            this.Close();
            this.Dispose();
            GC.Collect();
        }
        //-----------------------------------------------------------------------------------------------------------------
    }
}