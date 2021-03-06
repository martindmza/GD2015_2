﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Models;
using DAO;
using Logins;

namespace Facturacion
{
    public partial class FacturacionAbm : Form
    {

        private ItemDao itemDao;
        private ExtraDao extraDao;

        private List<ItemModel> items;
        private List<ItemModel> itemsSeleccionados;
        private ClienteModel cliente;
        private Double total;


        public FacturacionAbm()
        {
            cliente = UsuarioSingleton.getInstance().getUsuario().getMiCliente();
            itemDao = new ItemDao();
            extraDao = new ExtraDao();
            items = itemDao.getTransaccionesPendientesByCliente(cliente);
            itemsSeleccionados = new List<ItemModel>();

            InitializeComponent();
            fillTable();

            buttonFacturar.Enabled = false;
        }

        //-----------------------------------------------------------------------------------------------------------------
        public void response() {
            items = itemDao.getTransaccionesPendientesByCliente(cliente);
            fillTable();
            itemsSeleccionados.Clear();
        }
        //-----------------------------------------------------------------------------------------------------------------

        //-----------------------------------------------------------------------------------------------------------------
        private void fillTable()
        {
            dataGridView1.Rows.Clear();

            string[] row;
            foreach (ItemModel t in items)
            {
                row = new String[] {    t.id.ToString(),
                                        t.cuenta.id.ToString(),
                                        t.tipo.nombre.ToString(),
                                        t.importe.ToString(),
                                        t.fecha.ToShortDateString().ToString()
                                        };
                dataGridView1.Rows.Add(row);
            }
        }
        //-----------------------------------------------------------------------------------------------------------------

        //-----------------------------------------------------------------------------------------------------------------
        private void calcularPrecio()
        {
            total = 0;
            foreach (ItemModel t in itemsSeleccionados)
            {
                total += t.importe;
            }
            totalText.Text = total.ToString();
        }
        //-----------------------------------------------------------------------------------------------------------------

        //-----------------------------------------------------------------------------------------------------------------
        //Click en una transaccion
        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                int filaActiva = this.dataGridView1.CurrentCell.RowIndex;
                String idTransaccionActiva = dataGridView1.Rows[filaActiva].Cells[0].Value.ToString();

                int count = 0;
                foreach (ItemModel t in items)
                {
                    if (idTransaccionActiva.Equals(t.id.ToString()))
                    {
                        //SetPrice
                        if (itemsSeleccionados.Exists(i => i == t)) {
                            dataGridView1.Rows[filaActiva].DefaultCellStyle.BackColor = Color.White;
                            itemsSeleccionados.Remove(t);
                            dataGridView1.Rows[filaActiva].Selected = false;
                        }
                        else
                        {
                            dataGridView1.Rows[filaActiva].DefaultCellStyle.BackColor = Color.LightGray;
                            itemsSeleccionados.Add(t);
                            dataGridView1.Rows[filaActiva].Selected = true;

                        }
                        calcularPrecio();
                        break;
                    }
                    count++;
                }

                if (itemsSeleccionados.Count == 0)
                {
                    buttonFacturar.Enabled = false;
                }
                else {
                    buttonFacturar.Enabled = true;
                }
                
            }
            catch (NullReferenceException errTarj) { }
        }
        //-----------------------------------------------------------------------------------------------------------------

        //EVENT HANDLER***
        //-----------------------------------------------------------------------------------------------------------------
        private void facturar_Click(object sender, EventArgs e)
        {
            FacturaModel factura = new FacturaModel(extraDao.getDayToday(), itemsSeleccionados);
            factura.cliente = cliente;

            if (factura != null)
            {
                Form f = new FacturaForm(factura,total,this);
                f.MdiParent = this.MdiParent;
                f.Show();
            }
            else {
                MessageBox.Show("No se pudo crear la operación");
            }
        }
        //-----------------------------------------------------------------------------------------------------------------

        //-----------------------------------------------------------------------------------------------------------------
        private void buttonNinguno_Click(object sender, EventArgs e)
        {
            int count = 0;

            itemsSeleccionados.Clear();
            foreach (ItemModel t in items)
            {
                dataGridView1.Rows[count].DefaultCellStyle.BackColor = Color.White;
                dataGridView1.Rows[count].Selected = false;
                count++;
            }
            calcularPrecio();
        }
        //-----------------------------------------------------------------------------------------------------------------

        //-----------------------------------------------------------------------------------------------------------------
        private void buttonTodos_Click(object sender, EventArgs e)
        {

            int count = 0;

            itemsSeleccionados.Clear();
            foreach (ItemModel t in items)
            {
                dataGridView1.Rows[count].DefaultCellStyle.BackColor = Color.LightGray;
                itemsSeleccionados.Add(t);
                dataGridView1.Rows[count].Selected = true;
                count++;
            }
            calcularPrecio();
        }
        //-----------------------------------------------------------------------------------------------------------------
    }
}
