using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Models;
using DAO;
using FormsExtras;

namespace ABM
{
    public partial class ClienteForm : Form
    {
        private ClienteModel cliente;
        private int operacionTipo;
        private ClienteDao clienteDao;
        private ClienteAbm parent;
        private ExtraDao extraDao;

        private UInt32 nacionalidadId = 0;
        private UInt32 localidadId = 0;
        private UInt32 paisId = 0;
        private UInt32 docTipoId = 0;

        private const int SELECCIONAR_PAIS = 0;
        private const int SELECCIONAR_NACIONALIDAD = 1;

        public ClienteForm(int operacionTipo, ClienteModel cliente, ClienteDao clienteDao, ClienteAbm parent, ExtraDao extraDao)
        {
            InitializeComponent();

            if (cliente != null)
            {
                this.cliente = cliente;
            }
            this.operacionTipo = operacionTipo;
            this.clienteDao = clienteDao;
            this.extraDao = extraDao;
            this.parent = parent;

            switch (operacionTipo)
            {
                case 0:
                    button3.Enabled = false;
                    checkBox1.Visible = false;
                    this.Text = "Crear Nuevo Cliente";
                    break;
                case 1:
                    button3.Enabled = false;
                    fillData();
                    this.Text = "Modificar Cliente";
                    break;
                case 2:
                    button2.Enabled = false;
                    fillData();
                    this.Text = "Dar de Baja Cliente";
                    break;
            }
            fillDocTypes();

            id.Enabled = false;
            parent.Enabled = false;
        }

        //-----------------------------------------------------------------------------------------------------------------
        private void fillDocTypes()
        {
            foreach (KeyValuePair<int, string> tipo in extraDao.getDocTypes())
            {
                docTipo.Items.Add(tipo);
            }
            docTipo.DisplayMember = "Value";
            docTipo.ValueMember = "Key";
        }
        //-----------------------------------------------------------------------------------------------------------------

        //-----------------------------------------------------------------------------------------------------------------
        private void fillData() {

            nacimiento.Value = new DateTime(1990, 1, 1);

            if (cliente == null)
            {
                domCalle.Text = "";
                domNumero.Text = "";
                domPiso.Text = "";
                domDepartamento.Text = "";
               
            }
            else {
                id.Text = cliente.id.ToString();
                docNumero.Text = cliente.documentoNumero.ToString();
                apellido.Text = cliente.apellido;
                nombre.Text = cliente.nombre;
            }
            

        }
        //-----------------------------------------------------------------------------------------------------------------

        //-----------------------------------------------------------------------------------------------------------------
        public void setPaisSeleccionado(PaisModel pais) {
            this.paisText.Text = pais.nombre;
            this.paisId = pais.id;
        }
        //-----------------------------------------------------------------------------------------------------------------

        //-----------------------------------------------------------------------------------------------------------------
        public void setNacionalidadSeleccionado(PaisModel pais)
        {
            this.nacionalidadText.Text = pais.nacionalidad;
            this.nacionalidadId = pais.id;
        }
        //-----------------------------------------------------------------------------------------------------------------

        //-----------------------------------------------------------------------------------------------------------------
        public void setLocalidadSeleccionado(LocalidadModel localidad)
        {
            this.localidadText.Text = localidad.nombre;
            this.localidadId = localidad.id;
        }
        //-----------------------------------------------------------------------------------------------------------------

        //EVENT HANDLER***
        //cambian los campos de texto
        //-----------------------------------------------------------------------------------------------------------------
        private void requireds_TextChanged(object sender, EventArgs e)
        {
            /*
            MessageBox.Show( (docNumero.Text.Length != 0).ToString() + " ; " + (docTipo.SelectedItem != null).ToString() +
                " ; " + (apellido.Text.Length != 0).ToString() + " ; " +  (nombre.Text.Length != 0).ToString() +
                " ; " + (email.Text.Length != 0).ToString()  + " ; " + (nacionalidadText.Text.Length != 0).ToString() +
                " ; " + (paisId != 0 ).ToString() + " ; " + (localidadId != 0).ToString());
            */
            if (docNumero.Text.Length != 0 && docTipo.SelectedItem != null &&
                apellido.Text.Length != 0 && nombre.Text.Length != 0 && 
                email.Text.Length != 0 && nacionalidadText.Text.Length != 0 &&
                paisId != 0 && localidadId != 0)
            {
                button3.Enabled = true;
            }
            else {
                button3.Enabled = false;
            }
        }
        //-----------------------------------------------------------------------------------------------------------------

