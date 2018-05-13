using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace RD01_Task1_Matrix
{
    /// <summary>
    /// Класс для десериализации значений матрицы.
    /// </summary>
    internal class Deserialization
    {
        private static readonly BinaryFormatter formatter = new BinaryFormatter();   // Создаем объект BinaryFormatter.

        /// <summary>
        /// Метод DeserializationOfTheMatrix() десериализует матрицу, созданную в результате умножения первой и второй матрицы друг на друга при прошлом запуске программы.
        /// </summary>
        internal static void DeserializationOfTheMatrix()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Десериализация значений матрицы, созданной при прошлом запуске программы:");
            Console.ResetColor();

            if (!File.Exists("matrix.dat"))   // Проверяем, что файл существует
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Внимание: это первй запуск, сериализация значений матрицы еще не проводилась!\n");
                Console.ResetColor();
            }
            else
            {
                try
                {
                    using (FileStream fs = new FileStream("matrix.dat", FileMode.Open))   // Десериализация из файла matrix.dat.
                    {
                        var oldMatrix = (Matrix)formatter.Deserialize(fs);
                        oldMatrix.OutputMatrix();

                        fs.Close();
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}