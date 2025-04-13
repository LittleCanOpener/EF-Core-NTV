using Swashbuckle.AspNetCore.Filters;
using StudentManagement.Models;

namespace StudentManagement.Examples
{
    public class GroupExample : IExamplesProvider<Group>
    {
        public Group GetExamples()
        {
            return new Group
            {
                Name = "Group A"
            };
        }
    }
}