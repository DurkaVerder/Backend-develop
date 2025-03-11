namespace LabWork11
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int Age { get; set; }

        public User (int id, string name, int age)
        {
            Id = id;
            Name = name;
            Age = age;
        }
    }

    public class InputUser
    {
        public string Name { get; set; }

        public int Age { get; set; }

    }
}
