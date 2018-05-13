using System;

// Операции над матрицами: http://www.cleverstudents.ru/matrix/operations_on_matrices.html

namespace RD01_Task1_Matrix
{
    [Serializable]
    internal class Matrix
    {
        [NonSerialized]
        private static readonly Random random = new Random();

        // Массив элементов матрицы.
        private readonly int[,] array;

        // Конструктор матрицы с указанием ее размеров.
        public Matrix(int rows, int columns)
        {
            array = new int[rows, columns];
        }

        // Свойство получения количества строк матрицы.
        public int Rows => array.GetLength(0);

        // Свойство получения количества столбцов матрицы.
        public int Сolumns => array.GetLength(1);

        // Индексатор для доступа к элементам матрицы.
        public int this[int i, int j]
        {
            // Проверяется корректность индексов.
            get => i < 0 || i >= Rows || j < 0 || j >= Сolumns
                ? throw new Exception("Индексы выходят из диапазона")
                : array[i, j];
            set
            {
                if (i < 0 || i >= Rows || j < 0 || j >= Сolumns)
                    throw new Exception("Индексы выходят из диапазона");
                array[i, j] = value;
            }
        }

        /// <summary>
        /// Метод InputMatrix() заполняет матрицу случайными числами.
        /// </summary>
        public void InputMatrix()
        {
            int rows = Rows, columns = Сolumns;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    array[i, j] = random.Next(-5, 21);
                }
            }
        }

        /// <summary>
        /// Метод OutputMatrix() выводит матрицу на консоль.
        /// </summary>
        public void OutputMatrix()
        {
            int rows = Rows, columns = Сolumns;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write("{0, 3} ", array[i, j]);
                }
                Console.WriteLine();
            }

            Console.WriteLine();
        }

        /// <summary>
        /// Операция сложения двух матриц.
        /// </summary>
        /// <param name="matrixA">Первая матрица.</param>
        /// <param name="matrixB">Вторая матрица.</param>
        /// <returns>Результат сложения первой и второй матрицы в виде новой матрицы.</returns>
        public static Matrix operator +(Matrix matrixA, Matrix matrixB)
        {
            // Размеры матриц должны совпадать.
            if (matrixA.Rows != matrixB.Rows || matrixA.Сolumns != matrixB.Сolumns)
                throw new Exception("Матрицы таких размеров нельзя складывать!");

            var newMatrix = new Matrix(matrixA.Rows, matrixA.Сolumns);

            for (int i = 0; i < matrixA.Rows; i++)
            {
                for (int j = 0; j < matrixA.Сolumns; j++)
                {
                    newMatrix[i, j] = matrixA[i, j] + matrixB[i, j];
                }
            }

            return newMatrix;
        }

        /// <summary>
        /// Операция вычитания второй матрицы из первой.
        /// </summary>
        /// <param name="matrixA">Первая матрица в качестве параметра matrixA.</param>
        /// <param name="matrixB">Вторая матрица в качестве параметра matrixB.</param>
        /// <returns>Результат вычитания второй матрицы из первой в виде новой матрицы.</returns>
        public static Matrix operator -(Matrix matrixA, Matrix matrixB)
        {
            // Размеры матриц должны совпадать.
            if (matrixA.Rows != matrixB.Rows || matrixA.Сolumns != matrixB.Сolumns)
                throw new Exception("Матрицы таких размеров нельзя вычитать!");

            var newMatrix = new Matrix(matrixA.Rows, matrixA.Сolumns);

            for (int i = 0; i < matrixA.Rows; i++)
            {
                for (int j = 0; j < matrixA.Сolumns; j++)
                {
                    newMatrix[i, j] = matrixA[i, j] - matrixB[i, j];
                }
            }

            return newMatrix;
        }

        /// <summary>
        /// Умножает две матрицы друг на друга.
        /// </summary>
        /// <param name="matrixA">Первая матрица в качестве параметра matrixA.</param>
        /// <param name="matrixB">Вторая матрица в качестве параметра matrixB.</param>
        /// <returns>Результат умножения первой и второй матрицы друг на друга в виде новой матрицы.</returns>
        public static Matrix operator *(Matrix matrixA, Matrix matrixB)
        {
            // Умножать матрицы можно тогда и только тогда, когда количество столбцов первой матрицы равно количеству строк второй матрицы.
            if (matrixA.Сolumns != matrixB.Rows)
            {
                throw new Exception(
                    @"Внимание: Умножать матрицы можно тогда и только тогда,
когда количество столбцов матрицы A равно количеству строк матрицы B!");
            }

            // Создание матрицы - результата.
            var newMatrix = new Matrix(matrixA.Rows, matrixB.Сolumns);

            // Заполнение матрицы - результата.
            for (int i = 0; i < matrixA.Rows; i++)
            {
                for (int j = 0; j < matrixB.Сolumns; j++)
                {
                    for (int k = 0; k < matrixA.Сolumns; k++)
                    {
                        newMatrix[i, j] += matrixA[i, k] * matrixB[k, j];
                    }
                }
            }

            return newMatrix;
        }

        /// <summary>
        /// Сравнивает значения элементов двух матриц по заданному индексу.
        /// </summary>
        /// <param name="matrixA">Первая матрица в качестве параметра matrixA.</param>
        /// <param name="matrixB">Вторая матрица в качестве параметра matrixB.</param>
        /// <param name="i">Индекс строки матрица в качестве параметра i.</param>
        /// <param name="j">Индекс столбца матрица в качестве параметра j.</param>
        /// <returns>Результат сравнения элментов двух матриц по заданному индексу в виде true / false.</returns>
        public static bool ComparisonElements(Matrix matrixA, Matrix matrixB, int i, int j)
        {
            return matrixA[i, j] == matrixB[i, j];
        }
    }
}