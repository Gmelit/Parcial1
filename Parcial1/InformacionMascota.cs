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


            Mascota obMascota = new Mascota();


            obMascota.SetNombre(txtNombre.Text);
            obMascota.SetTipo(cbTipo.GetItemText(cbTipo.SelectedItem));
            obMascota.SetDNIDUEÑO(txtDniDueño.Text);


            // Validación de los datos obligatorios.
            if (string.IsNullOrEmpty(obMascota.GetNombre()) == true || string.IsNullOrEmpty(obMascota.GetTipo()) == true
            )
            {
                MessageBox.Show("Debe completar los campos obligatorios");

            }
            else
            {
                // Conexión BD.
                var conexion = new SqlConnection(Properties.Settings.Default.conexion);

                string insert;

                // Validación y creación de inserción.
                if (string.IsNullOrEmpty(obMascota.GetDNIDUEÑO().ToString()) == true)
                {
                    insert = "EXEC INSERTAR_MASCOTA '" + obMascota.GetNombre() + "', '" + obMascota.GetTipo() + "', NULL";
                }
                else
                {
                    insert = "EXEC INSERTAR_MASCOTA '" + obMascota.GetNombre() + "', '" + obMascota.GetTipo() + "', '" + obMascota.GetDNIDUEÑO() +"'";
                }

                
                var comando = new SqlCommand(insert, conexion);

                conexion.Open();

                // Se ejecuta la inserción y se valida si se realizó.
                var cantidadDeRegistros = comando.ExecuteNonQuery();

                if (cantidadDeRegistros > 0)
                {
                    MessageBox.Show("Mascota ingresada");
                }
                else
                {
                    MessageBox.Show("Mascota no ingresada, hubo algun error");
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
