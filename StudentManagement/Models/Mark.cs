namespace StudentManagement.Models;
public class Mark
{
    public int MarkId { get; set; }
    public int StudentId { get; set; }
    public int SubjectId { get; set; }
    public DateTime Date { get; set; }
    public int MarkValue { get; set; }
    public Student? Student { get; set; }
    public Subject? Subject { get; set; } 
}