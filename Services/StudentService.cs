using BlazorApp1.Models;


public class StudentService
{
    private List<Student> _students = new List<Student>
    {
        new Student { Id = 1, FullName = "Иванов Иван", AverageScore = 4.8 },
        new Student { Id = 2, FullName = "Петрова Анна", AverageScore = 5.0 },
        new Student { Id = 3, FullName = "Сидоров Алексей", AverageScore = 3.9 }
    };

    private int _nextId = 4; // 

    public List<Student> GetStudents() => _students;

    public List<Student> GetScholarshipStudents() =>
        _students.Where(s => s.IsOnScholarship).ToList();

    public void AddStudent(Student student)
    {
        student.Id = _nextId++;
        _students.Add(student);
    }

    public void UpdateStudentScore(int id, double newScore)
    {
        var student = _students.FirstOrDefault(s => s.Id == id);
        if (student != null)
        {
            student.AverageScore = Math.Clamp(newScore, 0, 5); // Ограничиваем балл от 0 до 5
        }
    }

    public void RemoveNonScholarshipStudents()
    {
        _students.RemoveAll(s => !s.IsOnScholarship);
    }

    public decimal GetTotalScholarshipAmount() =>
        GetScholarshipStudents().Sum(s => s.Scholarship);
}