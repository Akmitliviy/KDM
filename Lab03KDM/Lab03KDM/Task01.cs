using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KDM_Lab03
{
    static class Task01
    {
        public static void FirstTask()
        {
            //Console.ForegroundColor = ConsoleColor.Blue;
            //Console.WriteLine("Please, Enter graph: ");
            //Console.ForegroundColor = ConsoleColor.Gray;
            //int[,] graph = GetMatrix();
            int[,] graph =
            {
                {0, 7, 2, 1, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 2, 0, 1, 0, 0, 0, 0},
                {0, 0, 0, 0, 7, 4, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 3, 5, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 4, 5, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 6, 0, 2, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 3, 3, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 7},
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4},
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4},
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
            };
            //int[,] graph =
            //{
            //    {0,  1,   6,  5, 14},
            //    {1,  0,   3,  4,  6},
            //    {6,  3,   0, 10, 12},
            //    {5,  4,  10,  0,  6},
            //    {14, 6,  12,  6,  0}
            //};

            int[,] edges = FindMOD(graph);
            ShowMatrix(edges);

        }
        static int[,] GetMatrix()
        {
            int size;

            while (true)
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("Please, enter matrix size NxN:\nN = ");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    size = Convert.ToInt32(Console.ReadLine());
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
            Console.WriteLine();

            char[] l = new char[size];
            for (int i = 0; i < l.Length; i++)
            {
                l[i] = (char)(97 + i);
            }

            int[,] myMatrix = new int[size, size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (j <= i) continue;

                    while (true)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("Edge between \"{0}\" and \"{1}\": ", l[i], l[j]);
                        try
                        {
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            myMatrix[i, j] = Convert.ToInt32(Console.ReadLine());
                            Console.ForegroundColor = ConsoleColor.Gray;

                            myMatrix[j, i] = myMatrix[i, j];
                            if (myMatrix[i, j] == 0 || myMatrix[i, j] == 1)
                                break;
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("\nPlease, enter only \"1\" or \"0\"\n");
                                Console.ForegroundColor = ConsoleColor.Gray;
                            }
                        }
                        catch (FormatException)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nPlease, only digits\n");
                            Console.ForegroundColor = ConsoleColor.Gray;
                        }

                    }
                }
            }

            return myMatrix;
        }
        static int[,] FindMOD(int[,] graph)
        {
            int min = int.MaxValue;
            int iIn = 0, jIn = 0;
            int indexK1 = -1, indexK2 = -1;
            int counter = 0;
            int value = 0;
            int[,] edges = new int[graph.GetLength(0) - 1, 2];
            int[,] vertices = new int[graph.GetLength(0), graph.GetLength(0)];
            int[] verticesIndexes = new int[graph.GetLength(0)];

            for (int i = 0; i < graph.GetLength(0); i++)
                for (int j = 0; j < graph.GetLength(0); j++)
                {
                    vertices[i, j] = -1;
                    if (j < 2 && i < graph.GetLength(0) - 1)
                        edges[i, j] = -1;
                }

            for (int s = 0; s < graph.GetLength(0) - 1; s++)
            {

                for (int i = 0; i < graph.GetLength(0); i++)
                    for (int j = 0; j < graph.GetLength(0); j++)
                        if (j > i && graph[i, j] > 0 && graph[i, j] < min)
                        {
                            min = graph[i, j];
                            iIn = i;
                            jIn = j;
                        }


                for (int i = 0; i < graph.GetLength(0); i++)
                {
                    for (int j = 0; j < graph.GetLength(0); j++)
                    {
                        if (vertices[i, j] == iIn || vertices[i, j] == jIn)
                            counter++;
                    }

                    if (counter >= 2)
                        break;
                    else if (counter == 1 && indexK1 > -1)
                        indexK2 = i;
                    else if (counter == 1)
                        indexK1 = i;

                    counter = 0;
                }

                if (counter < 2)
                {
                    edges[s, 0] = iIn;
                    edges[s, 1] = jIn;
                    value += graph[iIn, jIn];

                    if (indexK1 == -1)
                    {
                        for (int l = 0; l < graph.GetLength(0); l++)
                        {
                            if (verticesIndexes[l] == 0)
                            {
                                vertices[l, iIn] = iIn;
                                vertices[l, jIn] = jIn;
                                verticesIndexes[l] = 1;
                                break;
                            }

                        }
                    }
                    else if (indexK1 > -1 && indexK2 == -1)
                    {
                        vertices[indexK1, iIn] = iIn;
                        vertices[indexK1, jIn] = jIn;
                    }
                    else if (indexK1 > -1 && indexK2 > -1)
                    {
                        for (int l = 0; l < graph.GetLength(0); l++)
                        {
                            if (vertices[indexK2, l] != -1)
                                vertices[indexK1, l] = vertices[indexK2, l];
                        }
                    }
                }
                else
                    --s;

                counter = 0;
                indexK1 = -1;
                indexK2 = -1;
                graph[iIn, jIn] = int.MaxValue;
                min = int.MaxValue;
            }
            Console.WriteLine(value);
            return edges;
        }
        static void ShowMatrix(int[,] matrix)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkYellow;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                Console.Write("{");
                for (int j = 0; j < 2; j++)
                {
                    Console.Write((char)(97 + matrix[i, j]));
                    if(j + 1 < 2)
                        Console.Write("    ");
                }
                Console.Write("}\t");
            }
            Console.WriteLine("\n\nEdges: {0}\nVertices: {1}\n", matrix.GetLength(0), matrix.GetLength(0) + 1);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
