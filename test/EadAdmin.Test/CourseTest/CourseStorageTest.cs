using Moq;
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

            var courseRepositoryMock = new Mock<IStorageRepository>();

            var courseStorage = new StorageCourse(courseRepositoryMock.Object);
        }
    }

    public class StorageCourse
    {
        public StorageCourse(IStorageRepository @object)
        {
            throw new NotImplementedException();
        }

        public void Store(CourseDto courseDto)
        {
            throw new NotImplementedException();
        }
    }

    public interface IStorageRepository
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
