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
using ABM;

namespace Tarjetas
{

        

    public partial class TarjetasForm : Form
    {
        private UInt32 operacionTipo;

        private TarjetasAbm parent;
        private TarjetaDeCreditoDao tarjetasDao;

        private TarjetaDeCreditoModel tarjeta;
        private ClienteModel cliente;

        private const int OPEN_CLIENTE_ABM_TO_SELECT = 1;

        public TarjetasForm(UInt32 operacionTipo,TarjetasAbm parent,TarjetaDeCreditoModel tarjeta)
        {
            InitializeComponent();
            if (tarjeta != null)
            {
                this.tarjeta = tarjeta;
            }

            this.operacionTipo = operacionTipo;
            this.tarjetasDao = new TarjetaDeCreditoDao();
            this.parent = parent;

            fillData();

            switch (operacionTipo)
            {
                case 0:
                    buttonAceptar.Enabled = false;
                    this.Text = "Agregar nueva Tarjeta";
                    break;
                case 1:
                    buttonAceptar.Enabled = true;
                    this.Text = "Modificar Tarjeta";
                    break;
                case 2:
                    buttonAceptar.Enabled = true;
                    this.Text = "Dar de Baja Tarjeta";
                    this.buttonAceptar.Text = "Dar de Baja";
                    disableInputs();
                    break;
            }

            parent.Enabled = false;
        }

        //-----------------------------------------------------------------------------------------------------------------
        private void disableInputs()
        {
            numeroText.Enabled = false;
            trigger1.Enabled = false;
            emisionText.Enabled = false;
            vencimientoText.Enabled = false;
            codigoSeguridadText.Enabled = false;
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
        private void fillData()
        {

            if (tarjeta == null)    
            {
                numeroText.Text = "";
                emisionText.Value = DateTime.Today;
                vencimientoText.Value = DateTime.Today;
                codigoSeguridadText.Text = "";
                clienteNameLabel.Text = "";
                checkBoxHabilitada.Checked = true;
            }
            else
            {
                numeroText.Text = tarjeta.numero;
                emisionText.Value = tarjeta.emision;
                vencimientoText.Value = tarjeta.vencimiento;
                codigoSeguridadText.Text = tarjeta.codigoSeguridad.ToString();
                clienteText.Text = tarjeta.propietario.id.ToString();
                clienteNameLabel.Text = tarjeta.propietario.apellido + ", " + tarjeta.propietario.nombre;
                checkBoxHabilitada.Checked = tarjeta.habilitada;
                cliente = tarjeta.propietario;
            }
        }
        //-----------------------------------------------------------------------------------------------------------------

        //Event Handler***
        //cambian los campos de texto
        //-----------------------------------------------------------------------------------------------------------------
        private void requireds_TextChanged(object sender, EventArgs e)
        {
            if (numeroText.Text.Length != 0     && clienteText.Text.Length != 0     &&
                emisionText.Text.Length != 0    && vencimientoText.Text.Length != 0 &&
                codigoSeguridadText.Text.Length !=0)
            {
                buttonAceptar.Enabled = true;
            }
            else
            {
                buttonAceptar.Enabled = false;
            }
        }
        //-----------------------------------------------------------------------------------------------------------------

        //-----------------------------------------------------------------------------------------------------------------
        private void numeroText_Leave(object sender, EventArgs e)
        {
            try{
                if (System.Text.RegularExpressions.Regex.IsMatch(numeroText.Text, "[^0-9]"))
                {
                    MessageBox.Show("Ingrese solo numeros");
                    numeroText.Text = "";
                }

                else if (numeroText.Text.Length != 16 && numeroText.Text.Length != 0)
                {
                    MessageBox.Show("El número de Tarjeta debe tener 16 dígitos");
                }
            }
            catch (FormatException erf) { }
            catch (NullReferenceException eru) { }
            catch (Exception erg) { }
        }
        //-----------------------------------------------------------------------------------------------------------------

        //-----------------------------------------------------------------------------------------------------------------
        private void validarNumeroSeguridad(object sender, EventArgs e)
        {
            try
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(codigoSeguridadText.Text, "[^0-9]"))
                {
                    MessageBox.Show("Ingrese solo numeros");
                    numeroText.Text = "";
                }

                else if (codigoSeguridadText.Text.Length != 3 && codigoSeguridadText.Text.Length != 0)
                {
                    MessageBox.Show("El código de seguridad debe tener 3 dígitos");
                }
            }
            catch (FormatException erf) { }
            catch (NullReferenceException eru) { }
            catch (Exception erg) { }
        }
        //-----------------------------------------------------------------------------------------------------------------

        //-----------------------------------------------------------------------------------------------------------------
        //Buscar Cliente
        private void trigger1_Click(object sender, EventArgs e)
        {
            Form clienteAbm = new ClienteAbm(OPEN_CLIENTE_ABM_TO_SELECT, this);
            clienteAbm.MdiParent = this.MdiParent;
            clienteAbm.Show();
        }
        //-----------------------------------------------------------------------------------------------------------------

        //-----------------------------------------------------------------------------------------------------------------
        private void buttonAceptar_Click(object sender, EventArgs e)
        {
            switch (operacionTipo)
            {
                case 0:
                    tarjeta = new TarjetaDeCreditoModel(numeroText.Text, codigoSeguridadText.Text, emisionText.Value,
                                                            vencimientoText.Value, cliente);

                    tarjeta = tarjetasDao.crearTarjeta(tarjeta);
                    parent.formResponseAdd(tarjeta);
                    MessageBox.Show("Cuenta creada exitosamente");
                    break;
                case 1:
                    tarjeta = new TarjetaDeCreditoModel(tarjeta.id,numeroText.Text, codigoSeguridadText.Text, 
                                                           emisionText.Value, vencimientoText.Value, cliente);
                    MessageBox.Show("Cliente modificado exitosamente");
                    tarjeta = tarjetasDao.modificarTarjeta(tarjeta);
                    parent.formResponseUpdate(tarjeta);
                    break;
                default:
                    MessageBox.Show("Cuenta dada de Baja Exitosamente");
                    tarjeta = tarjetasDao.borrarTarjeta(tarjeta);
                    parent.formResponseDisable(tarjeta);
                    break;
            }
            parent.Enabled = true;
            this.Close();
            this.Dispose();
            GC.Collect();
        }
        //-----------------------------------------------------------------------------------------------------------------

        //-----------------------------------------------------------------------------------------------------------------
        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            parent.Enabled = true;
            this.Close();
            this.Dispose();
            GC.Collect();
        }
        //-----------------------------------------------------------------------------------------------------------------
    }
}
