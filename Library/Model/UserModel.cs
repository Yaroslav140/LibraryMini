using Newtonsoft.Json;

namespace Library.Model
{
    class UserModel
    {
        private string filePath = "persons.json";
        public List<User> UsersList { get; private set; }

        public UserModel()
        {
            UsersList = LoadUsersFromFile();
        }
        public int MaxId()
        {
            if (UsersList.Count == 0)
                return 0;
            return UsersList.Max(p => p.Id);
        }
        public void SaveUsersToFile()
        {
            string jsonData = JsonConvert.SerializeObject(UsersList.ToList());
            File.WriteAllText(filePath, jsonData);
        }

        private List<User> LoadUsersFromFile()
        {
            if (!File.Exists(filePath))
                return [];

            string jsonData = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<List<User>>(jsonData) ?? new List<User>();
        }

        public void EditUser(User editedPerson)
        {
            Console.Write("Введите новое имя: ");
            string? name = Console.ReadLine();
            Console.Write("Введите вашу фамилию: ");
            string? firstName = Console.ReadLine();
            Console.Write("Введите логин: ");
            string? login = Console.ReadLine();
            Console.Write("Введите пароль: ");
            string? password = Console.ReadLine();

            if (editedPerson != null)
            {
                editedPerson.Name = name;
                editedPerson.FirstName = firstName;
                editedPerson.Login = login;
                editedPerson.Password = password;
            }
            SaveUsersToFile();
        }

        public void DeleteUser(User personToDelete)
        {
            UsersList.Remove(personToDelete);
            SaveUsersToFile();
        }
    }
}
