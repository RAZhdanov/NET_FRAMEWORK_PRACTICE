namespace Serialization
{
    public interface IProvider<T>
    {
        void Save(T valueToSave);
        T Load();
    }
}