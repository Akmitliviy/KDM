using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace KDM_Lab03
{
    static class Task05
    {
        public static void FifthTask()
        {
            //Console.ForegroundColor = ConsoleColor.Blue;
            //Console.WriteLine("Please, Enter matrix: ");
            //Console.ForegroundColor = ConsoleColor.Gray;
            //int[,] R1 = GetMatrix();

            int[,] R1 =
            {
                {1,  1,  1,  1},
                {1,  1,  0,  0},
                {1,  0,  1,  0},
                {1,  0,  0,  1}
            };

            Console.WriteLine("Marix:\n");
            ShowMatrix(R1);

            int isReflective = IsReflective(R1);
            int isSymmetrical = IsSymmetrical(R1);
            int isTransitive = IsTransitive(R1);
            switch (isReflective)
            {
                case 0:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Relation is nor reflective neither irreflective");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;

                case -1:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Relation is irreflective");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;

                case 1:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Relation is reflective");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;

                default:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Something went completely wrong :(");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;
            }

            switch (isSymmetrical)
            {
                case 0:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Relation is nor symmetrical neither antisymmetrical");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;

                case -1:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Relation is antisymmetrical");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;

                case 1:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Relation is symmetrical");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;
                case -2:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Relation is asymmetrical");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;

                default:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Something went completely wrong :(");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;
            }

            switch (isTransitive)
            {
                case 0:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Relation is nor transitive neither antitransitive");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;

                case -1:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Relation is antitransitive");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;

                case 1:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Relation is transitive");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;

                default:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Something went completely wrong :(");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;

            }

            if (isReflective == 1 && isSymmetrical == 1 && isTransitive == 1)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nThis is equivalence relation");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            else if (isSymmetrical < -1 && isTransitive == 1)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nThis is order relation");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            else if (isReflective == 1 && isSymmetrical == 1 && isTransitive == -1)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nThis is tolerance relation");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
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
        static void ShowMatrix(int[,] matrix)
        {
            int edges = 0, vertices = matrix.GetLength(0); 
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkYellow;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    if(matrix[i, j] != 0)
                        edges++;
                    Console.Write(matrix[i, j] + "    ");
                }
                Console.WriteLine("\n");
            }
            Console.WriteLine("Number of edges is: {0}\nNumber of vertix is: {1}\n", edges, vertices);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        static int IsReflective(int[,] matrix)
        {
            int zeroCounter = 0, oneCounter = 0, result;
            for(int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i,i] == 0)
                    zeroCounter++;
                else if(matrix[i,i] == 1)
                    oneCounter++;
            }

            if(zeroCounter == matrix.GetLength(0))
            {
                result = -1;
            }
            else if(oneCounter == matrix.GetLength(0))
            {
                result = 1;
            }
            else
            {
                result = 0;
            }

            return result;
        }
        static int IsSymmetrical(int[,] matrix)
        {
            int symmetry = 0, antisymmetry = 0, result;
            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    if (i >= j)
                        continue;

                    if (matrix[i, j] == matrix[j, i])
                        symmetry++;
                    else
                        antisymmetry++;
                }

            if (symmetry == ((matrix.GetLength(0) * (matrix.GetLength(0) - 1)) / 2))
                result = 1;
            else if (antisymmetry == ((matrix.GetLength(0) * (matrix.GetLength(0) - 1)) / 2) && IsReflective(matrix) == -1)
                result = -2;
            else if (antisymmetry == ((matrix.GetLength(0) * (matrix.GetLength(0) - 1)) / 2))
                result = -1;
            else
                result = 0;
            return result;


        }
        static int IsTransitive(int[,] matrix)
        {
            int transitivity = 0, ones = 0, result;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    ones++;

                    if (j < i)
                        continue;

                    if (matrix[i, j] != 0)
                    {
                        for (int k = 0; k < matrix.GetLength(0); k++)
                        {
                            if (matrix[j, k] != 0 && matrix[i, k] != 0)
                                transitivity++;
                        }
                    }
                }
            }

            if (transitivity == ones)
                result = 1;
            else if (transitivity == 0)
                result = -1;
            else
                result = 0;

            return result;
        }
    }
}
