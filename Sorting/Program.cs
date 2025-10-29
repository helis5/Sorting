using System;
class Program
{
    // Создаем 7 копий массива ([][] на первом месте номер массива, на втором - индекс ячейки)
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
                if (arrs[0][j + 1] + 1 < arrs[0][j])
                {
                    int z = arrs[0][j + 1];
                    arrs[0][j + 1] = arrs[0][j];
                    arrs[0][j] = z;
                }
            }
        }
        PrintArray(arrs[0]);
    }
}