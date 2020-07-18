using Bogus;
using EadAdmin.Domain.Courses;
using Moq;
using System;
using Xunit;

namespace EadAdmin.DomainTest.CourseTest
{
    public class CourseStorageTest
    {
        private CourseDto _courseDto;
        private Mock<ICourseRepository> _repositoryCourseMock;
        private StorageCourse _storageCourse;

        public CourseStorageTest()
        {
            _repositoryCourseMock = new Mock<ICourseRepository>();
            _storageCourse = new StorageCourse(_repositoryCourseMock.Object);
            var fake = new Faker();

            _courseDto = new CourseDto
            {
                Name = fake.Random.Word(),
                Description = fake.Lorem.Paragraph(),
                WorkLoad = 50.1,
                TargetAudienceId = 1,
                Price = 30.2
            };
        }

        [Fact]
        public void ShouldAddCourse()
        {
            _storageCourse.Store(_courseDto);

            _repositoryCourseMock.Verify(r => r.AddCourse(It.IsAny<Course>()));
        }
    }

    public class StorageCourse 
    {
        private readonly ICourseRepository _courseRepository;

        public StorageCourse(ICourseRepository courseRepository)
        {
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
