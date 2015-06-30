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

namespace Transferencias
{
    public partial class TransferenciaAbm : Form
    {
        private CuentaModel cuentaOrigen;
        private CuentaModel cuentaDestino;

        private ExtraDao extraDao;
        private TransferenciaDao transferenciaDao;
        private TransferenciaModel transferencia;

        private const int OPEN_CLIENTE_ABM_TO_SELECT = 1;

        public TransferenciaAbm()
        {
            extraDao = new ExtraDao();
            transferenciaDao = new TransferenciaDao();

            InitializeComponent();

            aceptar.Enabled = false;
        }

        //-----------------------------------------------------------------------------------------------------------------
        public void formResponseCuentaOrigen(CuentaModel cuenta)
        {

            if (cuenta.estado.nombre.Equals(EstadoModel.INHABILITADA)) 
            {
                MessageBox.Show("Seleccione una cuenta que se encuentre habilitada");
            }
            else
            {
                this.cuentaOrigen = cuenta;
                cuentaOrigenText.Text = cuenta.id.ToString();
                saldoLabel.Text = cuentaOrigen.saldo.ToString();
                saldoLabel.Visible = true;
                label4.Visible = true;
            }
            
        }
        //-----------------------------------------------------------------------------------------------------------------

        //-----------------------------------------------------------------------------------------------------------------
        public void formResponseCuentaDestino(CuentaModel cuenta)
        {

            if (cuenta.estado.id == 3 || cuenta.estado.id == 4)
            {
                MessageBox.Show("Seleccione una cuenta que no esté ni cerrada ni pendiente de Activación");
            }
            else
            {
                this.cuentaDestino = cuenta;
                cuentaDestinoText.Text = cuentaDestino.id.ToString();
                clienteDestinoLabel.Text = cuentaDestino.propietario.apellido + ", " + cuentaDestino.propietario.nombre;
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
            Form f = new CuentaAbm(this,0);
            f.MdiParent = this.MdiParent;
            f.Show();
        }
        //-----------------------------------------------------------------------------------------------------------------

        //-----------------------------------------------------------------------------------------------------------------
        private void trigger2_Click(object sender, EventArgs e)
        {
            Form f = new CuentaAbm(this,1);
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
            if (importeText.Text.Length != 0 && cuentaDestinoText.Text.Length != 0 && cuentaOrigenText.Text.Length != 0)
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

            //set importe
            Double importe = Double.Parse(importeText.Text);
            UInt32 monedaId = 1;
            String monedaNombre = "Dolar";

            if (importe > cuentaOrigen.saldo) {
                MessageBox.Show("El importe a transferir no puede ser mayor al saldo de la cuenta origen");
                importeText.Text = "";
                return;
            }

            transferencia = new TransferenciaModel(cuentaOrigen, cuentaDestino, importe, monedaId, monedaNombre);
            transferencia = transferenciaDao.createTransferencia(transferencia);

            if (transferencia.id != null)
            {
                MessageBox.Show("Transferencia realizada con éxito");
                this.Close();
                this.Dispose();
                GC.Collect();
            }
            else
            {
                throw new Exception("No se pudo realizar la operación");
            }
        }
        //-----------------------------------------------------------------------------------------------------------------

    }
}
