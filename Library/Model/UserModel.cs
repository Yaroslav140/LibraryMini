﻿using Newtonsoft.Json;

namespace Library.Model
{
    class UserModel
    {
        private string filePath = "persons.json";
        public List<User> UsersList { get; private set; }

        public UserModel()
        {
            UsersList = LoadPersonsFromFile();
        }
        public int MaxId()
        {
            if (UsersList.Count == 0)
                return 0;
            return UsersList.Max(p => p.Id);
        }
        public void SavePersonsToFile()
        {
            string jsonData = JsonConvert.SerializeObject(UsersList.ToList());
            File.WriteAllText(filePath, jsonData);
        }

        private List<User> LoadPersonsFromFile()
        {
            if (!File.Exists(filePath))
                return new List<User>();

            string jsonData = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<List<User>>(jsonData) ?? new List<User>();
        }

        public void EditPerson(User editedPerson)
        {
            var admin = UsersList.FirstOrDefault(p => p.Id == editedPerson.Id);
            if (admin != null)
            {
                admin.FirstName = editedPerson.FirstName;
                admin.Name = editedPerson.Name;
                admin.UniqueKey = editedPerson.UniqueKey;
                admin.RolePeople = editedPerson.RolePeople;
            }
            SavePersonsToFile();
        }

        public void DeletePerson(User personToDelete)
        {
            UsersList.Remove(personToDelete);
            SavePersonsToFile();
        }
    }
}
