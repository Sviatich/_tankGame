//Класс отвечающий за бота противника

using System;

namespace TankGame
{
    class Computer : IComputer
    {
        public void aiStep(Tank enemyTank, Tank myTank)
        {
            int rand = new Random().Next(2);
            if (rand > 0) //Делает выстрел
            {
                if (enemyTank.getAmmo() > 0)//Если боезапас не пустой, то стреляем
                {
                    enemyTank.shot(myTank);
                }
                else//Если боезапас пустой, то перезаряжаемся
                {
                    enemyTank.reload();
                }
            }
            else //Ремонтируется
            {
                if (enemyTank.getHealth() >= 70) //Если восстанавление здоровья не требуется, стреляем
                {
                    if (enemyTank.getAmmo() > 0) //Стреляем ели есть снаряды
                    {
                        enemyTank.shot(myTank);
                    }
                    else
                    {
                        enemyTank.reload();
                    }
                }
                else //Если здоровье не в максимуме, то возсстанавливаем N единиц
                {
                    enemyTank.repair();
                }
            }
        }


    }
}
