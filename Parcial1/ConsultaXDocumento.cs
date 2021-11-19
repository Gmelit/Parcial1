using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parcial1
{
    public partial class ConsultaXDocumento : Form
    {
        //1 consultar, 
        //2 editar
        //3 eliminar
        public int accion;
        public ConsultaXDocumento()
        {
            InitializeComponent();
        }
        public ConsultaXDocumento(string titulo, int accion)
        {
            InitializeComponent();
            this.lblTitulo.Text = titulo;
            this.accion = accion;
        }
        List<Mascota> listaMascotas;
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string documento = this.tbDocumento.Text;
            FormularioPersona frmP;
            Persona p;
            String mensaje = "";
            if (string.IsNullOrEmpty(documento))
            {
                MessageBox.Show("Todos los campos deben de estar llenos");
            }
            else
            {
                p = consultarPersona(documento);
                switch (accion)
                {
                    case 1:
                        if (p.Dni != null)
                        {
                            frmP = new FormularioPersona(p, accion);
                            frmP.Show();
                        }
                        else
                        {
                            mensaje = "Persona buscada no encontrada";
                        }
                        break;
                    case 2:
                        if (p.Dni != null)
                        {
                            frmP = new FormularioPersona(p, accion);
                            frmP.Show();
                        }
                        else
                        {

                            mensaje = "Persona buscada no encontrada";
                        }
                        break;
                    case 3:
                        eliminarPersona(documento);
                        break;
                    default:
                        break;
                }
                if (mensaje != "")
                {
                    MessageBox.Show(mensaje);
                }
                else
                {
                    this.Close();
                }
            }
        }

        private void eliminarPersona(string documento)
        {
            int respuesta = 0;
            SqlConnection conexion = new SqlConnection(Properties.Settings.Default.ConexionTercer);
            conexion.Open();
            SqlCommand comando = new SqlCommand("sp_eliminar_persona", conexion);

            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add(new SqlParameter("@numero_identificacion", documento));

            SqlDataReader reader = comando.ExecuteReader();


            while (reader.Read())
            {    //Every new row will create a new dictionary that holds the columns
                //reader["numero_identificacion"].ToString();
                respuesta = Convert.ToInt32(reader["respuesta"].ToString());

            }
            string mensaje;
            if (respuesta == 1)
            {
                mensaje = "Persona eliminada correctamente del sistema";
            }
            else if (respuesta == 2)
            {
                mensaje = "Esta persona ya fue eliminada del sistema";
            }
            else
            {
                mensaje = "Persona buscada no fue encontrada";
            }

            MessageBox.Show(mensaje);
        }

        private static Persona consultarPersona(string documento)
        {
            int respuesta = 0;
            SqlConnection conexion = new SqlConnection(Properties.Settings.Default.ConexionTercer);
            conexion.Open();
            SqlCommand comando = new SqlCommand("sp_consultar_persona", conexion);

            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add(new SqlParameter("@numero_identificacion", documento));

            SqlDataReader reader = comando.ExecuteReader();
            Persona persona = new Persona();
            while (reader.Read())
            {    //Every new row will create a new dictionary that holds the columns
                 //reader["numero_identificacion"].ToString();

                persona.Id = Convert.ToInt32(reader["Id"].ToString());
                persona.Dni = reader["numero_identificacion"].ToString();
                persona.Nombre1 = reader["nombre"].ToString();
                persona.Apellido = reader["apellido"].ToString();
                persona.Ciudad = reader["ciudad"].ToString();
                persona.Direccion = reader["direccion"].ToString();
                persona.Genero = reader["genero"].ToString();
                persona.FechaNacimiento = Convert.ToDateTime(reader["fecha_nacimiento"].ToString());
                persona.Imagen = (byte[])reader["foto_perfil"];
                //respuesta = Convert.ToInt32(reader["respuesta"].ToString());

            }

            string mensaje = "";
            if (respuesta == 2)
            {
                mensaje = "Persona buscada se encuentra inactiva";
            }
            else if (respuesta == 3)
            {
                mensaje = "Persona no encontrada";
            }
            if (respuesta == 2 || respuesta == 3)
            {
                MessageBox.Show(mensaje);
            }

            return persona;
        }
    }
}
