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
using Logins;

namespace Tarjetas
{
    public partial class TarjetasAbm : Form
    {
        private const int AGREGAR = 0;
        private const int MODIFICAR = 1;
        private const int DESHABILITAR = 2;

        private TarjetaDeCreditoDao dao;
        private List<TarjetaDeCreditoModel> tarjetas;
        private Int32 tarjetaActivoIndex;
        private TarjetaDeCreditoModel tarjetaActiva;

        private ClienteModel cliente;

        public TarjetasAbm()
        {
            InitializeComponent();

            dao = new TarjetaDeCreditoDao();
            cliente = Login.userLogued.cliente;
            tarjetas = dao.getTarjetasByCliente(cliente);
            fillData();

            buttonQuitar.Enabled = false;
            buttonModificar.Enabled = false;
        }



        //-----------------------------------------------------------------------------------------------------------------
        private void fillData()
        {
            dataGridView1.Rows.Clear();

            string[] row;
            foreach (TarjetaDeCreditoModel tarjeta in tarjetas)
            {
                row = new String[] {    tarjeta.numero.ToString(),
                                        tarjeta.codigoSeguridad.ToString(),
                                        tarjeta.emision.ToShortDateString(),
                                        tarjeta.vencimiento.ToShortDateString(),
                                        tarjeta.habilitada.ToString()
                                        };
                dataGridView1.Rows.Add(row);
            }
        }
        //-----------------------------------------------------------------------------------------------------------------

        //-----------------------------------------------------------------------------------------------------------------
        public void formResponseAdd(TarjetaDeCreditoModel tarjeta)
        {
            tarjetas.Add(tarjeta);
            fillData();
        }
        //-----------------------------------------------------------------------------------------------------------------

        //-----------------------------------------------------------------------------------------------------------------
        public void formResponseUpdate(TarjetaDeCreditoModel tarjeta)
        {
            tarjetas[tarjetaActivoIndex] = tarjeta;
            fillData();
        }
        //-----------------------------------------------------------------------------------------------------------------

        //-----------------------------------------------------------------------------------------------------------------
        public void formResponseDisable(TarjetaDeCreditoModel tarjeta)
        {
            tarjetas[tarjetaActivoIndex] = tarjeta;
            fillData();
        }
        //-----------------------------------------------------------------------------------------------------------------

        //Event Handler***
        //-----------------------------------------------------------------------------------------------------------------
        private void buttonAgregar_Click(object sender, EventArgs e)
        {
            Form f = new TarjetasForm(AGREGAR, this, null);
            f.MdiParent = this.MdiParent;
            f.Show();
        }
        //-----------------------------------------------------------------------------------------------------------------

        //-----------------------------------------------------------------------------------------------------------------
        private void buttonModificar_Click(object sender, EventArgs e)
        {
            Form f = new TarjetasForm(MODIFICAR, this, tarjetaActiva);
            f.MdiParent = this.MdiParent;
            f.Show();
        }
        //-----------------------------------------------------------------------------------------------------------------

        //-----------------------------------------------------------------------------------------------------------------
        private void buttonQuitar_Click(object sender, EventArgs e)
        {
            Form f = new TarjetasForm(DESHABILITAR, this, tarjetaActiva);
            f.MdiParent = this.MdiParent;
            f.Show();
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

                buttonModificar.Enabled = true;
                buttonQuitar.Enabled = true;
            }
            catch (NullReferenceException errTarj)
            {
                buttonModificar.Enabled = false;
                buttonQuitar.Enabled = false;
            }
        }
        //-----------------------------------------------------------------------------------------------------------------

        //-----------------------------------------------------------------------------------------------------------------
        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(numeroText.Text, "[^0-9]"))
                {
                    MessageBox.Show("Ingrese solo números");
                }
            }
            catch (NullReferenceException eru) { }
            catch (Exception erg) { }

            tarjetas = dao.getTarjetasByClienteAndNumero(cliente,numeroText.Text);
            fillData();
        }
        //-----------------------------------------------------------------------------------------------------------------
    }
}