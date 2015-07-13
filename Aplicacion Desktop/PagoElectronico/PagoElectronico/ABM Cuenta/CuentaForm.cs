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
using FormsExtras;

namespace ABM
{
    public partial class CuentaForm : Form
    {
        private CuentaModel cuenta;
        private int operacionTipo;
        private CuentaAbm parentCuenta;

        private ExtraDao extraDao;
        private CuentaDao cuentaDao;
        private ClienteDao clienteDao;
        private ClienteModel cliente;
        private EstadoDao estadoDao;
        private EstadoModel estado;
        private List<CuentaTipoModel> tipos;
        private CuentaTipoModel tipoActivo;
        private PaisModel paisCuenta;
        private MonedaDAO monedaDao;
        private MonedaModel monedaModel;

        private const int SELECCIONAR_PAIS = 0;
        private const int OPEN_CLIENTE_ABM_TO_SELECT = 1;

        public CuentaForm(int operacionTipo, CuentaModel cuenta,CuentaAbm parentCuenta)
        {
            InitializeComponent();
            if (cuenta != null)
            {
                this.cuenta = cuenta;
                
            }
            this.operacionTipo = operacionTipo;
            this.cuentaDao = new CuentaDao();
            this.clienteDao = new ClienteDao();
            this.extraDao = new ExtraDao();
            this.estadoDao = new EstadoDao();
            this.monedaDao = new MonedaDAO();
            this.parentCuenta = parentCuenta;
            this.cliente = Logins.UsuarioSingleton.getInstance().getUsuario().cliente;

            tipos = cuentaDao.getCuentaTypes();
            fillComboBox();
            fillData();

            switch (operacionTipo)
            {
                case 0:
                    aceptar.Enabled = false;
                    estadoText.Visible = false;
                    estadoLabel.Visible = false;
                    if (cliente != null)
                    {
                        this.formResponseCliente(cliente);
                        this.button1.Visible = false;
                    }
                    this.Text = "Crear Nueva Cuenta";
                    break;
                case 1:
                    aceptar.Enabled = true;
                    button1.Visible = false;
                    button2.Visible = false;
                    apertura.Enabled = false;
                    moneda.Enabled = false;
                    this.Text = "Modificar Cuenta";
                    break;
                case 2:
                    this.Text = "Dar de Baja Cuenta";
                    this.aceptar.Text = "Dar de Baja";
                    disableInputs();
                    break;
            }

            parentCuenta.Enabled = false;
            //clienteNameLabel.Text = "";

        }


        //-----------------------------------------------------------------------------------------------------------------
        private void disableInputs()
        {
            tipoCuenta.Enabled = false;
            apertura.Enabled = false;
            moneda.Enabled = false;
            button1.Enabled = false;
            button2.Enabled = false;
        }
        //-----------------------------------------------------------------------------------------------------------------

        //-----------------------------------------------------------------------------------------------------------------
        private void fillComboBox()
        {
            //tipos de cuentas
            foreach (CuentaTipoModel tipo in tipos)
            {
                tipoCuenta.Items.Add(new KeyValuePair<Decimal, String>(tipo.id, tipo.nombre));
            }
            tipoCuenta.DisplayMember = "Value";
            tipoCuenta.ValueMember = "Key";

            //tipos de moneda
            KeyValuePair<Decimal, String> dolares = new KeyValuePair<Decimal, String>(1,"Dolares");
            moneda.Items.Add(dolares);
            moneda.DisplayMember = "Value";
            moneda.ValueMember = "Key";


        }
        //-----------------------------------------------------------------------------------------------------------------

        //-----------------------------------------------------------------------------------------------------------------
        private void fillData()
        {

            if (cuenta == null)
            {
                apertura.Value = DateTime.Today;
                tipoCuenta.SelectedItem = tipoCuenta.Items[0];
                tipoActivo = tipos[0];
                moneda.SelectedItem = moneda.Items[0];
                estado = estadoDao.dameTuModelo(1.ToString());
                monedaModel = monedaDao.dameTuModelo(moneda.ValueMember);
            }
            else
            {
                clienteText.Text = cuenta.propietario.apellido + ", " + cuenta.propietario.nombre;
                estadoText.Text = cuenta.estado.nombre;
                numero.Text = cuenta.id.ToString();
                paisText.Text = cuenta.pais.nombre;
                moneda.SelectedItem = moneda.Items[0];
                apertura.Value = cuenta.fechaCreacion;

                for (int i = 0; i < tipoCuenta.Items.Count; i++)
                {
                    String[] result = tipoCuenta.Items[i].ToString().Split(',');
                    String[] valueString = result[0].Split('[');
                    UInt32 value = UInt32.Parse(valueString[1]);

                    if (value == cuenta.tipo.id)
                    {
                        tipoCuenta.SelectedItem = tipoCuenta.Items[i];
                        break;
                    }
                }

                cliente = cuenta.propietario;
                estado = cuenta.estado;
                paisCuenta = cuenta.pais;
                tipoActivo = cuenta.tipo;
                monedaModel = cuenta.moneda;
            }


        }
        //-----------------------------------------------------------------------------------------------------------------

