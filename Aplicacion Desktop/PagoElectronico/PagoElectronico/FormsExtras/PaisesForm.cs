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
    public partial class PaisesForm : Form
    {
        private List<PaisModel> paises;
        private Int32 paisActivoIndex;
        private PaisModel paisActivo;

        private ClienteForm parentFormCliente;
        private CuentaForm parentFormCuenta;

        private int operacionTipo;

        public PaisesForm(ClienteForm parentForm, int operacionTipo)
        {
            init(operacionTipo);
            this.parentFormCliente = parentForm;
            parentForm.Enabled = false;
        }

        public PaisesForm(CuentaForm parentFormCuenta, int operacionTipo)
        {
            init(operacionTipo);
            this.parentFormCuenta = parentFormCuenta;
            parentFormCuenta.Enabled = false;
        }


        //-----------------------------------------------------------------------------------------------------------------
        private void init(int operacionTipo)
        {
            InitializeComponent();
            paises = new PaisDAO().getListado();
            this.operacionTipo = operacionTipo;

            if (operacionTipo == 0)
            {
                this.Text = "Seleccionar País";
            }
            else if (operacionTipo == 1)
            {
                this.Text = "Seleccionar Nacionalidad";
            }

            button1.Enabled = false;
            fillData();
        }
        //-----------------------------------------------------------------------------------------------------------------

        //-----------------------------------------------------------------------------------------------------------------
        private void fillData(){
                
            dataGridView1.Rows.Clear();

            string[] row;

            if (operacionTipo == 0)
            {
                foreach (PaisModel pais in paises)
                {
                    row = new String[] {    pais.id.ToString(),
                                            pais.nombre.ToString()
                                            };
                    dataGridView1.Rows.Add(row);
                }
            }
            else {
                foreach (PaisModel pais in paises)
                {
                    row = new String[] {    pais.id.ToString(),
                                            pais.nacionalidad.ToString()
                                            };
                    dataGridView1.Rows.Add(row);
                }
            }

            
        }
        //-----------------------------------------------------------------------------------------------------------------


        //Event Handler***
        //-----------------------------------------------------------------------------------------------------------------
        //accept button click
        private void button1_Click(object sender, EventArgs e)
        {
            if (operacionTipo == 0)
            {
                if (parentFormCliente != null) {
                    parentFormCliente.setPaisSeleccionado(paisActivo);
                }
                if (parentFormCuenta != null)
                {
                    parentFormCuenta.setPaisSeleccionado(paisActivo);
                }
            }
            else {
                if (parentFormCliente != null)
                {
                    parentFormCliente.setNacionalidadSeleccionado(paisActivo);
                }
            }

            if (parentFormCliente != null)
            {
                parentFormCliente.Enabled = true;
            }
            if (parentFormCuenta != null)
            {
                parentFormCuenta.Enabled = true;
            }

            
            this.Close();
            this.Dispose();
            GC.Collect();
        }
        //-----------------------------------------------------------------------------------------------------------------

        //-----------------------------------------------------------------------------------------------------------------
        //Cancel Button Click
        private void button2_Click(object sender, EventArgs e)
        {
            if (parentFormCliente != null)
            {
                parentFormCliente.Enabled = true;
            }
            if (parentFormCuenta != null)
            {
                parentFormCuenta.Enabled = true;
            }
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
                String idPaisActivo = dataGridView1.Rows[filaActiva].Cells[0].Value.ToString();

                int count = 0;
                foreach (PaisModel pais in paises)
                {
                    if (idPaisActivo.Equals(pais.id.ToString()))
                    {
                        paisActivo = pais;
                        paisActivoIndex = count;
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
