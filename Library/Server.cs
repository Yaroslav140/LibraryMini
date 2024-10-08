using System.Collections.Generic;

namespace Library
{
    class Server
    {
        private int _shelvesNumber;

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
        public Dictionary<Book, int> Shelves { get; private set; }

        public static bool IsActiveServer;
        public Server(int shelves)
        {
            Shelves = [];
            polks = new int[shelves, shelves];
            ShelvesNumber = shelves;
        }

        public void DisplayLibrary()
        {
            Console.Write("   "); 
            for (int j = 0; j < polks.GetLength(1); j++)
            {
                Console.Write($"{j:D2} "); 
            }
            Console.WriteLine(); 

     
            for (int i = 0; i < polks.GetLength(0); i++)
            {
                Console.Write($"{i:D2} "); 

                for (int j = 0; j < polks.GetLength(1); j++)
                {
                    Console.Write($"{polks[i, j],2} ");
                }

                Console.WriteLine(); 
            }
        }



        public int IncrementShelves(int incremetShelves) => ShelvesNumber = (incremetShelves > 0) ? ShelvesNumber + incremetShelves : ShelvesNumber;

        public void AddBookOnShelves(Book book, int numberShelves = 0)
        {
            if (polks[numberShelves, numberShelves] == 0)
            {
                Shelves.Add(book, numberShelves);
                polks[numberShelves, numberShelves] = 1;
                Console.WriteLine($"Книга {book.Name} стоит теперь на полке {numberShelves}!");
            }
            else
            {
                Console.WriteLine($"Полка {numberShelves} занята выберите другую!");
            }
        }

        public void DeleateBookOnShelves(Book book, int numberShelves)
        {
            if (polks[numberShelves, numberShelves] == 1)
            {
                Shelves.Add(book, numberShelves);
                polks[numberShelves, numberShelves] = 0;
                Console.WriteLine($"Книга {book.Name} теперь не стоит на полке {numberShelves}!");
            }
            else
            {
                Console.WriteLine($"Полка {numberShelves} пуста выберите другую!");
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
        }
    }
}
