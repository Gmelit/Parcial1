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
    public partial class informacionPersona : Form
    {

        string img = "";

        public informacionPersona()
        {
            InitializeComponent();
            
        }
        
        //Lista utilizada para con
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
                        img = imagen;
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

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Hide();
            Bienvenida b1 = new Bienvenida();
            b1.Show();
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
            if (string.IsNullOrEmpty(nombre) == true || string.IsNullOrEmpty(apellidos) == true || string.IsNullOrEmpty(dni) == true || string.IsNullOrEmpty(genero) 
                )
            {
                MessageBox.Show("Debe de llenar los campos obligatorios");
            }
            else
            {
                var conexion = new SqlConnection("Data Source = .; Initial Catalog = INFOPERSONA; Integrated Security = true;");

                char deli = '/';
                string[] ap = fecha.Split(deli);
                fecha = ap[2] + "/" + ap[1] + "/" + ap[0];

       
                var insert = "INSERT INTO PERSONA VALUES('" + dni + "' ,'" + nombre + "', '" + apellidos +"'," +
                    "'" + genero + "','" + ciudad + "','" + direccion + "','" + img + "','" + fecha + "','" + 1 + "')";

                var comando = new SqlCommand(insert, conexion);
               
                conexion.Open();

                var cantidadDeRegistros = comando.ExecuteNonQuery();

                if (cantidadDeRegistros > 0)
                {
                    MessageBox.Show("Persona ingresada");
                }
                else
                {
                    MessageBox.Show("Persona no ingresada, hubo algun error");
                }

                conexion.Close();


                //Limpiar los controles
                txtNombre.Text = "";
                txtApellidos.Text = "";
                txtDNI.Text = "";
                cbGenero.SelectedIndex = -1;
                txtDireccion.Text = "";
                cbCiudad.SelectedIndex = -1;
                pbPerfil.Image = null;
                //Setear el valor minimo del control de fecha para limpiarlo en el valueChange
                dtpNacimiento.Value = DateTimePicker.MinimumDateTime;
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

        private void informacionPersona_Load(object sender, EventArgs e)
        {

        }
    }
}
