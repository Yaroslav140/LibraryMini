namespace Library
{
    class Book
    {
        public int Id { get; private set; }
        public string? Name { get; private set; }

        public int Pages { get; private set; }
        public int ShelvesNumber {  get; private set; }
        public DateTime DataOfPublication { get; private set; }

        public Book() { }
        public Book(string? name, int pages, DateTime dataOfPublication, int shelvesNumber)
        {
            Id++;
            Name = name;
            Pages = pages;
            DataOfPublication = dataOfPublication;
            ShelvesNumber = shelvesNumber;
        }
    }
}
