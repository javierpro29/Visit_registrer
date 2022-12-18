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
    public partial class configuracion : Form
    {
        E_configuracion entConfiguracion = new E_configuracion();
        B_configuracion objConfiguracion = new B_configuracion();
        private bool editando = false;

        public configuracion()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void configuracion_Load(object sender, EventArgs e)
        {
            mostarTablaEdificios();
            mostarTablaAulas();
            accionesTablas();
        }   

        private void mostarTablaEdificios()
        {
            B_configuracion objCosnfiguracion = new B_configuracion();
            tablaEdificios.DataSource = objCosnfiguracion.mostrarEdificios();
        }

        private void mostarTablaAulas()
        {
            B_configuracion objCosnfiguracion = new B_configuracion();
            tablaAulas.DataSource = objCosnfiguracion.mostrarAulas();
        }

        private void accionesTablas()
        {
            tablaEdificios.Columns[2].Visible = false;
            tablaEdificios.Columns[3].Visible = false;
            tablaAulas.Columns[0].Visible = false;
            tablaAulas.Columns[1].Visible = false;

            tablaAulas.ClearSelection();
            tablaEdificios.ClearSelection();

            cmbAgregar.SelectedIndex = 0;
        }

        private void tablaEdificios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tablaAulas.ClearSelection();
            cmbAgregar.SelectedIndex = 0;
        }

        private void tablaAulas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tablaEdificios.ClearSelection();
            cmbAgregar.SelectedIndex = 1;
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {

        }

        private void limpiarForm()
        {
            txtId.Text = "";
            txtNombre.Text = "";
            cmbAgregar.SelectedIndex = 0;
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {

            if (editando == false)
            {
                if(cmbAgregar.SelectedIndex == 0)
                {
                    try
                    {
                        entConfiguracion.Nombre_Edificio = txtNombre.Text.ToUpper();
                       

                        if (txtNombre.Text.Length < 1)
                        {
                            MessageBox.Show("El nombre del edifico no puede estar vacio");
                        }
                        else
                        {
                            objConfiguracion.insertarEdificio(entConfiguracion);

                            MessageBox.Show("Edificio guardado correctamente");
                            mostarTablaEdificios();
                            limpiarForm();
                        }



                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("El edificio no ha podido ser guardado, porfavor verifique sus datos");
                    }
                }
                
                if(cmbAgregar.SelectedIndex == 1)
                {
                    try
                    {
                        entConfiguracion.Nombre_Aula = txtNombre.Text.ToUpper();


                        if (txtNombre.Text.Length < 1)
                        {
                            MessageBox.Show("El nombre del Aula no puede estar vacio");
                        }
                        else
                        {
                            objConfiguracion.insertarAula(entConfiguracion);

                            MessageBox.Show("Aula guardado correctamente");
                            mostarTablaAulas();
                            limpiarForm();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("El aula no ha podido ser guardada, porfavor verifique sus datos");
                    }
                }

            }

            if(editando == true)
            {
                if(cmbAgregar.SelectedIndex == 0)
                {
                    try
                    {
                        entConfiguracion.ID_Edificio = Convert.ToInt32(tablaEdificios.CurrentRow.Cells[0].Value.ToString());
                        entConfiguracion.Nombre_Edificio = txtNombre.Text.ToUpper();


                        if (txtNombre.Text.Length < 1)
                        {
                            MessageBox.Show("El nombre del edifico no puede estar vacio");
                        }
                        else
                        {
                            objConfiguracion.editarEdificio(entConfiguracion);

                            MessageBox.Show("Edificio modificado correctamente");
                            mostarTablaEdificios();
                            limpiarForm();
                        }



                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("El edificio no ha podido ser guardado, porfavor verifique sus datos");
                    }
                }


                if (cmbAgregar.SelectedIndex == 1)
                {
                    try
                    {
                        entConfiguracion.ID_Aula = Convert.ToInt32(tablaAulas.CurrentRow.Cells[2].Value.ToString());
                        entConfiguracion.Nombre_Aula = txtNombre.Text.ToUpper();


                        if (txtNombre.Text.Length < 1)
                        {
                            MessageBox.Show("El nombre del aula no puede estar vacio");
                        }
                        else
                        {
                            objConfiguracion.editarAula(entConfiguracion);

                            MessageBox.Show("Aula modificada correctamente");
                            mostarTablaAulas();
                            limpiarForm();
                        }



                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("El aula no ha podido ser guardada, porfavor verifique sus datos");
                    }
                }
            }
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            if(cmbAgregar.SelectedIndex == 0)
            {
                if (tablaEdificios.SelectedRows.Count > 0)
                {
                    txtId.Text = tablaEdificios.CurrentRow.Cells[0].Value.ToString();
                    txtNombre.Text = tablaEdificios.CurrentRow.Cells[1].Value.ToString();


                    editando = true;
                }
            }
            else
            {
                if (tablaAulas.SelectedRows.Count > 0)
                {
                    txtId.Text = tablaAulas.CurrentRow.Cells[2].Value.ToString();
                    txtNombre.Text = tablaAulas.CurrentRow.Cells[3].Value.ToString();


                    editando = true;
                }
            }
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            if(cmbAgregar.SelectedIndex == 0)
            {
                if (tablaEdificios.SelectedRows.Count > 0)
                {

                    DialogResult btnDialog = MessageBox.Show("Esta seguro de que quiere eliminar este edificio permanentemente", "Eliminar edificios",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                    if (btnDialog == DialogResult.OK)
                    {
                        entConfiguracion.ID_Edificio = Convert.ToInt32(tablaEdificios.CurrentRow.Cells[0].Value.ToString()); ;
                        objConfiguracion.eliminarEdificio(entConfiguracion);

                        
                        mostarTablaEdificios();
                        tablaEdificios.ClearSelection();
                    }
                }
            }

            if(cmbAgregar.SelectedIndex == 1)
            {
                if (tablaAulas.SelectedRows.Count > 0)
                {

                    DialogResult btnDialog = MessageBox.Show("Esta seguro de que quiere eliminar esta aula permanentemente", "Eliminar aula",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                    if (btnDialog == DialogResult.OK)
                    {
                        entConfiguracion.ID_Aula = Convert.ToInt32(tablaAulas.CurrentRow.Cells[2].Value.ToString()); ;
                        objConfiguracion.eliminarAula(entConfiguracion);

                       
                        mostarTablaAulas();
                        tablaAulas.ClearSelection();
                    }
                }
            }
        }
    }
}
