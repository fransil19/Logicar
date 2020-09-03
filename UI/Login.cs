﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class Login : Form
    {
        public Login()
        {
            //Pruebo la conexion a la base para saber si esta activa.

            //
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {

            //Verifico que los campos no esten vacios
            if (String.IsNullOrEmpty(txtUsuario.Text) || String.IsNullOrEmpty(txtPass.Text))
            {
                MessageBox.Show("Por favor complete los campos requeridos");
                return;
            }

            //Verifico integridad de la base
            
        }
    }
}