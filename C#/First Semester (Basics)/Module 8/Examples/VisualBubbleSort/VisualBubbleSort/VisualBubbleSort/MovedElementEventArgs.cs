using System;
using System.Collections.ObjectModel;

namespace VisualBubbleSort
{
    public class MovedElementEventArgs<T> : EventArgs
    {
        public MovedElementEventArgs(ReadOnlyCollection<T> collection, int[] movedElementIndexes)
        {
            Collection = collection;
            MovedElementIndexes = movedElementIndexes;
        }
        public ReadOnlyCollection<T> Collection { get; private set; }

        public int[] MovedElementIndexes { get; private set; }
    }
}
