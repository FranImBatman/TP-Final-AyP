using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_INT
{
    public class Medico
    {
        private string nombreMedico;    
        private ArrayList listaPacientes = new ArrayList();
        private ArrayList listaTurnos = new ArrayList();
        

        public Medico(string nomMed)
        {
            this.nombreMedico = nomMed;
            

        }

        public string NombreMedico
        {
            set { nombreMedico = value; }
            get { return nombreMedico; }
        }

       

        //1 Pacientes
        public ArrayList ListaPacientes
        {
            get { return listaPacientes; }
        }
        //1 Turnos
        public ArrayList ListaTurnos
        {
            get { return listaTurnos; }
        }
     

        //2 Pacientes
        public void agregarPaciente(Paciente x)
        {
            listaPacientes.Add(x);
        }
        //3 Pacientes
        public void eliminarPaciente(Paciente k)
        {
            listaPacientes.Remove(k);
        }
        //4 Pacientes
        public int cantPacientes()
        {
            return listaPacientes.Count;
        }
        //5 Pacientes
        public bool existePaciente(Paciente P)
        {
            return listaPacientes.Contains(P);
        }

        //6 Pacientes
        public Paciente recuperarPaciente(int indice)
        {
            return (Paciente)listaPacientes[indice];
        }

        //2 Turnos

        public void agregarTurno(Turno x)
        {
            listaTurnos.Add(x);
        }

        //3 Turnos

        public void eliminarTurno(Turno k)
        {
            listaTurnos.Remove(k);
        }

        //4 Turnos

        public int cantTurnos()
        {
            return listaTurnos.Count;
        }

        //5 Turnos

        public bool existeTurno(Turno T)
        {
            return listaTurnos.Contains(T);
        }


        //6 Turnos

        public Turno recuperarTurno(int indice)
        {
            return (Turno)listaTurnos[indice];
        }
    }
}
