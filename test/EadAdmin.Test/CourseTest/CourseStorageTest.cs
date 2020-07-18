using EadAdmin.Domain.Courses;
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

            var courseRepositoryMock = new Mock<ICourseRepository>();

            var courseStorage = new StorageCourse(courseRepositoryMock.Object);

            courseStorage.Store(courseDto);

            courseRepositoryMock.Verify(r => r.AddCourse(It.IsAny<Course>()));
        }
    }

    public class StorageCourse 
    {
        private readonly ICourseRepository _courseRepository;

        public StorageCourse(ICourseRepository courseRepository)
        {
            throw new NotImplementedException();
            _courseRepository = courseRepository;
        }

        public void Store(CourseDto course)
        {
            var courseToStorage = new Course(course.Name, course.Description, course.WorkLoad, TargetAudience.Student, course.Price);

            _courseRepository.AddCourse(courseToStorage);
        }
    }

    public interface ICourseRepository
    {
        void AddCourse(Course course);
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
