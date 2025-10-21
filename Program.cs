using System;
using System.Threading;
using System.Collections.Generic;

class Program {
    static void Main(string[] args) {
        while (Variables.InTodoApp) {

            Thread.Sleep(300);
            Console.Clear();
            Methods.PrintAllTasks();

            Console.WriteLine("Write the operation to do\n 1:Add task 2:Remove task 3:Exit"); 
            Variables.choose = Console.ReadLine();

            switch (Variables.choose) {

                case "1": 
                    Methods.AddTask();
                    break;
                case "2":
                    Methods.RemoveTask();
                    break;
                case "3":
                    Variables.InTodoApp = false;
                    break;
                default:
                    Console.WriteLine("Invalid input!");
                    break;
            }

        }
    }

}

public class Variables {
    public static List<string> ToDo = new List<string>(); 
    public static string choose;
    public static bool InTodoApp = true;
}

public class Methods {
    public static void AddTask() {
        Console.WriteLine("Write a task: "); 
        string task = Console.ReadLine();
        if (task != null) {
            Variables.ToDo.Add(task);
        } else {
            Console.WriteLine("Invalid task");
        }

        int index = Variables.ToDo.IndexOf(task);

    }

    public static void RemoveTask() {


        Console.WriteLine("Write the operation to do 1.Remove all tasks 2.Remove a specific task");
        string choose = Console.ReadLine();

        if (choose == "1") {

            Variables.ToDo.Clear();

        } else if (choose == "2") {
            Console.WriteLine("Write the id of the task");
            string input = Console.ReadLine();
            if (int.TryParse(input, out int inputId)) {
                if (inputId >= 0 && inputId < Variables.ToDo.Count) {
                    Variables.ToDo.RemoveAt(inputId);
                    Console.WriteLine("Task removed");
                } else {
                    Console.WriteLine("Id out of range");
                }
            } else {
                Console.WriteLine("Invalid input not a number");
            }


        } else {
            Console.WriteLine("Invalid choose");
        }
    }
    public static void PrintAllTasks() {
        for (int i = 0; i < Variables.ToDo.Count; i++) {
            Console.WriteLine($"[{i}] | {Variables.ToDo[i]}"); 
        }

    }
}


