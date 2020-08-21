using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace VisualBubbleSort
{
    public class BubbleSorter<T>
    {
        // Событие о перестановке элементов в коллекции
        public event EventHandler<MovedElementEventArgs<T>> ElementMoved;

        public void Sort(IList<T> items, Func<T, T, bool> compareFunc)
        {
            int count;
            T temp;

            for (int i = 0; i < items.Count - 1; i++)
            {
                count = 0;
                for (int j = 0; j < items.Count - 1; j++)
                {
                    if (compareFunc(items[j], items[j + 1]))
                    {
                        temp = items[j];
                        items[j] = items[j + 1];
                        items[j + 1] = temp;
                        OnElementMoved(items, j, j + 1);
                        ++count;
                    }
                }
                if (count == 0) break;
            }
        }

        private void OnElementMoved(IList<T> items, int fromIndex, int toIndex)
        {
            EventHandler<MovedElementEventArgs<T>> handler = ElementMoved; // для потокобезопасности
            if (handler != null) handler(this, new MovedElementEventArgs<T>(new ReadOnlyCollection<T>(items), new int[] { fromIndex, toIndex })); // ReadOnlyCollection, чтобы при обработке события нельзя было испортить коллекцию

            // Аналогичный результат с использованием синтаксиса C# 6
            // ElementMoved?.Invoke(this, new MovedElementEventArgs<T>(new ReadOnlyCollection<T>(items), new int[] { fromIndex, toIndex }));
        }
    }
}
