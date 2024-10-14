using Library.Model;
using System;
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
            bool userFound = false;
            foreach (var person in user)
            {
                if (person.Login == login && person.Password == password)
                {
                    WriteLine("Успешный вход!");
                    return userFound = true;
                }
            }
            if (!userFound)
            {
                WriteLine("Такого пользователя нет, зарегестируйте нового пользователя чтобы войти");
                ReadKey();
                Clear();
            }
            return userFound;
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
                    return false;
                }
            }

            User people = new(name, firstName, uniqueKey, login, password, Role.Пользователь)
            {
               Id = userModel.MaxId() + 1
            };
            userModel.UsersList.Add(people);
            userModel.SaveUsersToFile();  

            WriteLine("Новый пользователь успешно добавлен!");
            ReadKey();
            Clear();

            return true;
        }

    }
}
