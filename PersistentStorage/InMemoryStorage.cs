namespace PersistentStorage
{
    internal class InMemoryStorage : IStorage
    {
        private Dictionary<string, string> storageTable;
        private Dictionary<string, IStorageListener> storageListeners;

        public InMemoryStorage() 
        {
            storageTable = new Dictionary<string, string>();
            storageListeners = new Dictionary<string, IStorageListener>();
        }
        public string Get(string key)
        {
            return storageTable[key];
        }

        public void Save(string key, string value) 
        {
            storageTable.Add(key, value);

            foreach (IStorageListener listener in storageListeners.Values) 
            {
                listener.OnStorageUpdate(key, value);
            }
        }

        public List<string> GetKeys()
        {
            return new List<string>(storageTable.Keys);
        }


        public void AddListener(string listenerId, IStorageListener listener)
        {
            storageListeners.Add(listenerId, listener);
        }
    }
}
