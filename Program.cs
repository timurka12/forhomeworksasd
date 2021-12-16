using System;
using System.Diagnostics;

namespace homework
{
    class Program
    {
        public static readonly int r = 10000000; // размер массива данных
        public class PointClass // вариант для ссылочного типа
        {
            public float X;
            public float Y;
        }
        public struct PointStructF // вариант для типа float
        {
            public float X;
            public float Y;
        }
        public struct PointStructD // вариант для типа double
        {
            public double X;
            public double Y;
        }
        // объявляем массивы с данными
        public static PointStructF[] masF = new PointStructF[r + 1];
        public static PointStructD[] masD = new PointStructD[r + 1];
        public static PointClass[] masC = new PointClass[r + 1];
        public static float PointDistance1(ref PointClass pointOne, ref PointClass pointTwo) // вариант теста 1
        {
            float x = pointOne.X - pointTwo.X;
            float y = pointOne.Y - pointTwo.Y;
            return MathF.Sqrt((x * x) + (y * y));
        }
        public static float PointDistance2(PointStructF pointOne, PointStructF pointTwo) // вариант теста 2
        {
            float x = pointOne.X - pointTwo.X;
            float y = pointOne.Y - pointTwo.Y;
            return MathF.Sqrt((x * x) + (y * y));
        }
        public static double PointDistance3(PointStructD pointOne, PointStructD pointTwo) // вариант теста 3
        {
            double x = pointOne.X - pointTwo.X;
            double y = pointOne.Y - pointTwo.Y;
            return Math.Sqrt((x * x) + (y * y));
        }
        public static float PointDistance4(PointStructF pointOne, PointStructF pointTwo) // вариант теста 4
        {
            float x = pointOne.X - pointTwo.X;
            float y = pointOne.Y - pointTwo.Y;
            return Sqrt((x * x) + (y * y));
        }
        public static float Sqrt(float x)
        {
            float s = ((x / 2) + x / (x / 2));
            for (int i = 0; i < 4; i++)
            {
                s = (s + x / s) / 2;
            }
            return s;
        }
        static void Main(string[] args)
        {
            Random rnd = new Random();
            // заполняем массив случайными данными
            for (int i = 0; i <= r; i++)
            {
                masF[i].X = (float)rnd.NextDouble();
                masF[i].Y = (float)rnd.NextDouble();
                masD[i].X = rnd.NextDouble();
                masD[i].Y = rnd.NextDouble();
                masC[i] = new PointClass
                {
                    X = masF[i].X,
                    Y = masF[i].Y
                };
            }
            // расчёты для всех 4-х вариантов
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Restart();
            for (int i = 0; i < r; i++)
            {
                _ = PointDistance1(ref masC[i], ref masC[i + 1]);
            }
            stopWatch.Stop();
            long m1 = stopWatch.ElapsedMilliseconds;
            stopWatch.Restart();
            for (int i = 0; i < r; i++)
            {
                _ = PointDistance2(masF[i], masF[i + 1]);
            }
            stopWatch.Stop();
            long m2 = stopWatch.ElapsedMilliseconds;
            stopWatch.Restart();
            for (int i = 0; i < r; i++)
            {
                _ = PointDistance3(masD[i], masD[i + 1]);
            }
            stopWatch.Stop();
            long m3 = stopWatch.ElapsedMilliseconds;
            stopWatch.Restart();
            for (int i = 0; i < r; i++)
            {
                _ = PointDistance4(masF[i], masF[i + 1]);
            }
            stopWatch.Stop();
            long m4 = stopWatch.ElapsedMilliseconds;
            // результаты
            Console.WriteLine("  Тест\t\tвремя");
            Console.WriteLine(" Тест № 1\t" + m1.ToString());
            Console.WriteLine(" Тест № 2\t" + m2.ToString());
            Console.WriteLine(" Тест № 3\t" + m3.ToString());
            Console.WriteLine(" Тест № 4\t" + m4.ToString());
            _ = Console.ReadLine();
        }
    }
}
