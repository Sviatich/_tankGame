//Интерфейс для класса Танк

using System;

namespace TankGame
{
    interface ITank
    {
        void getStatus();//Метод возвращает текущее состояние объекта
        void shot(Tank enemy);//Метод выстрела
        void repair();//Метод восполнения здоровья
        void reload();//Метод перезарядки
        double getHealth();//Метод возвращает текущее здоровье
        int getAmmo();//Метод возвращает текущее кол-во снарядов
    }
}
