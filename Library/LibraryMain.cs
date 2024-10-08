using static System.Console;
using System.IO;

namespace Library
{
    class LibraryMain
    {
        private static List<People> personInLibary = new List<People>();
        private static string filePath = "person.json";
        private static void Main()
        {
            MainMenu();
        }

        private static void MainMenu()
        {
            while (true)
            {
                WriteLine("Добро пожаловать в библиотеку!");
                WriteLine("1.Вход\n2.Регестрация");
                string? choice = ReadLine();
                switch (choice)
                {
                    case "1":
                        Authorization();
                        break;
                    case "2":
                        Registration();
                        break;
                }
            }
        }
        private static void Authorization()
        {
            Write("Введите логин: ");
            string? login = ReadLine();
            Write("Введите пароль: ");
            string? password = ReadLine();

            foreach (var person in personInLibary)
            {
                //Нужно подключаться к файлу и от чаитать данные
                if (person.Login == login && person.Password == password)
                {
                    WriteLine("Успешный вход!");
                }
            }
            WriteLine("Такого пользователя нет, зарегестируйте нового пользователя чтобы войти");
            ReadKey();
            Clear();
            MainMenu();
        }

        private static void Registration()
        {
            Write("Введите ваше имя: ");
            string? name = ReadLine();
            Write("Введите вашу фамилию: ");
            string? firstName = ReadLine();
            Write("Введите логин: ");
            string? login = ReadLine();
            Write("Введите пароль: ");
            string? password = ReadLine();
            Write("Введите уникальную метку: ");
            string? uniqueKey = ReadLine();

            foreach (var person in personInLibary)
            {
                if (person.Login == login && person.Password == password && person.UniqueKey == uniqueKey)
                {
                    WriteLine("Такой пользователь уже существует, повторите вход!");
                    ReadKey();
                    Clear();
                    Registration();
                }
            }
            if (uniqueKey == "ADmIn")
            {
                People people = new Admin(name, firstName, password, login, uniqueKey);
                personInLibary.Add(people);
                SaveData<People>.SaveJSONFile(people);
                WriteLine("Новый админ успешно добавлен!");
            }
            else
            {
                People people = new User(name, firstName, password, login, uniqueKey);
                personInLibary.Add(people);
                SaveData<People>.SaveJSONFile(people);
                WriteLine("Новый пользователь успешно добавлен!");
            }
        }
    }
}
