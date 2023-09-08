namespace PersistentStorage
{
    internal class SimpleTextStorage : IStorage
    {
        private string filePath;
        private Dictionary<string, IStorageListener> storageListeners;


        public SimpleTextStorage()
        {
            filePath = "data.txt";
            storageListeners = new Dictionary<string, IStorageListener>();
        }

        public SimpleTextStorage(string filePath)
        {
            this.filePath = filePath;
            storageListeners = new Dictionary<string, IStorageListener>();
        }

        private Dictionary<string, string> ReadStorageFile()
        {
            Dictionary<string, string> storageTable = new Dictionary<string, string>();

            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);
                foreach (string line in lines)
                {
                    string[] parts = line.Split(':');
                    if (parts.Length == 2)
                    {
                        storageTable[parts[0]] = parts[1];
                    }
                }
            }

            return storageTable;
        }

        private void WriteStorageFile(Dictionary<string, string> storageTable)
        {
            List<string> lines = new List<string>();
            foreach (var entry in storageTable)
            {
                lines.Add($"{entry.Key}:{entry.Value}");
            }
            File.WriteAllLines(filePath, lines);
        }

        public string Get(string key)
        {
            Dictionary<string, string> storageTable = ReadStorageFile();
            return storageTable[key];
        }

        public List<string> GetKeys()
        {
            Dictionary<string, string> storageTable = ReadStorageFile();
            return new List<string>(storageTable.Keys);
        }

        public void Save(string key, string value)
        {
            Dictionary<string, string> storageTable = ReadStorageFile();
            storageTable[key] = value;
            WriteStorageFile(storageTable);

            foreach (IStorageListener listener in storageListeners.Values)
            {
                listener.OnStorageUpdate(key, value);
            }
        }

        public void AddListener(string listenerId, IStorageListener listener)
        {
            storageListeners.Add(listenerId, listener);
        }
    }
}
