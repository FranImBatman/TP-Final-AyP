using System;
using System.Collections;
using TP_INT;

namespace TP
{
    class Program
    {
        public static void Main(string[] args)
        {
            Medico m1 = new Medico("Daniel Pires");
            Turno t1 = new Turno("08:00");
            Turno t2 = new Turno("08:30");
            Turno t3 = new Turno("09:00");
            Turno t4 = new Turno("09:30");
            Turno t5 = new Turno("10:00");
            Turno t6 = new Turno("10:30");
            Turno t7 = new Turno("11:00");
            Turno t8 = new Turno("11:30");
            Turno t9 = new Turno("12:00");
            m1.agregarTurno(t1);
            m1.agregarTurno(t2);
            m1.agregarTurno(t3);
            m1.agregarTurno(t4);
            m1.agregarTurno(t5);
            m1.agregarTurno(t6);
            m1.agregarTurno(t7);
            m1.agregarTurno(t8);
            m1.agregarTurno(t9);
            Paciente p1 = new Paciente("Gonzalo Caravajal", 6744, "Osde", 4545);
            Paciente p2 = new Paciente("Mauro Bardin", 9044, "Osde", 4545);
            Paciente p3 = new Paciente("Martin Banegas", 7244, "Particular", 0);
            Paciente p4 = new Paciente("Franco Giordano", 4246, "Anccor Salud", 4545);
            Paciente p5 = new Paciente("Luciano Escobar", 4944, "Osecac", 4545);
            m1.agregarPaciente(p1);
            m1.agregarPaciente(p2);
            m1.agregarPaciente(p3);
            m1.agregarPaciente(p4);
            m1.agregarPaciente(p5);
            Menu(m1);

            

            Console.ReadKey(true);
        }
        public static void Menu(Medico m1)
        {
        	Console.Clear();        	
        	Console.WriteLine("MENU PRINCIPAL");
        	Console.WriteLine("--------------");
        	Console.WriteLine("1) Dar Turno");//excepcion Si no hay turnos disponibles (“horarios no disponibles, llamar próximo día de atencion”) 
        	Console.WriteLine("2) Actualizar Diagnostico de un paciente");
        	Console.WriteLine("3) Cancelar un turno dado");
        	Console.WriteLine("4) Listado de turnos dados");
        	Console.WriteLine("5) Listado de obras sociales de pacientes(sin repeticion)");
        	Console.WriteLine("6) Agregar paciente");
        	Console.WriteLine("7) Eliminar paciente");
        	Console.WriteLine("8) Listado de pacientes");
			Console.WriteLine("9) Salir");
            Console.WriteLine("Ingrese una opcion: ");

            int opcion = verificarEnteroYVacio();

            opcionesMenuPrincipal(m1, opcion);
           
            //turno existe("Franco", "DNI", "Hora", "Bool")
            
        }
        public static void opcionesMenuPrincipal(Medico m1, int opc)
        {
            

            switch (opc)
            {
                case 1://("1) Dar Turno")
                    Console.WriteLine("Pacientes");
                    verPacientes(m1);
                    Console.WriteLine("Elija un paciente: ");
                    int selec = int.Parse(Console.ReadLine());
                    asignarTurno(m1, selec);
                    Console.ReadKey();
                    Console.Clear();
                    Menu(m1);

                    break;

                case 2://("2) Actualizar Diagnostico de un paciente");
                    Console.WriteLine("Pacientes");
                    Console.WriteLine("---------");
                    verPacientes(m1);
                    Console.WriteLine("Elija un paciente: ");
                    int option = int.Parse(Console.ReadLine());
                    Console.WriteLine("Ingrese el diagnostico para el paciente:");
                    string diag = Console.ReadLine();
                    actualizarDiagnostico(m1, option, diag);
                    verDiagnostico(m1, option);
                    Console.ReadKey();
                    Console.Clear();
                    Menu(m1);
                    break;

                case 3://("3) Cancelar un turno dado");
                    Console.WriteLine("Pacientes");
                    Console.WriteLine("---------");
                    verTurnosDados(turnosDados(m1.ListaTurnos));
                    Console.WriteLine("Elija un paciente: ");
                    int pacOp = int.Parse(Console.ReadLine());
                    cancelarTurno(turnosDados(m1.ListaTurnos), m1, pacOp);
                    Console.ReadKey();
                    Console.Clear();
                    Menu(m1);
                    break;

                case 4://("4) Listado de turnos dados");
                    verTurnosDados(turnosDados(m1.ListaTurnos));
                    Console.ReadKey();
                    Console.Clear();
                    Menu(m1);
                    break;

                case 5://("5) Listado de obras sociales de pacientes(sin repeticion)");
                    verObrasSociales(m1);
                    Console.ReadKey();
                    Console.Clear();
                    Menu(m1);
                    break;
                case 6://("6) Agregar paciente");                      
                    cargarPaciente(m1);
                    Console.Clear();
                    Menu(m1);
                    break;

                case 7://("7) Eliminar paciente");
                    Console.WriteLine("Pacientes");
                    Console.WriteLine("---------");
                    verPacientes(m1);
                    Console.WriteLine("Elija un paciente para dar de baja: ");
                    int pacElegido = int.Parse(Console.ReadLine());
                    eliminarUnPaciente(m1, pacElegido);
                    Console.ReadKey();
                    Console.Clear();
                    Menu(m1);
                    break;

                case 8://("8) Listado de pacientes");
                    Console.WriteLine("Pacientes");
                    Console.WriteLine("---------");
                    listarPacientes(m1);
                    Console.ReadKey();
                    Console.Clear();
                    Menu(m1);
                    break;
                case 9:
                    salir();
                    
                    break;

                default:
                    
                    break;




            }
            
           
        }

