using System;

/** <remark>
 * • Разработать тип для работы с матрицами*.
 * • Реализовать операции, позволяющие выполнять операции сложения, вычитания и умножения матриц, предусмотрев возможность их выполнения,
 * в противном случае должно генерироваться пользовательское исключение.
 * • Сохранить значение матрицы в файл (сериализация) и восстановить из файла.
 *
 * *Необходимые конструкторы, свойства и индексаторы, получение копии значения, сравнение значений.
</remark> */

namespace RD01_Task1_Matrix
{
    internal class Program
    {
        private static void Main()
        {
            Deserialization.DeserializationOfTheMatrix();

            try
            {
                var matrixA = new Matrix(3, 3);
                var matrixB = new Matrix(3, 3);

                const int i = 1, j = 2;   // Индексы для получения элементов матриц

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Матрица A");
                Console.ResetColor();
                matrixA.InputMatrix();
                matrixA.OutputMatrix();

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Матрица B");
                Console.ResetColor();
                matrixB.InputMatrix();
                matrixB.OutputMatrix();

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write($"Элемент матрицы A с индексом [{i}, {j}]: ");
                Console.ResetColor();
                Console.WriteLine(matrixA[i, j].ToString());

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write($"Элемент матрицы B с индексом [{i}, {j}]: ");
                Console.ResetColor();
                Console.WriteLine(matrixB[i, j].ToString());
                Console.WriteLine();

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"Сравнение значений матриц A и B по индексу [{i}, {j}]");
                Console.ResetColor();
                Console.WriteLine(!Matrix.ComparisonElements(matrixA, matrixB, i, j)
                    ? $"Значения {matrixA[i, j]} и {matrixB[i, j]} не равны"
                    : $"Значения {matrixA[i, j]} и {matrixB[i, j]} равны");
                Console.WriteLine();

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Сложение матриц A и B");
                Console.ResetColor();
                var matrixC = matrixA + matrixB;
                matrixC.OutputMatrix();

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Вычитание матрицы B из матриц A");
                Console.ResetColor();
                var matrixD = matrixA - matrixB;
                matrixD.OutputMatrix();

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Умножение матрицы A на матрицу B");
                Console.ResetColor();
                var matrixE = matrixA * matrixB;
                matrixE.OutputMatrix();

                Serialization.SerializationOfTheMatrix(matrixE);
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e.Message);
                Console.ResetColor();
            }

            Console.ReadKey();
        }
    }
}