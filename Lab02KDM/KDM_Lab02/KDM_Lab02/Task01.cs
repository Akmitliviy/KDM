namespace KDM_Lab02
{
    static class Task01
    {

        public static void FirstTask()
        {

            //Console.ForegroundColor = ConsoleColor.Blue;
            //Console.WriteLine("\nEnter first matrix: \n");
            //Console.ForegroundColor = ConsoleColor.Gray;
            //int[,] myMatrix = GetMatrix();
            int[,] myMatrix =
            {
                {0, 1, 0, 0, 0, 0, 1, 1 },
                {1, 0, 1, 1, 0, 0, 0, 0 },
                {0, 1, 0, 1, 1, 0, 1, 0 },
                {0, 1, 1, 0, 1, 0, 0, 0 },
                {0, 0, 1, 1, 0, 1, 0, 0 },
                {0, 0, 0, 0, 1, 0, 1, 1 },
                {1, 0, 1, 0, 0, 1, 0, 1 },
                {1, 0, 0, 0, 0, 1, 1, 0 }
            };
            //Console.ForegroundColor = ConsoleColor.Blue;
            //Console.WriteLine("Enter second matrix: \n");
            //Console.ForegroundColor = ConsoleColor.Gray;
            //int[,] secMatrix = GetMatrix();

            int[,] secMatrix =
            {
                {0, 0, 1, 0, 1, 0, 1 },
                {0, 0, 0, 1, 0, 1, 1 },
                {1, 0, 0, 0, 1, 0, 1 },
                {0, 1, 0, 0, 0, 1, 1 },
                {1, 0, 1, 0, 0, 0, 1 },
                {0, 1, 0, 1, 0, 0, 1 },
                {1, 1, 1, 1, 1, 1, 0 }
            };

            int[,] myMatrixComplemence = FindComplemence(myMatrix);
            int[,] matrixesAssociation = FindGraphsUnion(myMatrix, secMatrix);
            int[,] matrixIntersection = FindGraphsIntersection(myMatrix, secMatrix);


            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("First matrix: ");
            ShowMatrix(myMatrix);

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Second matrix: ");
            ShowMatrix(secMatrix);

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("First matrix Complemence: ");
            ShowMatrix(myMatrixComplemence);

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Association of first and second matrixes: ");
            ShowMatrix(matrixesAssociation);

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Intersection of first and second matrixes: ");
            ShowMatrix(matrixIntersection);

            Console.ForegroundColor = ConsoleColor.Gray;
        }

        static int[,] FindGraphsIntersection(int[,] myMatrix, int[,] secMatrix)
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
                    if (j <= i) continue;

                    if (myMatrix[i, j] == 1 && secMatrix[i, j] == 1)
                    {
                        result[i, j] = 1;
                        result[j, i] = 1;
                    }
                }
            }

            return result;
        }

        static int[,] FindGraphsUnion(int[,] myMatrix, int[,] secMatrix)
        {
            int myMtrxLength = myMatrix.GetLength(0);
            int secMtrxLength = secMatrix.GetLength(0);
            int[,] result, smaller, bigger;

            if (myMtrxLength > secMtrxLength)
            {
                result = new int[myMtrxLength,myMtrxLength];
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
                    if (j <= i) continue;

                    if (j >= smaller.GetLength(0) || i >= smaller.GetLength(0))
                    {
                        result[i, j] = bigger[i, j];
                        result[j, i] = result[i, j];
                        continue;
                    }

                    if (myMatrix[i, j] == 1 || secMatrix[i, j] == 1)
                    {
                        result[i, j] = 1;
                        result[j, i] = 1;
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
                    if (j <= i) continue;

                    result[i, j] = matrix[i, j] == 0 ? 1 : 0;
                    result[j, i] = result[i, j];

                }
            }

            return result;
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
        static void ShowMatrix(int[,] matrix)
        {
            int edges = 0, vertix = matrix.GetLength(0);

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkYellow;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    if (j >= i && matrix[i, j] != 0)
                        edges++;

                    Console.Write(matrix[i, j] + "    ");
                }
                Console.WriteLine("\n");
            }
            Console.WriteLine("Number of edges is: {0}\nNumber of vertix is: {1}\n", edges, vertix);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}