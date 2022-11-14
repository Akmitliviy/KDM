namespace KDM_Lab02
{
    static class Task04
    {
        public static void FourthTask()
        {
            //Console.ForegroundColor = ConsoleColor.Blue;
            //Console.WriteLine("\nEnter first matrix: \n");
            //Console.ForegroundColor = ConsoleColor.Gray;
            //int[,] myMatrix = GetMatrix();
            int[,] myMatrix =
            {
                {0, 1, 0, 1, 0, 1},
                {0, 0, 1, 1, 0, 0},
                {0, 0, 0, 0, 0, 1},
                {0, 0, 0, 0, 1, 0},
                {0, 0, 1, 0, 0, 1},
                {0, 0, 0, 0, 0, 0}
            };

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("\nPlease, choose method (Multiplication or Warshall): \n");

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                string variant = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.Gray;

                if (variant.ToLower() == "m" || variant.ToLower() == "multiplication")
                {
                    ViaMultiplication(myMatrix);
                    break;
                }
                else if (variant.ToLower() == "w" || variant.ToLower() == "Warshall")
                {
                    ViaWarshall(myMatrix);
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("\nPlease, enter proper value: ");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }

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

            int[] l = new int[size];
            for (int i = 0; i < l.Length; i++)
            {
                l[i] = i + 1;
            }

            int[,] myMatrix = new int[size, size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (j == i) continue;

                    while (true)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("Edge between \"x{0}\" and \"x{1}\": ", l[i], l[j]);
                        try
                        {
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            myMatrix[i, j] = Convert.ToInt32(Console.ReadLine());
                            Console.ForegroundColor = ConsoleColor.Gray;

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
        static void ViaMultiplication(int[,] myMatrix)
        {
            int index;
            int[,] adjacencyMatrix;

            while (true)
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("\nPlease, enter power of matrix multiplication: ");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    index = Convert.ToInt32(Console.ReadLine());
                    Console.ForegroundColor = ConsoleColor.Gray;

                    if (index > 0 && index <= myMatrix.GetLength(0))
                        break;
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nPlease, enter proper value (From 1 to the number of vertix)\n");
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }

                }
                catch (FormatException)
                {

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nPlease, enter numbers only!\n");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
            }
            Console.WriteLine();

            adjacencyMatrix = new int[myMatrix.GetLength(0), myMatrix.GetLength(0)];
            int[,] reachabilityMatrix = MatrixMultiplication(index, myMatrix, adjacencyMatrix);


            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("\nGraph's reachability in ONLY {0} steps", index);
            Console.ForegroundColor = ConsoleColor.Gray;
            ShowMatrix(adjacencyMatrix);

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("\nGraph's reachability in MAXIMUM {0} steps", index);
            Console.ForegroundColor = ConsoleColor.Gray;
            ShowMatrix(reachabilityMatrix);

        }
        static int[,] MatrixMultiplication(int index, int[,] matrix, int[,] adjacencyMatrix)
        {
            int powerNumber = 1;
            int[,] tempAdjacencyMatrix = new int[matrix.GetLength(0), matrix.GetLength(0)];
            int[,] reachabilityMatrix = new int[matrix.GetLength(0), matrix.GetLength(0)];
            int path = 0;

            for(int i = 0; i < matrix.GetLength(0); i++)
            {
                for(int j = 0; j < matrix.GetLength(0); j++)
                {
                    adjacencyMatrix[i, j] = matrix[i, j];
                    reachabilityMatrix[i, j] = matrix[i, j];
                }
            }


            while(powerNumber < index)
            {
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(0); j++)
                    {
                        for (int k = 0; k < matrix.GetLength(0); k++)
                            path += adjacencyMatrix[i,k] * matrix[k, j];

                        tempAdjacencyMatrix[i, j] = path;
                        path = 0;
                    }
                }

                for (int i = 0; i < matrix.GetLength(0); i++)
                    for (int j = 0; j < matrix.GetLength(0); j++)
                    {
                        if(adjacencyMatrix[i, j] != 0 || tempAdjacencyMatrix[i, j] != 0)
                            reachabilityMatrix[i, j] = 1;
                        adjacencyMatrix[i, j] = tempAdjacencyMatrix[i, j];
                    }

                powerNumber++;
            }
            
            return reachabilityMatrix;
        }
        static void ViaWarshall(int[,] myMatrix)
        {
            int[,] reachabilityMatrix = new int[myMatrix.GetLength(0), myMatrix.GetLength(0)];
            int[,] tempReachabilityMatrix = new int[myMatrix.GetLength(0), myMatrix.GetLength(0)];

            for (int i = 0; i < myMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < myMatrix.GetLength(0); j++)
                {
                    reachabilityMatrix[i, j] = myMatrix[i, j];
                    tempReachabilityMatrix[i, j] = myMatrix[i, j];
                }
            }

            for (int i = 0; i < myMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < myMatrix.GetLength(0); j++)
                {
                    if (reachabilityMatrix[j, i] == 1)
                    {
                        for (int k = 0; k < myMatrix.GetLength(0); k++)
                        {
                            if (reachabilityMatrix[j, k] == 0 && tempReachabilityMatrix[i, k] == 1)
                                reachabilityMatrix[j, k] = 1;
                        }
                    }
                }

                //Console.WriteLine("\nW{0}:\n\n", i+1);
                //ShowMatrix(reachabilityMatrix);
                //Console.WriteLine();

                for (int j = 0; j < myMatrix.GetLength(0); j++)
                    for (int k = 0; k < myMatrix.GetLength(0); k++)
                        tempReachabilityMatrix[j, k] = reachabilityMatrix[j, k];
            }


            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("\nGraph's reachability matrix: ");
            Console.ForegroundColor = ConsoleColor.Gray;
            ShowMatrix(reachabilityMatrix);
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
                    if (matrix[i, j] != 0)
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