//Класс отвечающий за бота противника

using System;

namespace TankGame
{
    class Computer : IComputer<Tank>
    {
        public void AiStep(Tank enemyTank, Tank myTank)
        {
            int rand = new Random().Next(2);
            if (rand > 0) //Делает выстрел
            {
                if (enemyTank.MyAmmo > 0)//Если боезапас не пустой, то стреляем
                {
                    enemyTank.Shot(myTank);
                }
                else//Если боезапас пустой, то перезаряжаемся
                {
                    enemyTank.Reload();
                }
            }
            else //Ремонтируется
            {
                if (enemyTank.MyHealth >= 70) //Если восстанавление здоровья не требуется, стреляем
                {
                    if (enemyTank.MyAmmo > 0) //Стреляем ели есть снаряды
                    {
                        enemyTank.Shot(myTank);
                    }
                    else
                    {
                        enemyTank.Reload();
                    }
                }
                else //Если здоровье не в максимуме, то возсстанавливаем N единиц
                {
                    enemyTank.Repair();
                }
            }
        }


    }
}
