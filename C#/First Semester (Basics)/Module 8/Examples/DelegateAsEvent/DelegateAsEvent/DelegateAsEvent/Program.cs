using System;

// Пример показывает проблемы при использовании public (экземпляра) делегата для генерации обратного вызова

namespace DelegateAsEvent
{
    class Program
    {
        static void Main()
        {
            Car opel = new Car {PetrolIsOverCallBack = Console.WriteLine}; // C# 6 возможна подписка на событие при инициализации объекта
            opel.Drive(600);
            Console.ReadLine();

            // Добавление подписки на обратный вызов еще на один метод
            opel.PetrolIsOverCallBack += message => Console.WriteLine($"Можно добавить подписку: {message}");
            opel.Drive(10);
            Console.ReadLine();

            // Но можно затереть все подписки, которые были сделаны ранее (возможно другими классами)
            opel.PetrolIsOverCallBack = message => Console.WriteLine("А Можно и затереть подписку");
            opel.Drive(10);
            Console.ReadLine();

            // Можно вообще сгенерировать обратный вызов вне класса, отвечающего за обратный вызов. Нарушение инкапсуляции
            opel.PetrolIsOverCallBack("Более того можно и самим вызвать callback, т.е. симулировать событие");

            Console.ReadLine();
        }
    }
}
