using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DISCOS_DB
{
    public partial class Formulario : Form
    {
        private List<Discos> listaDiscos;
        public Formulario()
        {
            InitializeComponent();
        }

        private void Formulario_Load(object sender, EventArgs e)
        {
            DiscosConexion conexion = new DiscosConexion();
            listaDiscos = conexion.Listar();
            dgvdiscos.DataSource = listaDiscos;
            dgvdiscos.Columns["UrlImagen"].Visible = false;
            cargarimagen(listaDiscos[0].UrlImagen);
        }

        private void dgvdiscos_SelectionChanged(object sender, EventArgs e)
        {
            Discos seleccionado = (Discos)dgvdiscos.CurrentRow.DataBoundItem;
            cargarimagen(seleccionado.UrlImagen);
        }
        private void cargarimagen(string imagen)
        {
            try
            {
                pictureBox1.Load(imagen);
            }
            catch (Exception)
            {
                pictureBox1.Load("https://efectocolibri.com/wp-content/uploads/2021/01/placeholder.png");
            }
        }
    }
}
