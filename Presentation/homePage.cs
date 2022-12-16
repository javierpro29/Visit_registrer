using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentation
{
    public partial class homePage : Form
    {
        public homePage()
        {
            InitializeComponent();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {

        }

        private void homePage_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void homePage_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.WindowState |= FormWindowState.Minimized;
        }

        private void lblLoginTitle_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton1_Click_1(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            DialogResult btnDialog = MessageBox.Show("Esta seguro de que quiere cerar la sesion", "Cerar Sesion",
            MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (btnDialog == DialogResult.OK)
            {
                login log = new login();
                log.Show();
                this.Hide();
            }
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {

        }

        private Form activeForm = null;
        private void openChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            pnForm.Controls.Add(childForm);
            pnForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void btnVisitas_Click(object sender, EventArgs e)
        {
            openChildForm(new usuarios());
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            openChildForm(new usuarios());
        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            try
            {
                openChildForm(null);
            }
            catch (Exception ex)
            {

            }
        }
    }
}
