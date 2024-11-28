using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_INT
{
    public class Turno
    {
        private string nomPac, hora;
        private int dni;
        private bool disponible;

        public Turno(string hora)
        {
           
            this.nomPac = " ";
            this.dni = 0;
            this.hora = hora;
            this.disponible = true;
        }

        public string NomPac
        {
            set { nomPac = value; }
            get { return nomPac; }
        }

        public string Hora
        {
            set { hora = value; }
            get { return hora; }
        }

        public int Dni 
        { 
            set { dni = value; }
            get { return dni; } 
        }  

        public bool Disponible
        {
            set { disponible = value; }
            get { return disponible; }
        }
        
    }
}

