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
    public partial class FormularioMascota : Form
    {
        //mascota
        public Mascota mascotaInfo { get; set; }
        

        public FormularioMascota()
        {
            InitializeComponent();


            
        }

        private void FormularioMascota_Load(object sender, EventArgs e)
        {
            Dictionary<int, string> dropDown = new Dictionary<int, string>();

            SqlConnection conexion = new SqlConnection(Properties.Settings.Default.ConexionTercer);
            conexion.Open();
            SqlCommand comando = new SqlCommand("sp_consultar_maestro_animales", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = comando.ExecuteReader();
            while (reader.Read())
            {
                dropDown.Add(Convert.ToInt32(reader["Id"].ToString()), reader["Nombre"].ToString());
            }
            conexion.Close();
            cbTipo.DataSource = new BindingSource(dropDown, null);
            cbTipo.DisplayMember = "Value";
            cbTipo.ValueMember = "Key";

            //Setear los campos en caso de edicion
            tbNombre.Text = mascotaInfo.Nombre;
            tbDecripcion.Text = mascotaInfo.Descripcion;

            int id_mascota = mascotaInfo.Fk_animal;
            if (id_mascota != 0) {
            
                var v = dropDown.Where(item => item.Key == id_mascota).ToList();
                if (v.Count >= 0)
                {
                cbTipo.SelectedItem = v[0];
                }
            }

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            
            mascotaInfo.Nombre = tbNombre.Text;
            mascotaInfo.Descripcion = tbDecripcion.Text;
            mascotaInfo.Fk_animal = ((KeyValuePair<int, string>)cbTipo.SelectedItem).Key;
        }

    }
}
