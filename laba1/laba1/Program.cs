using System;
using System.Diagnostics;
using System.Dynamic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Xml.Linq;
using Microsoft.VisualBasic.CompilerServices;

namespace laba1
{
    class Program
    {
        static void Main(String[] args)
        {
            Console.WriteLine("Введите номер задания/функции:\n");
            Console.WriteLine(" 1)Типы.\n 2)Строки.\n 3)Массивы.\n 4)Кортежи.\n 5)Работа с массивами.\n 6)Работа с unchecked.\n 7)Работа с checked.\n");
            int num_switch = Convert.ToInt32(Console.ReadLine());
                switch (num_switch)
                {
                    case 1:
                        func1(args);
                        break;

                    case 2:
                        func2(args);
                        break;

                    case 3:
                        func3(args);
                        break;

                    case 4:
                        func4(args);
                        break;

                    case 5:
                        func5(args);
                        break;
                    case 6:
                        func6(args);
                        break;
                case 7:
                    func7(args);
                    break;

            }
        }

        static void func1(string[] args)
        {
            Console.WriteLine("Тип bool:");
            bool tf = true;
            Console.WriteLine(tf ? "True" : "False");
            byte a = 16;
            Console.WriteLine("Тип byte:");
            Console.WriteLine(a);
            Console.WriteLine("Тип sbyte:");
            sbyte b = -128;
            Console.WriteLine(b);
            Console.WriteLine("Тип Char:");
            char c = 'a';
            Console.WriteLine(c);
            Console.WriteLine("Тип decimal:");
            decimal d = 42.03M;
            Console.WriteLine(d);
            Console.WriteLine("Тип double:");
            double e = 5466546;
            Console.WriteLine(e);
            Console.WriteLine("Тип float:");
            float f = 3646.36F;
            Console.WriteLine(f);
            Console.WriteLine("Тип int:");
            int g = 15;
            Console.WriteLine(g);
            Console.WriteLine("Тип uint:");
            uint i = 44;
            Console.WriteLine(i);
            Console.WriteLine("Тип long:");
            long l = -475643;
            Console.WriteLine(l);
            Console.WriteLine("Тип ulong:");
            ulong ul = 47564;
            Console.WriteLine(ul);
            Console.WriteLine("Тип short");
            short sh = -23;
            Console.WriteLine(sh);
            Console.WriteLine("Тип ushort:");
            ushort ush = 23;
            Console.WriteLine(ush);
            Console.WriteLine("----------------------");
            Console.WriteLine("Явное преобразование");
            Console.WriteLine("До преобразования: " + sh + " " + sh.GetType());
            int shint = (int)sh;
            Console.WriteLine("После преобразования: " + shint + " " + shint.GetType());
            Console.WriteLine("Неявное преобразование");
            int aint = 11;
            Console.WriteLine("До преобразования: " + aint + " " + aint.GetType());
            long along = aint;
            Console.WriteLine("После преобразования: " + along + " " + along.GetType());
            Console.WriteLine("----------------------");
            Console.WriteLine("Работа с неявно типизированной переменной");
            var nt = 656;
            Console.WriteLine("Переменнная: " + nt + "Её тип: " + nt.GetType());
            Console.WriteLine("----------------------");
            Console.WriteLine("Работа с null");
            string str0 = null;
            if(str0 == null)
            {
                Console.WriteLine("Value is null");

            }
            else
            {
                Console.WriteLine(str0);
            }
            Console.WriteLine("----------------------");
            Console.WriteLine("Упаковка/Распаковка");
            int x = 15;
            object box = x;
            int ubox = (int)box;
            Console.WriteLine("Распакованная переменная: " + ubox);
            Console.WriteLine("----------------------");

        }

