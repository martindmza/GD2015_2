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

namespace Tarjetas
{

    public partial class TarjetasForm : Form
    {
        private UInt32 operacionTipo;

        private TarjetasAbm parent;
        private TarjetaDeCreditoModel tarjeta;
        private ExtraDao dao;

        public TarjetasForm(UInt32 operacionTipo,TarjetasAbm parent,TarjetaDeCreditoModel tarjeta)
        {
            InitializeComponent();
        }
    }
}
