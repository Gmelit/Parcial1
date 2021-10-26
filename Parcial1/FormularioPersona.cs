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
    public partial class FormularioPersona : Form
    {

        public Persona persona;

        public FormularioPersona()
        {
            InitializeComponent();
        }
        public FormularioPersona(Persona p, int accion)
        {
            InitializeComponent();

            txtNombre.Text = p.Nombre1;
            txtApellidos.Text = p.Nombre1;
            cbGenero.SelectedItem = p.Genero;
            txtDNI.Text = p.Dni;
            cbCiudad.SelectedItem = p.Ciudad;
            txtDireccion.Text = p.Direccion;
            dtpNacimiento.Text = p.FechaNacimiento.ToString();
            if (p.Imagen != null)
            {
                pbPerfil.Image = byteAImagen(p.Imagen);
            }
            if (accion == 1)
            {
                txtNombre.ReadOnly = true;
                txtApellidos.ReadOnly = true;
                cbGenero.Enabled = false;
                txtDNI.ReadOnly = true;
                cbCiudad.Enabled = false;
                txtDireccion.ReadOnly = true;
                dtpNacimiento.Enabled = false;
                btnAgregarMascota.Visible = false;
                btnAgregarMascota.Enabled = false;
                btnCargar.Enabled = false;
                btnCargar.Visible = false;
                btnEditarMascota.Visible = false;
                btnEditarMascota.Enabled = false;
                btnLimpiar.Visible = false;
                btnLimpiar.Enabled = false;
                btnGuardar.Visible = false;
                btnGuardar.Enabled = false;
                consultar_mascotas(p);
            }
            else
            {
                txtNombre.ReadOnly = true;
                txtApellidos.ReadOnly = true;
                txtDNI.ReadOnly = true;
                btnLimpiar.Visible = false;
                btnLimpiar.Enabled = false;
            }
        }
        //Lista utilizada para con
        public readonly List<string> extencionImagen = new List<string> { "JPG", "JPE", "BMP", "GIF", "PNG" };
        //Lista de mascotas
        List<Mascota> mascotas;
        //Evento utilizado para subir una imagen
        private void btnCargar_Click(object sender, EventArgs e)
        {
            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {

                    string imagen = openFileDialog1.FileName;
                    //validar la extención
                    if (extencionImagen.Contains(imagen.Split('.').Last().ToUpper()) == true)
                    {
                        pbPerfil.Image = Image.FromFile(imagen);
                    }
                    else
                    {
                        MessageBox.Show("Archivo seleccionado no valido. \nformatos de imagen permitidos (JPG, JPE, BMP, GIF, PNG)");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error inesperado.\npor favor vuelva a intentarlo");
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        //Evento utilizado para guardar la información ingresada en los controles
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            string apellidos = txtApellidos.Text;
            string genero = cbGenero.GetItemText(cbGenero.SelectedItem);
            string dni = txtDNI.Text;
            string ciudad = cbCiudad.GetItemText(cbCiudad.SelectedItem);
            string direccion = txtDireccion.Text;
            string fecha = dtpNacimiento.Text;
            //
            if (string.IsNullOrEmpty(nombre) == true || string.IsNullOrEmpty(apellidos) == true || string.IsNullOrEmpty(dni) == true || string.IsNullOrEmpty(genero) == true || string.IsNullOrEmpty(ciudad) == true
                || string.IsNullOrEmpty(direccion) == true)
            {
                MessageBox.Show("Todos los campos deben de estar llenos");
            }
            else
            {
                byte[] foto = ImagenAByte(pbPerfil.Image);
                persona = new Persona(dni, nombre, apellidos, genero, ciudad, Convert.ToDateTime(fecha), direccion, foto);

                ingresarPersona(persona);

            }
        }

        private void fechaNacimiento_ValueChanged(object sender, EventArgs e)
        {
            if (dtpNacimiento.Value == DateTimePicker.MinimumDateTime)
            {
                dtpNacimiento.Value = DateTime.Now;
                dtpNacimiento.Format = DateTimePickerFormat.Custom;
                dtpNacimiento.CustomFormat = " ";
            }
            else
            {
                dtpNacimiento.Format = DateTimePickerFormat.Short;
            }
        }

        private void btnAgregarMascota_Click(object sender, EventArgs e)
        {
            using (FormularioMascota formMascota = new FormularioMascota() { mascotaInfo = new Mascota() })
            {
                if (formMascota.ShowDialog() == DialogResult.OK)
                {
                    mascotaBindingSource.Add(formMascota.mascotaInfo);
                }
            }
        }

        private void btnEditarMascota_Click(object sender, EventArgs e)
        {
            Mascota mascotaSeleccionada = mascotaBindingSource.Current as Mascota;

            if (mascotaSeleccionada != null)
            {
                using (FormularioMascota formMascota = new FormularioMascota() { mascotaInfo = mascotaSeleccionada })
                {
                    if (formMascota.ShowDialog() == DialogResult.OK)
                    {
                        mascotaBindingSource.EndEdit();
                        btnEditarMascota.Focus();
                    }
                }

            }


        }
        public void ingresarPersona(Persona p)
        {

            SqlConnection conexion = new SqlConnection(Properties.Settings.Default.ConexionTercer);
            conexion.Open();
            SqlCommand comando = new SqlCommand("sp_registrar_persona", conexion);

            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add(new SqlParameter("@NumeroIdentificacion", p.Dni));
            comando.Parameters.Add(new SqlParameter("@Nombre", p.Nombre1));
            comando.Parameters.Add(new SqlParameter("@Apellido", p.Apellido));
            comando.Parameters.Add(new SqlParameter("@Genero", p.Genero));
            comando.Parameters.Add(new SqlParameter("@ciudad", p.Ciudad));
            comando.Parameters.Add(new SqlParameter("@FechaNacimiento", p.FechaNacimiento));
            comando.Parameters.Add(new SqlParameter("@direccion", p.Direccion));
            comando.Parameters.Add(new SqlParameter("@FotoPerfil", p.Imagen));

            SqlDataReader reader = comando.ExecuteReader();
            int id_persona = 0;
            while (reader.Read())
            {
                id_persona = Convert.ToInt32(reader["Id"].ToString());
            }

            string query = "insert into mascota([FK_persona],[nombre],[descripcion],[FK_animal]) VALUES ";
            foreach (Mascota item in mascotaBindingSource)
            {
                query += "("+id_persona+","+"'"+item.Nombre+"'," + "'"+item.Descripcion+"',"+item.Fk_animal+"),";

            }
            query = query.Remove( query.Length - 1);

            conexion.Close();

            insertar_mascota(query);

            this.Close();
        }


        public void insertar_mascota(string query_mascota) {
            SqlConnection conexion = new SqlConnection(Properties.Settings.Default.ConexionTercer);
            conexion.Open();
            SqlCommand command = new SqlCommand(query_mascota, conexion);

            command.ExecuteReader();

            conexion.Close();
        }
        public void consultar_mascotas(Persona p)
        {
            mascotas = new List<Mascota>();
            SqlConnection conexion = new SqlConnection(Properties.Settings.Default.ConexionTercer);
            conexion.Open();
            SqlCommand comando = new SqlCommand("consultar_mascotas_x_persona", conexion);

            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add(new SqlParameter("@id_persona", p.Id));
            
            SqlDataReader reader = comando.ExecuteReader();
            while (reader.Read())
            {
                Mascota m = new Mascota(
                    Convert.ToInt32(reader["Id"].ToString()),
                    Convert.ToInt32(reader["FK_persona"].ToString()),
                    reader["Nombre"].ToString(),
                    reader["descripcion"].ToString(),
                    Convert.ToInt32(reader["FK_animal"].ToString())
                    );

                mascotas.Add(m);
                mascotaBindingSource.Add(m);
            }
            conexion.Close();

        }


        public static byte[] ImagenAByte(Image img)
        {
            ImageConverter converter = new ImageConverter();
            return (byte[])converter.ConvertTo(img, typeof(byte[]));
        }

        public static Image byteAImagen(byte[] img)
        {
            ImageConverter converter = new ImageConverter();
            return (Image)converter.ConvertTo(img, typeof(Image));
        }


    }
}
