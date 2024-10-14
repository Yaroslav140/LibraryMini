
namespace Library
{
    class User
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? FirstName { get; set; }

        public string? UniqueKey { get; set; }
        public string? Login { get; set; }
        public string? Password { get; set; }
        public Role RolePeople { get; set; }

        public User(string? name, string? firstName, string? uniqueKey, string? login, string? password, Role role)
        {
            Name = name;
            FirstName = firstName;
            UniqueKey = uniqueKey;
            Login = login;
            Password = password;
            RolePeople = role;
        }


        public override string ToString() =>
            $"Id: {Id},\n Name: {Name},\n FirstName: {FirstName},\n UniqueKey: {UniqueKey},\n Login: {Login},\n Password: {Password},\n Role: {RolePeople}";
    }
}
