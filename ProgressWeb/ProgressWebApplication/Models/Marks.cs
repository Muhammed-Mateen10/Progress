namespace ProgressWebApplication.Models
{
    public class Marks
    {
        public int Code { get; set; }
       public int Mid1 { get; set; }
        public int Mid2 { get; set; }
        public int A1 { get; set; }
        public int A2 { get; set; }
        public int A3 { get; set; }
        public int A4 { get; set; }
        public int Final{ get; set; }
        public Marks(int code, int mid1, int mid2, int a1, int a2,int a3, int a4, int final)
        {
            Code = code;
            Mid1 = mid1;
            Mid2 = mid2;
            A1 = a1;
            A2 = a2;
            A3 = a3;
            A4 = a4;
            Final = final;
        }
        public Marks()
        {
            Code = 0;
            Mid1 = 0;
            Mid2 = 0;
            A1 = 0;
            A2 = 0;
            Final = 0;
            A3 = 0;
            A4 = 0;
        }


    }
}
