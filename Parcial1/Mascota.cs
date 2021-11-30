using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial1
{
    public class Mascota
    {

        public Mascota()
        {

        }

        public Mascota(int iD, string tipo, string dNIDUEÑO, string nombre)
        {
            this.iD = iD;
            this.tipo = tipo;
            this.dNIDUEÑO = dNIDUEÑO;
            this.nombre = nombre;
        }

        private int iD = 0;

        public int GetID()
        {
            return iD;
        }

        public void SetID(int value)
        {
            iD = value;
        }

        private string tipo = "";

        public string GetTipo()
        {
            return tipo;
        }

        public void SetTipo(string value)
        {
            tipo = value;
        }

        private String dNIDUEÑO = "";

        public String GetDNIDUEÑO()
        {
            return dNIDUEÑO;
        }

        public void SetDNIDUEÑO(String value)
        {
            dNIDUEÑO = value;
        }

        private string nombre = "";

        public string GetNombre()
        {
            return nombre;
        }

        public void SetNombre(string value)
        {
            nombre = value;
        }
    }


}
