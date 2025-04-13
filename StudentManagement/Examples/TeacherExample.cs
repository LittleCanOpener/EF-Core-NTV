using Swashbuckle.AspNetCore.Filters;
using StudentManagement.Models;

namespace StudentManagement.Examples
{
    public class TeacherExample : IExamplesProvider<Teacher>
    {
        public Teacher GetExamples()
        {
            return new Teacher
            {
                FirstName = "Jane",
                LastName = "Smith"
            };
        }
    }
}