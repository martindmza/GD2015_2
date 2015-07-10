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

namespace FormsExtras
{
    public partial class EmisoresForm : Form
    {
        private EmisorDao emisorDao;
        private List<EmisorModel> emisores;
        private Int32 activoIndex;
        private EmisorModel objectActivo;
        private TarjetasForm parent;

        public EmisoresForm(TarjetasForm parent)
        {
            this.parent = parent;
            parent.Enabled = false;

            InitializeComponent();
            emisorDao = new EmisorDao();
            emisores = emisorDao.getListado();

            fillData();
        }


        //-----------------------------------------------------------------------------------------------------------------
        private void fillData()
        {

            dataGridView1.Rows.Clear();

            string[] row;

            foreach (EmisorModel e in emisores)
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
            if (objectActivo != null){
                parent.formResponseEmisor(objectActivo);
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
                foreach (EmisorModel em in emisores)
                {
                    if (idActivo.Equals(em.id.ToString()))
                    {
                        objectActivo = em;
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
