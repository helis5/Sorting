using System;
using Microsoft.VisualBasic.FileIO;
using System.Diagnostics;
class Program
{
    // Создаем 7 копий массива ([][] на первом месте индекс массива, на втором - ячейки)
    public static int[][] arrs = new int[7][];

    public static void Main()
    {
        int[] origArr = new int[10];
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
        BubbleImp();
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
        int[] arr = arrs[0];
        Stopwatch Sw = new Stopwatch();
        Sw.Start();
        long freq = Stopwatch.Frequency; 
        for (int i = 0; i < arr.Length; i++)
        {
            for (int j = 0; j < arr.Length - 1; j++)
            {
                if (arr[j + 1] < arr[j])
                {
                    int z = arr[j + 1];
                    arr[j + 1] = arr[j];
                    arr[j] = z;
                }
            }
        }
        Sw.Stop();
        double sec = (double)Sw.ElapsedTicks / freq;
        Console.WriteLine(sec);
        PrintArray(arr);
    }

    static void BubbleImp()
    {
        int[] arr = arrs[1];
        Stopwatch Sw = new Stopwatch();
        Sw.Start();
        long freq = Stopwatch.Frequency; 
        int i = 0; int k = 1;
        while (k > 0)
        {
            k = 0;
            for (int j = 0; j < arr.Length - 1; j++)
            {
                if (arr[j + 1] < arr[j])
                {
                    int z = arr[j + 1];
                    arr[j + 1] = arr[j];
                    arr[j] = z;
                    k++;
                }
            }
            i++;
        }
        Sw.Stop();
        double sec = (double)Sw.ElapsedTicks / freq;
        Console.WriteLine(sec);
        PrintArray(arr);        
    }

    static void Shaker()
    {
        int[] arr = arrs[2];
        Stopwatch Sw = new Stopwatch();
        Sw.Start();
        long freq = Stopwatch.Frequency; 
        int left = 0;
        int right = arr.Length - 1;

        while (left <= right)
        {
            // Проход слева направо
            for (int i = left; i < right; i++)
            {
                if (arr[i] > arr[i + 1])
                {
                    int temp = arr[i];
                    arr[i] = arr[i + 1];
                    arr[i + 1] = temp;
                }
            }
            right--; // Уменьшаем правую границу, т.к. наибольший элемент уже на месте

            // Проход справа налево
            for (int i = right; i > left; i--)
            {
                if (arr[i - 1] > arr[i])
                {
                    int temp = arr[i];
                    arr[i] = arr[i - 1];
                    arr[i - 1] = temp;
                }
            }
            left++; // Увеличиваем левую границу, т.к. наименьший элемент уже на месте
        }
        Sw.Stop();
        double sec = (double)Sw.ElapsedTicks / freq;
        Console.WriteLine(sec);
        PrintArray(arr);
    }
    //ищем максимальный и ставим в конец
    static void Selection()
    {
        int[] arr = arrs[3];
        Stopwatch Sw = new Stopwatch();
        Sw.Start();
        long freq = Stopwatch.Frequency; 
        for (int i = 0; i < arr.Length - 1; i++)
        {
            int max = arr[0];
            int maxIndex = 0;
            for (int j = 0; j < arr.Length - i; j++)
            {
                if (arr[j] > max)
                {
                    max = arr[j];
                    maxIndex = j;
                }
            }
            int t = arr[arr.Length - i - 1];
            arr[arr.Length - i - 1] = arr[maxIndex];
            arr[maxIndex] = t;
        }
        Sw.Stop();
        double sec = (double)Sw.ElapsedTicks / freq;
        Console.WriteLine(sec);
        PrintArray(arr);
    }
    static void Incert()
    {
        int[] arr = arrs[4];
        Stopwatch Sw = new Stopwatch();
        Sw.Start();
        long freq = Stopwatch.Frequency; 
        for (int i = 1; i < arr.Length; i++)
        {
            int t = arr[i];
            int j = i;

            // Сдвигаем элементы вправо, пока не найдем место для t
            while (j > 0 && arr[j - 1] > t)
            {
                arr[j] = arr[j - 1];
                j--;
            }
            arr[j] = t; // Вставляем сохраненный элемент
        }
        Sw.Stop();
        double sec = (double)Sw.ElapsedTicks / freq;
        Console.WriteLine(sec);
        PrintArray(arr);
    }
    static void Shellsort()
    {
        int[] arr = arrs[5];
        Stopwatch Sw = new Stopwatch();
        Sw.Start();
        long freq = Stopwatch.Frequency;
        int d = arr.Length / 2;
        while (d >= 1)
        {
            for (int i = d; i < arr.Length; i++)
            {
                int j = i;
                while ((j >= d) && (arr[j - d] > arr[j]))
                {
                    int t = arr[j - d];
                    arr[j - d] = arr[j];
                    arr[j] = t;
                    j = j - d;
                }
            }
            d = d / 2;
        }
        Sw.Stop();
        double sec = (double)Sw.ElapsedTicks / freq;
        Console.WriteLine(sec);
        PrintArray(arr);
    }
    static void QSort()
    {
        int[] arr = arrs[6];
        Stopwatch Sw = new Stopwatch();
        Sw.Start();
        long freq = Stopwatch.Frequency;

        Sw.Stop();
        double sec = (double)Sw.ElapsedTicks / freq;
        Console.WriteLine(sec);
        PrintArray(arrs[5]);
    }
}