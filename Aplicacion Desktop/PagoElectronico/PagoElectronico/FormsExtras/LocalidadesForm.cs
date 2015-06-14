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

namespace FormsExtras
{
    public partial class LocalidadesForm : Form
    {
        private ExtraDao extraDao;
        private List<LocalidadModel> localidades;
        private Int32 localidadActivoIndex;
        private LocalidadModel localidadActivo;
        private ClienteForm parentForm;

        public LocalidadesForm(ClienteForm parentForm)
        {
            InitializeComponent();

            extraDao = new ExtraDao();
            localidades = extraDao.getLocalidades();
            fillData();

            this.parentForm = parentForm;

            button1.Enabled = false;
            parentForm.Enabled = false;
        }



        //-----------------------------------------------------------------------------------------------------------------
        private void fillData()
        {
            dataGridView1.Rows.Clear();

            string[] row;
            foreach (LocalidadModel localidad in localidades)
            {
                row = new String[] {    localidad.id.ToString(),
                                        localidad.nombre.ToString()
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
            parentForm.setLocalidadSeleccionado(localidadActivo);
            parentForm.Enabled = true;
            this.Close();
            this.Dispose();
            GC.Collect();
        }
        //-----------------------------------------------------------------------------------------------------------------

        //-----------------------------------------------------------------------------------------------------------------
        //Cancel Button click
        private void button2_Click(object sender, EventArgs e)
        {
            parentForm.Enabled = true;
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
                String idPaisActivo = dataGridView1.Rows[filaActiva].Cells[0].Value.ToString();

                int count = 0;
                foreach (LocalidadModel localidad in localidades)
                {
                    if (idPaisActivo.Equals(localidad.id.ToString()))
                    {
                        localidadActivo = localidad;
                        localidadActivoIndex = count;
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
