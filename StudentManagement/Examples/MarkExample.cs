using Swashbuckle.AspNetCore.Filters;
using StudentManagement.Models;

namespace StudentManagement.Examples
{
    public class MarkExample : IExamplesProvider<Mark>
    {
        public Mark GetExamples()
        {
            return new Mark
            {
                Value = 85,
                StudentId = 1,
                SubjectId = 1
            };
        }
    }
}