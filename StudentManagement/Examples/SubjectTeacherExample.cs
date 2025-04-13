using Swashbuckle.AspNetCore.Filters;
using StudentManagement.Models;

namespace StudentManagement.Examples
{
    public class SubjectTeacherExample : IExamplesProvider<SubjectTeacher>
    {
        public SubjectTeacher GetExamples()
        {
            return new SubjectTeacher
            {
                SubjectId = 1,
                TeacherId = 1
            };
        }
    }
}