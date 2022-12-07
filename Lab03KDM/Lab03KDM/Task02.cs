using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KDM_Lab03
{
    static class Task02
    {
        public static void SecondTask()
        {
            int vNum;
            int badCounter = 0;
            int EdgesIndex = 0;
            while (true)
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("\nPlease, enter number of vertices: ");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    vNum = Convert.ToInt32(Console.ReadLine());
                    Console.ForegroundColor = ConsoleColor.Gray;

                    break;
                }
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nPlease, enter numbers only!\n");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
            }

            int[] v = new int[vNum];
            int[] p = new int[vNum - 2];
            //int[] p = { 2, 4, 5, 6, 4, 3, 3, 2, 5, 6 };
            int[,] edges = new int[vNum - 1, 2];

            Console.WriteLine();
            for(int i = 0; i < vNum; i++)
            {
                v[i] = i + 1;

                if (i < vNum - 2)
                {

                    while (true)
                    {
                        try
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write("\nPlease, enter {0} element of sequence: ", i + 1);
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            p[i] = Convert.ToInt32(Console.ReadLine());
                            Console.ForegroundColor = ConsoleColor.Gray;

                            break;
                        }
                        catch (FormatException)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nPlease, enter numbers only!\n");
                            Console.ForegroundColor = ConsoleColor.Gray;
                        }
                    }
                }
            }

            while (vNum - 2 != 0)
            {
                for (int i = 0; i < v.Length; i++)
                {
                    for (int j = 0; j < p.Length; j++)
                    {
                        if (v[i] == p[j])
                        {
                            badCounter++;
                            break;
                        }
                    }
                    if (badCounter == 0)
                    {
                        edges[EdgesIndex, 0] = v[i];
                        edges[EdgesIndex, 1] = p[0];
                        EdgesIndex++;

                        v = MatchArray(v, i);
                        p = MatchArray(p, 0);
                        vNum--;
                        break;
                    }
                    badCounter = 0;
                }
            }
            edges[EdgesIndex, 0] = v[0];
            edges[EdgesIndex, 1] = v[1];
            ShowMatrix(edges);
        }

        static int[] MatchArray(int[] arr, int index)
        {
            int[] tempArr = new int [arr.Length - 1];

            for (int i = 0; i < index; i++)
                tempArr[i] = arr[i];

            for(int i = index; i < tempArr.Length; i++)
                tempArr [i] = arr [i + 1];

            return tempArr;
        }
        static void ShowMatrix(int[,] matrix)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkYellow;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    Console.Write(matrix[i, j] + "    ");
                }
                Console.WriteLine("\n");
            }
            Console.WriteLine("Number of edges is: {0}\nNumber of vertix is: {1}\n", matrix.GetLength(0), matrix.GetLength(0) + 1);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
