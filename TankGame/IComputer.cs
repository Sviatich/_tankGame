//Интерфейс для класса комьютер

using System;

namespace TankGame
{
    interface IComputer
    {
        void aiStep(Tank enemyTank, Tank myTank); //Метод определяющий действия бота Танка
    }
}
