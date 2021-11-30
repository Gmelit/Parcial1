using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial1
{
    public class Persona
    {
        public int dNI;

        public Persona()
        {
        }

        public int GetDNI()
        {
            return dNI;
        }

        public void SetDNI(int value)
        {
            dNI = value;
        }

        public string nombre;

        public string GetNombre()
        {
            return nombre;
        }

        public void SetNombre(string value)
        {
            nombre = value;
        }

        public string apellidos;

        public string GetApellidos()
        {
            return apellidos;
        }

        public void SetApellidos(string value)
        {
            apellidos = value;
        }

        public string genero;

        public string GetGenero()
        {
            return genero;
        }

        public void SetGenero(string value)
        {
            genero = value;
        }

        public Persona(int dNI, string nombre, string apellidos, string genero, string ciudad, string direccion, byte[] fotoPerfil1, DateTime fechaNacimiento)
        {
            this.dNI = dNI;
            this.nombre = nombre;
            this.apellidos = apellidos;
            this.genero = genero;
            this.ciudad = ciudad;
            this.direccion = direccion;
            this.fotoPerfil1 = fotoPerfil1;
            this.fechaNacimiento = fechaNacimiento;
        }

        public string ciudad;

        public string GetCiudad()
        {
            return ciudad;
        }

        public void SetCiudad(string value)
        {
            ciudad = value;
        }

        public string direccion;

        public string GetDireccion()
        {
            return direccion;
        }

        public void SetDireccion(string value)
        {
            direccion = value;
        }

        public byte[] fotoPerfil1;

        public byte[] GetfotoPerfil()
        {
            return fotoPerfil1;
        }

        public void SetfotoPerfil(byte[] value)
        {
            fotoPerfil1 = value;
        }

        public DateTime fechaNacimiento;

        public DateTime GetfechaNacimiento()
        {
            return fechaNacimiento;
        }

        public void SetfechaNacimiento(DateTime value)
        {
            fechaNacimiento = value;
        }
    }

}
