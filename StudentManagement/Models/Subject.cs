namespace StudentManagement.Models;
public class Subject
{
    public int SubjectId { get; set; }
    public required string Title { get; set; }
    public List<Mark> Marks { get; set; } = new List<Mark>();
    public List<SubjectTeacher> SubjectTeachers { get; set; } = new List<SubjectTeacher>();
}