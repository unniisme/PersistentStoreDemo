using PersistentStorage;

namespace CliApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Initializing In Memory Storage");

            IStorage storage = StorageFactory.CreateStorage();
            IStorageListener listener = new StorageListener();
            storage.AddListener("CliApp", listener);

            string? input = Console.ReadLine();
            while (input != "q") 
            {
                string[] tokens = input.Split(new char[] { ',' }, 2);
                if (tokens.Length == 1)
                {
                    if (storage.GetKeys().Contains(tokens[0]))
                    {
                        string word = storage.Get(tokens[0]);
                        Console.WriteLine(tokens[0] + " : " + word);
                    }
                    else
                    Console.WriteLine("Word not present in storage");
                }
                else if (tokens.Length == 2)
                {
                    storage.Save(tokens[0], tokens[1]);
                    Console.WriteLine("Wrote { " + tokens[0] + " : " + tokens[1] + " } to storage" );
                }
                input = Console.ReadLine();
            }
        }
    }
}