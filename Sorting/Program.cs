using System;
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

        for (int i = 0; i < arrs.Length; i++)
        {
            arrs[i] = (int[])origArr.Clone();  //.Clone возвращает Object, поэтому явно укажем (int[])
        }

        Bubble();
        Shaker();
    }

    static void PrintArray(int[] arr)
    {
        Console.WriteLine(string.Join(" ", arr));
    }


    // сортировка пузырьком
    static void Bubble()
    {
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
        PrintArray(arrs[0]);
    }

    static void Shaker()
    {
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
        
        PrintArray(arrs[1]);
    }
}