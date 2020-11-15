//Класс отвечающий за бота противника

using System;

namespace TankGame
{
    class Computer : IComputer
    {
        public static void aiStep(Tank enemyTank, Tank myTank)
        {
            int rand = new Random().Next(2);
            if (rand > 0) //Делает выстрел
            {
                if (enemyTank.getAmmo() > 0)
                {
                    enemyTank.shot(myTank);
                }
                else
                {
                    enemyTank.reload();
                }
            }
            else //Ремонтируется
            {
                if (enemyTank.getHealth() >= 70)
                {
                    if (enemyTank.getAmmo() > 0)
                    {
                        enemyTank.shot(myTank);
                    }
                    else
                    {
                        enemyTank.reload();
                    }
                }
                else
                {
                    enemyTank.repair();
                }
            }
        }


    }
}
