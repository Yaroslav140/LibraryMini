
namespace Library
{
    class User
    {
        public int Id { get; private set; }
        public string? Name { get; private set; }
        public string? FirstName { get; private set; }

        public string? UniqueKey { get; private set; }
        public string? Login { get; private set; }
        public string? Password { get; private set; }
        public Role RolePeople { get; private set; }
        public User(string? name, string? firstName, string? uniqueKey, string? login, string? password, Role role)
        {
            Id++;
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
