using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace RD01_Task1_Matrix
{
    /// <summary>
    /// Класс для сериализации значений матрицы.
    /// </summary>
    internal class Serialization
    {
        private static readonly BinaryFormatter formatter = new BinaryFormatter();   // Создаем объект BinaryFormatter.

        /// <summary>
        /// Метод SerializationOfTheMatrix() сериализует матрицу - результат умножения первой и второй матрицы друг на друга.
        /// </summary>
        /// <param name="matrixE"></param>
        internal static void SerializationOfTheMatrix(Matrix matrixE)
        {
            try
            {
                // Получаем поток, куда будем записывать сериализованный объект.
                using (FileStream fs = new FileStream("matrix.dat", FileMode.OpenOrCreate))
                {
                    formatter.Serialize(fs, matrixE);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Объект успешно сериализован в файл matrix.dat");
                    Console.ResetColor();

                    fs.Close();
                }
            }
            catch (SerializationException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}