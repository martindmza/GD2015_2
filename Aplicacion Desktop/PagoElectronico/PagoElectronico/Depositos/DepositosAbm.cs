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
    

namespace Depositos
{
    public partial class DepositosAbm : Form
    {
        private TarjetaDeCreditoModel tarjeta;
        private CuentaModel cuenta;
        private ClienteModel cliente;
        private ExtraDao extraDao;
        private DepositoDao depositoDao;
        private DepositoModel deposito;
        
        private const int OPEN_CLIENTE_ABM_TO_SELECT = 1;

        public DepositosAbm()
        {
            extraDao = new ExtraDao();
            depositoDao = new DepositoDao();
            cliente = Login.Login.userLogued.cliente;

            InitializeComponent();
            fillComboBox();

            aceptar.Enabled = false;            
        }

        //-----------------------------------------------------------------------------------------------------------------
        private void fillComboBox()
        {
            //tipos de moneda
            KeyValuePair<UInt32, String> dolares = new KeyValuePair<UInt32, String>(1, "Dolares");
            comboBoxMoneda.Items.Add(dolares);
            comboBoxMoneda.DisplayMember = "Value";
            comboBoxMoneda.ValueMember = "Key";

            comboBoxMoneda.SelectedItem = dolares;
        }
        //-----------------------------------------------------------------------------------------------------------------

        //-----------------------------------------------------------------------------------------------------------------
        public void formResponseCuenta(CuentaModel cuenta)
        {
            this.cuenta = cuenta;
            cuentaText.Text = cuenta.id.ToString();
            clienteDestinoLabel.Text = cuenta.propietario.apellido + ", " + cuenta.propietario.nombre;
            clienteDestinoLabel.Visible = true;
            label2.Visible = true;
        }
        //-----------------------------------------------------------------------------------------------------------------

        //-----------------------------------------------------------------------------------------------------------------
        public void formResponseTarjeta(TarjetaDeCreditoModel tarjetaSeleccionada)
        {
            if (extraDao.getDayToday() > tarjetaSeleccionada.vencimiento)
            {
                MessageBox.Show("La tarjeta seleccionada se encuentra vencida");
            }
            else {
                this.tarjeta = tarjetaSeleccionada;
                tarjetaDeCreditoText.Text = tarjetaSeleccionada.numero.ToString();
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
        //buscar tarjeta
        private void trigger2_Click(object sender, EventArgs e)
        {
            Form f = new TarjetaDeCreditoForm(this,cliente);
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
            if (importeText.Text.Length != 0 && tarjetaDeCreditoText.Text.Length != 0 && cuentaText.Text.Length != 0)
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

            //set Moneda id
            String[] result = comboBoxMoneda.SelectedItem.ToString().Split(',');
            String[] monedaIdString = result[0].Split('[');
            UInt32 monedaId = UInt32.Parse(monedaIdString[1]);

            //set Moneda Nombre
            String[] monedaNombreString = result[1].Split(']');
            String monedaNombre = monedaNombreString[0];

            //set importe
            Double importe = Double.Parse(importeText.Text);

            deposito = new DepositoModel(cliente,cuenta,importe,monedaId,monedaNombre,tarjeta,extraDao.getDayToday());
            deposito = depositoDao.createDeposito(deposito);

            if (deposito.id != null)
            {
                Form f = new DepositosComprobante(deposito);
                f.MdiParent = this.MdiParent;
                f.Show();
            }
            else {
                throw new Exception("No se pudo crear la transacción");
            }


            this.Close();
            this.Dispose();
            GC.Collect();
        }
        //-----------------------------------------------------------------------------------------------------------------
    }
}
