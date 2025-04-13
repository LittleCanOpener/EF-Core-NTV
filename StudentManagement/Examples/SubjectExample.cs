using Swashbuckle.AspNetCore.Filters;
using StudentManagement.Models;

namespace StudentManagement.Examples
{
    public class SubjectExample : IExamplesProvider<Subject>
    {
        public Subject GetExamples()
        {
            return new Subject
            {
                Name = "Mathematics"
            };
        }
    }
}