        //aceptar
        //-----------------------------------------------------------------------------------------------------------------
        private void button3_Click(object sender, EventArgs e)
        {

            if (docTipo.SelectedItem != null)
            {
                String[] result = docTipo.SelectedItem.ToString().Split(',');
                String[] valueString = result[0].Split('[');
                UInt32 value = UInt32.Parse(valueString[1]);
                docTipoId = value;
            }

            switch (operacionTipo)
            {
                case 0:
                    cliente = new ClienteModel(apellido.Text,nombre.Text, docTipoId,
                                            UInt64.Parse(docNumero.Text),
                                            nacimiento.Value, email.Text, nacionalidadId,
                                            domCalle.Text, UInt32.Parse(domNumero.Text),
                                            UInt32.Parse(domPiso.Text),domDepartamento.Text,
                                            localidadId,paisId);
                    cliente.id = clienteDao.addNewCliente(cliente);
                    MessageBox.Show("Cliente creado exitosamente");
                    parent.formResponseAdd(cliente);
                    break;
                case 1:
                    cliente = clienteDao.updateCliente(new ClienteModel(UInt32.Parse(id.Text), apellido.Text, nombre.Text,
                                            UInt32.Parse(docTipo.SelectedValue.ToString()),
                                            UInt64.Parse(docNumero.Text),
                                            nacimiento.Value, email.Text, nacionalidadId,
                                            domCalle.Text, UInt32.Parse(domNumero.Text),
                                            UInt32.Parse(domPiso.Text), domDepartamento.Text,
                                            localidadId, paisId));
                    MessageBox.Show("Cliente modificado exitosamente");
                    parent.formResponseUpdate(cliente);
                    break;
                default:
                    cliente = clienteDao.unsubscribeCliente(cliente);
                    parent.formResponseDisable(cliente);
                    break;
            }
            parent.Enabled = true;
            this.Close();
            this.Dispose();
            GC.Collect();
        }
        //-----------------------------------------------------------------------------------------------------------------

        //Cancelar
        //-----------------------------------------------------------------------------------------------------------------
        private void button5_Click(object sender, EventArgs e)
        {
            parent.Enabled = true;
            this.Close();
            this.Dispose();
            GC.Collect();
        }
        //-----------------------------------------------------------------------------------------------------------------

        //-----------------------------------------------------------------------------------------------------------------
        private void docNumero_Leave(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(docNumero.Text, "[^0-9]"))
            {
                MessageBox.Show("Ingrese solo numeros");
                docNumero.Text = "";
            }
        }
        //-----------------------------------------------------------------------------------------------------------------

        //-----------------------------------------------------------------------------------------------------------------
        private void domNumero_Leave(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(domNumero.Text, "[^0-9]"))
            {
                MessageBox.Show("Ingrese solo numeros");
                domNumero.Text = "";
            }
        }
        //-----------------------------------------------------------------------------------------------------------------

        //-----------------------------------------------------------------------------------------------------------------
        private void domPiso_Leave(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(domPiso.Text, "[^0-9]"))
            {
                MessageBox.Show("Ingrese solo numeros");
                domPiso.Text = "";
            }
        }
        //-----------------------------------------------------------------------------------------------------------------

        //-----------------------------------------------------------------------------------------------------------------
        //Nacionalidad
        private void button4_Click(object sender, EventArgs e)
        {
            PaisesForm clienteForm = new PaisesForm(this, SELECCIONAR_NACIONALIDAD);
            clienteForm.MdiParent = this.MdiParent;
            clienteForm.Show();
        }
        //-----------------------------------------------------------------------------------------------------------------

        //-----------------------------------------------------------------------------------------------------------------
        //Localidad
        private void button1_Click(object sender, EventArgs e)
        {
            LocalidadesForm clienteForm = new LocalidadesForm(this);
            clienteForm.MdiParent = this.MdiParent;
            clienteForm.Show();
        }
        //-----------------------------------------------------------------------------------------------------------------

        ////-----------------------------------------------------------------------------------------------------------------
        //Pais
        private void button6_Click(object sender, EventArgs e)
        {
            PaisesForm clienteForm = new PaisesForm(this, SELECCIONAR_PAIS);
            clienteForm.MdiParent = this.MdiParent;
            clienteForm.Show();
        }
        //-----------------------------------------------------------------------------------------------------------------        
    }
}
