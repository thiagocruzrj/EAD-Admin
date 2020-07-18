using System;
using Xunit;

namespace EadAdmin.DomainTest.CourseTest
{
    public class CourseStorageTest
    {
        public readonly IStorageCourse _storageCourse;
        public CourseStorageTest(IStorageCourse storageCourse)
        {
            _storageCourse = storageCourse;
        }

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

            _storageCourse.Store(courseDto);
        }
    }

    public class StorageCourse
    {
        public void Store(CourseDto courseDto)
        {
            throw new NotImplementedException();
        }
    }

    public interface IStorageCourse
    {
        void Store(CourseDto courseDto);
    }

    public class CourseDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double WorkLoad { get; set; }
        public int TargetAudienceId { get; set; }
        public double Price { get; set; }
    }
}
