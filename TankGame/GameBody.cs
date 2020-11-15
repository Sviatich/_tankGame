//Класс меню, также по сути представляющий основное тело игры, отвечает за запуск
//действий, выбранных игроком.
//Управляет последовательностью ходов игрок/бот

using System;

namespace TankGame
{
    class GameBody
    {
        public static bool Open(Tank myTank, Tank enemyTank)//Функция вызова контекстного меню
        {
            if(myTank.MyHealth <= 0)//Проверка на поражение
            {
                Console.WriteLine("Вы проиграли!");
                Console.WriteLine("\nНажмите для выхода..");
                Console.ReadKey();
                return true;
            }
            if(enemyTank.MyHealth <= 0)//Проверка на победу
            {
                Console.WriteLine("Победа!");
                Console.WriteLine("\nНажмите для выхода..");
                Console.ReadKey();
                return true;
            }
            Console.ForegroundColor = ConsoleColor.Green;
            myTank.GetStatus(); //Выводим текущее состояние нашего танка
            Console.ForegroundColor = ConsoleColor.Red;
            enemyTank.GetStatus(); //Выводим текущее состояние вражеского танка
            Console.ResetColor();
            Console.WriteLine("\nВаш ход!\n");
            int int_choice;
            Show(); //Выводим варианты действий
            try//Отлавливаем исключения при вводе данных
            {
                string _choice = Console.ReadLine(); //Выбираем с клавиатуры режим
                int_choice = Convert.ToInt32(_choice); //Преобразуем в int для более удобной работы
                switch (int_choice) //Рекурсивный выбор 
                {
                    case 1://Выстрел
                        myTank.Shot(enemyTank);//Игрок стреляет
                        EnemyStep(myTank,enemyTank);
                        break;
                    case 2://Починка
                        myTank.Repair();//Игрок ремонтируется
                        EnemyStep(myTank, enemyTank);
                        break;
                    case 3://Перезарядка
                        myTank.Reload();
                        EnemyStep(myTank, enemyTank);
                        break;
                    case 4://Выход
                        break;
                    default://Неверный ввод
                        Console.WriteLine("Неверный ввод. Нажмите чтоб продолжить..");
                        Console.ReadKey();
                        Console.Clear();
                        Open(myTank, enemyTank);
                        break;
                }
            }
            catch(System.FormatException)//Перезапуск меню при ошибке ввода
            {
                Console.WriteLine("Неверный ввод. Нажмите чтоб продолжить..");
                Console.ReadKey();
                Console.Clear();
                Open(myTank, enemyTank);//Перезапуск хода путем вызова игрового меню
            }
        return true;
        }
        public static void Show() //Вывод всех возможных действий
        {
            Console.WriteLine("1.Выстрел\n2.Ремонт\n3.Перезарядка\n4.Завершить бой");
        }
        public static void EnemyStep(Tank myTank, Tank enemyTank)
        {
            Computer Call = new Computer();
            Console.ReadKey();//Передача хода компьютеру
            Console.Clear();//Очистка консольного окна
            Console.ForegroundColor = ConsoleColor.Green;//Красим текст в зеленый
            myTank.GetStatus(); //Выводим текущее состояние нашего танка
            Console.ForegroundColor = ConsoleColor.Red;//Красим текст в красный
            enemyTank.GetStatus(); //Выводим текущее состояние вражеского танка
            Console.ResetColor();//Сброс цвета
            Console.WriteLine("\nХод противника!\n");//Индикация передачи хода
            Call.AiStep(enemyTank, myTank);//Компьютер совершает ход
            Console.ReadKey();//Передача хода игроку
            Console.Clear();//Очистка консоли
            Open(myTank, enemyTank);//Перезапуск хода путем вызова игрового меню
        }
    }
}
