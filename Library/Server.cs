using Newtonsoft.Json;

namespace Library
{
    class Server
    {
        private int _shelvesNumber;
        private static string filePath = "book.json";
        private static string shelvesFilePath = "shelves.json";
        public int ShelvesNumber
        {
            get { return _shelvesNumber; }
            private set
            {
                if (value > 0 && value <= 100)
                {
                    _shelvesNumber = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Полок может быть только от 0 до 100.");
                }
            }
        }
        public int[,] polks;
        public List<Book> Shelves { get; private set; }

        public Server(int shelves)
        {
            Shelves = LoadBooksFromFile();
            polks = LoadShelvesFromFile(shelves); 
            ShelvesNumber = shelves;
        }

        public void DisplayLibrary()
        {
            Console.Write("   ");
            for (int j = 0; j < polks.GetLength(1); j++)
            {
                Console.Write($"{j + 1:D2} ");
            }
            Console.WriteLine();

            for (int i = 0; i < polks.GetLength(0); i++)
            {
                Console.Write($"{i + 1:D2} ");
                for (int j = 0; j < polks.GetLength(1); j++)
                {
                    Console.Write($"{polks[i, j],2} ");
                }
                Console.WriteLine();
            }
        }

        public int IncrementShelves(int incremetShelves) => ShelvesNumber = (incremetShelves > 0) ? ShelvesNumber + incremetShelves : ShelvesNumber;

        public void AddBookOnShelves(Book book)
        {
            try
            {
                if (polks[book.ShelvesNumber, book.ShelvesNumber] == 0)
                {
                    Shelves.Add(book);
                    polks[book.ShelvesNumber - 1, book.ShelvesNumber - 1] = 1;
                    Console.WriteLine($"Книга {book.Name} стоит теперь на полке {book.ShelvesNumber}!");
                    SaveBooksToFile();
                    SaveShelvesToFile();
                }
                else
                {
                    Console.WriteLine($"Полка {book.ShelvesNumber} занята выберите другую!");
                }
            } catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void DeleateBookOnShelves(Book book)
        {
            if (polks[book.ShelvesNumber, book.ShelvesNumber] == 1)
            {
                Shelves.Remove(book);
                polks[book.ShelvesNumber, book.ShelvesNumber] = 0;
                Console.WriteLine($"Книга {book.Name} теперь не стоит на полке {book.ShelvesNumber}!");
                SaveBooksToFile();
                SaveShelvesToFile();
            }
            else
            {
                Console.WriteLine($"Полка {book.ShelvesNumber} пуста выберите другую!");
            }
        }

        public void DropAllLibary()
        {
            for (int i = 0; i < polks.GetLength(0); i++)
            {
                for (int j = 0; j < polks.GetLength(1); j++)
                {
                    polks[i, j] = 0;
                }
            }
            SaveShelvesToFile();
        }

        private void SaveBooksToFile()
        {
            string jsonData = JsonConvert.SerializeObject(Shelves.ToList());
            File.WriteAllText(filePath, jsonData);
        }

        private List<Book> LoadBooksFromFile()
        {
            if (!File.Exists(filePath))
                return new List<Book>();

            string jsonData = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<List<Book>>(jsonData) ?? new List<Book>();
        }

        private void SaveShelvesToFile()
        {
            string jsonData = JsonConvert.SerializeObject(polks);
            File.WriteAllText(shelvesFilePath, jsonData);
        }

        private int[,] LoadShelvesFromFile(int size)
        {
            if (!File.Exists(shelvesFilePath))
                return new int[size, size];

            string jsonData = File.ReadAllText(shelvesFilePath);
            return JsonConvert.DeserializeObject<int[,]>(jsonData) ?? new int[size, size];
        }
    }
}
