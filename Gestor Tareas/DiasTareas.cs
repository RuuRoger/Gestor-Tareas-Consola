using Spectre.Console;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class DiasTareas
{
    private Dictionary<string, List<string>> tareasPorDia;

    public DiasTareas()
    {
        tareasPorDia = new Dictionary<string, List<string>>()
        {
            { "Lunes", new List<string>() },
            { "Martes", new List<string>() },
            { "Miercoles", new List<string>() },
            { "Jueves", new List<string>() },
            { "Viernes", new List<string>() },
            { "Sabado", new List<string>() },
            { "Domingo", new List<string>() }
        };
    }

    public void AgregarTarea(string dia, string tarea)
    {
        if (tareasPorDia.ContainsKey(dia))
        {
            tareasPorDia[dia].Add(tarea);
        }
        else
        {
            Console.WriteLine("Día no válido.");
        }
    }

    public void EliminarTarea(string dia, string tarea)
    {
        if (tareasPorDia.ContainsKey(dia))
        {
            if (tareasPorDia[dia].Remove(tarea))
            {
                Console.WriteLine($"Tarea '{tarea}' eliminada del día {dia}.");
            }
            else
            {
                Console.WriteLine($"Tarea '{tarea}' no encontrada en el día {dia}.");
            }
        }
        else
        {
            Console.WriteLine("Día no válido.");
        }
    }

    public void MostrarTareasComoTabla()
    {
        var table = new Table();

        // Añadir las cabeceras de los días de la semana
        table.AddColumn("Día");
        table.AddColumn("Tareas");

        // Añadir las filas con las tareas
        foreach (var dia in tareasPorDia.Keys)
        {
            var tareas = string.Join("\n", tareasPorDia[dia]);
            table.AddRow(dia, tareas);
        }

        // Mostrar la tabla en la consola
        AnsiConsole.Write(table);
    }

    public void GuardarTareas(string filePath)
    {
        var json = JsonSerializer.Serialize(tareasPorDia);
        File.WriteAllText(filePath, json);
    }

    public void CargarTareas(string filePath)
    {
        if (File.Exists(filePath))
        {
            var json = File.ReadAllText(filePath);
            tareasPorDia = JsonSerializer.Deserialize<Dictionary<string, List<string>>>(json);
        }
    }
}

