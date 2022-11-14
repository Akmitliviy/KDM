namespace KDM_Lab02
{
    static class Task03
    {
        public static void ThirdTask()
        {
            int value;
            //int[,] myMatrix = GetMatrix();
            int[,] myMatrix =
            {
                {0, 4, 6, 5, 1, 5, 5, 5 },
                {4, 0, 5, 5, 6, 7, 1, 5 },
                {6, 5, 0, 5, 5, 5, 4, 5 },
                {5, 5, 5, 0, 3, 1, 2, 2 },
                {1, 6, 5, 3, 0, 1, 1, 1 },
                {5, 7, 5, 1, 1, 0, 2, 7 },
                {5, 1, 4, 2, 1, 2, 0, 7 },
                {5, 5, 5, 2, 1, 7, 7, 0 }
            };

            int[] walk = new int[myMatrix.GetLength(0) + 1];

            value = NearestNeighbour(myMatrix, walk);

            Show(walk, value);
        }

        static int NearestNeighbour(int[,] myMatrix, int[] walk)
        {
            int minIndex = 0, realMinIndex = 0, min = 100, counter = 0;
            int[] indexHolder = new int[myMatrix.GetLength(0)];
            walk[0] = 1;

            for (int i = 0; i < indexHolder.GetLength(0); i++)
                indexHolder[i] = i + 1;

            for (int f = 0; f < myMatrix.GetLength(0); f++)
            {

                if (f == myMatrix.GetLength(0) - 1)
                {
                    counter += myMatrix[realMinIndex, 0];
                    break;
                }

                for (int i = indexHolder[0]; i < indexHolder.GetLength(0); i++)
                {
                    if (indexHolder[i] != 0 && myMatrix[realMinIndex, i] < min && i != realMinIndex)
                    {
                        min = myMatrix[realMinIndex, i];
                        minIndex = i;
                    }

                }
                indexHolder[minIndex] = 0;
                realMinIndex = minIndex;
                walk[f + 1] = realMinIndex + 1;
                counter += min;

                min = 100;
            }
            walk[myMatrix.GetLength(0)] = 1;

            return counter;
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

                            break;
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
        static void Show(int[] walk, int value)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("\nPath: ");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            for (int i = 0; i < walk.Length; i++)
            {
                Console.Write(walk[i]);
                if (i != walk.Length - 1)
                    Console.Write(" - ");
            }
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("\nThe value of path is: ");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write(value);
            Console.ForegroundColor = ConsoleColor.Gray;

            Console.WriteLine("\n");
        }
    }
}