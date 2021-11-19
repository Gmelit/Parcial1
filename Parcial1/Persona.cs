using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial1
{
    public class Persona
    {
        private int id;
        private string nombre;
        private string apellido;
        private string genero;
        private string dni;
        private string ciudad;
        private string direccion;
        private DateTime fechaNacimiento;
        private Boolean estado;
        private byte[] imagen;
        private Boolean bandera;

        public Persona()
        {
        }

        public Persona(string dni, string nombre1, string apellido, string genero, string ciudad, DateTime fechaNacimiento, string direccion, byte[] imagen = null, bool estado = false)
        {
            Dni = dni;
            Nombre1 = nombre1;
            Apellido = apellido;
            Genero = genero;
            Ciudad = ciudad;
            Direccion = direccion;
            FechaNacimiento = fechaNacimiento;
            Imagen = imagen;
            Estado = estado;
        }

        public string obtener_nombre_completo() { 
            return this.Nombre1 + " " + this.Apellido;
        }
        public string Nombre1 { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Genero { get => genero; set => genero = value; }
        public string Dni { get => dni; set => dni = value; }
        public string Ciudad { get => ciudad; set => ciudad = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public DateTime FechaNacimiento { get => fechaNacimiento; set => fechaNacimiento = value; }
        public byte[] Imagen { get => imagen; set => imagen = value; }
        public bool Estado { get => estado; set => estado = value; }
        public int Id { get => id; set => id = value; }
        public bool Bandera { get => bandera; set => bandera = value; }
    }
}
