using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace KDM_Lab03
{
    class Program
    {
        public static void Main()
        {
            bool isStopped = false;

            while (!isStopped)
            {
                Program program = new Program();

                switch (program.Hello())
                {
                    case 0:
                        isStopped = true;
                        break;
                    case 1:
                        Task01.FirstTask();
                        break;
                    case 2:
                        Task02.SecondTask();
                        break;
                    case 5:
                        Task05.FifthTask();
                        break;
                    case 6:
                        Task06.SixthTask();
                        break;

                    default:

                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("\nSorry, but we don't have this task. Please, try again.\n");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        break;
                }
            }
        }
        int Hello()
        {
            int taskNumber = -1;
            string s = "-1";

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Please, Enter the number of task, you want to check or press \"S\" to stop process: ");
            s = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Gray;

            if (s == "s" || s == "S" || s == "Stop")
            {
                taskNumber = 0;
            }
            else
            {
                try
                {
                    taskNumber = Convert.ToInt32(s);
                }
                catch (FormatException)
                {

                }
            }

            return taskNumber;
        }
    }
}