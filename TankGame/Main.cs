//Входная точка в игру

using System;

namespace TankGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Нажмите чтоб начать игру..");
            Console.ReadKey();
            Console.Clear();
            Tank myTank = new Tank (100, 100, 30, 5, 0); //Задаем начальные значения для здоровья, брони и урона.
                                                         //Если аргумент №5 соответствует 0, то это танк игрока, если 1 - компьютера. 
            Tank enemyTank = new Tank(100, 100, 30, 5, 1); //Задаем начальные значения для здоровья, брони и урона
            
            GameBody.open(myTank, enemyTank);//Вызов игрового меню
        }
    }
}
