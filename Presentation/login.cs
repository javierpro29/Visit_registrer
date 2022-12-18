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
            imgMessage.Visible = false;
            
        }

        

        private void btnLogin_Click(object sender, EventArgs e)
        {

            if(txtUsername.Text != "" || txtPassword.Text != "")
            {
                B_usuarios objUsuarios = new B_usuarios();
                var validLogin = objUsuarios.login(txtUsername.Text, txtPassword.Text);

                if (validLogin == true)
                {
                    this.Hide();
                    welcomeForm welcomepage = new welcomeForm();
                    welcomepage.Show();
                }
                else
                {
                    errorMessage("El username o password no es valido \n Porfavor intente nuevamente");
                    imgMessage.Visible = true;
                }
            }
            else
            {
                errorMessage("Los campos no pueden estar vacios");
            }

        }

        private void errorMessage(string msg)
        {
            lblMensaje.Text = msg;
            imgMessage.Visible = true;
        }


        private void login_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtUsername_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void txtPassword_MouseClick(object sender, MouseEventArgs e)
        {
           
        }

        private void txtUsername_MouseClick_1(object sender, MouseEventArgs e)
        {
            errorMessage("");
            imgMessage.Visible = false;
        }

        private void txtPassword_MouseClick_1(object sender, MouseEventArgs e)
        {
            errorMessage("");
            imgMessage.Visible = false;
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
