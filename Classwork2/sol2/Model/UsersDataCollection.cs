namespace Classwork2.Model;

public class UsersDataCollection
{
    public List<User> Users { get; } =
    [
        new User
        {
            Name = "Anna",
            BirthDate = new DateTime(2020, 1, 1)
        },

        new User
        {
            Name = "John",
            BirthDate = new DateTime(2030, 5, 5)
        }
    ];
}