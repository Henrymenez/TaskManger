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

        public static void StartAProcess()
        {
            Process? process = null;

            try
            {
                Console.WriteLine("You want to start a task?\nInput file name");
                string? taskName = Console.ReadLine();
                Console.WriteLine("\n What Thread Would you like to start on this task");
                string? threadName = Console.ReadLine();
                ProcessStartInfo processStartInfo = new ProcessStartInfo(taskName, threadName);
                processStartInfo.WindowStyle = ProcessWindowStyle.Maximized;
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

            /*while (true)
            {
                Console.WriteLine("\nDo you want to kill this process \nType 1: Yes\nType 2: No");
                string options = Console.ReadLine();

                switch (options)
                {
                    case "1":
                        try
                        {
                            foreach (var task in Process.GetProcessesByName(_fileName))
                            {
                                task.Kill(true);
                                Console.WriteLine($"You have successfully stopped " +
                                    $"{task.ProcessName}");
                            }
                            Utility.Headers();
                        }
                        catch (InvalidOperationException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        catch (FormatException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case "2":
                        Console.Clear();
                        Console.WriteLine("\nReturning to Menu...");
                        Utility.Headers();
                        break;
                    default:
                        Console.WriteLine("Invalid input...");
                        break;
                }
            }*/
        }

        }
    }
