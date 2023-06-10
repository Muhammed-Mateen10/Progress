namespace ProgressWebApplication.Models
{
    public class Student
    {
         public int Id { get; set; }
        public string Name { get; set; }
        public string LoginPassword { get; set; }
        public List<Course> courses;


        public Student(int id, string name, string loginpassword)
        {
            this.Id = id;
            this.Name = name;
            this.LoginPassword = loginpassword;
            this.courses = new List<Course>();
        }
        public Student() {
            Id = 0;
            Name = "";
            LoginPassword = "";
            courses = new List<Course>();
        }
    }
}
