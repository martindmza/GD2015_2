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
using Depositos;
using Retiros;
using Transferencias;

namespace ABM
{
    public partial class CuentaAbm : Form
    {
        private const int AGREGAR = 0;
        private const int MODIFICAR = 1;
        private const int DESHABILITAR = 2;

        private ClienteModel clienteSeleccionado;
        private Int32 cuentaActivoIndex;
        private CuentaModel cuentaActiva;
        private List<CuentaModel> cuentas;

        private DepositosAbm parentDepositos;
        private RetirosAbm parentRetiros;
        private TransferenciaAbm parentTransferenciaOrigen;
        private TransferenciaAbm parentTransferenciaDestino;
        private ConsultaDeSaldos parentConsultaDeSaldos;

        private const int OPEN_CLIENTE_ABM_TO_SELECT = 1;

        public CuentaAbm()
        {
            init();
        }

        public CuentaAbm(DepositosAbm parentDepositos)
        {
            initToSelect(true);
            this.parentDepositos = parentDepositos;
            this.parentDepositos.Enabled = false;
        }

        public CuentaAbm(ConsultaDeSaldos parentConsultaDeSaldos)
        {
            initToSelect(true);
            this.parentConsultaDeSaldos = parentConsultaDeSaldos;
            this.parentConsultaDeSaldos.Enabled = false;
        }

        public CuentaAbm(RetirosAbm parentRetiros)
        {
            initToSelect(false);
            this.parentRetiros = parentRetiros;
            this.parentRetiros.Enabled = false;
            button1.Enabled = false;
            button5.Visible = false;
        }

        public CuentaAbm(TransferenciaAbm parentTransferencia,int origenOdestino)
        {
            if (origenOdestino == 0) {
                initToSelect(false);
                button1.Enabled = false;
                button5.Visible = false;
                this.parentTransferenciaOrigen = parentTransferencia;
                this.parentTransferenciaOrigen.Enabled = false;
            }
            else if (origenOdestino == 1) {
                initToSelect(true);
                this.parentTransferenciaDestino = parentTransferencia;
                this.parentTransferenciaDestino.Enabled = false;
            }
            
        }


        //-----------------------------------------------------------------------------------------------------------------
        private void init() {
            InitializeComponent();
            button3.Enabled = false;
            button4.Enabled = false;
            cargarCuentasSiTieneCliente();
            
        }

        private void cargarCuentasSiTieneCliente()
        {
            UserModel usuario = Logins.UsuarioSingleton.getInstance().getUsuario();
            if (usuario.cliente != null)
            {
                this.formResponseCliente(usuario.cliente);
                cuentas = new CuentaDao().getCuentasByCliente(usuario.cliente);
                button1.Visible = false;
                button5.Visible = false;
                buttonLimpiar.Visible = false;
            }
            else
            {
                this.cuentas = new CuentaDao().getCuentas();
                this.nombreLabel.Text = "";
            }
            fillTable();
        }
        //-----------------------------------------------------------------------------------------------------------------

        //-----------------------------------------------------------------------------------------------------------------
        private void initToSelect(Boolean doFillTable)
        {
            InitializeComponent();

            this.cargarCuentasSiTieneCliente();
            this.Text = "Seleccionar una Cuenta";
            buttonElegir.Visible = true;
            buttonElegir.Enabled = false;
            buttonCancelar.Visible = true;
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
            ControlBox = false;
        }
        //-----------------------------------------------------------------------------------------------------------------

        //-----------------------------------------------------------------------------------------------------------------
        private void fillTable()
        {
            dataGridView1.Rows.Clear();

            string[] row;
            foreach (CuentaModel cuenta in cuentas)
            {
                row = new String[] {    cuenta.id.ToString(),
                                       (cuenta.pais != null)? cuenta.pais.nombre : "",
                                       (cuenta.moneda != null)? cuenta.moneda.nombre : "",
                                       (cuenta.tipo.nombre != null)? cuenta.tipo.nombre : "",
                                       (cuenta.propietario != null)? cuenta.propietario.apellido + ", " +
                                                                    cuenta.propietario.nombre : "",
                                        cuenta.fechaCreacion.ToString(),
                                        cuenta.fechaCierre.ToString(),
                                       (cuenta.estado != null)? cuenta.estado.nombre : ""
                                        };
                dataGridView1.Rows.Add(row);
            }
            dataGridView1.PerformLayout();
        }
        //-----------------------------------------------------------------------------------------------------------------

        //-----------------------------------------------------------------------------------------------------------------
        public void formResponseCliente(ClienteModel cliente)
        {
            if (cliente != null)
            {
                clienteSeleccionado = cliente;
                clienteText.Text = cliente.id.ToString();
                nombreLabel.Text = cliente.apellido + ", " + cliente.nombre;
            }
        }
        //-----------------------------------------------------------------------------------------------------------------

        //-----------------------------------------------------------------------------------------------------------------
        public void formResponseAdd(CuentaModel cuenta)
        {
            cuentas.Add(cuenta);
            fillTable();
        }
        //-----------------------------------------------------------------------------------------------------------------

        //-----------------------------------------------------------------------------------------------------------------
        public void formResponseUpdate(CuentaModel cuenta)
        {
            cuentas[cuentaActivoIndex] = cuenta;
            fillTable();
        }
        //-----------------------------------------------------------------------------------------------------------------

