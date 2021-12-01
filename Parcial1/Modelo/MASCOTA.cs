//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Parcial1.Modelo
{
    using System;
    using System.Collections.Generic;
    
    public partial class MASCOTA
    {
        public long ID { get; set; }
        public string NOMBRE { get; set; }
        public string TIPO { get; set; }
        public Nullable<int> DNIDUEÑO { get; set; }
        public Nullable<short> ESTADO { get; set; }
    
        public virtual PERSONA PERSONA { get; set; }

        public static Proyecto4 baseDeDatos = new Proyecto4();
        public List<Mascota> consultar_mascotas()
        {

            List<Mascota> mascotas = new List<Mascota>();

            var resultado = baseDeDatos.CONSULTAR_MASCOTAS();

            foreach (var mascota in resultado)
            {
                mascotas.Add(new Mascota((int) mascota.ID,
                    mascota.TIPO,
                    mascota.DNIDUEÑO.ToString(),
                    mascota.NOMBRE));
            }

            return mascotas;
        }

        public Persona consultar_mascota(string id)
        {
            int num_doc = 0;
            try
            {
                num_doc = Convert.ToInt32(id);
            }
            catch (Exception ex)
            {
                //Nada
            }
            Persona persona = new Persona();

            var resultado = baseDeDatos.CONSULTAR_PERSONA(num_doc);

            foreach (var item in resultado)
            {
                persona.SetDNI(item.DNI);
                persona.SetNombre(item.NOMBRE);
                persona.SetApellidos(item.APELLIDOS);
                persona.SetCiudad(item.CIUDAD);
                persona.SetDireccion(item.DIRECCION);
                persona.SetGenero(item.GENERO);
                persona.SetfechaNacimiento((DateTime)item.FECHANACIMIENTO);
            }

            return persona;
        }

        public bool insertar_persona(int dni, string nombres, string apellidos, string genero, string ciudad, string direccion, byte[] foto, DateTime fecha)
        {
            // Creamos un objeto de la clase de contexto llamada 'VeterinariaEntities'
            // Representa la conexión con la base de datos

            var resultado = baseDeDatos.CONSULTAR_PERSONA(dni);

            Boolean existe = true;

            foreach (var item in resultado)
            {
                existe = false;
            }
            // se puede hacer parametrico
            baseDeDatos.INSERTAR_PERSONA(dni, nombres, apellidos, genero, ciudad, direccion, foto, fecha);

            return existe;
        }

        public bool actualizar_persona(string dni, string nombre, string apellido, string ciudad, string genero, string direccion, DateTime fecha)
        {
            int num_doc = 0;
            try
            {
                num_doc = Convert.ToInt32(dni);
            }
            catch (Exception ex)
            {
                //Nada
            }

            var resultado = baseDeDatos.CONSULTAR_PERSONA(num_doc);
            Boolean existe = false;
            foreach (var item in resultado)
            {
                existe = true;
            }

            baseDeDatos.ACTUALIZAR_PERSONA(num_doc, nombre, apellido, genero, ciudad, direccion, fecha);

            return existe;
        }

        public bool eliminar_persona(string dni)
        {
            int num_doc = 0;
            try
            {
                num_doc = Convert.ToInt32(dni);
            }
            catch (Exception ex)
            {
                //Nada
            }
            var resultado = baseDeDatos.CONSULTAR_PERSONA(num_doc);
            Boolean existe = false;

            foreach (var item in resultado)
            {
                existe = true;
            }

            //Eliminar
            baseDeDatos.ELIMINAR_PERSONA(num_doc);

            return existe;
        }

    }
}
