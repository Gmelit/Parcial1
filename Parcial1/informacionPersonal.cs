using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parcial1
{
    public partial class informacionPersonal : Form
    {

        string[] informacion;
        string[] nombres;
        string[] imagenes;
        int cantidadP = 0;

        public informacionPersonal()
        {
            InitializeComponent();
            txtReg.Text = cantidadP.ToString();
        }
        public informacionPersonal(int num)
        {
            InitializeComponent();
            informacion = new string[num];
            nombres = new string[num];
            imagenes = new string[num];
            txtReg.Enabled = false;
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
                        imagenes[cantidadP] = imagen;
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
                informacion[cantidadP] = "\n" + "Nombre completo: " + nombre + " " + apellidos + "\n" +
                    "Genero: " + genero + "\n" + "DNI: " + dni + "\n" + "Ciudad: " + ciudad + "\n" +
                    "Dirección: " + direccion + "\n" + "Fecha de nacimiento: " + fecha;

                nombres[cantidadP] = nombre + " " + apellidos + " " + dni;
                
                cantidadP += 1;
                txtReg.Text = cantidadP.ToString();

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
                if (cantidadP == informacion.Length)

                {
                    MessageBox.Show("Se han agregado todas las personas");
                    this.Hide();
                    consultaInformacion ci = new consultaInformacion(informacion, nombres, imagenes);
                    ci.Show();

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
    }
}
