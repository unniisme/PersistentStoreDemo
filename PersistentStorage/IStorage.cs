namespace PersistentStorage
{
    public interface IStorage
    {
        void Save(string key, string value);
        string Get(string key);
        List<string> GetKeys();

        void AddListener(string listenerId, IStorageListener listener);
    }
}
