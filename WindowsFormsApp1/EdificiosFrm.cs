using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Modelos;

namespace WindowsFormsApp1
{
    public partial class EdificiosFrm : Form
    {
        int edificio_id = 0;
        public EdificiosFrm()
        {
            InitializeComponent();
        }

        private void EdificiosFrm_Load(object sender, EventArgs e)
        {
            {
                dataGridView1.DataSource =  Edificio.Obtener();
                if (dataGridView1.Columns.Count > 0)
                {
                    dataGridView1.Columns["id"].Visible = false;

                }
            }
        }

        private void btnGuarda_Click(object sender, EventArgs e)
        {
            {
                string nombres = txtNombre.Text;
                string direccion = txtDireccion.Text;
                bool resultado = false;
                if (edificio_id == 0)
                {
                    resultado = Edificio.Crear(nombres, direccion);
                }
                else
                {
                    resultado = Edificio.Editar(edificio_id, nombres, direccion);
                }

                dataGridView1.DataSource = Edificio.Obtener();
                limpiar();
            }

        }
        private void limpiar()
        {
            txtDireccion.Clear();
            txtNombre.Clear();
          
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            {
                txtNombre.Text = dataGridView1.CurrentRow.Cells["nombre"].Value.ToString();
                txtDireccion.Text = dataGridView1.CurrentRow.Cells["direccion"].Value.ToString();
                edificio_id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["id"].Value);


            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["id"].Value.ToString());
            bool resultado = Edificio.Eliminar(id);
            if (resultado)
            {
                MessageBox.Show("Cliente Eliminado Correctamente");
            }
            dataGridView1.DataSource = Edificio.Obtener();
            limpiar();
        }
    }

}