        static void func2(string[] args)
        {
            Console.WriteLine("Работа со строками");
            Console.WriteLine("Введите строку:");
            string str1 = Console.ReadLine();
            Console.WriteLine("Введите строку:");
            string str2 = Console.ReadLine();
            Console.WriteLine("После сравнения строк получаем :" + str1==str2);
            Console.WriteLine("----------------------");
            string s1 = "Мороз Егор Андреевич ";
            string s2 = "2 курс 3 группа ";
            string s3 = "Белорусский Государственный Технологический Университет ";
            Console.WriteLine("Первая строка: " + s1);
            Console.WriteLine("Вторая строка: " + s2);
            Console.WriteLine("Третья строка: " + s3);
            Console.WriteLine("Сложение строк: " + (s1 + s2 + s3));
            Console.WriteLine("----------------------");
            Console.WriteLine("Выделие строки: " + s1.Substring(0,5));
            Console.WriteLine("----------------------");
            Console.WriteLine("Копирование строки: ");
            Console.WriteLine("Введите строку для копирования");
            string strcopy = Console.ReadLine();
            string strcopy1 = strcopy.Substring(0, strcopy.Length);
            Console.WriteLine("Скопированная строка: " + strcopy1);
            Console.WriteLine("----------------------");
            Console.WriteLine("Разделение строки на слова");
            string[] mystring = s1.Split(' ');
            for(int i = 0; i <= 2; i++)
            {
                Console.WriteLine(mystring[i]);
            }
            Console.WriteLine("----------------------");
            string vst = s2.Insert(6, s1);
            Console.WriteLine("После вставки получаем: " + vst);
            Console.WriteLine("----------------------");
            vst = vst.Remove(2, 9);
            Console.WriteLine("После удаление получаем: " + vst);
            Console.WriteLine("----------------------");
            Console.WriteLine("Интерполирование строк: ");
            Console.WriteLine($"Привет, я - {s1} и я учусь в {s3}");
            Console.WriteLine("----------------------");
            string st1 = "";
            string st2 = null;
            Console.WriteLine("Проверяем первую строку:");
            Console.WriteLine(string.IsNullOrEmpty(st1));
            Console.WriteLine("Проверяем вторую строку:");
            Console.WriteLine(string.IsNullOrEmpty(st2));
            Console.WriteLine("----------------------");
            Console.WriteLine("StringBuilder");
            StringBuilder sb = new StringBuilder("My name i's Egor");
            sb.Remove(4, 8);
            Console.WriteLine("После удаления символов " + sb);
            sb.Insert(0, "Hello, ");
            sb.Insert(sb.Length, " poka");
            Console.WriteLine("После изменения строки: " + sb);
            Console.WriteLine("----------------------");



        }

        static void func3(string[] args)
        {
            Console.WriteLine("Работа с массивами");
            Console.WriteLine("Двумерный массив");
            Console.WriteLine("Введите размерность массива");
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            int[,] mass = new int[n, m];
            Random rand = new Random();
            Console.WriteLine("Вывод двумерного массива:");
            for (int i = 0; i < n; i++) {
                for(int j = 0; j < m; j++)
                {
                    mass[i, j] = rand.Next(0, 10);
                    Console.Write("{0}\t", mass[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine("----------------------");
            Console.WriteLine("Работа с одномерным массивом:");
            string[] mass1 = { "Moros", "Egor", "Andreevitch" };
            Console.WriteLine("Вывод одномерного массива: ");
            for(int i=0; i< mass1.Length; i++)
            {
                Console.WriteLine(mass1[i]);
            }
            Console.WriteLine("Длина массива - " + mass1.Length);
            Console.WriteLine("Какой эллемент вы хотите заменить?");
            int repl = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите новый эллемент: ");
            string ell = Console.ReadLine();
            mass1[repl] = ell;
            Console.WriteLine("Получившийся массив: ");
            for (int i = 0; i < mass1.Length; i++)
            {
                Console.WriteLine(mass1[i]);
            }
            Console.WriteLine("----------------------");
            Console.WriteLine("Ступеньчатый массив");
            int[][] mass2 = new int[3][];
            mass2[0] = new int[2] { 1, 2 };
            mass2[1] = new int[3] { 1, 2, 3 };
            mass2[2] = new int[4] { 1, 2, 3, 4 };
            for (int i = 0; i < mass2.Length; i++)
            {
                for (int j = 0; j < mass2[i].Length; j++)
                {
                    Console.Write($"{mass2[i][j]} \t");
                }
                Console.WriteLine();
            }
            Console.WriteLine("----------------------");
            Console.WriteLine("Массив, записанный в var: ");
            var mass3 = new[] {5, 4, 3, 2, 1};
            for(int i=0; i < mass3.Length; i++)
            {
                Console.Write(mass3[i] + " ");
            }
            Console.WriteLine("----------------------");
        }

        static void func4(string[] args)
        {
            (int, string, char, string, ulong) kort = (18, "Годиков", 'я', "кушаю", 373249);
            Console.WriteLine(kort);
            Console.WriteLine(kort.Item1 + " " + kort.Item2 + " " + kort.Item4);
            Console.WriteLine("----------------------");
            (int a, byte b) one = (5, 25);
            (int a, byte b) two = (5, 25);
            Console.WriteLine(one == two);
            Console.WriteLine("----------------------");

        }

        static void func5(string[] args)
        {
            Console.WriteLine("Создание кортежа:");
            int[] mas = new int[] { 1, 2, 3, 4, 5 };
            string str = "Egor";

            (int, int, int, char) kort = (mas.Min() , mas.Max() , mas.Sum() , str.First());
            Console.WriteLine("Получившийся кортеж:" + kort);

        }

        static void func6(string[] args)
        {
            int ten = 10;
            unchecked
            {
                int i1 = 2147483647 + ten;
                Console.WriteLine(i1);
            }
        }

        static void func7(string[] args)
        {
            int ten = 10;
            checked
            {
                int i1 = 2147483647 + ten;
                Console.WriteLine(i1);
            }
        }
    }
}
