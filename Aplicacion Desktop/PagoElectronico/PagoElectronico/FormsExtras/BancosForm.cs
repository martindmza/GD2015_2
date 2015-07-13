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
using Tarjetas;
using Retiros;

namespace FormsExtras
{
    public partial class BancosForm : Form
    {
        private BancoDAO bancoDao;
        private List<BancoModel> bancos;
        private Int32 activoIndex;
        private BancoModel objectActivo;
        private RetirosAbm parent;

        public BancosForm(RetirosAbm parent)
        {
            this.parent = parent;
            parent.Enabled = false;

            InitializeComponent();
            bancoDao = new BancoDAO();
            bancos = bancoDao.getListado();

            fillData();
        }


        //-----------------------------------------------------------------------------------------------------------------
        private void fillData()
        {

            dataGridView1.Rows.Clear();

            string[] row;

            foreach (BancoModel e in bancos)
            {
                row = new String[] {    e.id.ToString(),
                                        e.nombre.ToString()
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
            if (objectActivo != null)
            {
                parent.formResponseBanco(objectActivo);
                parent.Enabled = true;
                this.Close();
                this.Dispose();
                GC.Collect();
            }
        }
        //-----------------------------------------------------------------------------------------------------------------

        //-----------------------------------------------------------------------------------------------------------------
        //Cancel Button Click
        private void button2_Click(object sender, EventArgs e)
        {
            parent.Enabled = true;
            this.Close();
            this.Dispose();
            GC.Collect();
        }
        //-----------------------------------------------------------------------------------------------------------------


        //selccion de un pais
        //-----------------------------------------------------------------------------------------------------------------
        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                int filaActiva = this.dataGridView1.CurrentCell.RowIndex;
                String idActivo = dataGridView1.Rows[filaActiva].Cells[0].Value.ToString();

                int count = 0;
                foreach (BancoModel b in bancos)
                {
                    if (idActivo.Equals(b.id.ToString()))
                    {
                        objectActivo = b;
                        activoIndex = count;
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


    }
}
