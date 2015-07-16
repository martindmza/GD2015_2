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
using FormsExtras;

namespace Tarjetas
{

        

    public partial class TarjetasForm : Form
    {
        private UInt32 operacionTipo;

        private TarjetasAbm parent;
        private TarjetaDeCreditoDao tarjetasDao;

        private TarjetaDeCreditoModel tarjeta;
        private EmisorModel emisor;
        private ClienteModel propietario;

        private const int OPEN_CLIENTE_ABM_TO_SELECT = 1;
        private const String EXCEPTION_MESSAGE = "La operacion no se pudo completar";

        public TarjetasForm(UInt32 operacionTipo,TarjetasAbm parent,TarjetaDeCreditoModel tarjeta,ClienteModel propietario)
        {
            this.parent = parent;
            this.propietario = propietario;
            init(operacionTipo,tarjeta);
        }

        private void init(UInt32 operacionTipo,TarjetaDeCreditoModel tarjeta)
        {
            InitializeComponent();

            if (tarjeta != null)
            {
                this.tarjeta = tarjeta;
            }

            this.operacionTipo = operacionTipo;
            this.tarjetasDao = new TarjetaDeCreditoDao();

            fillData();

            switch (operacionTipo)
            {
                case 0:
                    buttonAceptar.Enabled = false;
                    
                    this.Text = "Agregar nueva Tarjeta";
                    break;
                case 1:
                    buttonAceptar.Enabled = true;
                    numeroText.Enabled = false;
                    this.Text = "Modificar Tarjeta";
                    codigoSeguridadText.Visible = false;
                    label5.Visible = false;
                    break;
                case 2:
                    buttonAceptar.Enabled = true;
                    this.Text = "Desasociar la Tarjeta";
                    this.buttonAceptar.Text = "Desasociar";
                    codigoSeguridadText.Visible = false;
                    label5.Visible = false;
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
        public void formResponseEmisor(EmisorModel emisor) {
            this.emisorText.Text = emisor.id.ToString();
            emisorNameLabel.Text = emisor.nombre;
            this.emisor = emisor;
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
                emisorNameLabel.Text = "";
            }
            else
            {
                numeroText.Text = tarjeta.numero;
                emisionText.Value = tarjeta.emision;
                vencimientoText.Value = tarjeta.vencimiento;
                codigoSeguridadText.Text = tarjeta.codigoSeguridad.ToString();
                emisorText.Text = tarjeta.emisor.id.ToString();
                emisorNameLabel.Text = tarjeta.emisor.nombre;
                emisor = tarjeta.emisor;
            }
        }
        //-----------------------------------------------------------------------------------------------------------------

        //Event Handler***
        //cambian los campos de texto
        //-----------------------------------------------------------------------------------------------------------------
        private void requireds_TextChanged(object sender, EventArgs e)
        {
            if (numeroText.Text.Length != 0     && emisorText.Text.Length != 0     &&
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
        //Buscar Emisor
        private void trigger1_Click(object sender, EventArgs e)
        {
            Form form = new EmisoresForm(this);
            form.MdiParent = this.MdiParent;
            form.Show();
        }
        //-----------------------------------------------------------------------------------------------------------------

        //-----------------------------------------------------------------------------------------------------------------
        private void buttonAceptar_Click(object sender, EventArgs e)
        {
            Respuesta respuesta;
            switch (operacionTipo)
            {
                case 0:
                    tarjeta = new TarjetaDeCreditoModel(numeroText.Text, codigoSeguridadText.Text, emisor,
                                                            emisionText.Value, vencimientoText.Value);
                    tarjeta.propietario = propietario;
                    try
                    {
                        respuesta = tarjetasDao.crearTarjeta(tarjeta);
                        MessageBox.Show(respuesta.mensaje);
                        if (respuesta.codigo > 0)
                        {
                            tarjeta.id = respuesta.codigo;
                            parent.formResponseAdd(tarjeta);
                            parent.Enabled = true;
                            this.Close();
                            this.Dispose();
                            GC.Collect();
                        }
                    }
                    catch (Exception er)
                    {
                        MessageBox.Show(EXCEPTION_MESSAGE + " : " + er);
                    }
                    break;
                case 1:
                    tarjeta = new TarjetaDeCreditoModel(tarjeta.id,numeroText.Text, codigoSeguridadText.Text, emisor,
                                                           emisionText.Value, vencimientoText.Value);
                    try
                    {
                        respuesta = tarjetasDao.modificarTarjeta(tarjeta);
                        MessageBox.Show(respuesta.mensaje);
                        if (respuesta.codigo > 0)
                        {
                            parent.formResponseUpdate(tarjeta);
                            parent.Enabled = true;
                            this.Close();
                            this.Dispose();
                            GC.Collect();
                        }
                    }
                    catch (Exception er)
                    {
                        MessageBox.Show(EXCEPTION_MESSAGE + " : " + er);
                    }
                    break;
                default:
                    try
                    {
                        respuesta = tarjetasDao.borrarTarjeta(tarjeta);
                        MessageBox.Show(respuesta.mensaje);
                        if (respuesta.codigo > 0)
                        {
                            parent.formResponseDisable(tarjeta);
                            parent.Enabled = true;
                            this.Close();
                            this.Dispose();
                            GC.Collect();
                        }
                    }
                    catch (Exception er)
                    {
                        MessageBox.Show(EXCEPTION_MESSAGE + " : " + er);
                    }
                    break;
            }
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
