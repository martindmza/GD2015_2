using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Models;

namespace Depositos
{
    public partial class DepositosComprobante : Form
    {
        public DepositosComprobante(DepositoModel deposito)
        {
            InitializeComponent();

            depositoNum.Text = deposito.id.ToString();
            fecha.Text      = deposito.fecha.ToString();
            cliente.Text    = deposito.depositante.apellido + ", " + deposito.depositante.nombre;
            cuenta.Text     = deposito.cuentaDestino.id.ToString();
            importe.Text    = deposito.importe.ToString();
            moneda.Text     = deposito.monedaId.nombre;
            tarjeta.Text    = deposito.tarjetaDeCredito.numero.ToString();
        }

        private void buttonAceptar_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
            GC.Collect();
        }
    }
}
