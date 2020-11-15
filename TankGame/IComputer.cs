//Интерфейс для класса комьютер

using System;

namespace TankGame
{
    interface IComputer<T>
    {
        void AiStep(T enemyTank, T myTank); //Метод определяющий действия бота Танка
    }
}
