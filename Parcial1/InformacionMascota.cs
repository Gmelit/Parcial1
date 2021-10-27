using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Parcial1
{
    public partial class InformacionMascota : Form
    {
        public InformacionMascota()
        {
            InitializeComponent();
        }
        // Evento que nos permite guardar la mascota ingresada
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            string tipo = cbTipo.GetItemText(cbTipo.SelectedItem);
            string dueño = txtDniDueño.Text;

            if(string.IsNullOrEmpty(nombre) == true || string.IsNullOrEmpty(tipo) == true
            )
            {
                MessageBox.Show("Debe completar los campos obligatorios");

            }
            else
            {
                var conexion = new SqlConnection("Data Source = .; Initial Catalog = INFOPERSONA; Integrated Security = true;");

              
                var insert = "INSERT INTO MASCOTA VALUES('" + nombre + "' ,'" + tipo + "', '" + dueño + "'," +
                    "'" + 1 + "')";

                
                var comando = new SqlCommand(insert, conexion);

                conexion.Open();

                try
                {
                    var cantidadDeRegistros = comando.ExecuteNonQuery();

                    if (cantidadDeRegistros > 0)
                    {
                        MessageBox.Show("Mascota ingresada");
                    }
                    else
                    {
                        MessageBox.Show("Mascota no ingresada, hubo algun error");
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Dueño no registrado");
                }


                conexion.Close();

                txtDniDueño.Text = "";
                txtNombre.Text = "";
                cbTipo.SelectedItem = -1;

            }

        }
        // Salir.
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Bienvenida b1 = new Bienvenida();
            b1.Show();
        }

    }
}
