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

namespace ABM
{
    public partial class FuncionalidadesForm : Form
    {
        private List<FuncionalidadModel> funcionalidades;
        private List<FuncionalidadModel> funcionalidadesContenidas;
        private Int32 funcionalidadActivoIndex;
        private FuncionalidadModel funcionalidadActivo;
        private RolForm parentForm;

        public FuncionalidadesForm(RolForm parentForm, List<FuncionalidadModel> funcionalidadesContenidas)
        {
            InitializeComponent();

            funcionalidades = new FuncionalidadDao().getFuncionalidades();
            this.parentForm = parentForm;
            this.funcionalidadesContenidas = funcionalidadesContenidas;
            fillData();

            buttonElegir.Enabled = false;
            parentForm.Enabled = false;
        }



        //-----------------------------------------------------------------------------------------------------------------
        private void fillData()
        {
            dataGridView1.Rows.Clear();

            string[] row;
            foreach (FuncionalidadModel f in funcionalidades)
            {
                if (!funcionalidadesContenidas.Exists(i => i.id == f.id))
                {
                    row = new String[] {    f.id.ToString(),
                                            f.nombre.ToString()
                                        };
                    dataGridView1.Rows.Add(row);
                }
            }
        }
        //-----------------------------------------------------------------------------------------------------------------

        //Event Handler***
        //-----------------------------------------------------------------------------------------------------------------
        //accept button click
        private void buttonElegir_Click(object sender, EventArgs e)
        {
            parentForm.setSeleccionado(funcionalidadActivo);
            parentForm.Enabled = true;
            this.Close();
            this.Dispose();
            GC.Collect();
        }
        //-----------------------------------------------------------------------------------------------------------------

        //-----------------------------------------------------------------------------------------------------------------
        //Cancel Button click
        private void buttonCancelar_Click(object sender, EventArgs e)
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
                String idActivo = dataGridView1.Rows[filaActiva].Cells[0].Value.ToString();

                int count = 0;
                foreach (FuncionalidadModel f in funcionalidades)
                {
                    if (idActivo.Equals(f.id.ToString()))
                    {
                        funcionalidadActivo = f;
                        funcionalidadActivoIndex = count;
                        break;
                    }
                    count++;
                }

                buttonElegir.Enabled = true;
            }
            catch (NullReferenceException errTarj)
            {
                buttonElegir.Enabled = false;
            }
        }
        //-----------------------------------------------------------------------------------------------------------------
    }
}
