namespace StudentManagement.Models;

public class Subject
{
    public int SubjectId { get; set; }
    public required string Name { get; set; }
    public List<Mark> Marks { get; set; } = new();
    public List<SubjectTeacher> SubjectTeachers { get; set; } = new();
}