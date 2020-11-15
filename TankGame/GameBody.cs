//Класс меню, также по сути представляющий основное тело игры, отвечает за запуск
//действий, выбранных игроком
//Управляет последовательностью ходов игрок/бот

using System;

namespace TankGame
{
    class GameBody
    {
        public static bool open(Tank myTank, Tank enemyTank)//Функция вызова контекстного меню
        {
            if(myTank.getHealth() <= 0)//Проверка на поражение
            {
                Console.WriteLine("Вы проиграли!");
                Console.WriteLine("\nНажмите для выхода..");
                Console.ReadKey();
                return true;
            }
            if(enemyTank.getHealth() <= 0)//Проверка на победу
            {
                Console.WriteLine("Победа!");
                Console.WriteLine("\nНажмите для выхода..");
                Console.ReadKey();
                return true;
            }
            Console.ForegroundColor = ConsoleColor.Green;
            myTank.getStatus(); //Выводим текущее состояние нашего танка
            Console.ForegroundColor = ConsoleColor.Red;
            enemyTank.getStatus(); //Выводим текущее состояние вражеского танка
            Console.ResetColor();
            Console.WriteLine("\nВаш ход!\n");
            int int_choice;
            show(); //Выводим варианты действий
            try//Отлавливаем исключения при вводе данных
            {
                string _choice = Console.ReadLine(); //Выбираем с клавиатуры режим
                int_choice = Convert.ToInt32(_choice); //Преобразуем в int для более удобной работы
                switch (int_choice) //Рекурсивный выбор 
                {
                    case 1://Выстрел
                        myTank.shot(enemyTank);//Игрок стреляет
                        enemyStep(myTank,enemyTank);
                        break;
                    case 2://Починка
                        myTank.repair();//Игрок ремонтируется
                        enemyStep(myTank, enemyTank);
                        break;
                    case 3://Перезарядка
                        myTank.reload();
                        enemyStep(myTank, enemyTank);
                        break;
                    default://Выход из игры
                        break;
                }
            }
            catch(System.FormatException)//Перезапуск меню при ошибке ввода
            {
                Console.WriteLine("Неверный ввод. Нажмите чтоб продолжить..");
                Console.ReadKey();
                Console.Clear();
                open(myTank, enemyTank);//Перезапуск хода путем вызова игрового меню
            }
        return true;
        }
        public static void show() //Вывод всех возможных действий
        {
            Console.WriteLine("1.Выстрел\n2.Починка\n3.Перезарядка\n4.Завершить бой");
        }
        public static void enemyStep(Tank myTank, Tank enemyTank)
        {
            Console.ReadKey();//Передача хода компьютеру
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            myTank.getStatus(); //Выводим текущее состояние нашего танка
            Console.ForegroundColor = ConsoleColor.Red;
            enemyTank.getStatus(); //Выводим текущее состояние вражеского танка
            Console.ResetColor();
            Console.WriteLine("\nХод противника!\n");//Индикация передачи хода
            Computer.aiStep(enemyTank, myTank);//Компьютер совершает ход
            Console.ReadKey();//Передача хода игроку
            Console.Clear();//Очистка консоли
            open(myTank, enemyTank);//Перезапуск хода путем вызова игрового меню
        }
    }
}
