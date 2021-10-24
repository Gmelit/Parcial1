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
    public partial class Bienvenida : Form
    {
        public Bienvenida()
        {
            InitializeComponent();
        }

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
            informacionPersonal ip = new informacionPersonal();
            ip.Show();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {

        }

        private void btnConsultarTodo_Click(object sender, EventArgs e)
        {
            
        }
    }
}
