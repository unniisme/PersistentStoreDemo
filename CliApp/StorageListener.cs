using PersistentStorage;

namespace CliApp
{
    internal class StorageListener : IStorageListener 
    {
        public StorageListener()
        {}

        public void OnStorageUpdate(string key, string value)
        {
            Console.WriteLine("Updated key " + key + " with value " + value);
        }
    }
}
