//Класс реализующий методы действий игрока

using System;

namespace TankGame
{
    public class Tank : ITank<Tank> //Реализация методов интерфейса ITank
    {
        public int iD { get; set; } //Индекс для вывода в консоль
        public double MyArmor { get; set; } //Количесто брони
        public double MyHealth { get; set; } //Количесто здоровья
        public int MyDamage { get; set; } //Количесто урона
        public int MyAmmo { get; set; } //Количесто снатядов
        public Tank(double myArmor, double myHealth, int myDamage, int myAmmo, int iD)  //Базовый конструктор
        {
            this.MyArmor = myArmor;
            this.MyHealth = myHealth;
            this.MyDamage = myDamage;
            this.MyAmmo = myAmmo;
            this.iD = iD;
        }
        public void GetStatus() //Выводим ткущее состояние экземпляров класса
        {
            if (this.iD == 0)
            { Console.WriteLine($"> Ваш танк. Броня: [{this.MyArmor}] Урон:  [{this.MyDamage}] Здоровье: [{this.MyHealth}] Кол-во снарядов: [{this.MyAmmo}]"); }
            else
            { Console.WriteLine($"> Вражеский танк. Броня: [{this.MyArmor}] Урон:  [{this.MyDamage}] Здоровье: [{this.MyHealth}] Кол-во снарядов: [{this.MyAmmo}]"); }
        }
        public void Shot(Tank enemy)//Метод выстрела
        {
            if (this.MyAmmo != 0)
            {
                this.MyAmmo--;
                int rand = new Random().Next(11);//Псевдослучайное значение служит для реализации механики попал/промахнулся
                if (rand <= 1)//Условие выполнения критического выстрела
                {
                    if (enemy.MyArmor > 0) //Попадание засчитано
                    { 
                        enemy.MyArmor -= this.MyDamage * 1.2; //Если броня не закончилась, то отнимаются очки брони по 30
                        if (enemy.MyArmor <= 0)
                        { enemy.MyArmor = 0; }
                    } 
                    else//Если броня закончилась, отнимаем отки здоровья по 30
                    { 
                        enemy.MyHealth -= this.MyDamage * 1.2;
                    } 
                    Console.WriteLine($"Нанесен критический урон {this.MyDamage * 1.2}. Нажмите кнопку для продолжения...");
                }
                if((rand <=2) && (rand > 1))
                { 
                    Console.WriteLine("Промах. Нажмите кнопку для продолжения..."); 
                }
                if(rand > 2)
                {
                    if (enemy.MyArmor > 0) //Попадание засчитано
                    { 
                        enemy.MyArmor -= this.MyDamage;  //Если броня не закончилась, то отнимаются очки брони по 30
                        if(enemy.MyArmor <= 0)
                        { enemy.MyArmor = 0; }
                    }
                    else
                    { 
                        enemy.MyHealth -= this.MyDamage;//Если броня закончилась, отнимаем отки здоровья по 30  
                    } 
                    Console.WriteLine($"Нанесено {this.MyDamage} урона. Нажмите кнопку для продолжения...");
                }
            }
            else
            {
                { Console.WriteLine("Кончились снаряды, обновите боезапас. Нажмите кнопку для продолжения..."); }
            }
        }
        public void Repair()//Метод починки
        {
            if (this.MyHealth < 100)
            {
                this.MyHealth += 20;//Восполняет 20 единиц здоровья после выполнения
                Console.WriteLine("Восстановлено 20 здоровья. Нажмите кнопку для продолжения...");
            }
            else 
            {
                Console.WriteLine("Максимум здоровье. Нажмите кнопку для продолжения...");
            }
        }
        public void Reload()//Метод перезарядки
        {
            this.MyAmmo += 5;//Пополняем 5 единиц боезапаса
            Console.WriteLine("Добавлено 5 снарядов. Нажмите кнопку для продолжения...");
        }
    }
}
