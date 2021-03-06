﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Models;
using DAO;
using ABM;
using Retiros;
using Depositos;
using Transferencias;

namespace ABM
{
    public partial class ConsultaDeSaldos : Form
    {

        private CuentaModel cuenta;
        private List<RetiroModel> retiros;
        private List<DepositoModel> depositos;
        private List<TransferenciaModel> transferencias;


        public ConsultaDeSaldos()
        {
            
            InitializeComponent();
        }

        //-----------------------------------------------------------------------------------------------------------------
        private void fillTables()
        {
            dataGridViewDepositos.Rows.Clear();
            dataGridViewRetiros.Rows.Clear();
            dataGridViewTransferencias.Rows.Clear();

            if (depositos != null && depositos.Count != 0) {

                string[] row;
                foreach (DepositoModel d in depositos)
                {
                    row = new String[]  {   d.id.ToString(),
                                            d.depositante.apellido + ", " + d.depositante.nombre,
                                            d.importe.ToString(),
                                            d.monedaId.nombre.ToString(),
                                            d.tarjetaDeCredito.numero.ToString(),
                                            d.fecha.ToShortDateString()
                                        };
                                            
                    dataGridViewDepositos.Rows.Add(row);
                }
            }

            if (retiros != null && retiros.Count != 0)
            {

                string[] row;
                foreach (RetiroModel r in retiros)
                {
                    row = new String[]  {   r.id.ToString(),
                                            r.importe.ToString(),
                                            r.moneda.nombre.ToString(),
                                            r.fecha.ToShortDateString(),
                                            r.chequeId.ToString(),
                                            r.banco.nombre.ToString()
                                        };

                    dataGridViewRetiros.Rows.Add(row);
                }
            }

            if (transferencias != null && transferencias.Count != 0)
            {

                string[] row;
                foreach (TransferenciaModel t in transferencias)
                {
                    row = new String[]  {   t.id.ToString(),
                                            t.cuentaOrigen.id.ToString(),
                                            t.cuentaDestino.id.ToString(),
                                            t.importe.ToString(),
                                            t.moneda.nombre.ToString(),
                                            t.fecha.ToShortDateString()
                                        };

                    dataGridViewTransferencias.Rows.Add(row);
                }
            }

            
        }
        //-----------------------------------------------------------------------------------------------------------------

        //-----------------------------------------------------------------------------------------------------------------
        public void formResponseCuenta(CuentaModel cuenta)
        {
            if (cuenta != null)
            {
                this.cuenta = cuenta;
                cuentaText.Text = cuenta.id.ToString();
                labelPropietario.Visible = true;
                labelPropietarioText.Visible = true;
                labelPropietarioText.Text = cuenta.propietario.apellido + ", " + cuenta.propietario.nombre;

                labelSaldo.Visible = true;
                labelSaldoText.Visible = true;
                labelSaldoText.Text = cuenta.saldo.ToString();


                retiros = new RetiroDao().getRetiroByCuenta(cuenta);
                depositos = new DepositoDao().getDepositosByCuenta(cuenta);
                transferencias = new TransferenciaDao().getTransferenciasByCuenta(cuenta);

                fillTables();
            }

        }
        //-----------------------------------------------------------------------------------------------------------------


        //Event Handler**
        //-----------------------------------------------------------------------------------------------------------------
        //Buscar Cuenta
        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            Form f = new CuentaAbm(this);
            f.MdiParent = this.MdiParent;
            f.Show();
        }
        //-----------------------------------------------------------------------------------------------------------------
    }
}
