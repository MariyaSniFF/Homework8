//Задания к семинару 8. Двумерные массивы. Продолжение
Start();
void Start()
{
    while (true)
    {
        Console.ReadLine();
        Console.Clear();

        System.Console.WriteLine("54) Задача 54: Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию элементы каждой строки двумерного массива.");
        System.Console.WriteLine("56) Задача 56: Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов.");
        System.Console.WriteLine("58) Задача 58: Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.");
        System.Console.WriteLine("60) Задача 60: Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.");
        System.Console.WriteLine("62) Задача 62: Напишите программу, которая заполнит спирально массив 4 на 4.");
        System.Console.WriteLine("0 End");

        int numTask = SetNumber("task");

        int SetNumber(string numberName)
        {
            Console.Write($"Введите номер задачи {numberName}: ");
            int num = Convert.ToInt32(Console.ReadLine());
            return num;
        }

        switch (numTask)
        {
            case 0: return; break;
            case 54: GetOrderedMatrix(); break;
            case 56: RectangularMatrixMinRowSum(); break;
            case 58: MultiplicationTwoMatrices(); break;
            case 60: ThreeDimensionalMatrix(); break;
            case 62: FillMatrixSpiral(); break;
            default: System.Console.WriteLine("Error"); break;
        }

    }

}

void GetOrderedMatrix()
{
    //Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию элементы каждой строки двумерного массива.
    Console.WriteLine("Введите количество строк");
    int rows = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Введите количество столбцов");
    int column = Convert.ToInt32(Console.ReadLine());
    int[,] matrix = new int[rows, column];
    matrix = GetRandomMatrix(rows, column);
    PrintMatrix(matrix);
    Console.WriteLine();
    GetOrderedMatrix(matrix);
    PrintMatrix(matrix);

    int[,] GetRandomMatrix(int rows, int column, int maxValue = 10, int minValue = 0)
    {
        int[,] matrix = new int[rows, column];
        var random = new Random();
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < column; j++)
            {
                matrix[i, j] = random.Next(minValue, maxValue + 1);
            }
        }
        return matrix;
    }

    void PrintMatrix(int[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                System.Console.Write(matrix[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
    void GetOrderedMatrix(int[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                for (int k = 0; k < matrix.GetLength(1) - 1; k++)
                {
                    if (matrix[i, k] < matrix[i, k + 1])
                    {
                        int temp = matrix[i, k + 1];
                        matrix[i, k + 1] = matrix[i, k];
                        matrix[i, k] = temp;
                    }

                }
            }
        }
    }
}

void RectangularMatrixMinRowSum()
{
    // Задача 56: Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов.
    int rows = 6;
    int column = 4;
    int[,] matrix = new int[rows, column];
    matrix = GetRandomMatrix(rows, column);
    PrintMatrix(matrix);
    Console.WriteLine();

    int[,] GetRandomMatrix(int rows, int column, int maxValue = 10, int minValue = 0)
    {
        int[,] matrix = new int[rows, column];
        var random = new Random();
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < column; j++)
            {
                matrix[i, j] = random.Next(minValue, maxValue + 1);
            }
        }
        return matrix;
    }

    void PrintMatrix(int[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                System.Console.Write(matrix[i, j] + " ");
            }
            Console.WriteLine();
        }
    }

    int minSumRow = 0;
    int sumRow = GetRowSumElements(matrix, 0);
    for (int i = 1; i < matrix.GetLength(0); i++)
    {
        int tempSumRow = GetRowSumElements(matrix, 1);
        if (sumRow > tempSumRow)
        {
            sumRow = tempSumRow;
            minSumRow = i;
        }
    }

    int GetRowSumElements(int[,] matrix, int i)
    {
        int sumRow = matrix[i, 0];
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            sumRow += matrix[i, j];
        }
        return sumRow;
    }

    Console.WriteLine($"{minSumRow + 1} - строкa с наименьшей суммой элементов");
}

