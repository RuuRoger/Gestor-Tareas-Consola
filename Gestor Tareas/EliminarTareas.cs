using System;

public static class Eliminar
{
    public static void EliminarTarea(DiasTareas diasTareas)
    {
        Console.Write("Ingresa el día: ");
        string dia = Console.ReadLine();
        Console.Write("Ingresa la tarea a eliminar: ");
        string tarea = Console.ReadLine();
        diasTareas.EliminarTarea(dia, tarea);
    }
}

