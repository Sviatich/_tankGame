//Класс реализующий методы действий игрока

using System;

namespace TankGame
{
    public class Tank : ITank //Реализация методов интерфейса ITank
    {
        private int iD; //Индекс для вывода в консоль
        private double myArmor { get; set; } //Количесто брони
        private double myHealth { get; set; } //Количесто здоровья
        private int myDamage { get; set; } //Количесто урона
        private int myAmmo { get; set; } //Количесто снатядов
        public Tank(double myArmor, double myHealth, int myDamage, int myAmmo, int iD)  //Базовый конструктор
        {
            this.myArmor = myArmor;
            this.myHealth = myHealth;
            this.myDamage = myDamage;
            this.myAmmo = myAmmo;
            this.iD = iD;
        }
        public void getStatus() //Отладочный метод для проверки инициализации объекта
        {
            if (this.iD == 0)
            { Console.WriteLine($"> Ваш танк. Броня: [{this.myArmor}] Урон:  [{this.myDamage}] Здоровье: [{this.myHealth}] Кол-во снарядов: [{this.myAmmo}]"); }
            else
            { Console.WriteLine($"> Вражеский танк. Броня: [{this.myArmor}] Урон:  [{this.myDamage}] Здоровье: [{this.myHealth}] Кол-во снарядов: [{this.myAmmo}]"); }
        }
        public void shot(Tank enemy)//Метод выстрела
        {
            if (this.myAmmo != 0)
            {
                this.myAmmo--;
                int rand = new Random().Next(11);//Псевдослучайное значение служит для реализации механики попал/промахнулся
                if (rand <= 1)//Условие выполнения критического выстрела
                {
                    if (enemy.myArmor > 0) //Попадание засчитано
                    { 
                        enemy.myArmor -= this.myDamage * 1.2; //Если броня не закончилась, то отнимаются очки брони по 30
                        if (enemy.myArmor <= 0)
                        { enemy.myArmor = 0; }
                    } 
                    else//Если броня закончилась, отнимаем отки здоровья по 30
                    { 
                        enemy.myHealth -= this.myDamage * 1.2;
                    } 
                    Console.WriteLine($"Нанесен критический урон {this.myDamage * 1.2}. Нажмите кнопку для продолжения...");
                }
                if((rand <=2) && (rand > 1))
                { 
                    Console.WriteLine("Промах. Нажмите кнопку для продолжения..."); 
                }
                if(rand > 2)
                {
                    if (enemy.myArmor > 0) //Попадание засчитано
                    { 
                        enemy.myArmor -= this.myDamage;  //Если броня не закончилась, то отнимаются очки брони по 30
                        if(enemy.myArmor <= 0)
                        { enemy.myArmor = 0; }
                    }
                    else
                    { 
                        enemy.myHealth -= this.myDamage;//Если броня закончилась, отнимаем отки здоровья по 30  
                    } 
                    Console.WriteLine($"Нанесено {this.myDamage} урона. Нажмите кнопку для продолжения...");
                }
            }
            else
            {
                { Console.WriteLine("Кончились снаряды, обновите боезапас. Нажмите кнопку для продолжения..."); }
            }
        }
        public void repair()//Метод починки
        {
            if (this.myHealth < 100)
            {
                this.myHealth += 20;//Восполняет 10 HP после выполнения
                Console.WriteLine("Восстановлено 20 здоровья. Нажмите кнопку для продолжения...");
            }
            else 
            {
                Console.WriteLine("Максимум здоровье. Нажмите кнопку для продолжения...");
            }
        }
        public void reload()//Метод перезарядки
        {
            this.myAmmo += 5;//Пополняем боезапас
            Console.WriteLine("Добавлено 5 снарядов. Нажмите кнопку для продолжения...");
        }
        public double getHealth()//Возвращает значения здоровья
        {
            return this.myHealth;
        }
        public int getAmmo()//Возвращает значения кол-ва снарядов
        {
            return this.myAmmo;
        }
    }
}