        public static int verificarEnteroYVacio()
        {
            try
            {
                int entero = int.Parse(Console.ReadLine());
                return entero;
            }
            catch (Exception)
            {
                escribirRojo("Dato incorrecto");
                return verificarEnteroYVacio();
            }
        }

        public static void salir()
        {
            Console.Clear();
            Console.WriteLine("El programa se ejecuto correctamente.");
            return;
        }







        //(1) DAR TURNO
        public static void asignarTurno(Medico x, int opc)
        {
            
            
                if(!HayTurno(x))
                {
                    Console.WriteLine("No hay turno");
                }
            
           
            else
            {
                int contador = 1;
                foreach (Turno m in x.ListaTurnos)
                {
                    if (!m.Disponible)
                    {
                        escribirRojo(contador++ + " " + " " + m.NomPac + " / " + m.Hora);
                    }
                    else
                    {
                        escribirVerde(contador++ + " " + " " + m.NomPac + " / " + m.Hora);
                    }
                }

                foreach (Paciente P in x.ListaPacientes)
                {
                    if (P.Dni == retornarPaciente(x, opc).Dni)
                    {
                        Console.WriteLine("Ingrese el turno deseado");
                        int opcion = int.Parse(Console.ReadLine());
                        if (HayTurnoOpcion(x, opcion))
                        {
                            int posicion = opcion - 1;
                            Turno turno = (Turno)x.recuperarTurno(posicion);
                            turno.Dni = P.Dni;
                            turno.NomPac = P.Nombre;
                            turno.Disponible = false;
                            Console.WriteLine("Turno asignado con exito.");
                        }
                        else
                        {
                            Console.WriteLine("El turno seleccionado no esta disponibe");
                        }
                    }
                }
            }
            
            
        }


