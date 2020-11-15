//Класс наследующий интерфейсы ITank и IComputer и объединяет возможности классов в себе. 
//Представляет из себя бота, который играет сам с собой. Для запуска требуется в MAIN методе закомментировать 1 раздел, и раскомментировать 2 раздел.

using System;

namespace TankGame
{
    class BotTank : IComputer<BotTank>, ITank<BotTank>
    {
        public int iD { get; set; } //Индекс для вывода в консоль
        public double MyArmor { get; set; } //Количесто брони
        public double MyHealth { get; set; } //Количесто здоровья
        public int MyDamage { get; set; } //Количесто урона
        public int MyAmmo { get; set; } //Количесто снатядов
        public BotTank(double myArmor, double myHealth, int myDamage, int myAmmo, int iD)  
        {
            this.MyArmor = myArmor;
            this.MyHealth = myHealth;
            this.MyDamage = myDamage;
            this.MyAmmo = myAmmo;
            this.iD = iD;
        }
        public void AiStep(BotTank enemyTank, BotTank myTank)
        {
            while(true)
            {
                int rand = new Random().Next(2);//Псевдослучайное число обуславливает какое действие выполнит бот
                Console.Clear();//Очистка консоли
                enemyTank.GetStatus();//Вывод текущего состояния бота 1
                myTank.GetStatus();//Вывод текущего состояния бота 2
                Console.WriteLine("Ходит бот 1\n");
                if (rand > 0)//Либо выстрел, либо ремонт
                { enemyTank.Shot(myTank); }
                else
                { enemyTank.Repair(); }
                rand = new Random().Next(2);//Обновляем псевдослучайное число и выполняем все вышеперечисленное для бота 2
                Console.Clear();
                enemyTank.GetStatus();
                myTank.GetStatus();
                Console.WriteLine("Ходит бот 2\n");
                if (rand > 0)
                { myTank.Shot(enemyTank); }
                else
                { myTank.Repair(); }


                if (enemyTank.MyHealth <= 0)//Если здоровье кончилось у бота 1, он проиграл
                {
                    Console.Clear();
                    Console.WriteLine("Бот 1 проиграл\n");
                    Console.ReadKey();
                    break;
                }
                if (myTank.MyHealth <= 0)//Если здоровье кончилось у бота 2, он проиграл
                {
                    Console.Clear();
                    Console.WriteLine("Бот 2 проиграл\n");
                    Console.ReadKey();
                    break;
                }
            }
        }
        public void GetStatus() //Вывод текущего состояния экземпляра в консоль
        { Console.WriteLine($"> Состояние бота {this.iD}: Здоровье: [{this.MyHealth}] Урон: [{this.MyDamage}] Кол-во снарядов: [{this.MyAmmo}]"); }
        public void Reload() //Восстановление 5 единиц боезапаса
        {

            Console.WriteLine("Восстановлено 5 единиц боезапаса. Для продолжения нажмите..");
            Console.ReadKey();
        }
        public void Repair() //Восстановление 20 единиц здоровья
        {
            if (this.MyHealth <= 70)
            {
                //this.health += 20;
                Console.WriteLine("Восстановлено 20 единиц здоровья. Для продолжения нажмите..");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Максимальный запас здоровья. Для продолжения нажмите..");
                Console.ReadKey();
            }
        }

        public void Shot(BotTank enemy) //Выстрел бота по боту
        {
            enemy.MyHealth -= this.MyDamage;
            Console.WriteLine($"Нанесено {enemy.MyDamage} урона. Для продолжения нажмите..");
            Console.ReadKey();
        }
    }
}
