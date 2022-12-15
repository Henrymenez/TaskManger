using System.Data;
using System.Diagnostics;

namespace TaskManger
{
    public class TaskManger
    {
        //running process
        public static void GetAllRunningProcess()
        {
            var runningProcess = from proc in Process.GetProcesses()
                                 orderby proc.Id
                                 select proc;

            foreach (var p in runningProcess)
            {
                string info = $"Pid: {p.Id} \t Name: {p.ProcessName}";
                Console.WriteLine(info);
                Console.WriteLine("----------------------------------------------");
            }


        }

        //start a process
        public static void StartAProcess()
        {
            Process? process = null;
            try
            {
                Console.WriteLine("You want to start a task?\nInput file name");
                string? taskName = Console.ReadLine();
                Console.WriteLine("What Thread Would you like to start on this task(optional)");
                string? threadName = Console.ReadLine();
                ProcessStartInfo processStartInfo = new ProcessStartInfo(taskName, threadName);
                processStartInfo.WindowStyle = ProcessWindowStyle.Normal;
                processStartInfo.Verb = "Open";
                processStartInfo.UseShellExecute = true;
                process = Process.Start(processStartInfo);
                Console.WriteLine("Task Started");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                StartAProcess();
            }
        }

        //end a process
        public static void EndAProcess()
        {
            Console.WriteLine("Enter name of the task you want to  terminate");
          string? option =  Console.ReadLine();
            try
            {
                foreach (var p in Process.GetProcessesByName(option))
                {
                    p.Kill(true);
                }
                Console.WriteLine("Process have been terminated");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        }
    }
