using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_INT
{
    public class Paciente
    {
        string nombre, obraSocial, diagnostico;
        int dni, numeroAfiliado;

        public Paciente(string nom, int doc, string obraSoc, int numAfil)
        {
            this.nombre = nom;
            this.dni = doc;
            this.obraSocial = obraSoc;
            this.numeroAfiliado = numAfil;
            this.diagnostico = "";
        }

        public string Nombre
        {
            set { nombre = value; }
            get { return nombre; }
        }

        public int Dni
        {
            set { dni = value; }
            get { return dni; }
        }

        public string ObraSocial
        {
            set { obraSocial = value; }
            get { return obraSocial; }
        }

        public int NumeroAfiliado
        {
            set { numeroAfiliado = value; }
            get { return numeroAfiliado; }
        }

        public string Diagnostico
        {
            set { diagnostico = value; }
            get { return diagnostico; }
        }
    }
}
