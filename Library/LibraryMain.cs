using static System.Console;
using System.IO;
using Library.Model;

namespace Library
{
    class LibraryMain
    {
        private string? name = ReadLine() ?? "Пушкин";
        private int pages = int.Parse(ReadLine());
        private DateTime dateOfRelease = DateTime.Parse(ReadLine());
        private int shelvesNumber = int.Parse(ReadLine());

        private static List<User> peopleList;
        private static UserModel userModel = new UserModel();
        private static Server server;

        private static bool _isActiveMenu = true;
        private static bool _isActiveLibary = true;
        public static void Main(string[] args)
        {
            server = new Server(20);
            peopleList = userModel.UsersList;
            MainMenu();
        }

        private static void MainMenu()
        {
            while (_isActiveMenu)
            {
                WriteLine("Добро пожаловать в библиотеку!");
                WriteLine("1.Вход\n2.Регестрация\n3.Выход");
                string? choice = ReadLine();
                switch (choice)
                {
                    case "1":
                        if (Login.Authorization(peopleList))
                        {
                            Clear();
                            _isActiveMenu = false;
                            Menu();

                        }
                        else
                        {
                            MainMenu();
                        }
                        break;
                    case "2":
                        if(Login.Registration(peopleList, userModel))
                        {
                            Clear();
                            MainMenu();
                        }
                        else
                        {
                            MainMenu();
                        }
                        break;
                    case "3":
                        _isActiveMenu = false;
                        Clear();
                        break;
                    default:
                        WriteLine("Неккоректный ввод!");
                        MainMenu();
                        break;
                }
            }
        }

        private static void Menu()
        {
            while (_isActiveLibary)
            {
                WriteLine("1.Посмотреть весь каталог\n2.Добавить новую книгу на полку\n3.Убрать книгу с полки\n4.Уйти");
                var choice = ReadLine();
                switch (choice)
                {
                    case "1":
                        Clear();
                        server.DisplayLibrary();
                        Write("Нажмите чтобы продолжить...");
                        ReadKey();
                        break;
                    case "2":
                        WriteLine("Что за книгу вы хотите добавить?");
                        server.AddBookOnShelves(AddNewBook());
                        Write("Нажмите чтобы продолжить...");
                        ReadKey();
                        Clear();
                        break;
                    case "3":
                        Write("Скажите название книги или полку на котрой она стоит?");
                        server.DeleateBookOnShelves(RemoveBook());
                        break;
                    case "4":
                        _isActiveLibary = false;
                        _isActiveMenu = true;
                        MainMenu();
                        break;
                }
            }
        }

        private static Book AddNewBook()
        {
            Write("Название книги: ");
            string? name = ReadLine() ?? "Пушкин";
            Write("Колличество страниц: ");
            int pages = int.Parse(ReadLine());
            Write("Дата выпуска: ");
            DateTime dateOfRelease = DateTime.Parse(ReadLine());
            Write("На какую полку хотите поставить: ");
            int shelvesNumber = int.Parse(ReadLine());;

            return new Book(name, pages, dateOfRelease, shelvesNumber);
        }
        private static Book RemoveBook()
        {
            Write("Название книги: ");
            string? name = ReadLine() ?? "Пушкин";
            Write("На какой полке стоит книга: ");
            int shelvesNumber = int.Parse(ReadLine()); ;
            foreach (var book in server.Shelves)
            {
                if (book.Name == name && book.ShelvesNumber == shelvesNumber)
                {
                    return new Book(book.Name, book.Pages, book.DataOfPublication, book.ShelvesNumber);
                }
            }
            return null;
        }
    }
}
