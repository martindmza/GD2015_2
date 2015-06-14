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

namespace Facturacion
{
    public partial class FacturaForm : Form
    {
        private FacturaDao facturaDao;
        private FacturaModel factura;

        public FacturaForm(FacturaModel factura)
        {
            facturaDao = new FacturaDao();
            this.factura = factura;

            InitializeComponent();
            fillData();
        }



        private void fillData() {
            dataGridView1.Rows.Clear();
            string[] row;
            foreach (TransaccionModel t in factura.transacciones)
            {
                row = new String[] {    t.id.ToString(),
                                        t.cuenta.id.ToString(),
                                        t.tipo.nombre.ToString(),
                                        t.importe.ToString(),
                                        t.fecha.ToShortDateString().ToString()
                                        };
                dataGridView1.Rows.Add(row);
            }

            numeroText.Text = factura.id.ToString();
            fechaText.Text = factura.fecha.ToShortTimeString();
            clienteText.Text = factura.transacciones[0].cuenta.propietario.apellido + ", " +
                                factura.transacciones[0].cuenta.propietario.nombre;
            totalText.Text = factura.total.ToString();
        }

        private void buttonAcpetar_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
            GC.Collect();
        }
    }
}
