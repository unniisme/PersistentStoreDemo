namespace PersistentStorage
{
    public interface IStorageListener
    {
        void OnStorageUpdate(string key, string value);
    }
}