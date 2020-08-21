using System;

namespace Exceptions
{
    // Пример создания своего собственного класса исключения
    public class MustBeMoreThenZeroException : Exception
    {
        public MustBeMoreThenZeroException(int enteredValue)
    : base($"А-А-А. Число то должно быть больше 0. А ты вводишь {enteredValue}. Ай-я-яй, не хорошо.")
        {
            EnteredValue = enteredValue;
        }

        // расширяем базовый класс новым свойством.
        public int EnteredValue { get; } // Синтаксис C# 6 - readonly свойство
    }
}
