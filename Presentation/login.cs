using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentation
{
    public partial class login : Form
    {
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
            welcomeForm welcomeForm = new welcomeForm();   
            welcomeForm.ShowDialog();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        SqlConnection conexion = new SqlConnection("Data Source = ANDERSON_JAVIER; Initial Catalog = REGISTRO_DE_VISITAS; Integrated Security = True");

        private void btnLogin_Click(object sender, EventArgs e)
        {
            conexion.Open();
            SqlCommand cmd = new SqlCommand("SELECT USERNAME, PASSWORD FROM USUARIOS WHERE USERNAME = @USERNAME AND PASSWORD = @PASSWORD", conexion);
            cmd.Parameters.AddWithValue("@USERNAME", txtUsername.Text);
            cmd.Parameters.AddWithValue("@PASSWORD", txtPassword.Text);

           SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                conexion.Close();
                welcomeForm welcomepage = new welcomeForm();
                welcomepage.Show();
            }
        }
    }
}
