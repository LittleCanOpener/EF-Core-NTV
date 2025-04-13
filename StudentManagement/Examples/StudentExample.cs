using Swashbuckle.AspNetCore.Filters;
using StudentManagement.Models;

namespace StudentManagement.Examples
{
    public class StudentExample : IExamplesProvider<Student>
    {
        public Student GetExamples()
        {
            return new Student
            {
                FirstName = "John",
                LastName = "Doe",
                GroupId = 1
            };
        }
    }
}