void MultiplicationTwoMatrices()
{
    // Задача 58: Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.
    Console.WriteLine("Введите количество строк");
    int rows = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Введите количество столбцов");
    int column = Convert.ToInt32(Console.ReadLine());
    int[,] matrix1 = new int[rows, column];
    int[,] matrix2 = new int[rows, column];
    matrix1 = GetRandomMatrix(rows, column);
    matrix2 = GetRandomMatrix(rows, column);
    PrintMatrix(matrix1);
    Console.WriteLine();
    PrintMatrix(matrix2);
    Console.WriteLine();

    int[,] multiplMatrix = new int[rows, column];
    if (matrix1.GetLength(0) != matrix2.GetLength(1))
    {
        Console.WriteLine("Нельзя найти произведение");
        return;
    }
    for (int i = 0; i < matrix1.GetLength(0); i++)
    {
        for (int j = 0; j < matrix2.GetLength(1); j++)
        {
            multiplMatrix[i, j] = 0;
            for (int k = 0; k < matrix1.GetLength(1); k++)
            {
                multiplMatrix[i, j] += matrix1[i, k] * matrix2[k, j];
            }
        }
    }
    PrintMatrix(multiplMatrix);

    int[,] GetRandomMatrix(int rows, int column, int maxValue = 5, int minValue = 0)
    {
        int[,] matrix = new int[rows, column];
        var random = new Random();
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < column; j++)
            {
                matrix[i, j] = random.Next(minValue, maxValue + 1);
            }
        }
        return matrix;
    }
    void PrintMatrix(int[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                System.Console.Write(matrix[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
}

void ThreeDimensionalMatrix()
{
    // Задача 60. Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.

    Console.WriteLine("Введите размер массива x");
    int x = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Введите размер массива y");
    int y = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Введите размер массива z");
    int z = Convert.ToInt32(Console.ReadLine());
    int[,,] matrix = new int[x, y, z];

    GetRandomMatrix(matrix);
    PrintMatrixWithIdex(matrix);

    void GetRandomMatrix(int[,,] matrix, int minNumber = 10, int maxNumber = 100)
    {
        Random rand = new Random();

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                for (int h = 0; h < matrix.GetLength(2); h++)
                {
                    while (matrix[i, j, h] == 0)
                    {
                        int number = rand.Next(minNumber, maxNumber + 1);

                        if (IsNumberInMatrix(matrix, number) == false)
                        {
                            matrix[i, j, h] = number;
                        }
                    }

                }
            }
        }
    }

    bool IsNumberInMatrix(int[,,] matrix, int number)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                for (int h = 0; h < matrix.GetLength(2); h++)
                {
                    if (matrix[i, j, h] == number) return true;
                }
            }
        }

        return false;
    }

    void PrintMatrixWithIdex(int[,,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                for (int h = 0; h < matrix.GetLength(2); h++)
                {
                    Console.Write(matrix[i, j, h]);
                    Console.Write("({0},{1},{2})\t", i, j, h);
                }

                Console.WriteLine();
            }

            Console.WriteLine();
        }
    }
}

void FillMatrixSpiral()
{
    // Задача 62. Напишите программу, которая заполнит спирально массив 4 на 4.

    int n = 4;
    int[,] matrix = new int[n, n];

    int temp = 1;
    int i = 0;
    int j = 0;

    while (temp <= matrix.GetLength(0) * matrix.GetLength(1))
    {
        matrix[i, j] = temp;
        temp++;
        if (i <= j + 1 && i + j < matrix.GetLength(1) - 1)
            j++;
        else if (i < j && i + j >= matrix.GetLength(0) - 1)
            i++;
        else if (i >= j && i + j > matrix.GetLength(1) - 1)
            j--;
        else
            i--;
    }

    PrintMatrix(matrix);

    void PrintMatrix(int[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] / 10 <= 0)
                    Console.Write($" {matrix[i, j]} ");

                else Console.Write($"{matrix[i, j]} ");
            }
            Console.WriteLine();
        }
    }
}