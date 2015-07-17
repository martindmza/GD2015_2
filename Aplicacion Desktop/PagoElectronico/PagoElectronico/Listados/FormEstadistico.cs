using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DAO;

namespace PagoElectronico.Listados
{
    public partial class FormEstadistico : Form
    {
        int operacionItem;
        int trimestre;
        DateTime anio;
        DateTime periodoInicial;
        DateTime periodoFinal;

        public FormEstadistico()
        {
            InitializeComponent();
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            operacionItem = this.cbListado.SelectedIndex;
            trimestre = this.cbTrimestre.SelectedIndex;
            anio  = this.dateTimePicker1.Value;
            String mensaje = "";
            
            switch (trimestre)
            {
                case 0:
                    periodoInicial = new DateTime(anio.Year, 1, 1);
                    periodoInicial.ToShortDateString();
                    periodoFinal = new DateTime(anio.Year, 4, 1).AddDays(-1);
                    mensaje = mensaje + " Periodo Inicial: " + periodoInicial.ToShortDateString() + " Periodo Final: " + periodoFinal.ToShortDateString();
                    break;
                case 1:
                    periodoInicial = new DateTime(anio.Year, 4, 1);
                    periodoFinal = new DateTime(anio.Year, 7, 1).AddDays(-1);
                    mensaje = mensaje + " Periodo Inicial: " + periodoInicial.ToShortDateString() + "Periodo Final: " + periodoFinal.ToShortDateString();
                    break;
                case 2:
                    periodoInicial = new DateTime(anio.Year, 7, 1);
                    periodoFinal = new DateTime(anio.Year, 10, 1).AddDays(-1);
                    mensaje = mensaje + " Periodo Inicial: " + periodoInicial.ToShortDateString() + "Periodo Final: " + periodoFinal.ToShortDateString();
                    break;
                case 3:
                    periodoInicial = new DateTime(anio.Year, 10, 1);
                    periodoFinal = new DateTime(anio.Year+1,1 ,1).AddDays(-1);
                    mensaje = mensaje + " Periodo Inicial: " + periodoInicial.ToShortDateString() + "Periodo Final: " + periodoFinal.ToShortDateString();
                    break;
                default: 
                    return;
            }

            switch (operacionItem)
            {
                case 0:
                    this.setTablaClientesConCuentasInhabilitadas(periodoInicial, periodoFinal);
                    mensaje = mensaje +" Acción: " + cbListado.SelectedItem.ToString();
                    break;
                case 1:
                    this.setTablaClientesConComisionesFacturadas(periodoInicial, periodoFinal);
                    mensaje = mensaje + " Acción: " + cbListado.SelectedItem.ToString();
                    break;
                case 2:
                    this.setTablaClientesConMayorCantidadDeTransiccion(periodoInicial, periodoFinal);
                    mensaje = mensaje + " Acción: " + cbListado.SelectedItem.ToString();
                    break;
                case 3:
                    this.setTablaPaisesConMayorCantidadMovimientos(periodoInicial, periodoFinal);
                    mensaje = mensaje + " Acción: " + cbListado.SelectedItem.ToString();
                    break;
                case 4:
                    this.setTablaTotalFacturado(periodoInicial, periodoFinal);
                    mensaje = mensaje + " Acción: " + cbListado.SelectedItem.ToString();
                    break;
                default:
                    return;
            }

            etiMensaje.Text = mensaje;
        }

        private void setTablaClientesConCuentasInhabilitadas(DateTime inicial, DateTime final)
        {
            this.dgTablaResultado.DataSource = new ClienteDao().getClientInhabilitados(inicial,final);
            
        }

        private void setTablaClientesConComisionesFacturadas(DateTime inicial, DateTime final)
        {
            this.dgTablaResultado.DataSource = new ClienteDao().getClientComisiones(inicial,final);
        }

        private void setTablaClientesConMayorCantidadDeTransiccion(DateTime inicial, DateTime final)
        {
            this.dgTablaResultado.DataSource = new ClienteDao().getClientTransacciones(inicial,final);
        }

        private void setTablaPaisesConMayorCantidadMovimientos(DateTime inicial, DateTime final)
        {
            this.dgTablaResultado.DataSource = new PaisDAO().getPaisConMasMovimientos(inicial,final);
        }

        private void setTablaTotalFacturado(DateTime inicial, DateTime final)
        {
            this.dgTablaResultado.DataSource = new CuentaDao().getTotalFacturadoCuenta(inicial,final);
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }




    }
}
