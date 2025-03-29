using StudentManagement.Models;

class Program
{
    static void Main(string[] args)
    {
        var student = new Student
        {
            StudentId = 1,
            FirstName = "John",
            LastName = "Doe",
            GroupId = 1
        };

        var group = new Group
        {
            GroupId = 1,
            Name = "Group A",
            Students = new List<Student> { student }
        };

        student.Group = group;

        Console.WriteLine($"Student: {student.FirstName} {student.LastName}, Group: {student.Group.Name}");
    }
}