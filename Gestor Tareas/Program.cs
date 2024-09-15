using Spectre.Console;
using System;

class Program
{
    static void Main(string[] args)
    {
        DiasTareas diasTareas = new DiasTareas();
        string filePath = "tareas.json";

        // Cargar tareas desde el archivo
        diasTareas.CargarTareas(filePath);

        while (true)
        {
            // Mostrar el menú y obtener la selección del usuario
            var option = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("[blue]Selecciona una opción:[/]")
                    .PageSize(10)
                    .AddChoices(new[] {
                        "Ver semana completa", "Agregar tarea", "Eliminar tarea", "Salir"
                    }));

            switch (option)
            {
                case "Ver semana completa":
                    diasTareas.MostrarTareasComoTabla();
                    break;
                case "Agregar tarea":
                    Console.Write("Ingresa el día: ");
                    string diaAgregar = Console.ReadLine();
                    Console.Write("Ingresa la tarea: ");
                    string tareaAgregar = Console.ReadLine();
                    diasTareas.AgregarTarea(diaAgregar, tareaAgregar);
                    break;
                case "Eliminar tarea":
                    Eliminar.EliminarTarea(diasTareas);
                    break;
                case "Salir":
                    // Guardar tareas en el archivo antes de salir
                    diasTareas.GuardarTareas(filePath);
                    return;
            }
        }
    }
}


