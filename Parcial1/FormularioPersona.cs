using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
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
            txtApellidos.Text = p.Apellido;
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
                persona = p;
            }
            else
            {
                txtNombre.ReadOnly = true;
                txtApellidos.ReadOnly = true;
                txtDNI.ReadOnly = true;
                btnLimpiar.Visible = false;
                btnLimpiar.Enabled = false;
                consultar_mascotas(p);
                persona = p;
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
                if (persona != null) {
                    persona.Dni = dni;
                    persona.Nombre1 = nombre;
                    persona.Apellido = apellidos;
                    persona.Genero = genero;
                    persona.Ciudad = ciudad;
                    persona.FechaNacimiento = Convert.ToDateTime(fecha);
                    persona.Direccion = direccion;
                    persona.Imagen = foto;

                    actualizar_persona(persona);
                }
                else
                {
                    persona = new Persona(dni, nombre, apellidos, genero, ciudad, Convert.ToDateTime(fecha), direccion, foto);

                    ingresar_persona(persona);

                }
                

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
                        if (mascotaSeleccionada.Id != 0)
                        {
                            mascotaSeleccionada.Bandera = true;
                        }
                        mascotaBindingSource.EndEdit();
                        mascotaBindingSource.ResetBindings(true);
                        btnEditarMascota.Focus();
                    }
                }

            }


        }
        public void ingresar_persona(Persona p)
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

            foreach (Mascota item in mascotaBindingSource)
            {
                item.Fk_persona = id_persona;
                insertar_mascota(item);

            }
            conexion.Close();
            this.Close();
        }
        public void actualizar_persona(Persona p)
        {
            SqlConnection conexion = new SqlConnection(Properties.Settings.Default.ConexionTercer);
            conexion.Open();
            SqlCommand comando = new SqlCommand("sp_actualizar_persona", conexion);

            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add(new SqlParameter("@id", p.Id));
            comando.Parameters.Add(new SqlParameter("@numero_identificacion", p.Dni));
            comando.Parameters.Add(new SqlParameter("@nombre", p.Nombre1));
            comando.Parameters.Add(new SqlParameter("@apellido", p.Apellido));
            comando.Parameters.Add(new SqlParameter("@genero", p.Genero));
            comando.Parameters.Add(new SqlParameter("@ciudad", p.Ciudad));
            comando.Parameters.Add(new SqlParameter("@fecha_nacimiento", p.FechaNacimiento));
            comando.Parameters.Add(new SqlParameter("@direccion", p.Direccion));
            comando.Parameters.Add(new SqlParameter("@foto_perfil", p.Imagen));

            comando.ExecuteNonQuery();
            foreach (Mascota item in mascotaBindingSource)
            {
                if (item.Bandera.Equals(true)) {
                    actualizar_mascota(item);
                } else if (item.Id == 0) {
                    item.Fk_persona = p.Id;
                    insertar_mascota(item);
                }
            }
            conexion.Close();
            this.Close();
        }

        public void actualizar_mascota(Mascota mascota)
        {
            SqlConnection conexion = new SqlConnection(Properties.Settings.Default.ConexionTercer);
            conexion.Open();
            SqlCommand command = new SqlCommand("sp_actualizar_mascota", conexion);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@nombre", mascota.Nombre));
            command.Parameters.Add(new SqlParameter("@descripcion", mascota.Descripcion));
            command.Parameters.Add(new SqlParameter("@fk_animal", mascota.Fk_animal));
            command.Parameters.Add(new SqlParameter("@id", mascota.Id));
            command.ExecuteNonQuery();
            conexion.Close();
        }

        public void insertar_mascota(Mascota mascota) {

            SqlConnection conexion = new SqlConnection(Properties.Settings.Default.ConexionTercer);
            conexion.Open();

            SqlCommand command = new SqlCommand("sp_insertar_mascotas", conexion);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@fk_persona", mascota.Fk_persona));
            command.Parameters.Add(new SqlParameter("@nombre", mascota.Nombre));
            command.Parameters.Add(new SqlParameter("@descripcion", mascota.Descripcion));
            command.Parameters.Add(new SqlParameter("@fk_animal", mascota.Fk_animal));
            command.ExecuteNonQuery();

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
            var imageStream = new MemoryStream(img);
            Image imagen = Image.FromStream(imageStream);
            return imagen;
        }


    }
}
