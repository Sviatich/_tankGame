//Интерфейс для класса комьютер

using System;

namespace TankGame
{
    interface IComputer
    {
        static void aiStep(Tank enemyTank, Tank myTank) { }
    }
}
