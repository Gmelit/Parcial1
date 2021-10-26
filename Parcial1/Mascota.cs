using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial1
{
    public class Mascota
    {
        private int id;
        private int fk_persona;
        private string nombre;
        private string descripcion;
        private int fk_animal;

        public Mascota() { 
        
        }

        public Mascota(int id, int fk_persona, string nombre, string descripcion, int fk_animal)
        {
            Id = id;
            Fk_persona = fk_persona;
            Nombre = nombre;
            Descripcion = descripcion;
            Fk_animal = fk_animal;
        }

        public int Id { get => id; set => id = value; }
        public int Fk_persona { get => fk_persona; set => fk_persona = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public int Fk_animal { get => fk_animal; set => fk_animal = value; }
    }
}
