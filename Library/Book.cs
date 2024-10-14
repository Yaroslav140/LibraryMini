namespace Library
{
    class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int Pages { get; set; }
        public int ShelvesNumber {  get; set; }
        public DateTime DataOfPublication { get; set; }

        public Book() { }
        public Book(string name, int pages, DateTime dataOfPublication, int shelvesNumber)
        {
            Name = name;
            Pages = pages;
            DataOfPublication = dataOfPublication;
            ShelvesNumber = shelvesNumber;
        }
    }
}
