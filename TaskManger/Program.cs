using System.Diagnostics;

namespace TaskManger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Task Manger";
        start: Console.WriteLine("What would you like to do \n 1. Check all runing Process" +
              "\n 2. Start Process \n 3. Stop a process \n 4. Start Thread" +
              "\n 5.Check if a thread isLive or Background " +
              "\n 6. Exit");
            string? option = Console.ReadLine();
            switch (option)
            {
                case "1":
                    Console.Clear();
                    TaskManger.GetAllRunningProcess();
                    goto start;
                case "2":
                    Console.Clear();
                    TaskManger.StartAProcess();
                    goto start;
                case "3":
                    Console.Clear();
                    TaskManger.EndAProcess();
                    goto start;
                case "4":
                    Threads.StartThread();
                    goto start;
                case "5":
                    Threads.ThreadsInAProcess();
                    goto start;
                case "6":
                    Console.WriteLine("Thank you bye");
                    Environment.Exit(0);
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine($"{option} is an invalid Option, please Select a valid option");
                    goto start;
            }
        }
    }
}