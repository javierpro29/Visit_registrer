using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business;

namespace Presentation
{
    public partial class login : Form
    {

        B_usuarios objUsuarios = new B_usuarios();

        public login()
        {
            InitializeComponent();
        }

        private void lblLoginTitle_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            //Application.Exit();
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        

        private void btnLogin_Click(object sender, EventArgs e)
        {

            if(objUsuarios.login(txtUsername.Text, txtPassword.Text))
            {
                this.Hide();
                welcomeForm welcomepage = new welcomeForm();
                welcomepage.Show();
            } 


           // conexion.Open();
           // SqlCommand cmd = new SqlCommand("SELECT USERNAME, PASSWORD FROM USUARIOS WHERE USERNAME = @USERNAME AND PASSWORD = @PASSWORD", conexion);
           // cmd.Parameters.AddWithValue("@USERNAME", txtUsername.Text);
           // cmd.Parameters.AddWithValue("@PASSWORD", txtPassword.Text);

           //SqlDataReader reader = cmd.ExecuteReader();

           // if (reader.Read())
           // {
           //     conexion.Close();
           //     this.Hide();
           //     welcomeForm welcomepage = new welcomeForm();
           //     welcomepage.Show();
                
           // }
        }
    }
}
