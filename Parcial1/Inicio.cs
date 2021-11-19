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
    public partial class Inicio : Form
    {
        public Inicio()
        {
            InitializeComponent();
        }
        public List<Persona> personas = new List<Persona>();
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        //Enviar la cantidad de personas a ingresar
        private void btnEnviar_Click(object sender, EventArgs e)
        {
            //try { 
            //    int numPersonas = Int32.Parse(txtPersonas.Text);
            //    this.Hide();
            //    informacionPersonal ip = new informacionPersonal(numPersonas);
            //    ip.Show();
            //}
            //catch (Exception ex) {
            //    MessageBox.Show("Numero no valido.");
            //    txtPersonas.Text = "";
            //};
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            FormularioPersona ip = new FormularioPersona();
            ip.Show();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            ConsultaXDocumento c = new ConsultaXDocumento("Consultar por documento",1);
            c.Show();
        }

        private void btnConsultarTodo_Click(object sender, EventArgs e)
        {
            SqlConnection conexion = new SqlConnection(Properties.Settings.Default.ConexionTercer);
            conexion.Open();
            SqlCommand comando = new SqlCommand("sp_consultar_personas_activas", conexion);

            comando.CommandType = CommandType.StoredProcedure;

            SqlDataReader reader = comando.ExecuteReader();
            personas.Clear();

            while (reader.Read())
            {    

                personas.Add(new Persona(
                    reader["numero_identificacion"].ToString(),
                    reader["nombre"].ToString(),
                    reader["apellido"].ToString(),
                    reader["genero"].ToString(),
                    reader["ciudad"].ToString(),
                    Convert.ToDateTime(reader["fecha_nacimiento"].ToString()),
                    reader["direccion"].ToString(),
                    null,
                    Convert.ToBoolean(reader["estado"]))
                    );

            }
            int contador = 0;

            gridPersonas.Rows.Clear();
            gridPersonas.DataSource = null;
            foreach (Persona persona in personas)
            {

                gridPersonas.Rows.Insert(contador,
                persona.Dni,
                persona.Nombre1,
                persona.Apellido,
                persona.FechaNacimiento,
                persona.Direccion,
                persona.Ciudad,
                persona.Estado
                );
                ++contador;
            }

            gridPersonas.Refresh();
            conexion.Close();

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            ConsultaXDocumento c = new ConsultaXDocumento("Editar por documento",2);
            c.Show();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            ConsultaXDocumento c = new ConsultaXDocumento("Eliminar por documento",3);
            c.Show();
        }
    }
}
