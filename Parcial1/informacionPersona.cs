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
using System.IO;

namespace Parcial1
{
    public partial class informacionPersona : Form
    {

        string img = "";
        public static Modelo.PERSONA persona = new Modelo.PERSONA();
        Persona obPersona = new Persona();

        public informacionPersona()
        {
            InitializeComponent();
            
        }
        
        //Lista utilizada para validar la extensión de la imagen
        public readonly List<string> extencionImagen = new List<string> { "JPG", "JPE", "BMP", "GIF", "PNG" };
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
                    else {
                        MessageBox.Show("Archivo seleccionado no valido. \nformatos de imagen permitidos (JPG, JPE, BMP, GIF, PNG)");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error inesperado.\npor favor vuelva a intentarlo");
            }
        }
        // Evento utilizado para salir del formulario actual
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Hide();
            Bienvenida b1 = new Bienvenida();
            b1.Show();
        }

        //Evento utilizado para guardar la información ingresada en los controles
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Extracción de la información que tenga los controles.
            
            obPersona.SetNombre(txtNombre.Text);
            obPersona.SetApellidos(txtApellidos.Text);
            obPersona.SetGenero(cbGenero.GetItemText(cbGenero.SelectedItem));
            obPersona.SetCiudad(cbCiudad.GetItemText(cbCiudad.SelectedItem));
            obPersona.SetDNI(int.Parse(txtDNI.Text));
            obPersona.SetDireccion(txtDireccion.Text);
            obPersona.SetfechaNacimiento(Convert.ToDateTime(dtpNacimiento.Text));
            obPersona.SetfotoPerfil(ImagenAByte(pbPerfil.Image));

            // Validación de los campos obligatorios.
            if (string.IsNullOrEmpty(obPersona.GetNombre()) == true || string.IsNullOrEmpty(obPersona.GetApellidos()) == true || string.IsNullOrEmpty(obPersona.GetDNI().ToString()) == true || string.IsNullOrEmpty(obPersona.GetGenero()) 
                )
            {
                MessageBox.Show("Debe de llenar los campos obligatorios");
            }
            else
            {
                //// Conexión DB.
                //var conexion = new SqlConnection(Properties.Settings.Default.conexion);

                //// Creación de la inserción.

                //var comando = new SqlCommand("INSERTAR_PERSONA", conexion);
                //comando.CommandType = CommandType.StoredProcedure;
                //comando.Parameters.Add(new SqlParameter("@DNI", obPersona.GetDNI()));
                //comando.Parameters.Add(new SqlParameter("@NOM", obPersona.GetNombre()));
                //comando.Parameters.Add(new SqlParameter("@APE", obPersona.GetApellidos()));
                //comando.Parameters.Add(new SqlParameter("@GEN", obPersona.GetGenero()));
                //comando.Parameters.Add(new SqlParameter("@CIU", obPersona.GetCiudad()));
                //comando.Parameters.Add(new SqlParameter("@DIR", obPersona.GetDireccion()));
                //comando.Parameters.Add(new SqlParameter("@FOT", obPersona.GetfotoPerfil()));
                //comando.Parameters.Add(new SqlParameter("@FECH", obPersona.GetfechaNacimiento()));

                //conexion.Open();

                bool se_inserto = persona.insertar_persona(obPersona.GetDNI(), obPersona.GetNombre(), obPersona.GetApellidos(), obPersona.GetGenero(), obPersona.GetCiudad(), obPersona.GetDireccion(), obPersona.GetfotoPerfil(), obPersona.GetfechaNacimiento());
                //// Se ejecuta la inserción y se valida si se realizó.
                //var cantidadDeRegistros = comando.ExecuteNonQuery();

                if (se_inserto)
                {
                    MessageBox.Show("Persona ingresada");
                }
                else
                {
                    MessageBox.Show("Persona no ingresada, hubo algun error");
                }
                this.Close();
                //conexion.Close();


                //Limpiar los controles
                //txtNombre.Text = "";
                //txtApellidos.Text = "";
                //txtDNI.Text = "";
                //cbGenero.SelectedIndex = -1;
                //txtDireccion.Text = "";
                //cbCiudad.SelectedIndex = -1;
                //pbPerfil.Image = null;
                ////Setear el valor minimo del control de fecha para limpiarlo en el valueChange
                //dtpNacimiento.Value = DateTimePicker.MinimumDateTime;
                //validar si aun hay personas por agregar
             
                    
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

        //Convierte una imagen a un arreglo de bytes
        public static byte[] ImagenAByte(Image img)
        {
            ImageConverter converter = new ImageConverter();
            return (byte[])converter.ConvertTo(img, typeof(byte[]));
        }
        //Convierte un arreglo de bytes a Imagen
        public static Image byteAImagen(byte[] img)
        {
            var imageStream = new MemoryStream(img);
            Image imagen = Image.FromStream(imageStream);
            return imagen;
        }
    }
}
