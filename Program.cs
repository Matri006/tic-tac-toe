using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Крестики_нолики
{
    class Program
    {
        static void Main(string[] args)
        {
            bool again = true;
            int cx = 0, c0 = 0;
            char winner = ' ';
            while (again) // повтор игры 
            {
                bool w = false;
                char player = 'x';
                int step = 1, k = 0;
                char[,] pole = new char[3, 3]; 
                for (int i = 0; i < 3; i++) // вывод и заполнение массива числами от 1 до 9
                {
                    for (int j = 0; j < 3; j++)
                    {
                        Console.Write("| {0 }", k + 1);
                        pole[i, j] = Convert.ToChar(49 + k);
                        k++;
                    }
                    Console.WriteLine("|");
                }
                while (!w && step <= 9) // проверка ходов
                {
                    bool inp = false;
                    int n = 0;
                    int x = 0, y = 0;
                    while (!inp)
                    {
                        Console.Write("ходит {0}{1}", player, ": ");
                        n = Convert.ToInt32(Console.ReadLine());
                        if (n % 3 == 0) // получение номера клетки, в которую польователь хочет сходить
                        {
                            x = (n / 3) - 1;
                            y = 2;
                        }
                        else
                        {
                            x = Convert.ToInt32(n / 3);
                            y = (n % 3) - 1;
                        }
                        if (n < 1 || n > 9 || pole[x, y] == 'x' || pole[x, y] == '0') // проверка на существоваие такой клетки
                        {
                            Console.WriteLine("Ошибка!!!");
                            inp = false;
                        }
                        else
                        {
                            inp = true;
                        }
                    }
                    Console.Clear();
                    for (int i = 0; i < 3; i++) // вывод нового массива с учётом хода пользователя
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            if (pole[i, j] == Convert.ToChar(48 + n)) pole[i, j] = Convert.ToChar(player);
                            Console.Write("| {0 }", pole[i, j]);
                        }
                        Console.WriteLine("|");
                    }
                    if (pole[0, 0] == pole[0, 1] && pole[0, 0] == pole[0, 2] || pole[1, 0] == pole[1, 1] && pole[1, 0] == pole[1, 2] || pole[2, 0] == pole[2, 1]
                        && pole[2, 0] == pole[2, 2] || pole[0, 0] == pole[1, 0] && pole[0, 0] == pole[2, 0] || pole[0, 1] == pole[1, 1] && pole[0, 1] == pole[2, 1] ||
                        pole[0, 2] == pole[1, 2] && pole[0, 2] == pole[2, 2] || pole[0, 0] == pole[1, 1] && pole[0, 0] == pole[2, 2] || pole[0, 2] == pole[1, 1] && pole[0, 2] == pole[2, 0]) w = true; // проверка на выигрыш

                    if (!w) // проверяет, есть ли победитель
                    {
                        if (player == 'x') player = '0'; else player = 'x'; // замена игроков
                        step++;
                    }
                    else
                    {
                        winner = player;
                        if (winner == 'x') cx++; else c0++;
                    }
                }
                if (!w && step >= 9) // проверка на ничью
                {
                    Console.WriteLine("Ничья!!!");
                }
                else
                {
                    Console.WriteLine("Победил {0}", winner, "!!!"); // вывод победителей, общего счёта
                }
                    Console.Write("Общий счёт ");
                    Console.WriteLine("{0}:{1}", cx, c0);
                    int a;
                    do
                    {
                        Console.WriteLine("Вы хотите сыграть ещё раз? 1 - да; 0 - нет."); // повтор игры
                        a = Convert.ToInt32(Console.ReadLine());
                    } while (a != 1 && a != 0);
                    if (a == 1)
                    {
                        again = true;
                        Console.Clear();
                    }
                    else if (a == 0)
                    {
                        again = false;
                        Console.WriteLine("Нажмите любуй клавишу для выхода");
                    }
                }
                Console.ReadKey();
            }
        }
    }

