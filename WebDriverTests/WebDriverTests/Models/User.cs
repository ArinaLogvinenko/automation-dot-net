namespace WebDriverTests.Models
{
    public class User
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }

        public User(string login, string password)
        {
            Login = login;
            Password = password;
        }

        public User(string login, string password, string address)
        {
            Login = login;
            Password = password;
            Address = address;
        }
    }
}
