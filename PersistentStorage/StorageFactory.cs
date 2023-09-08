namespace PersistentStorage
{
    public static class StorageFactory // Factory
    {
        static IStorage? s_storage = null; // Singleton
        public static IStorage CreateStorage()
        {
            if (s_storage == null)
            {
                if (File.Exists("data.txt"))
                {
                    s_storage = new SimpleTextStorage();
                }
                else
                {
                    s_storage = new InMemoryStorage();
                }
            }

            return s_storage;
        }
    }
}
