namespace ProgressWebApplication.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string LoginPassword { get; set; }
        public Teacher(int id, string name, string email, string loginPassword)
        {
            Id = id;
            Name = name;
            Email = email;
            LoginPassword = loginPassword;
        }
        public Teacher()
        {
            Id = 0;
            Name = "";
            Email = "";
            LoginPassword = "";
        }
    }
}
