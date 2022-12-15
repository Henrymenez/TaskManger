using System.Diagnostics;

namespace TaskManger
{
    internal class Program
    {
        public static void getProcessByItsID()
        {
            Process theProc = null;
            try
            {
                theProc = Process.GetProcessById(21204);
                Console.WriteLine($"Process name: {theProc?.ProcessName}" +
                    $" Proc Id: {theProc.Id}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void getProcessAndItsThread()
        {
            Process theProc = null;
            try
            {
                theProc = Process.GetProcessById(21204);
                Console.WriteLine($"Process name: {theProc?.ProcessName}" +
                    $" Proc Id: {theProc.Id}");
                Console.WriteLine("Here are the threads");

                ProcessThreadCollection threadCollection = theProc.Threads;
                foreach (ProcessThread thread in threadCollection)
                {
                    string info = $"Thread Id: {thread.Id} \t Start Time: {thread.StartTime.ToShortTimeString()} \t Priority: {thread.PriorityLevel}";
                    Console.WriteLine(info);
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void getProcessAndItsModules()
        {
            Process theProc = null;
            try
            {
                theProc = Process.GetProcessById(21204);
                Console.WriteLine($"Process name: {theProc?.ProcessName}" +
                    $" Proc Id: {theProc.Id}");
                Console.WriteLine("Here are the threads");

                ProcessModuleCollection threadCollection = theProc.Modules;
                foreach (ProcessModule thread in threadCollection)
                {
                    string info = $"Module Name: {thread.ModuleName} \t Memory Size: {thread.ModuleMemorySize} \t Site: {thread.Site}";
                    Console.WriteLine(info);
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void startAndStopProcess()
        {
            Process proc = null;
            try
            {
                proc = Process.Start("C:\\Program Files\\Google\\Chrome\\Application\\chrome.exe", "www.google.com");
                Console.WriteLine(proc?.ProcessName);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.Write("--> Hit enter to kill {0}...",
                                        proc.ProcessName);
            Console.ReadLine();
            // Kill all of the msedge.exe processes.
            try
            {
                foreach (var p in Process.GetProcessesByName("chrome"))
                {
                    p.Kill(true);
                }
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        static void Main(string[] args)
        {
            Console.Title = "Task Manger";
        start: Console.WriteLine("What would you like to do \n 1. Check all runing Process" +
              "\n 2. Start Process \n 3. Stop a process \n 4.Check if a thread isLive or Background " +
              "\n 5. Exit");
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
                    Threads.CheckingThread();
                    goto start;
                case "5":
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