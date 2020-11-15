//Класс наследующий интерфейсы ITank и IComputer

using System;

namespace TankGame
{
    class AITank : IComputer, ITank
    {
        public void aiStep(Tank enemyTank, Tank myTank)
        {

        }

        public int getAmmo()
        {
            int A = 0;
            return A;
        }

        public double getHealth()
        {
            int A = 0;
            return A;
        }

        public void getStatus()
        {

        }

        public void reload()
        {

        }

        public void repair()
        {

        }

        public void shot(Tank enemy)
        {

        }
    }
}
