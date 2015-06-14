using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Models;

namespace Retiros
{
    public partial class ChequeForm : Form
    {
        public ChequeForm(RetiroModel retiro)
        {
            InitializeComponent();

            this.Text = "Cheque n° " + retiro.chequeId;

            clienteText.Text = retiro.cuenta.propietario.apellido + ", " + retiro.cuenta.propietario.nombre;
            BancoText.Text = retiro.banco.nombre;
            ImporteText.Text = retiro.importe.ToString();
            cuentaText.Text = retiro.cuenta.id.ToString();
            FechaText.Text = retiro.fecha.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
            GC.Collect();
        }
    }
}
