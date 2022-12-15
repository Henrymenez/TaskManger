using System.Diagnostics;

namespace TaskManger
{
    internal class Threads : TaskManger
    {
        public static void ThreadsInAProcess()
        {
            GetAllRunningProcess();
            var runningProcesses = from proc in Process.GetProcesses()
                                   select proc.Id;
        Start: Console.WriteLine("Enter Id number of the Process you want to check");
            try
            {
                int procId = Convert.ToInt32(Console.ReadLine());
                if (runningProcesses.Contains(procId))
                {
                    Process proc = Process.GetProcessById(procId);
                    Console.WriteLine($"Threads for => {proc.ProcessName}");
                    ProcessThreadCollection TheThread = proc.Threads;
                    foreach (ProcessThread thread in TheThread)
                    {
                        string info = $"Thread ID: {thread.Id} " +
                            $"\t Start Time: {thread.StartTime.ToShortTimeString()}\t" +
                            $"Priority: {thread.PriorityLevel}";
                        Console.Clear();
                        Console.WriteLine(info);
                    }
                    Console.WriteLine("check if thread is alive {1} or is Background {2}");
                    string? check = Console.ReadLine();
                    switch (check)
                    {
                        case "1":
                            CheckIsAlive();
                            break;
                        case "2":
                            CheckIsBackground();
                            break;
                        default:
                            goto Start;
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine($"{procId} is an invalid Id");
                    GetAllRunningProcess();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                goto Start;
            }
        }

        public static void StartThread()
        {
            Console.WriteLine("----------StartThread--------------");
            Console.WriteLine("Do you want {1} or {2} threads?");
            string threadCount = Console.ReadLine();
            Test(threadCount);

            static void Test(string input)
            {
                if (input == "1")
                {
                    PrintNumbers();
                }
                else
                {
                    ThreadStart threadStart = new ThreadStart(PrintNumbers);
                    Thread backGroundThread = new Thread(threadStart);
                    backGroundThread.Name = "Secondary";
                    backGroundThread.Start();
                   
                }
            }

            static void PrintNumbers()
            {
                Console.WriteLine($"{Thread.CurrentThread.Name} is running PrintNumbers");
                Console.WriteLine("Your numbers: ");
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine(i);
                    Thread.Sleep(2000);
                }
                Console.WriteLine();
            }
        }
        public static void CheckIsAlive()
        {
            Console.WriteLine("Check if thread is Alive \n Enter Id  of the Thread you want to check ");
            int option = Convert.ToInt32(Console.ReadLine());
            Thread thread;
            thread = Thread.CurrentThread;
            Console.WriteLine($"Thread {option} is alive : {thread.IsAlive}");
        }
        public static void CheckIsBackground()
        {
            Console.WriteLine("Check if thread is Background \n Enter Id  of the Thread you want to check ");
            int option = Convert.ToInt32(Console.ReadLine());
            Thread thread;
            thread = Thread.CurrentThread;
            Console.WriteLine($"Thread {option} is background : {thread.IsBackground}");
        }

    }
}
