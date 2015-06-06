﻿using System;
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

namespace Login
{
    public partial class Login : Form
    {

        public static UserModel userLogued;
        public static RolModel rolSelected;
        public UserDao dao = new UserDao();

        public Login() {
            InitializeComponent();
            this.usuario.Text = "admin";
            this.password.Text = "w32e";
        }
        
        //---------------------------------------------------------------------------------------------------------------------
        private void button1_Click(object sender, EventArgs e)
        {

            String usuario = this.usuario.Text;
            String password = this.password.Text;

            try {
                userLogued = dao.loguin(usuario,password);
                if (userLogued == null) { 
                    throw new UserNotFoundException("el usuario se encontró pero no puedo crearse");
                }
            }
            catch (UserNotFoundException err)
            {
                MessageBox.Show("Contraseña incorrecta :" + err);
            }

            try {
                Frame.Frame frame = new Frame.Frame();
                this.Hide();
                frame.Show();
            }
            catch (UserRolNotFoundException err2)
            {
                MessageBox.Show(err2.message);
            }
        }
        //---------------------------------------------------------------------------------------------------------------------
        
        
    }
}

