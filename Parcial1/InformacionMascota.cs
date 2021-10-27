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
            // Extracción de los datos que haya en los campos.
            string nombre = txtNombre.Text;
            string tipo = cbTipo.GetItemText(cbTipo.SelectedItem);
            string dueño = txtDniDueño.Text;

            // Validación de los datos obligatorios.
            if(string.IsNullOrEmpty(nombre) == true || string.IsNullOrEmpty(tipo) == true
            )
            {
                MessageBox.Show("Debe completar los campos obligatorios");

            }
            else
            {
                // Conexión BD.
                var conexion = new SqlConnection("Data Source = .; Initial Catalog = INFOPERSONA; Integrated Security = true;");

                string insert;

                // Validación y creación de inserción.
                if (string.IsNullOrEmpty(dueño) == true)
                {
                    insert = "INSERT INTO MASCOTA VALUES('" + nombre + "' ,'" + tipo + "', NULL," +
                    "'" + 1 + "')";
                }
                else
                {
                    insert = "INSERT INTO MASCOTA VALUES('" + nombre + "' ,'" + tipo + "', '" + dueño + "'," +
                    "'" + 1 + "')";
                }

                
                var comando = new SqlCommand(insert, conexion);

                conexion.Open();

                // Se ejecuta la inserción y se valida si se realizó.
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

                // Se vacian los campos.
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
