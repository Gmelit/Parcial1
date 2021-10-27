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
using Microsoft.VisualBasic;

namespace Parcial1
{
    public partial class Bienvenida : Form
    {
        public Bienvenida()
        {
            InitializeComponent();

        }
        // Evento utilizado para abrir el formulario de persona.
        private void btnIngresarPersona_Click(object sender, EventArgs e)
        {
            informacionPersona ob = new informacionPersona();
            this.Hide();
            ob.Show();
        }
        // Evento utilizado para cerrar el formulario.
        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
        // Evento utilizado para abrir el formulario de mascota.
        private void btnIngresarMascota_Click(object sender, EventArgs e)
        {
            InformacionMascota im = new InformacionMascota();
            this.Hide();
            im.Show();
        }

        // Evento que me permite consultar una persona mediante su numero de identificación.
        private void btnConsultarPersona_Click(object sender, EventArgs e)
        {
            string d = Interaction.InputBox("Ingrese el DNI de la personas a buscar");

            var conexion = new SqlConnection("Data Source=.;Initial Catalog=INFOPERSONA;Integrated Security=True");


            var query = "SELECT DNI, NOMBRE, APELLIDOS, GENERO, CIUDAD, DIRECCION, FECHANACIMIENTO FROM PERSONA WHERE ESTADO = 1 AND DNI = " + d;


            var comando = new SqlCommand(query, conexion);


            var dataAdapter = new SqlDataAdapter(comando);


            var dataSet = new DataSet();


            dataAdapter.Fill(dataSet, "Personas");


            dgvConsultas.DataSource = dataSet.Tables[0];

            conexion.Close();

        }

        // Evento que me permite consultar una mascota mediante un identificador.
        private void btnConsultarMascota_Click(object sender, EventArgs e)
        {

            string d = Interaction.InputBox("Ingrese el ID de la mascota a buscar");

            var conexion = new SqlConnection("Data Source=.;Initial Catalog=INFOPERSONA;Integrated Security=True");

            var query = "SELECT ID, NOMBRE, TIPO, DNIDUEÑO FROM MASCOTA WHERE ESTADO = 1 AND ID = " + d;

            var comando = new SqlCommand(query, conexion);

            var dataAdapter = new SqlDataAdapter(comando);

            var dataSet = new DataSet();

            dataAdapter.Fill(dataSet, "Mascotas");

            dgvConsultas.DataSource = dataSet.Tables[0];

            conexion.Close();

        }
        // Evento limpia el dataGridView.
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            dgvConsultas.DataSource = null;
        }
        // Evento que permite consultar todas las personas activas.
        private void btnConsultarPersonas_Click(object sender, EventArgs e)
        {

            var conexion = new SqlConnection("Data Source=.;Initial Catalog=INFOPERSONA;Integrated Security=True");


            var query = "SELECT DNI, NOMBRE, APELLIDOS, GENERO, CIUDAD, DIRECCION, FECHANACIMIENTO FROM PERSONA WHERE ESTADO = 1";


            var comando = new SqlCommand(query, conexion);


            var dataAdapter = new SqlDataAdapter(comando);


            var dataSet = new DataSet();


            dataAdapter.Fill(dataSet, "Personas");


            dgvConsultas.DataSource = dataSet.Tables[0];

            conexion.Close();
        }
        // Evento que me permite consultar todas las mascotas activas.
        private void btnConsultarMascotas_Click(object sender, EventArgs e)
        {

            var conexion = new SqlConnection("Data Source=.;Initial Catalog=INFOPERSONA;Integrated Security=True");


            var query = "SELECT ID, NOMBRE, TIPO, DNIDUEÑO FROM MASCOTA WHERE ESTADO = 1";


            var comando = new SqlCommand(query, conexion);


            var dataAdapter = new SqlDataAdapter(comando);


            var dataSet = new DataSet();

            dataAdapter.Fill(dataSet, "Mascotas");


            dgvConsultas.DataSource = dataSet.Tables[0];

            conexion.Close();
        }
        // Evento que me permite actualizar los datos de una persona.
        private void btnActualizarPersona_Click(object sender, EventArgs e)
        {

            var conexion = new SqlConnection("Data Source = .; Initial Catalog = INFOPERSONA; Integrated Security = true;");
            string dni = Interaction.InputBox("Ingresa el DNI de la persona a actualizar");
            conexion.Open();
            string nombre = Interaction.InputBox("Nuevo nombre");
            string apellidos = Interaction.InputBox("Nuevos apellidos");
            string genero = Interaction.InputBox("Nuevo genero");
            string ciudad = Interaction.InputBox("Nueva ciudad");
            string direccion = Interaction.InputBox("Nueva direccion");
            string fecha = Interaction.InputBox("Nueva fecha de nacimiento (AÑO/MES/DIA)");

            string consulta = "UPDATE PERSONA SET NOMBRE = '" + nombre + "', APELLIDOS = '" + apellidos + "'," +
                "GENERO = '" + genero + "', CIUDAD = '" + ciudad + "', DIRECCION = '" + direccion + "'," +
                "FECHANACIMIENTO = '" + fecha + "' WHERE DNI = " + dni;

            var comando = new SqlCommand(consulta, conexion);

            var cantidadDeRegistros = comando.ExecuteNonQuery();

            if (cantidadDeRegistros > 0)
            {
                MessageBox.Show("Persona actualizada");
            }
            else
            {
                MessageBox.Show("No se actualizó la persona, id no encontrado");
            }

            conexion.Close();

        }
        // Evento utilizado para eliminar una persona del sistema
        private void btnEliminarPersona_Click(object sender, EventArgs e)
        {
            var conexion = new SqlConnection("Data Source = .; Initial Catalog = INFOPERSONA; Integrated Security = true;");

            string dele = Interaction.InputBox("Ingrese el DNI de la persona a eliminar");

            var consulta = "UPDATE PERSONA SET ESTADO = 0 WHERE DNI = " + dele;

            string query = "UPDATE MASCOTA SET DNIDUEÑO = NULL WHERE DNIDUEÑO = " + dele;
            var comando = new SqlCommand(consulta, conexion);
            var coman = new SqlCommand(query, conexion);

            conexion.Open();

            var cantidadDeRegistros = comando.ExecuteNonQuery();

            if (cantidadDeRegistros > 0)
            {
                MessageBox.Show("Persona eliminada");
                coman.ExecuteNonQuery();
            }
            else
            {
                MessageBox.Show("No se eliminó la persona");
            }

            conexion.Close();
        }
        // Evento creado para eliminar(inactivar) mascota.
        private void btnEliminarMascota_Click(object sender, EventArgs e)
        {
            var conexion = new SqlConnection("Data Source = .; Initial Catalog = INFOPERSONA; Integrated Security = true;");

            string dele = Interaction.InputBox("Ingrese el ID de la mascota a eliminar");

            var consulta = "UPDATE MASCOTA SET ESTADO = 0 WHERE ID = " + dele;

            var comando = new SqlCommand(consulta, conexion);

            conexion.Open();

            var cantidadDeRegistros = comando.ExecuteNonQuery();

            if (cantidadDeRegistros > 0)
            {
                MessageBox.Show(" Mascota eliminada");
            }
            else
            {
                MessageBox.Show("No se eliminó la mascota");
            }

            conexion.Close();
        }

