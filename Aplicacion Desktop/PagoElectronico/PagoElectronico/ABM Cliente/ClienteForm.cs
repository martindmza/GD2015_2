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

        private PaisModel pais;
        private PaisModel nacionalidad;
        private LocalidadModel localidad;
        private TipoDocumentoModel tipoDocumento;

        private const int SELECCIONAR_PAIS = 0;
        private const int SELECCIONAR_NACIONALIDAD = 1;
        private const String EXCEPTION_MESSAGE = "La operacion no se pudo completar";

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

            fillDocTypes();
            fillData();

            switch (operacionTipo)
            {
                case 0:
                    button3.Enabled = false;
                    this.Text = "Crear Nuevo Cliente";
                    break;
                case 1:
                    button3.Enabled = false;
                    this.Text = "Modificar Cliente";
                    break;
                case 2:
                    this.Text = "Dar de Baja Cliente";
                    this.button2.Visible = false;
                    this.button3.Text = "Dar de Baja";
                    disableInputs();
                    break;
            }

            checkBox1.Enabled = false;
            id.Enabled = false;
            parent.Enabled = false;
        }

        //-----------------------------------------------------------------------------------------------------------------
        private void disableInputs()
        {
            docNumero.Enabled = false;
            docTipo.Enabled = false;
            apellido.Enabled = false;
            nombre.Enabled = false;
            nacimiento.Enabled = false;
            email.Enabled = false;
            button4.Enabled = false;
            button6.Enabled = false;
            domCalle.Enabled = false;
            domDepartamento.Enabled = false;
            domNumero.Enabled = false;
            domPiso.Enabled = false;
            localidadText.Enabled = false;
        }
        //-----------------------------------------------------------------------------------------------------------------

        //-----------------------------------------------------------------------------------------------------------------
        private void fillDocTypes()
        {
            TipoDocumentoDAO docDao = new TipoDocumentoDAO();
            foreach (TipoDocumentoModel tipo in docDao.getListado())
            {
                docTipo.Items.Add(new KeyValuePair<Decimal, String>(tipo.id, tipo.nombre));
            }
            docTipo.DisplayMember = "Value";
            docTipo.ValueMember = "Key";
        }
        //-----------------------------------------------------------------------------------------------------------------

        //-----------------------------------------------------------------------------------------------------------------
        private void fillData() {

            if (cliente == null)
            {
                nacimiento.Value = new DateTime(1990, 1, 1);
                docTipo.SelectedItem = docTipo.Items[0];
                checkBox1.Checked = true;

            }
            else {

                id.Text = cliente.id.ToString();
                localidadText.Text = cliente.localidad;

                for (int i = 0;i<docTipo.Items.Count;i++)
                {
                    String[] result = docTipo.Items[i].ToString().Split(',');
                    String[] valueString = result[0].Split('[');
                    UInt32 value = UInt32.Parse(valueString[1]);

                    if (value == cliente.tipoDocumento.id ) {
                        docTipo.SelectedItem = docTipo.Items[i];
                        break;
                    }
                }

                docNumero.Text = cliente.nroDocumento.ToString();
                apellido.Text = cliente.apellido;
                nombre.Text = cliente.nombre;
                nacimiento.Value = cliente.nacimiento;
                email.Text = cliente.email;
                checkBox1.Checked = cliente.habilitado;
                
                if (cliente.direccionCalle != null && cliente.direccionCalle.Length != 0) {
                    domCalle.Text = cliente.direccionCalle;
                }
                if (cliente.direccionNumeroCalle != 0)
                {
                    domNumero .Text = cliente.direccionNumeroCalle.ToString();
                }
                if (cliente.direccionPiso != 0)
                {
                    domPiso.Text = cliente.direccionPiso.ToString();
                }
                if (cliente.direccionDepto != null && cliente.direccionDepto.Length != 0)
                {
                    domDepartamento.Text = cliente.direccionDepto;
                }

                nacionalidadText.Text = cliente.pais.nacionalidad;
                paisText.Text = cliente.pais.nombre;
                localidadText.Text = cliente.localidad;

                nacionalidad = cliente.pais;
                pais = cliente.pais;
                tipoDocumento = cliente.tipoDocumento;
                
            }
            

        }
        //-----------------------------------------------------------------------------------------------------------------

        //-----------------------------------------------------------------------------------------------------------------
        public void setPaisSeleccionado(PaisModel paisSeleccionado) {
            this.paisText.Text = paisSeleccionado.nombre;
            this.pais = paisSeleccionado;
        }
        //-----------------------------------------------------------------------------------------------------------------

        //-----------------------------------------------------------------------------------------------------------------
        public void setNacionalidadSeleccionado(PaisModel nacionalidad)
        {
            this.nacionalidadText.Text = nacionalidad.nacionalidad;
            this.nacionalidad = nacionalidad;
        }
        //-----------------------------------------------------------------------------------------------------------------

        //-----------------------------------------------------------------------------------------------------------------
        public void setLocalidadSeleccionado(LocalidadModel localidad)
        {
            this.localidadText.Text = localidad.nombre;
            this.localidad = localidad;
        }
        //-----------------------------------------------------------------------------------------------------------------

        //EVENT HANDLER***
        //cambian los campos de texto
        //-----------------------------------------------------------------------------------------------------------------
        private void requireds_TextChanged(object sender, EventArgs e)
        {
            if (docNumero.Text.Length != 0 && 
                apellido.Text.Length != 0  && nombre.Text.Length != 0           && 
                email.Text.Length != 0     && nacionalidadText.Text.Length != 0 &&
                paisText.Text.Length != 0  && localidadText.Text.Length != 0    &&
                domCalle.Text.Length != 0  && domNumero.Text.Length != 0        &&
                domPiso.Text.Length != 0   && domDepartamento.Text.Length != 0)
            {
                button3.Enabled = true;
            }
            else {
                if(operacionTipo < 2){
                    button3.Enabled = false;
                }
            }
        }
        //-----------------------------------------------------------------------------------------------------------------

        //aceptar
        //-----------------------------------------------------------------------------------------------------------------
        private void button3_Click(object sender, EventArgs e)
        {
            String[] result = docTipo.SelectedItem.ToString().Split(',');
            String[] valueString = result[0].Split('[');
            UInt32 docTipoSelected = UInt32.Parse(valueString[1]);
            TipoDocumentoDAO docDao = new TipoDocumentoDAO();
           
            TipoDocumentoModel documentoToSend = docDao.dameTuModelo(docTipoSelected.ToString());

            switch (operacionTipo)
            {
                //agregar Cliente
                case 0:
                    cliente = new ClienteModel(apellido.Text,nombre.Text,documentoToSend,Decimal.Parse(docNumero.Text),
                                                nacimiento.Value,email.Text,nacionalidad,domCalle.Text,
                                               Decimal.Parse(domNumero.Text),Decimal.Parse(domPiso.Text),
                                               domDepartamento.Text,localidadText.Text,pais);
                    try
                    {
                        Respuesta respuesta = clienteDao.addNewCliente(cliente);
                        MessageBox.Show(respuesta.mensaje);
                        if (respuesta.codigo > 0)
                        {
                            cliente.id = respuesta.codigo;
                            parent.formResponseAdd(cliente);
                            parent.Enabled = true;
                            this.Close();
                            this.Dispose();
                            GC.Collect();
                        }
                    }
                    catch (Exception er)
                    {
                        MessageBox.Show(EXCEPTION_MESSAGE + " : " + er);
                    }
                    break;
                //modificar Cliente
                case 1:
                    cliente = new ClienteModel(cliente.id,apellido.Text, nombre.Text, documentoToSend, 
                                                Decimal.Parse(docNumero.Text),
                                                nacimiento.Value, email.Text, nacionalidad, domCalle.Text,
                                                Decimal.Parse(domNumero.Text), Decimal.Parse(domPiso.Text),
                                                domDepartamento.Text, localidadText.Text, pais);

                    try
                    {
                        Respuesta respuesta = clienteDao.updateCliente(cliente);
                        MessageBox.Show(respuesta.mensaje);
                        if (respuesta.codigo > 0)
                        {
                            parent.formResponseUpdate(cliente);
                            parent.Enabled = true;
                            this.Close();
                            this.Dispose();
                            GC.Collect();
                        }
                    }
                    catch (Exception er)
                    {
                        MessageBox.Show(EXCEPTION_MESSAGE + " : " + er);
                    }
                    break;
                case 2:
                    try
                    {
                        Respuesta respuesta = clienteDao.unsubscribeCliente(cliente);
                        MessageBox.Show(respuesta.mensaje);
                        if (respuesta.codigo > 0)
                        {
                            cliente.habilitado = false;
                            parent.formResponseDisable();
                            parent.Enabled = true;
                            this.Close();
                            this.Dispose();
                            GC.Collect();
                        }
                    }
                    catch (Exception er)
                    {
                        MessageBox.Show(EXCEPTION_MESSAGE + " : " + er);
                    }
                    break;
            }
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
            try
            {
                if (Double.Parse(docNumero.Text) <= 0)
                {
                    MessageBox.Show("El valor no puede ser cero");
                    docNumero.Text = "";
                }
            }
            catch (FormatException erf) { }
            catch (NullReferenceException eru) { }
            catch (Exception erg) { }
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
            try
            {
                if (Double.Parse(domNumero.Text) <= 0)
                {
                    MessageBox.Show("El valor no puede ser cero");
                    domNumero.Text = "";
                }
            }
            catch (FormatException erf) { }
            catch (NullReferenceException eru) { }
            catch (Exception erg) { }
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
            try
            {
                if (Double.Parse(domPiso.Text) <= 0)
                {
                    domPiso.Text = "";
                }
            }
            catch (FormatException erf) { }
            catch (NullReferenceException eru) { }
            catch (Exception erg) { }
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
