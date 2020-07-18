using System;
using Xunit;

namespace EadAdmin.DomainTest.CourseTest
{
    public class CourseStorageTest
    {
        [Fact]
        public void ShouldAddCourse()
        {
            var courseDto = new CourseDto
            {
                Name = "C#",
                Description = "A CSharp´course",
                WorkLoad = 50.5,
                TargetAudienceId = 1,
                Price = 30.5
            };

            var storageCourse = new StorageCourse();
            storageCourse.Store(courseDto);
        }
    }
}
