//Интерфейс для класса Танк

using System;

namespace TankGame
{
    interface ITank<T>
    {
        public int iD { get; set; } //Индекс для вывода в консоль
        public double MyArmor { get; set; } //Количесто брони
        public double MyHealth { get; set; } //Количесто здоровья
        public int MyDamage { get; set; } //Количесто урона
        public int MyAmmo { get; set; } //Количесто снатядов

        void GetStatus();//Метод возвращает текущее состояние объекта
        void Shot(T enemy);//Метод выстрела
        void Repair();//Метод восполнения здоровья
        void Reload();//Метод перезарядки
    }
}
