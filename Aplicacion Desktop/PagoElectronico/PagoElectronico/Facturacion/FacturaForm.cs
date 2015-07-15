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
        private ItemDao transaccionDao;
        private FacturacionAbm parent;
        private bool confirmed = false;

        private FacturaModel factura;
        private Double total;

        public FacturaForm(FacturaModel factura,Double total, FacturacionAbm parent)
        {
            facturaDao = new FacturaDao();
            transaccionDao = new ItemDao();
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
            foreach (ItemModel t in factura.items)
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
            clienteText.Text = factura.cliente.apellido + ", " + factura.cliente.nombre;
            totalText.Text = this.total.ToString();
        }

        private void buttonAcpetar_Click(object sender, EventArgs e)
        {
            try
            {
                Respuesta respuesta = facturaDao.crearFactura(factura);
                MessageBox.Show(respuesta.mensaje);
                if (respuesta.codigo > 0)
                {
                    factura.id = respuesta.codigo;
                    factNumText.Visible = true;
                    factNumLabel.Visible = true;
                    factNumText.Text = factura.id.ToString();
                    buttonAcpetar.Visible = false;
                    button1.Text = "Finalizar";
                    confirmed = true;
                }
            }
            catch (Exception err)
            {
                MessageBox.Show("No se pudo completar la operación" + err);
            }
        }

        private void FacturaForm_Leave(object sender, EventArgs e)
        {
            parent.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(confirmed){
                parent.response();
            }

            this.Close();
            this.Dispose();
            GC.Collect();
        }
    }
}
