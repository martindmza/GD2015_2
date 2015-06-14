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
using ABM;

namespace Retiros
{
    public partial class RetirosAbm : Form
    {
        private TarjetaDeCreditoModel tarjeta;
        private CuentaModel cuenta;
        private ClienteModel cliente;
        private ExtraDao extraDao;
        private RetiroDao retiroDao;
        private RetiroModel retiro;

        private const int OPEN_CLIENTE_ABM_TO_SELECT = 1;

        public RetirosAbm()
        {
            extraDao = new ExtraDao();
            retiroDao = new RetiroDao();

            InitializeComponent();

            aceptar.Enabled = false;
        }

        //-----------------------------------------------------------------------------------------------------------------
        public void formResponseCuenta(CuentaModel cuenta)
        {

            if (cuenta.habilitado == false) 
            {
                MessageBox.Show("Seleccione una cuenta que se encuentre habilitada");
            }
            else
            {
                this.cuenta = cuenta;
                cuentaText.Text = cuenta.id.ToString();
                clienteDestinoLabel.Text = cuenta.propietario.apellido + ", " + cuenta.propietario.nombre;
                clienteDestinoLabel.Visible = true;
                label2.Visible = true;
            }
            
        }
        //-----------------------------------------------------------------------------------------------------------------


        //EVENT HANDLER***
        //-----------------------------------------------------------------------------------------------------------------
        //buscar cuenta
        private void trigger1_Click(object sender, EventArgs e)
        {
            Form f = new CuentaAbm(this);
            f.MdiParent = this.MdiParent;
            f.Show();
        }
        //-----------------------------------------------------------------------------------------------------------------

        //-----------------------------------------------------------------------------------------------------------------
        //validar importe
        private void textBox1_Leave(object sender, EventArgs e)
        {

            if (System.Text.RegularExpressions.Regex.IsMatch(importeText.Text, "[^0-9]"))
            {
                MessageBox.Show("Ingrese solo numeros");
                importeText.Text = "";
            }
            try
            {
                if (Double.Parse(importeText.Text) <= 0)
                {
                    MessageBox.Show("No puede depositar un importe igual a cero");
                    importeText.Text = "";
                }
            }
            catch (FormatException erf) { }
            catch (NullReferenceException eru) { }
            catch (Exception erg) { }

        }
        //-----------------------------------------------------------------------------------------------------------------

        //cambian los campos de texto
        //-----------------------------------------------------------------------------------------------------------------
        private void requireds_TextChanged(object sender, EventArgs e)
        {
            if (importeText.Text.Length != 0 && dniText.Text.Length != 0 && cuentaText.Text.Length != 0)
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
        private void aceptar_Click(object sender, EventArgs e)
        {
            //validar Documento
            if ( ! dniText.Text.Equals(Login.Login.userLogued.cliente.documento.numero.ToString())) {
                MessageBox.Show("Número de Documento Inválido");
                dniText.Text = "";
                return;
            }

            //set importe
            Double importe = Double.Parse(importeText.Text);
            UInt32 monedaId = 1;
            String monedaNombre = "Dolar";

            if (importe > cuenta.saldo) {
                MessageBox.Show("El importe a retirar no puede ser mayor al saldo de la cuenta");
                importeText.Text = "";
                return;
            } 

            retiro = new RetiroModel(cuenta, importe,monedaId,monedaNombre,extraDao.getDayToday());
            retiro = retiroDao.createRetiro(retiro);

            if (retiro.id != null)
            {
                Form f = new ChequeForm(retiro);
                f.MdiParent = this.MdiParent;
                f.Show();

                this.Close();
                this.Dispose();
                GC.Collect();
            }
            else
            {
                throw new Exception("No se pudo crear el cheque");
            }
        }
        //-----------------------------------------------------------------------------------------------------------------
    }
}
