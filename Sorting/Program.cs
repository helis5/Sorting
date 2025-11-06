using System;
using Microsoft.VisualBasic.FileIO;
using System.Diagnostics;
class Program
{
    // Создаем 7 копий массива ([][] на первом месте индекс массива, на втором - ячейки)
    public static int[][] arrs = new int[7][];

    public static void Main()
    {
        int[] origArr = new int[30];
        Random rnd = new Random();

        // Заполняем массив случайными числами
        for (int i = 0; i < origArr.Length; i++)
        {
            origArr[i] = rnd.Next(1, 101); // числа от 1 до 100
        }

        // Выводим исходный массив
        Console.WriteLine("Исходный массив:");
        PrintArray(origArr);
        Console.WriteLine("---------------------");

        for (int i = 0; i < arrs.Length; i++)
        {
            arrs[i] = (int[])origArr.Clone();  //.Clone возвращает Object, поэтому явно укажем (int[])
        }

        Bubble();
        Shaker();
        Selection();
        Incert();
        Shellsort();
    }

    static void PrintArray(int[] arr)
    {
        Console.WriteLine(string.Join(" ", arr));
    }


    // сортировка пузырьком
    static void Bubble()
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        for (int i = 0; i < arrs[0].Length; i++)
        {
            for (int j = 0; j < arrs[0].Length - i - 1; j++)
            {
                if (arrs[0][j + 1] < arrs[0][j])
                {
                    int z = arrs[0][j + 1];
                    arrs[0][j + 1] = arrs[0][j];
                    arrs[0][j] = z;
                }
            }
        }
        stopwatch.Stop();
        Console.WriteLine(stopwatch.ElapsedTicks);
        PrintArray(arrs[0]);
    }

    static void Shaker()
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        int left = 0;
        int right = arrs[0].Length - 1;

        while (left <= right)
        {
            // Проход слева направо
            for (int i = left; i < right; i++)
            {
                if (arrs[1][i] > arrs[1][i + 1])
                {
                    int temp = arrs[1][i];
                    arrs[1][i] = arrs[1][i + 1];
                    arrs[1][i + 1] = temp;
                }
            }
            right--; // Уменьшаем правую границу, т.к. наибольший элемент уже на месте

            // Проход справа налево
            for (int i = right; i > left; i--)
            {
                if (arrs[1][i - 1] > arrs[1][i])
                {
                    int temp = arrs[1][i];
                    arrs[1][i] = arrs[1][i - 1];
                    arrs[1][i - 1] = temp;
                }
            }
            left++; // Увеличиваем левую границу, т.к. наименьший элемент уже на месте
        }
        stopwatch.Stop();
        Console.WriteLine(stopwatch.ElapsedTicks);
        PrintArray(arrs[1]);
    }
    //ищем максимальный и ставим в конец
    static void Selection()
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        for (int i = 0; i < arrs[2].Length - 1; i++)
        {
            int max = arrs[2][0];
            int maxIndex = 0;
            for (int j = 0; j < arrs[2].Length - i; j++)
            {
                if (arrs[2][j] > max)
                {
                    max = arrs[2][j];
                    maxIndex = j;
                }
            }
            int t = arrs[2][arrs[2].Length - i - 1];
            arrs[2][arrs[2].Length - i - 1] = arrs[2][maxIndex];
            arrs[2][maxIndex] = t;
        }
        stopwatch.Stop();
        Console.WriteLine(stopwatch.ElapsedTicks);
        PrintArray(arrs[2]);
    }
    static void Incert()
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        for (int i = 1; i < arrs[3].Length; i++)
        {
            int t = arrs[3][i];
            int j = i;

            // Сдвигаем элементы вправо, пока не найдем место для t
            while (j > 0 && arrs[3][j - 1] > t)
            {
                arrs[3][j] = arrs[3][j - 1];
                j--;
            }
            arrs[3][j] = t; // Вставляем сохраненный элемент
        }
        stopwatch.Stop();
        Console.WriteLine(stopwatch.ElapsedTicks);
        PrintArray(arrs[3]);
    }
    static void Shellsort()
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        int d = arrs[4].Length / 2;
        while (d >= 1)
        {
            for (int i = d; i < arrs[4].Length; i++)
            {
                int j = i;
                while ((j >= d) && (arrs[4][j - d] > arrs[4][j]))
                {
                    int t = arrs[4][j - d];
                    arrs[4][j - d] = arrs[4][j];
                    arrs[4][j] = t;
                    j = j - d;
                }
            }
            d = d / 2;
        }
        stopwatch.Stop();
        Console.WriteLine(stopwatch.ElapsedTicks);
        PrintArray(arrs[4]);
    }
}