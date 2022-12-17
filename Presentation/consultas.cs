using Business;
using Entity;
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
    public partial class consultas : Form
    {
        E_visitas EntConsulta= new E_visitas();

        public consultas()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void consultas_Load(object sender, EventArgs e)
        {
            consultarEdificio("");
            accionesConsultas();

            cmbConsultar.SelectedIndex = 0;
        }

        public void consultarEdificio(string buscar)
        {
            B_consultas objConsultas = new B_consultas();
            tablaConsultas.DataSource = objConsultas.consultadoEdificio(buscar);
        }

        public void consultarAula(string buscar)
        {
            B_consultas objConsultas = new B_consultas();
            tablaConsultas.DataSource = objConsultas.consultadoAula(buscar);
        }

        public void consultarNombre(string buscar)
        {
            B_consultas objConsultas = new B_consultas();
            tablaConsultas.DataSource = objConsultas.consultadoNombre(buscar);
        }




        public void accionesConsultas()
        {
            tablaConsultas.Columns[0].Visible = false;
            tablaConsultas.Columns[1].Width = 60;
            tablaConsultas.Columns[2].Width = 70;
            tablaConsultas.Columns[3].Width = 70;
            tablaConsultas.Columns[4].Width = 85;
            tablaConsultas.Columns[5].Width = 140;
            tablaConsultas.Columns[6].Width = 60;
            tablaConsultas.Columns[7].Width = 45;
            tablaConsultas.Columns[8].Width = 115;
            tablaConsultas.Columns[9].Width = 115;
            tablaConsultas.Columns[10].Width = 800;
            //tablaVisitas.Columns[11].Visible = false;
            //tablaVisitas.Columns[12].Visible = false;

            tablaConsultas.ClearSelection();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {

            if(cmbConsultar.SelectedIndex == 0)
            {
                consultarEdificio(txtBuscar.Text.ToUpper());
            }

            if(cmbConsultar.SelectedIndex == 1)
            {
                consultarAula(txtBuscar.Text.ToUpper());
            }

            if(cmbConsultar.SelectedIndex == 2) 
            { 
                consultarNombre(txtBuscar.Text.ToUpper());
            }
            
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            ExportarDatosExcel(tablaConsultas);
        }


        public void ExportarDatosExcel(DataGridView datalista)
        {
            Microsoft.Office.Interop.Excel.Application exportarExcel = new Microsoft.Office.Interop.Excel.Application();

            exportarExcel.Application.Workbooks.Add(true);

            int indiceColumna = 0;

            foreach (DataGridViewColumn columna in datalista.Columns)
            {
                indiceColumna++;
                exportarExcel.Cells[1, indiceColumna] = columna.Name;

            }

            int indiceFila = 0;

            foreach (DataGridViewRow row in datalista.Rows)
            {
                indiceFila++;
                indiceColumna = 0;
                foreach (DataGridViewColumn columna in datalista.Columns)
                {
                    indiceColumna++;
                    exportarExcel.Cells[indiceFila + 1, indiceColumna] = row.Cells[columna.Name].Value;
                }
            }

            exportarExcel.Visible = true;
        }
    }
}