        //-----------------------------------------------------------------------------------------------------------------
        public void formResponseCliente(ClienteModel clienteSeleccionado)
        {
            this.clienteText.Text = clienteSeleccionado.id.ToString();
            clienteNameLabel.Text = clienteSeleccionado.apellido + ", " + clienteSeleccionado.nombre;
            this.cliente = clienteSeleccionado;
        }
        //-----------------------------------------------------------------------------------------------------------------

        //-----------------------------------------------------------------------------------------------------------------
        public void setPaisSeleccionado(PaisModel paisSeleccionado)
        {
            this.paisText.Text = paisSeleccionado.nombre;
            this.paisCuenta = paisSeleccionado;
        }
        //-----------------------------------------------------------------------------------------------------------------

        //EVENT HANDLER***
        //cambian los campos de texto
        //-----------------------------------------------------------------------------------------------------------------
        private void requireds_TextChanged(object sender, EventArgs e)
        {
            if (clienteText.Text.Length != 0 && paisText.Text.Length != 0 )
            {
                aceptar.Enabled = true;
            }
            else
            {
                aceptar.Enabled = false;
            }
        }
        //-----------------------------------------------------------------------------------------------------------------

        //-----------------------------------------------------------------------------------------------------------------
        //Seleccionar un cliente
        private void button1_Click(object sender, EventArgs e)
        {
            Form clienteAbm = new ClienteAbm(OPEN_CLIENTE_ABM_TO_SELECT, this);
            clienteAbm.MdiParent = this.MdiParent;
            clienteAbm.Show();
        }
        //-----------------------------------------------------------------------------------------------------------------

        //-----------------------------------------------------------------------------------------------------------------
        //Seleccionar un País
        private void button2_Click(object sender, EventArgs e)
        {
            PaisesForm clienteForm = new PaisesForm(this, SELECCIONAR_PAIS);
            clienteForm.MdiParent = this.MdiParent;
            clienteForm.Show();
        }
        //-----------------------------------------------------------------------------------------------------------------


        //-----------------------------------------------------------------------------------------------------------------
        private void aceptar_Click(object sender, EventArgs e)
        {
            //set Moneda id
            String[] result = moneda.SelectedItem.ToString().Split(',');
            String[] monedaIdString = result[0].Split('[');
            UInt32 monedaId = UInt32.Parse(monedaIdString[1]);

            //set Moneda Nombre
            String[] monedaNombreString = result[1].Split(']');
            String monedaNombre = monedaNombreString[0];

            //set Cuenta Tipo
            String[] result2 = tipoCuenta.SelectedItem.ToString().Split(',');
            String[] tipoCuentaString = result2[0].Split('[');
            
            tipoActivo = new CuentaTipoDAO().dameTuModelo(tipoCuentaString[1]);
           
            switch (operacionTipo)
            {
                case 0:
                    cuenta = new CuentaModel();
                    cuenta.pais = this.paisCuenta;
                    cuenta.tipo = this.tipoActivo;
                    cuenta.moneda = this.monedaModel;
                    cuenta.estado = this.estado;
                    cuenta.fechaCreacion = apertura.Value;
                    cuenta.propietario = this.cliente;
                    cuenta.moneda = new MonedaModel();
                    cuenta.propietario = cliente;
                    cuenta = cuentaDao.agregarBasica(cuenta);
                    parentCuenta.formResponseAdd(cuenta);
                    MessageBox.Show("Cuenta creada exitosamente");
                    break;
                case 1:
                    this.cuenta.tipo = this.tipoActivo;
                    this.cuenta.estado = this.estado;
                    cuenta = cuentaDao.updateCuenta(this.cuenta);
                    parentCuenta.formResponseUpdate(cuenta);
                    MessageBox.Show("Cliente modificado exitosamente");
                    break;
                default:
                    MessageBox.Show("Cuenta dada de Baja Exitosamente");
                    cuenta = cuentaDao.unsubscribeCuenta(cuenta);
                    parentCuenta.formResponseDisable(cuenta);
                    break;
            }
            parentCuenta.Enabled = true;
            this.Close();
            this.Dispose();
            GC.Collect();
        }
        //-----------------------------------------------------------------------------------------------------------------


        //-----------------------------------------------------------------------------------------------------------------
        private void cancelar_Click(object sender, EventArgs e)
        {
            parentCuenta.Enabled = true;
            this.Close();
            this.Dispose();
            GC.Collect();
        }
        //-----------------------------------------------------------------------------------------------------------------
    }
}