        //-----------------------------------------------------------------------------------------------------------------
        public void formResponseDisable(CuentaModel cuenta)
        {
            cuentas[cuentaActivoIndex] = cuenta;
            fillTable();
        }
        //-----------------------------------------------------------------------------------------------------------------

        //Event Handler***
        //click en una cuenta
        //-----------------------------------------------------------------------------------------------------------------
        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                int filaActiva = this.dataGridView1.CurrentCell.RowIndex;
                String idCuentaActiva = dataGridView1.Rows[filaActiva].Cells[0].Value.ToString();

                int count = 0;
                foreach (CuentaModel cuenta in cuentas)
                {
                    if (idCuentaActiva.Equals(cuenta.id.ToString()))
                    {
                        cuentaActiva = cuenta;
                        cuentaActivoIndex = count;
                        break;
                    }
                    count++;
                }

                button3.Enabled = true;
                button4.Enabled = true;
                buttonElegir.Enabled = true;
            }
            catch (NullReferenceException errTarj)
            {
                buttonElegir.Enabled = false;
            }
            
        }
        //-----------------------------------------------------------------------------------------------------------------

        //-----------------------------------------------------------------------------------------------------------------
        //Buscar cliente
        private void button1_Click(object sender, EventArgs e)
        {
            Form clienteAbm = new ClienteAbm(OPEN_CLIENTE_ABM_TO_SELECT, this);
            clienteAbm.MdiParent = this.MdiParent;
            clienteAbm.Show();
        }
        //-----------------------------------------------------------------------------------------------------------------

        //-----------------------------------------------------------------------------------------------------------------
        //Buscar cuenta por cliente
        private void button5_Click(object sender, EventArgs e)
        {
            if (clienteSeleccionado == null)
            {
                cuentas = new CuentaDao().getCuentas();
            }
            else {
                cuentas = new CuentaDao().getCuentasByCliente(clienteSeleccionado);
            }
            fillTable();
        }
        //-----------------------------------------------------------------------------------------------------------------

        //-----------------------------------------------------------------------------------------------------------------
        //Alta
        private void button2_Click(object sender, EventArgs e)
        {
            CuentaForm cuentaForm = new CuentaForm(AGREGAR,null,this);
            cuentaForm.MdiParent = this.MdiParent;
            cuentaForm.Show();
        }
        //-----------------------------------------------------------------------------------------------------------------

        //-----------------------------------------------------------------------------------------------------------------
        //Modificar
        private void button3_Click(object sender, EventArgs e)
        {
            CuentaForm cuentaForm = new CuentaForm(MODIFICAR, cuentaActiva, this);
            cuentaForm.MdiParent = this.MdiParent;
            cuentaForm.Show();
        }
        //-----------------------------------------------------------------------------------------------------------------

        //-----------------------------------------------------------------------------------------------------------------
        //Baja
        private void button4_Click(object sender, EventArgs e)
        {
            CuentaForm cuentaForm = new CuentaForm(DESHABILITAR, cuentaActiva, this);
            cuentaForm.MdiParent = this.MdiParent;
            cuentaForm.Show();
        }
        //-----------------------------------------------------------------------------------------------------------------

        //-----------------------------------------------------------------------------------------------------------------
        private void buttonElegir_Click(object sender, EventArgs e)
        {
            if (parentDepositos != null) {
                parentDepositos.formResponseCuenta(cuentaActiva);
                parentDepositos.Enabled = true;
            }
            else
            if (parentRetiros != null)
            {
                parentRetiros.formResponseCuenta(cuentaActiva);
                parentRetiros.Enabled = true;
            }
            else
            if (parentTransferenciaOrigen != null)
            {
                parentTransferenciaOrigen.formResponseCuentaOrigen(cuentaActiva);
                parentTransferenciaOrigen.Enabled = true;
            }
            else
            if (parentTransferenciaDestino != null)
            {
                parentTransferenciaDestino.formResponseCuentaDestino(cuentaActiva);
                parentTransferenciaDestino.Enabled = true;
            }
            if (parentConsultaDeSaldos != null)
            {
                parentConsultaDeSaldos.formResponseCuenta(cuentaActiva);
                parentConsultaDeSaldos.Enabled = true;
            }
            
            this.Close();
            this.Dispose();
            GC.Collect();
        }
        //-----------------------------------------------------------------------------------------------------------------

        //-----------------------------------------------------------------------------------------------------------------
        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            if (parentDepositos != null) {
                parentDepositos.Enabled = true;
            }
            if (parentRetiros != null)
            {
                parentRetiros.Enabled = true;
            }
            if (parentTransferenciaDestino != null)
            {
                parentTransferenciaDestino.Enabled = true;
            }
            if (parentTransferenciaOrigen != null)
            {
                parentTransferenciaOrigen.Enabled = true;
            }
            if (parentConsultaDeSaldos != null)
            {
                parentConsultaDeSaldos.Enabled = true;
            }

            this.Close();
            this.Dispose();
            GC.Collect();
        }
        //-----------------------------------------------------------------------------------------------------------------

        //-----------------------------------------------------------------------------------------------------------------
        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            clienteSeleccionado = null;
            clienteText.Text = "";
            nombreLabel.Text = "";
        }
        //-----------------------------------------------------------------------------------------------------------------
    }
}
