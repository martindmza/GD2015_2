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
using Logins;

namespace Retiros
{
    public partial class RetirosAbm : Form
    {
        private TarjetaDeCreditoModel tarjeta;
        private CuentaModel cuenta;
        private ClienteModel cliente;
        private ExtraDao extraDao;
        private TipoDocumentoDAO docDao;
        private RetiroDao retiroDao;
        private RetiroModel retiro;
        private BancoModel banco;

        private const int OPEN_CLIENTE_ABM_TO_SELECT = 1;

        public RetirosAbm()
        {
            extraDao = new ExtraDao();
            retiroDao = new RetiroDao();
            docDao = new TipoDocumentoDAO();

            InitializeComponent();
            fillDocTypes();

            aceptar.Enabled = false;
        }

        //-----------------------------------------------------------------------------------------------------------------
        public void formResponseCuenta(CuentaModel cuenta)
        {

            if (cuenta.estado.nombre.Equals(EstadoModel.INHABILITADA)) 
            {
                MessageBox.Show("Seleccione una cuenta que se encuentre habilitada");
            }
            else
            {
                this.cuenta = cuenta;
                cuentaText.Text = cuenta.id.ToString();
                label2.Visible = true;

                saldoLabel.Visible = true;
                saldoText.Visible = true;
                saldoText.Text = cuenta.saldo.ToString() + "  USD";
            }
            
        }
        //-----------------------------------------------------------------------------------------------------------------

        //-----------------------------------------------------------------------------------------------------------------
        public void formResponseBanco(BancoModel banco)
        {
            if (banco != null)
            {
                this.banco = banco;
                bancoText.Text = banco.id.ToString();

                bancoLabel.Visible = true;
                bancoLabel.Text = banco.nombre;
            }
        }
        //-----------------------------------------------------------------------------------------------------------------


        //-----------------------------------------------------------------------------------------------------------------
        private void fillDocTypes()
        {
            foreach (TipoDocumentoModel tipo in docDao.getListado())
            {
                docTipo.Items.Add(new KeyValuePair<Decimal, String>(tipo.id, tipo.nombre));
            }
            docTipo.DisplayMember = "Value";
            docTipo.ValueMember = "Key";
            docTipo.SelectedIndex = 0;
            
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
            if (importeText.Text.Length != 0 && dniText.Text.Length != 0 && 
                cuentaText.Text.Length != 0 && bancoText.Text.Trim() != "" )
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

            String[] result = docTipo.SelectedItem.ToString().Split(',');
            String[] valueString = result[0].Split('[');
            Decimal docTipoSelected = Decimal.Parse(valueString[1]);
            TipoDocumentoModel documento = docDao.dameTuModelo(docTipoSelected.ToString());

            //set importe
            Double importe = Double.Parse(importeText.Text);

            if (importe > cuenta.saldo) {
                MessageBox.Show("El importe a retirar no puede ser mayor al saldo de la cuenta");
                importeText.Text = "";
                return;
            }

            MonedaModel moneda = new MonedaModel();
            retiro = new RetiroModel(cuenta, importe,moneda,extraDao.getDayToday());
            retiro.banco = this.banco;
            try
            {
                Respuesta respuesta = retiroDao.createRetiro(retiro,documento, Decimal.Parse(dniText.Text));
                MessageBox.Show(respuesta.mensaje);
                if (respuesta.codigo > 0)
                {
                    retiro.id = respuesta.codigo;
                    Form f = new ChequeForm(retiro);
                    f.MdiParent = this.MdiParent;
                    f.Show();

                    this.Close();
                    this.Dispose();
                    GC.Collect();
                }
            }
            catch (Exception err)
            {
                MessageBox.Show("No se pudo completar la operación" + err);
            }
        }
        //-----------------------------------------------------------------------------------------------------------------

        //-----------------------------------------------------------------------------------------------------------------
        private void trigger2_Click(object sender, EventArgs e)
        {
            Form f = new BancosForm(this);
            f.MdiParent = this.MdiParent;
            f.Show();
        }
        //-----------------------------------------------------------------------------------------------------------------
    }
}
