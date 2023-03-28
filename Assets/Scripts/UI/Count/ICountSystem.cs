namespace UI.Count
{
    public interface ICountSystem
    {
        int Count { get; }
        void AddCount(int addedCount);
        void RemoveCount(int removedCount);
        void SaveCount();
    }
}