using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KDM_Lab03
{
    static class Task06
    {
        public static void SixthTask()
        {
            //Console.ForegroundColor = ConsoleColor.Blue;
            //Console.WriteLine("Please, Enter matrix R1: ");
            //Console.ForegroundColor = ConsoleColor.Gray;
            //int[,] R1 = GetMatrix();
            //Console.ForegroundColor = ConsoleColor.Blue;
            //Console.WriteLine("Please, Enter matrix R2: ");
            //Console.ForegroundColor = ConsoleColor.Gray;
            //int[,] R2 = GetMatrix();

            int[,] R1 =
            {
                {1,  0,  1},
                {1,  1,  0},
                {0,  0,  1}
            };

            int[,] R2 =
            {
                {1,  0,  0},
                {0,  1,  0},
                {1,  0,  1}
            };

            int[,] intersection = FindIntersection(R1, R2);
            int[,] union = FindUnion(R1, R2);
            int[,] complemenceToR1 = FindComplemence(R1);
            int[,] complemenceToR2 = FindComplemence(R2);
            int[,] difference12 = FindDifference(R1, R2);
            int[,] difference21 = FindDifference(R2, R1);
            int[,] hardDifference = FindUnion(difference21, difference12);
            int[,] transposedR1 = Transpose(R1);
            int[,] transposedR2 = Transpose(R2);
            int[,] composingR1R2 = MatrixMultiplication(R2, R1);
            int[,] composingR2R1 = MatrixMultiplication(R1, R2);

            Console.WriteLine("\n\nIntersection:");
            ShowMatrix(intersection);
            Console.WriteLine("\n\nUnion:");
            ShowMatrix(union);
            Console.WriteLine("\n\nComplemence to R1:");
            ShowMatrix(complemenceToR1);
            Console.WriteLine("\n\nComplemence to R2:");
            ShowMatrix(complemenceToR2);
            Console.WriteLine("\n\nDifference R1 \\ R2:");
            ShowMatrix(difference12);
            Console.WriteLine("\n\nDifference R2 \\ R1:");
            ShowMatrix(difference21);
            Console.WriteLine("\n\nDifference in both ways (R1 \\ R2) \\/ (R2 \\ R1): ");
            ShowMatrix(hardDifference);
            Console.WriteLine("\n\nTransposed R1: ");
            ShowMatrix(transposedR1);
            Console.WriteLine("\n\nTransposed R2: ");
            ShowMatrix(transposedR2);
            Console.WriteLine("\n\nComposition R1 o R2: ");
            ShowMatrix(composingR1R2);
            Console.WriteLine("\n\nComposition R2 o R1: ");
            ShowMatrix(composingR2R1);

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
        static int[,] FindIntersection(int[,] myMatrix, int[,] secMatrix)
        {
            int myMtrxLength = myMatrix.GetLength(0);
            int secMtrxLength = secMatrix.GetLength(0);
            int[,] result;

            if (myMtrxLength > secMtrxLength)
            {
                result = new int[secMtrxLength, secMtrxLength];
            }
            else
            {
                result = new int[myMtrxLength, myMtrxLength];
            }

            for (int i = 0; i < result.GetLength(0); i++)
            {

                for (int j = 0; j < result.GetLength(0); j++)
                {
                    if (myMatrix[i, j] == 1 && secMatrix[i, j] == 1)
                    {
                        result[i, j] = 1;
                    }
                }
            }

            return result;
        }
        static int[,] FindUnion(int[,] myMatrix, int[,] secMatrix)
        {
            int myMtrxLength = myMatrix.GetLength(0);
            int secMtrxLength = secMatrix.GetLength(0);
            int[,] result, smaller, bigger;

            if (myMtrxLength > secMtrxLength)
            {
                result = new int[myMtrxLength, myMtrxLength];
                smaller = secMatrix;
                bigger = myMatrix;
            }
            else
            {
                result = new int[secMtrxLength, secMtrxLength];
                smaller = myMatrix;
                bigger = secMatrix;
            }

            for (int i = 0; i < result.GetLength(0); i++)
            {

                for (int j = 0; j < result.GetLength(0); j++)
                {
                    if (j >= smaller.GetLength(0) || i >= smaller.GetLength(0))
                    {
                        result[i, j] = bigger[i, j];
                        continue;
                    }

                    if (myMatrix[i, j] == 1 || secMatrix[i, j] == 1)
                    {
                        result[i, j] = 1;
                    }
                }
            }

            return result;
        }
        static int[,] FindComplemence(int[,] matrix)
        {
            int len = matrix.GetLength(0);
            int[,] result = new int[len, len];

            for (int i = 0; i < len; i++)
            {
                for (int j = 0; j < len; j++)
                {
                    result[i, j] = matrix[i, j] == 0 ? 1 : 0;
                }
            }

            return result;
        }
        static int[,] FindDifference(int[,] myMatrix, int[,] secMatrix)
        {

            int[,] result = new int[myMatrix.GetLength(0), myMatrix.GetLength(0)];

            for (int i = 0; i < myMatrix.GetLength(0); i++)
                for (int j = 0; j < myMatrix.GetLength(0); j++)
                    result[i, j] = myMatrix[i, j];

            for (int i = 0; i < result.GetLength(0); i++)
            {

                for (int j = 0; j < result.GetLength(0); j++)
                {
                    if (myMatrix[i, j] == 1 && secMatrix[i, j] == 1)
                    {
                        result[i, j] = 0;
                    }
                }
            }

            return result;
        }
        static int[,] Transpose(int[,] myMatrix)
        {
            int[,] result = new int[myMatrix.GetLength(0), myMatrix.GetLength(0)];

            for (int i = 0; i < myMatrix.GetLength(0); i++)
                for (int j = 0; j < myMatrix.GetLength(0); j++)
                    result[i, j] = myMatrix[j, i];

            return result;
        }
        static int[,] MatrixMultiplication(int[,] matrix_1, int[,] matrix_2)
        {
            int[,] result = new int[matrix_1.GetLength(0), matrix_1.GetLength(0)];
            int path = 0;

            for (int i = 0; i < matrix_1.GetLength(0); i++)
            {
                for (int j = 0; j < matrix_1.GetLength(0); j++)
                {
                    for (int k = 0; k < matrix_1.GetLength(0); k++)
                        path += matrix_1[i, k] * matrix_2[k, j];

                    result[i, j] = path != 0 ? 1 : 0;
                    path = 0;
                }
            }

            return result;
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
                    if (matrix[i, j] != 0)
                        edges++;
                    Console.Write(matrix[i, j] + "    ");
                }
                Console.WriteLine("\n");
            }
            Console.WriteLine("Number of edges is: {0}\nNumber of vertix is: {1}\n", edges, vertices);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
