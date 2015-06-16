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
using Depositos;

namespace FormsExtras
{
    public partial class TarjetaDeCreditoForm : Form
    {
        private TarjetaDeCreditoDao dao;
        private List<TarjetaDeCreditoModel> tarjetas;
        private Int32 tarjetaActivoIndex;
        private TarjetaDeCreditoModel tarjetaActiva;
        private DepositosAbm parentDepositos;
        private ClienteModel cliente;

        public TarjetaDeCreditoForm(DepositosAbm parentDepositos, ClienteModel cliente)
        {
            InitializeComponent();

            dao = new TarjetaDeCreditoDao();
            tarjetas = dao.getTarjetasByCliente(cliente);
            this.parentDepositos = parentDepositos;
            this.cliente = cliente;

            fillData();

            button1.Enabled = false;
            parentDepositos.Enabled = false;
        }



        //-----------------------------------------------------------------------------------------------------------------
        private void fillData()
        {
            dataGridView1.Rows.Clear();

            string[] row;
            foreach (TarjetaDeCreditoModel tarjeta in tarjetas)
            {
                row = new String[] {    tarjeta.numero.ToString()
                                        };
                dataGridView1.Rows.Add(row);
            }
        }
        //-----------------------------------------------------------------------------------------------------------------

        //Event Handler***
        //-----------------------------------------------------------------------------------------------------------------
        //accept button click
        private void button1_Click(object sender, EventArgs e)
        {
            parentDepositos.formResponseTarjeta(tarjetaActiva);
            parentDepositos.Enabled = true;
            this.Close();
            this.Dispose();
            GC.Collect();
        }
        //-----------------------------------------------------------------------------------------------------------------

        //-----------------------------------------------------------------------------------------------------------------
        //Cancel Button click
        private void button2_Click(object sender, EventArgs e)
        {
            parentDepositos.Enabled = true;
            this.Close();
            this.Dispose();
            GC.Collect();
        }
        //-----------------------------------------------------------------------------------------------------------------

        //-----------------------------------------------------------------------------------------------------------------
        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                int filaActiva = this.dataGridView1.CurrentCell.RowIndex;
                String numTarjetaActiva = dataGridView1.Rows[filaActiva].Cells[0].Value.ToString();

                int count = 0;
                foreach (TarjetaDeCreditoModel t in tarjetas)
                {
                    if (numTarjetaActiva.Equals(t.numero.ToString()))
                    {
                        tarjetaActiva = t;
                        tarjetaActivoIndex = count;
                        break;
                    }
                    count++;
                }
                button1.Enabled = true;
            }
            catch (NullReferenceException errTarj)
            {
                button1.Enabled = false;
            }
        }
        //-----------------------------------------------------------------------------------------------------------------
    }
}
