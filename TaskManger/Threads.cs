using System.Diagnostics;

namespace TaskManger
{
    internal class Threads : TaskManger
    {
        public static void CheckingThread()
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
                        Console.WriteLine(info);
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
    }
}
