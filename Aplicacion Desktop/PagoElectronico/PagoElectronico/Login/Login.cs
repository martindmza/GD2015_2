using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Models;
using Frame;
using DAO;
using System.Security.Cryptography;
using MyExceptions;

namespace Logins
{
    public partial class Login : Form
    {

        public static RolModel rolSelected;
        public UserDao dao = new UserDao();

        public Login() {
            InitializeComponent();
            this.usuario.Text = "admin";
            this.password.Text = "w23e";
        }
        
        //---------------------------------------------------------------------------------------------------------------------
        private void button1_Click(object sender, EventArgs e)
        {

            String usuario = this.usuario.Text;
            String password = this.password.Text;

            UsuarioSingleton.getInstance().setUsuario(dao.loguin(usuario,password));

            if (UsuarioSingleton.getInstance().getUsuario() != null)
            {
                Frame.Frame frame = new Frame.Frame(this);
                this.Hide();
                frame.Show();
            }
        }
        //---------------------------------------------------------------------------------------------------------------------
    }
}

