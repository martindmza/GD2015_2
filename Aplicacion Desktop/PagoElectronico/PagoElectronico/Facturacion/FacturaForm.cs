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
        private TranscaccionDao transaccionDao;
        private FacturacionAbm parent;

        private FacturaModel factura;
        private Double total;

        public FacturaForm(FacturaModel factura,Double total, FacturacionAbm parent)
        {
            facturaDao = new FacturaDao();
            transaccionDao = new TranscaccionDao();
            this.factura = factura;
            this.total = total;
            this.parent = parent;
            parent.Enabled = false;

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

            fechaText.Text = factura.fecha.ToShortTimeString();
            clienteText.Text = factura.transacciones[0].cuenta.propietario.apellido + ", " +
                                factura.transacciones[0].cuenta.propietario.nombre;
            totalText.Text = this.total.ToString();
        }

        private void buttonAcpetar_Click(object sender, EventArgs e)
        {
            try
            {
                this.factura = facturaDao.crearFactura(factura);

                foreach (TransaccionModel t in factura.transacciones)
                {
                    transaccionDao.insertTransaccion(t, factura);
                }

                MessageBox.Show("Facturación Realizada exitosamente");

                parent.Close();
                parent.Dispose();

            }
            catch (Exception err) {
                MessageBox.Show("no se pudo completar la operacion" + err);
                parent.Enabled = true;
            }

            this.Close();
            this.Dispose();
            GC.Collect();
        }

        private void FacturaForm_Leave(object sender, EventArgs e)
        {
            parent.Enabled = true;
        }
    }
}
