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
    public partial class visitas : Form
    {
        E_visitas EntVisitas = new E_visitas();
        B_visitas objVisitas = new B_visitas();

        private bool editandoVisita = false;


        public visitas()
        {
            InitializeComponent();
        }

        private void visitas_Load(object sender, EventArgs e)
        {
            mostrarVisitas("");
            accionesVisitas();
            cargarComboEdificio();
            cargarComboAula();

            dtEntrada.Value = DateTime.Now;
            dtSalida.Value = DateTime.Now;
        }


        B_edificios objEdificio = new B_edificios();

        public void cargarComboEdificio()
        {
            cmbEdifios.DataSource = objEdificio.cargarComboEdificio();
            cmbEdifios.DisplayMember = "NOMBRE";
            cmbEdifios.ValueMember = "ID";
        }

        B_aulas objAula = new B_aulas();
        public void cargarComboAula()
        {
            cmbAulas.DataSource = objAula.cargarComboAula();
            cmbAulas.DisplayMember = "NOMBRE";
            cmbAulas.ValueMember = "ID";
        }



        public void mostrarVisitas(string buscar)
        {
            B_visitas objVisitas = new B_visitas();
            tablaVisitas.DataSource = objVisitas.listandoVisitas(buscar);
        }

        public void accionesVisitas()
        {
            tablaVisitas.Columns[0].Visible = false;
            tablaVisitas.Columns[1].Width = 60;
            tablaVisitas.Columns[2].Width = 70;
            tablaVisitas.Columns[3].Width = 70;
            tablaVisitas.Columns[4].Width = 85;
            tablaVisitas.Columns[5].Width = 140;
            tablaVisitas.Columns[6].Width = 60;
            tablaVisitas.Columns[7].Width = 45; 
            tablaVisitas.Columns[8].Width = 115;
            tablaVisitas.Columns[9].Width = 115;
            tablaVisitas.Columns[10].Width = 800;
            //tablaVisitas.Columns[11].Visible = false;
            //tablaVisitas.Columns[12].Visible = false;

            tablaVisitas.ClearSelection();
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            limpiarFormulario();
        }

        public void limpiarFormulario()
        {
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtCarrera.Text = "";
            txtCorreo.Text = "";
            txtMotivo.Text = "";

            dtEntrada.Value = DateTime.Now;
            dtSalida.Value = DateTime.Now;
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (editandoVisita == false)
            {
                try
                {
                    EntVisitas.Name = txtNombre.Text.ToUpper();
                    EntVisitas.Apellido = txtApellido.Text.ToUpper();
                    EntVisitas.Carrera = txtCarrera.Text.ToUpper();
                    EntVisitas.Correo = txtCarrera.Text.ToUpper();
                    EntVisitas.Edifico = Convert.ToInt32(cmbEdifios.SelectedValue.ToString());
                    EntVisitas.Aula = Convert.ToInt32(cmbAulas.SelectedValue.ToString());
                    EntVisitas.HoraEntrada = dtEntrada.Value;
                    EntVisitas.HoraSalida = dtSalida.Value;
                    EntVisitas.Motivo = txtMotivo.Text.ToUpper();

                    objVisitas.insertandoVisita(EntVisitas);

                    MessageBox.Show("Visita guardada correctamente");
                    mostrarVisitas("");
                    limpiarFormulario();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("La visita no ha ha podido ser guardada, porfavor verifique sus datos");
                }
            }


            if(editandoVisita == true)
            {
                try
                {
                    EntVisitas.Id = Convert.ToInt32(tablaVisitas.CurrentRow.Cells[0].Value.ToString());
                    EntVisitas.Name = txtNombre.Text.ToUpper();
                    EntVisitas.Apellido = txtApellido.Text.ToUpper();
                    EntVisitas.Carrera = txtCarrera.Text.ToUpper();
                    EntVisitas.Correo = txtCorreo.Text.ToUpper();
                    EntVisitas.Edifico = Convert.ToInt32(cmbEdifios.SelectedValue.ToString());
                    EntVisitas.Aula = Convert.ToInt32(cmbAulas.SelectedValue.ToString());
                    EntVisitas.HoraEntrada = dtEntrada.Value;
                    EntVisitas.HoraSalida = dtSalida.Value;
                    EntVisitas.Motivo = txtMotivo.Text.ToUpper();

                    objVisitas.editandoVisita(EntVisitas);

                    MessageBox.Show("Visita modificada correctamente");
                    mostrarVisitas("");
                    limpiarFormulario();
                    editandoVisita = false;
                }
                catch(Exception ex)
                {
                    MessageBox.Show("La visita no ha podido ser modificada, porfavor verifique sus datos");
                }
            }

        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            if(tablaVisitas.SelectedRows.Count > 0)
            {
                txtNombre.Text = tablaVisitas.CurrentRow.Cells[2].Value.ToString();
                txtApellido.Text = tablaVisitas.CurrentRow.Cells[3].Value.ToString();
                txtCarrera.Text = tablaVisitas.CurrentRow.Cells[4].Value.ToString();
                txtCorreo.Text = tablaVisitas.CurrentRow.Cells[5].Value.ToString();
                txtMotivo.Text = tablaVisitas.CurrentRow.Cells[10].Value.ToString();

                cmbEdifios.SelectedValue = tablaVisitas.CurrentRow.Cells[11].Value;
                cmbAulas.SelectedValue = tablaVisitas.CurrentRow.Cells[12].Value;

                dtEntrada.Value = Convert.ToDateTime(tablaVisitas.CurrentRow.Cells[8].Value);
                dtSalida.Value = Convert.ToDateTime(tablaVisitas.CurrentRow.Cells[9].Value);


                editandoVisita = true;
            }
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {

            if (tablaVisitas.SelectedRows.Count > 0)
            {

                DialogResult btnDialog = MessageBox.Show("Esta seguro de que quiere eliminar esta visita permanentemente", "Eliminar Visitas",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (btnDialog == DialogResult.OK)
                {
                    EntVisitas.Id = Convert.ToInt32(tablaVisitas.CurrentRow.Cells[0].Value.ToString());
                    objVisitas.eliminandoVisita(EntVisitas);

                    //MessageBox.Show("La visita ha sido eliminada correctamente");
                    mostrarVisitas("");
                    tablaVisitas.ClearSelection();
                }
            }
        }
    }
}
