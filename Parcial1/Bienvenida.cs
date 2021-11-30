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

        public static Modelo.PERSONA persona = new Modelo.PERSONA();

        public Bienvenida()
        {
            InitializeComponent();

        }
        // Evento utilizado para cerrar el formulario.
        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }


        #region Persona

        // Evento utilizado para abrir el formulario de persona.
        private void btnIngresarPersona_Click(object sender, EventArgs e)
        {
            // Se muestra la interfaz InformacionPersona y se esconde Bienvenida.

            informacionPersona ob = new informacionPersona();
            ob.Show();
        }
        // Evento que me permite consultar una persona mediante su numero de identificación.
        private void btnConsultarPersona_Click(object sender, EventArgs e)

        {
            string d = Interaction.InputBox("Ingrese el DNI de la personas a buscar");

            List<Persona> personas = new List<Persona> { persona.consultar_persona(d) };

            int contador = 0;

            dgvConsultas.Columns.Clear();
            dgvConsultas.Rows.Clear();

            dgvConsultas.Columns.Add("dni", "dni");
            dgvConsultas.Columns.Add("nombre", "nombre");
            dgvConsultas.Columns.Add("apellido", "apellido");
            dgvConsultas.Columns.Add("genero", "Genero");
            dgvConsultas.Columns.Add("fechaNacimiento", "fechaNacimiento");
            dgvConsultas.Columns.Add("direccion", "direccion");
            dgvConsultas.Columns.Add("ciudad", "Ciudad");

            foreach (Persona per in personas)
            {
                if (per.GetDNI() == 0)
                {

                }
                else
                {
                    dgvConsultas.Rows.Insert(contador, per.GetDNI(),
                    per.GetNombre(),
                    per.GetApellidos(),
                    per.GetGenero(),
                    per.GetfechaNacimiento(),
                    per.GetDireccion(),
                    per.GetCiudad()
                    );
                    ++contador;
                }
            }

            dgvConsultas.Refresh();

        }

        private static Persona consultar_persona(string documento)
        {
            Persona p = persona.consultar_persona(documento);

            return p;

        }

        // Evento limpia el dataGridView.
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            dgvConsultas.DataSource = null;
        }


        // Evento que permite consultar todas las personas activas.
        private void btnConsultarPersonas_Click(object sender, EventArgs e)
        {
            var persona = new Modelo.PERSONA();

            List<Persona> personas = persona.consultar_personas();

            int contador = 0;

            dgvConsultas.Columns.Clear();
            dgvConsultas.Rows.Clear();

            dgvConsultas.Columns.Add("dni", "dni");
            dgvConsultas.Columns.Add("nombre", "nombre");
            dgvConsultas.Columns.Add("apellido", "apellido");
            dgvConsultas.Columns.Add("genero", "Genero");
            dgvConsultas.Columns.Add("fechaNacimiento", "fechaNacimiento");
            dgvConsultas.Columns.Add("direccion", "direccion");
            dgvConsultas.Columns.Add("ciudad", "Ciudad");

            foreach (Persona per in personas)
            {
                if (per.GetDNI() == 0)
                {

                }
                else
                {
                    dgvConsultas.Rows.Insert(contador, per.GetDNI(),
                    per.GetNombre(),
                    per.GetApellidos(),
                    per.GetGenero(),
                    per.GetfechaNacimiento(),
                    per.GetDireccion(),
                    per.GetCiudad()
                    );
                    ++contador;
                }
            }

            dgvConsultas.Refresh();

        }

        // Evento que me permite actualizar los datos de una persona.
        private void btnActualizarPersona_Click(object sender, EventArgs e)
        {

            string dni = Interaction.InputBox("Ingresa el DNI de la persona a actualizar");

            if (dni != "")
            {
                Modelo.PERSONA persona_model = new Modelo.PERSONA();
                Persona persona = persona_model.consultar_persona(dni);
                // Se piden los datos a actualizar.
                string nombre = Interaction.InputBox("Nuevo nombre");
                string apellidos = Interaction.InputBox("Nuevos apellidos");
                string genero = Interaction.InputBox("Nuevo genero");
                string ciudad = Interaction.InputBox("Nueva ciudad");
                string direccion = Interaction.InputBox("Nueva direccion");
                DateTime fecha;
                try
                {
                    fecha = Convert.ToDateTime(Interaction.InputBox("Nueva fecha de nacimiento (AÑO/MES/DIA)"));
                }
                catch (Exception ex)
                {
                    fecha = persona.GetfechaNacimiento();
                }
                //dejar el valor anterior en caso de que el usuario no ingrese los datos
                nombre = string.IsNullOrEmpty(nombre) ? persona.GetNombre() : nombre;
                apellidos = string.IsNullOrEmpty(apellidos) ? persona.GetApellidos() : apellidos;
                genero = string.IsNullOrEmpty(genero) ? persona.GetGenero() : genero;
                ciudad = string.IsNullOrEmpty(ciudad) ? persona.GetCiudad() : ciudad;
                direccion = string.IsNullOrEmpty(direccion) ? persona.GetDireccion() : direccion;

                bool se_actualizo = persona_model.actualizar_persona(dni, nombre, apellidos, ciudad, genero, direccion, fecha);

                if (se_actualizo)
                {
                    MessageBox.Show("Se actualizó correctamente.");
                }
                else
                {
                    MessageBox.Show("Ocurrio un error inesperado.");
                }
            }
            else
            {
                MessageBox.Show("No se ingreso dni");
            }
        }


        // Evento utilizado para eliminar una persona del sistema
        private void btnEliminarPersona_Click(object sender, EventArgs e)
        {


            // Se conecya a la BD.
            //var conexion = new SqlConnection(Properties.Settings.Default.conexion);

            //// Ingreso de DNI a eliminar.
            string dni = Interaction.InputBox("Ingrese el DNI de la persona a eliminar");

            bool se_elimino = persona.eliminar_persona(dni);

            if (se_elimino)
            {
                MessageBox.Show("Se eliminó correctamente la persona solicitada.");
            }
            else
            {
                MessageBox.Show("No se encontro la persona buscada.");
            }

        }
        #endregion
        #region Mascotas
        // Evento utilizado para abrir el formulario de mascota.
        private void btnIngresarMascota_Click(object sender, EventArgs e)
        {

            // Se muestra la interfaz InformacionMascota y se esconde Bienvenida.

            InformacionMascota im = new InformacionMascota();
            this.Hide();
            im.Show();
        }
        private static Mascota consultar_mascota(string documento)
        {
            Mascota mascota = new Mascota();
            SqlConnection conexion = new SqlConnection(Properties.Settings.Default.conexion);
            conexion.Open();
            SqlCommand comando = new SqlCommand("CONSULTAR_MASCOTA", conexion);

            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add(new SqlParameter("@ID", documento));

            SqlDataReader reader = comando.ExecuteReader();
            //Mientras se pueda leer
            while (reader.Read())
            {
                mascota.SetDNIDUEÑO(reader["DNIDUENO"].ToString());
                mascota.SetNombre(reader["NOMBRE"].ToString());
            }
            return mascota;
        }

        // Evento que me permite consultar todas las mascotas activas.
        private void btnConsultarMascotas_Click(object sender, EventArgs e)
        {
            // Se conecta a la BD.
            var conexion = new SqlConnection(Properties.Settings.Default.conexion);

            // Se crea la consulta a realizar.
            var query = "EXEC CONSULTAR_MASCOTAS";

            // Se instancia un objeto SqlCommand con la consulta.
            var comando = new SqlCommand(query, conexion);


            var dataAdapter = new SqlDataAdapter(comando);


            var dataSet = new DataSet();

            // Se le asigna al dataSet el resultado de la consulta.
            dataAdapter.Fill(dataSet, "Mascotas");

            // Se llena el dataGrid con el resultado de la consulta que tiene el DataSet.
            dgvConsultas.DataSource = dataSet.Tables[0];

            conexion.Close();
        }
        // Evento que me permite consultar una mascota mediante un identificador.
        private void btnConsultarMascota_Click(object sender, EventArgs e)
        {
            // Ingreso del ID a buscar.
            string d = Interaction.InputBox("Ingrese el ID de la mascota a buscar");

            // Se conecta a la BD.
            var conexion = new SqlConnection(Properties.Settings.Default.conexion);

            // Se crea la consulta a realizar.
            var query = "EXEC CONSULTAR_MASCOTA " + d;

            // Se instancia un objeto SqlCommand con la consulta.
            var comando = new SqlCommand(query, conexion);

            var dataAdapter = new SqlDataAdapter(comando);

            var dataSet = new DataSet();

            // Se le asigna al dataSet el resultado de la consulta.
            dataAdapter.Fill(dataSet, "Mascotas");

            // Se llena el dataGrid con el resultado de la consulta que tiene el DataSet.
            dgvConsultas.DataSource = dataSet.Tables[0];

            //conexion.Close();

        }
        // Evento creado para eliminar(inactivar) mascota.
        private void btnEliminarMascota_Click(object sender, EventArgs e)
        {
            // Conexión a BD.
            var conexion = new SqlConnection(Properties.Settings.Default.conexion);

            // Ingreso ID a eliminar.
            string dele = Interaction.InputBox("Ingrese el ID de la mascota a eliminar");

            // Creación de consulta.
            var consulta = "EXEC ELIMINAR_MASCOTA " + dele;

            var comando = new SqlCommand(consulta, conexion);


            var dataAdapter = new SqlDataAdapter(comando);

            var dataSet = new DataSet();

            // Se le asigna al dataSet el resultado de la consulta.
            dataAdapter.Fill(dataSet, "Mascotas");

            // Se llena el dataGrid con el resultado de la consulta que tiene el DataSet.
            dgvConsultas.DataSource = dataSet.Tables[0];
        }

        private void btnActualizarMascota_Click(object sender, EventArgs e)
        {
            // Conexión BD.
            var conexion = new SqlConnection(Properties.Settings.Default.conexion);

            // Id mascota a actualizar.
            string dni = Interaction.InputBox("Ingresa el ID de la mascota a actualizar");
            conexion.Open();
            if (dni != "")
            {
                Mascota mascota = consultar_mascota(dni);
                // Datos a actualizar.
                string nombre = Interaction.InputBox("Nuevo nombre");
                string dueño = Interaction.InputBox("Nuevo dueño");

                string consulta;
                //validar que si haya ingresado un valor en el input box
                nombre = string.IsNullOrEmpty(nombre) ? mascota.GetNombre() : nombre;
                dueño = string.IsNullOrEmpty(dueño) ? mascota.GetDNIDUEÑO() : dueño;
                // Se valida si el dniDueño es vacio o nulo.
                if (String.IsNullOrEmpty(dueño) == true)
                {
                    consulta = "EXEC ACTUALIZAR_MASCOTA " + dni + ", '" + nombre + "', NULL";
                }
                else
                {
                    consulta = "EXEC ACTUALIZAR_MASCOTA " + dni + ", '" + nombre + "', '" + dueño + "'";
                }

                var comando = new SqlCommand(consulta, conexion);

                var dataAdapter = new SqlDataAdapter(comando);

                var dataSet = new DataSet();

                // Se le asigna al dataSet el resultado de la consulta.
                dataAdapter.Fill(dataSet, "Mascotas");

                // Se llena el dataGrid con el resultado de la consulta que tiene el DataSet.
                dgvConsultas.DataSource = dataSet.Tables[0];

            }
            else
            {
                MessageBox.Show("No se ingreso dni");
            }
        }

        // Evento que me permite consultar las mascotas por persona.
        private void btnMascotasPersona_Click(object sender, EventArgs e)
        {
            // Conexión BD.
            var conexion = new SqlConnection(Properties.Settings.Default.conexion);

            // Dni de la persona que quiere conocer sus mascotas.
            string dele = Interaction.InputBox("Ingrese el DNI de la persona que quiere conocer sus mascotas");

            // Consulta a realizar.
            var consulta = "EXEC CONSULTAR_MASCOTASPERSONA " + dele;

            var comando = new SqlCommand(consulta, conexion);


            var dataAdapter = new SqlDataAdapter(comando);


            var dataSet = new DataSet();


            dataAdapter.Fill(dataSet, "MascotasPersonas");

            // Se llena el dataGrid con el resultado de la consulta.
            dgvConsultas.DataSource = dataSet.Tables[0];
        }
        #endregion

    }


}