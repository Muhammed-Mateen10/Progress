using Microsoft.CodeAnalysis.VisualBasic.Syntax;

namespace ProgressWebApplication.Models
{
    public class Course
    {
        public int Code { get; set; }
        public int CreditHours { get; set; }
        public string Name { get; set; }

        public Course(int code, int creditHours, string name)
        {
            Code = code;
            CreditHours = creditHours;
            Name = name;
        }
        public Course()
        {
            Code = 0;
            CreditHours = 0;
            Name = "";
        }
    }
}
