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
    public partial class consultaInformacion : Form
    {
        //arreglos que utilizaremos para almacenar la info
        string[] informacion;
        string[] nombres;
        string[] imagenes;

        public consultaInformacion()
        {
            InitializeComponent();
        }
        //recibir la info previamente almacenada
        public consultaInformacion(string[] info, string[] nom, string[] img)
        {
            InitializeComponent();
            informacion = new string[info.Length];
            nombres = new string[info.Length];
            imagenes = new string[info.Length];
            
            informacion = info;
            nombres = nom;
            imagenes = img;
            
            foreach (string a in nombres) 
            {
                cbPersonas.Items.Add(a);
            }

        }
        //consultar la persona seleccionada
        private void btnConsultar_Click(object sender, EventArgs e)
        {
            string nombre = cbPersonas.GetItemText(cbPersonas.SelectedItem);
            int aux = 0;

            if(nombre == "")
            {
                MessageBox.Show("Seleccione un nombre");
            }
            else
            {
                aux = cbPersonas.SelectedIndex;

                rtxtbInfo.Text = informacion[aux];

                pbPerfil.Image = Image.FromFile(imagenes[aux]);

            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
            System.Windows.Forms.Application.Exit();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            rtxtbInfo.Text = "Información personal: ";
            cbPersonas.Text = "";
            pbPerfil.Image = null;
            
        }

    }
}