        private void btnActualizarMascota_Click(object sender, EventArgs e)
        {
            var conexion = new SqlConnection("Data Source = .; Initial Catalog = INFOPERSONA; Integrated Security = true;");
            string dni = Interaction.InputBox("Ingresa el ID de la mascota a actualizar");
            conexion.Open();
            string nombre = Interaction.InputBox("Nuevo nombre");
            string dueño = Interaction.InputBox("Nuevo dueño");

            string consulta;

            if (String.IsNullOrEmpty(dueño) == true)
            {
                consulta = "UPDATE MASCOTA SET NOMBRE = '" + nombre + "',DNIDUEÑO = NULL WHERE ID =" + dni;
            }
            else
            {
                consulta = "UPDATE MASCOTA SET NOMBRE = '" + nombre + "',DNIDUEÑO = '" + dueño + "' WHERE ID =" + dni;
            }


            var comando = new SqlCommand(consulta, conexion);

            try
            {
                var cantidadDeRegistros = comando.ExecuteNonQuery();

                if (cantidadDeRegistros > 0)
                {
                    MessageBox.Show("Mascota actualizada");
                }
                else
                {
                    MessageBox.Show("No se actualizó la mascota, id no encontrado");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Dueño ingresado no existente");
            }

            conexion.Close();
        }
        // Evento que me permite consultar las mascotas por persona.
        private void btnMascotasPersona_Click(object sender, EventArgs e)
        {

            var conexion = new SqlConnection("Data Source = .; Initial Catalog = INFOPERSONA; Integrated Security = true;");

            string dele = Interaction.InputBox("Ingrese el DNI de la persona que quiere conocer sus mascotas");

            var consulta = "SELECT * FROM MASCOTA WHERE DNIDUEÑO = " + dele;

            var comando = new SqlCommand(consulta, conexion);


            var dataAdapter = new SqlDataAdapter(comando);


            var dataSet = new DataSet();


            dataAdapter.Fill(dataSet, "MascotasPersonas");


            dgvConsultas.DataSource = dataSet.Tables[0];
        }
    }

}