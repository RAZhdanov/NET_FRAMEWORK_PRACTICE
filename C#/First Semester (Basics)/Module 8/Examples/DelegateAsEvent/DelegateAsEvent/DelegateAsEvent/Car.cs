using System;

namespace DelegateAsEvent
{
    class Car
    {
        private const float LitersPer100 = 10;
        private float _petrol = 50;

        public PetrolIsOver PetrolIsOverCallBack { get; set; } // public делегат для обратного вызова

        public void Drive(int km)
        {
            for (int i = km; i > 0; i--)
            {
                Console.WriteLine($"Осталось проехать {i} км");
                _petrol -= 1 * LitersPer100 / 100;
                if (_petrol <= 0)
                {
                    PetrolIsOverCallBack("Приехали"); // Обратный вызов. Бензин закончился
                    break;
                }
                if (_petrol < 5) PetrolIsOverCallBack("Бензин заканчивается"); // Обратный вызов. Бензин на исходе
            }
        }
    }

    public delegate void PetrolIsOver(string message); // описание делегата
}