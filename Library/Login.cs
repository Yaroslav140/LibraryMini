using Library.Model;
using static System.Console;

namespace Library
{
    static class Login
    {
        public static bool Authorization(List<User> user)
        {
            Write("Введите логин: ");
            string? login = ReadLine();
            Write("Введите пароль: ");
            string? password = ReadLine();

            foreach (var person in user)
            {
                if (person.Login == login && person.Password == password)
                {
                    WriteLine("Успешный вход!");
                    return true;
                }
                else
                {
                    WriteLine("Такого пользователя нет, зарегестируйте нового пользователя чтобы войти");
                    ReadKey();
                    Clear();
                }
            }
            return false;
        }

        public static bool Registration(List<User> user, UserModel userModel)
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

            foreach (var person in user)
            {
                if (person.Login == login && person.Password == password && person.UniqueKey == uniqueKey)
                {
                    WriteLine("Такой пользователь уже существует, повторите вход!");
                    ReadKey();
                    Clear();
                    Registration(user, userModel);
                    return false;
                }
                if (person.Login != login && person.Password != password && person.UniqueKey != uniqueKey)
                {
                    User people = new(name, firstName, uniqueKey, login, password, Role.Пользователь);
                    user.Add(people);
                    userModel.UsersList.Add(people);
                    userModel.SavePersonsToFile();
                    WriteLine("Новый пользователь успешно добавлен!");
                    return true;
                }
            }
            return true;
        }
    }
}
