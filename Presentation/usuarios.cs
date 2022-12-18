using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business;
using Entity;

namespace Presentation
{
    public partial class usuarios : Form
    {
        E_usuarios entUsuarios = new E_usuarios();
        B_usuarios objUsuario = new B_usuarios();

        public bool editandoUsuarios = false;

        public usuarios()
        {
            InitializeComponent();
        }

        private void usuarios_Load(object sender, EventArgs e)
        {
            mostrarUsuarios("");

            cmbPermisos.SelectedIndex = 1;
            dtNacimiento.Value = Convert.ToDateTime("01/01/2000");
        }

        public void accionesTablaUsuario()
        {
            tablaUsuarios.Columns[0].Visible = false;
            tablaUsuarios.Columns[1].Width = 60;
            tablaUsuarios.Columns[3].Width = 70;
            

            tablaUsuarios.ClearSelection();
        }

        public void mostrarUsuarios(String buscar)
        {
            B_usuarios objUsuario = new B_usuarios();
            tablaUsuarios.DataSource = objUsuario.MostrandoUsuarios(buscar);
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            limpiarForm();
        }

        public void limpiarForm()
        {
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtUsername.Text = "";
            txtPassword.Text = "";
            dtNacimiento.Value = Convert.ToDateTime("01/01/2000");
            cmbPermisos.SelectedIndex = 1;
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (editandoUsuarios == false)
            {
                try
                {
                    entUsuarios.Nombre = txtNombre.Text.ToUpper();
                    entUsuarios.Apellido = txtApellido.Text.ToUpper();
                    entUsuarios.Username = txtUsername.Text.ToUpper();
                    entUsuarios.Password = txtUsername.Text.ToUpper();

                    entUsuarios.Fecha_nacimiento = dtNacimiento.Value;
                    entUsuarios.Permisos = cmbPermisos.SelectedItem.ToString().ToUpper();

                    if (txtPassword.Text.Length < 8)
                    {
                        MessageBox.Show("El password debe contener 8 caracteres minimos");
                    }
                    else
                    {
                        objUsuario.insertandoUsuarios(entUsuarios);

                        MessageBox.Show("Usuario guardado correctamente");
                        mostrarUsuarios("");
                        limpiarForm();
                    }

                    

                }
                catch (Exception ex)
                {
                    MessageBox.Show("El usuario no ha podido ser guardada, porfavor verifique sus datos");
                }
            }


            if (editandoUsuarios == true)
            {
                try
                {
                    entUsuarios.Id = Convert.ToInt32(tablaUsuarios.CurrentRow.Cells[0].Value.ToString());
                    entUsuarios.Nombre = txtNombre.Text.ToUpper();
                    entUsuarios.Apellido = txtApellido.Text.ToUpper();
                    entUsuarios.Username = txtUsername.Text.ToUpper();
                    entUsuarios.Password = txtPassword.Text.ToUpper();

                    entUsuarios.Fecha_nacimiento = dtNacimiento.Value;
                    entUsuarios.Permisos = cmbPermisos.SelectedItem.ToString().ToUpper();


                    if (txtPassword.Text.Length < 8)
                    {
                        MessageBox.Show("El password debe contener 8 caracteres minimos");
                    }
                    else
                    {
                        objUsuario.editandoUsuarios(entUsuarios);

                        MessageBox.Show("Usuario modificado correctamente");
                        mostrarUsuarios("");
                        limpiarForm();


                        editandoUsuarios = false;
                    }

                   
                }
                catch (Exception ex)
                {
                    MessageBox.Show("El usuario no ha podido ser modificado, porfavor verifique sus datos");
                }
            }
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            if (tablaUsuarios.SelectedRows.Count > 0)
            {
                txtNombre.Text = tablaUsuarios.CurrentRow.Cells[2].Value.ToString();
                txtApellido.Text = tablaUsuarios.CurrentRow.Cells[3].Value.ToString();

                dtNacimiento.Value = Convert.ToDateTime(tablaUsuarios.CurrentRow.Cells[4].Value);

                txtUsername.Text = tablaUsuarios.CurrentRow.Cells[7].Value.ToString();
               
                txtPassword.Text = tablaUsuarios.CurrentRow.Cells[7].Value.ToString();

                editandoUsuarios = true;
            }
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            if (tablaUsuarios.SelectedRows.Count > 0)
            {

                DialogResult btnDialog = MessageBox.Show("Esta seguro de que quiere eliminar este usuario permanentemente", "Eliminar Usuarios",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (btnDialog == DialogResult.OK)
                {
                    entUsuarios.Id = Convert.ToInt32(tablaUsuarios.CurrentRow.Cells[0].Value.ToString()); ;
                    objUsuario.eliminandoUsuarios(entUsuarios);

                    //MessageBox.Show("La visita ha sido eliminada correctamente");
                    mostrarUsuarios("");
                    tablaUsuarios.ClearSelection();
                }
            }
        }
    }
}
