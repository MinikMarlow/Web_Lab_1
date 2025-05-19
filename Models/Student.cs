namespace BlazorApp1.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string? FullName { get; set; }
        public double AverageScore { get; set; }

        public bool IsOnScholarship => AverageScore >= 4.5;

        public decimal Scholarship
        {
            get
            {
                if (AverageScore >= 4.5 && AverageScore < 4.8) return 5000.00M;
                if (AverageScore >= 4.8 && AverageScore < 5.0) return 6000.00M;
                if (AverageScore == 5.0) return 7000.00M;
                return 0.00M;
            }
        }
    }
}