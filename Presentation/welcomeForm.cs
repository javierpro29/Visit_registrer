using Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entity.cache;

namespace Presentation
{
    public partial class welcomeForm : Form
    {

        B_usuarios objUsuarios = new B_usuarios();

        public welcomeForm()
        {
            InitializeComponent();
        }

        private void lblLoginTitle_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            if (this.Opacity < 1) this.Opacity += 0.05;
            progressBar1.Value += 1;
            if(progressBar1.Value == 100)
            {
                timer1.Stop();
                timer2.Start();
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            this.Opacity -= 0.1;
            if(this.Opacity == 0)
            {
                timer2.Stop();
                this.Close();
                homePage home = new homePage();
                home.Show();
                login log = new login();
            }
        }

        private void welcomeForm_Load(object sender, EventArgs e)
        {
            this.Opacity = 0.0;
            timer1.Start();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            lblUserActive.Text = Convert.ToString(C_login.nombre + " " + C_login.apellido);  
        }
    }
}
