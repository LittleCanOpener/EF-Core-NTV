namespace StudentManagement.Models;

public class Group
{
    public int GroupId { get; set; }
    public required string Name { get; set; }
    public List<Student> Students { get; set; } = new();
}