        public static bool HayTurno(Medico x) // devuelve true si hay algun turno disponible o false si no hay ningun turno
        {


            foreach (Turno m in x.ListaTurnos)
            {
                if (m.Disponible)
                {
                    return true;
                }
            }
            return false;

        }  
           
       
        public static bool HayTurnoOpcion(Medico x, int opcion)
        {
            int posicion = opcion - 1;
            Turno turno = (Turno)x.recuperarTurno(posicion);
            if (turno.Disponible)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        
        
        
        
        
        
//(2) ACTUALIZAR DIAGNOSTICO DE PACIENTE
       	 	public static void verPacientes(Medico x)
	        {
	            int cont = 1;
	            foreach (Paciente p in x.ListaPacientes)
	            {
	                Console.WriteLine(cont++ + " " + " " + p.Nombre);
	            }
	        }
       	 	
	        public static void actualizarDiagnostico(Medico x, int opc, string diag)
	        {
	            retornarPaciente(x, opc).Diagnostico = diag;
	        }
	         
	        public static void verDiagnostico(Medico x, int opc)
	        {
	            foreach(Paciente p in x.ListaPacientes)
	            {
	                Console.WriteLine(p.Nombre + " / " + p.Diagnostico);
	            }
	        }
	        public static Paciente retornarPaciente(Medico x, int op)
		    {
		            int pos = op - 1;
		            Paciente p = (Paciente)x.recuperarPaciente(pos);
		            return p;
		    }
	        
	        
        
        
        
        
        
//(3) CANCELAR UN TURNO DADO	    
        public static void cancelarTurno(ArrayList list, Medico x, int opc)
        {
            foreach(Turno t in x.ListaTurnos)
            {
                if (((Turno)list[opc-1]).Dni== t.Dni)
                {
                    t.NomPac = "";
                    t.Dni = 0;
                    t.Disponible = true;
                }
            }
           

        }
        
        
        
             
//(4) LISTADO DE TURNOS DADOS
        public static void verTurnosDados(ArrayList turnos)
        {
            int cont = 1;
            foreach (Turno t in turnos)
            {
                Console.WriteLine(cont++ + " " + " " + t.NomPac + " / " + t.Hora);
            }
        }
        public static ArrayList turnosDados(ArrayList lista)
        {
            ArrayList tDados = new ArrayList();
            foreach(Turno t in lista)
            {
                if (t.Dni>0)
                {
                    tDados.Add(t);
                }
            }
            return tDados;
        }







        //(5) LISTADO DE OBRAS SOCIALES DE PACIENTES (sin repeticion)
        public static void verObrasSociales(Medico x)
        {
            ArrayList lista = AcomodaLista(x.ListaPacientes);
            foreach (string ObraSocia in lista)
            {
                Console.WriteLine(ObraSocia);
            }
        }

        public static ArrayList AcomodaLista(ArrayList lista)
        {
            ArrayList ListaAcomodada = new ArrayList();
            foreach (Paciente p in lista)
            {
                if (!ListaAcomodada.Contains(p.ObraSocial))
                {
                    ListaAcomodada.Add(p.ObraSocial);
                }
            }
            return ListaAcomodada;
        }






        //(6) AGREGAR PACIENTE
        public static void cargarPaciente(Medico x)
        {
        	Console.WriteLine("AGREGAR PACIENTE");
        	Console.WriteLine("----------------");
        	Console.WriteLine("");
            Console.WriteLine("Ingrese el Nombre y Apellido del paciente: ");
            Console.WriteLine("(Si no quiere cargar mas pacientes ingrese N)"); 
            string nombre = Console.ReadLine();

            while (nombre != "N")
            {
                Console.Write("Ingrese el DNI: ");
                int dni = int.Parse(Console.ReadLine());
                Console.Write("Ingrese Obra Social(Escriba 'Particular' si no posee): ");
                string obraSocial = Console.ReadLine();
                Console.Write("Ingrese N° de Afiliado (Escriba '0' si no posee): ");
                int numAfil = int.Parse(Console.ReadLine());
                Paciente P = new Paciente(nombre, dni, obraSocial, numAfil);
                x.agregarPaciente(P);

                Console.Write("Ingrese el Nombre y Apellido del paciente: ");
                nombre = Console.ReadLine();
            }    
        }
        
        
        
        
        
//(7) ELIMINAR PACIENTE        
		public static void eliminarUnPaciente(Medico x, int opc)
        {
            int pos = opc - 1;
            foreach (Turno t in x.ListaTurnos)
            {
                if (t.Dni == x.recuperarPaciente(pos).Dni)
                {
                    t.NomPac = "";
                    t.Dni = 0;
                    t.Disponible = true;

                }
            }
            x.eliminarPaciente(x.recuperarPaciente(pos));
            
        }
       		

			
        	
       
        
        
//(8) LISTA DE PACIENTE     
			public static void listarPacientes(Medico x)
			{
				foreach(Paciente i in x.ListaPacientes)
				{
					Console.WriteLine("Nombre: {0} (Dni: {1})",i.Nombre, i.Dni, i);
				}
				
			}
        
        
        
////////////////////////////////////////////////////////////////////////
/// COLORES
        
          public static void escribirRojo(string texto)
        {

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(texto);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public static void escribirVerde(string texto)
        {

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(texto);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        
        
    }


    public class NoHayTurno : Exception
    {
        
    }
}
