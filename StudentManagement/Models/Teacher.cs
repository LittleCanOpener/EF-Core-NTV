namespace StudentManagement.Models;
public class Teacher
{
    public int TeacherId { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public List<SubjectTeacher> SubjectTeachers { get; set; } = new List<SubjectTeacher>();
}