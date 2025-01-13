using System;
using System.Collections.Generic;

namespace ClinicaTurnos
{
    // Clase Paciente para representar los datos de un paciente
    public class Paciente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Especialidad { get; set; }
        public DateTime FechaTurno { get; set; }

        public override string ToString()
        {
            return $"ID: {Id}, Nombre: {Nombre} {Apellido}, Especialidad: {Especialidad}, Fecha del turno: {FechaTurno:dd/MM/yyyy HH:mm}";
        }
    }

    // Clase Agenda para manejar la agenda de turnos
    public class Agenda
    {
        private List<Paciente> turnos = new List<Paciente>();

        // Agregar un turno
        public void AgregarTurno(Paciente paciente)
        {
            turnos.Add(paciente);
        }

        // Visualizar todos los turnos
        public void VisualizarTurnos()
        {
            if (turnos.Count == 0)
            {
                Console.WriteLine("No hay turnos agendados.");
            }
            else
            {
                Console.WriteLine("Turnos agendados:");
                foreach (var turno in turnos)
                {
                    Console.WriteLine(turno);
                }
            }
        }

        // Consultar un turno por ID
        public void ConsultarTurnoPorId(int id)
        {
            var turno = turnos.Find(p => p.Id == id);
            if (turno != null)
            {
                Console.WriteLine("Turno encontrado:");
                Console.WriteLine(turno);
            }
            else
            {
                Console.WriteLine("No se encontró un turno con ese ID.");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Agenda agenda = new Agenda();
            bool salir = false;

            while (!salir)
            {
                Console.WriteLine("\n--- Menú de opciones ---");
                Console.WriteLine("1. Registrar paciente");
                Console.WriteLine("2. Visualizar todos los turnos");
                Console.WriteLine("3. Consultar turno por ID");
                Console.WriteLine("4. Salir");
                Console.WriteLine("Elija una opción:");

                if (int.TryParse(Console.ReadLine(), out int opcion))
                {
                    switch (opcion)
                    {
                        case 1: // Registrar paciente
                            Console.WriteLine("Ingrese el ID del paciente:");
                            int id = int.Parse(Console.ReadLine());

                            Console.WriteLine("Ingrese el nombre del paciente:");
                            string nombre = Console.ReadLine();

                            Console.WriteLine("Ingrese el apellido del paciente:");
                            string apellido = Console.ReadLine();

                            Console.WriteLine("Ingrese la especialidad del turno:");
                            string especialidad = Console.ReadLine();

                            Console.WriteLine("Ingrese la fecha y hora del turno (formato: dd/MM/yyyy HH:mm):");
                            if (DateTime.TryParse(Console.ReadLine(), out DateTime fechaTurno))
                            {
                                agenda.AgregarTurno(new Paciente
                                {
                                    Id = id,
                                    Nombre = nombre,
                                    Apellido = apellido,
                                    Especialidad = especialidad,
                                    FechaTurno = fechaTurno
                                });
                                Console.WriteLine("Turno registrado exitosamente.");
                            }
                            else
                            {
                                Console.WriteLine("Fecha inválida. Intente nuevamente.");
                            }
                            break;

                        case 2: // Visualizar todos los turnos
                            agenda.VisualizarTurnos();
                            break;

                        case 3: // Consultar turno por ID
                            Console.WriteLine("Ingrese el ID del turno:");
                            if (int.TryParse(Console.ReadLine(), out int consultaId))
                            {
                                agenda.ConsultarTurnoPorId(consultaId);
                            }
                            else
                            {
                                Console.WriteLine("ID inválido. Intente nuevamente.");
                            }
                            break;

                        case 4: // Salir
                            salir = true;
                            Console.WriteLine("Saliendo del sistema...");
                            break;

                        default:
                            Console.WriteLine("Opción no válida. Intente nuevamente.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Por favor, ingrese un número válido.");
                }
            }
        }
    }
}
