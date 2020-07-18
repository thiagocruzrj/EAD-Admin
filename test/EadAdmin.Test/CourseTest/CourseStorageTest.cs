using Bogus;
using EadAdmin.Domain.Courses;
using EadAdmin.DomainTest._Utils;
using Moq;
using System;
using Xunit;

namespace EadAdmin.DomainTest.CourseTest
{
    public class CourseStorageTest
    {
        private readonly CourseDto _courseDto;
        private readonly Mock<ICourseRepository> _repositoryCourseMock;
        private readonly StorageCourse _storageCourse;

        public CourseStorageTest()
        {
            _repositoryCourseMock = new Mock<ICourseRepository>();
            _storageCourse = new StorageCourse(_repositoryCourseMock.Object);
            var fake = new Faker();

            _courseDto = new CourseDto
            {
                Name = fake.Random.Word(),
                Description = fake.Lorem.Paragraph(),
                WorkLoad = fake.Random.Double(10, 100),
                TargetAudience = "Student",
                Price = fake.Random.Double(2, 100)
            };
        }

        [Fact]
        public void ShouldAddCourse()
        {
            _storageCourse.Store(_courseDto);

            _repositoryCourseMock.Verify(r => r.AddCourse(It.IsAny<Course>()));
        }

        [Fact]
        public void ShouldntSetAnInvalidTargetAudience()
        {
            var targetAudienceInvalid = "Medic";
            _courseDto.TargetAudience = targetAudienceInvalid;

            Assert.Throws<ArgumentException>(() => _storageCourse.Store(_courseDto))
                .WithMessage("Target Audience invalid");
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
            Enum.TryParse(typeof(TargetAudience), course.TargetAudience, out var targetAudience);

            if (targetAudience == null)
                throw new ArgumentException("Target Audience invalid");

            var courseToStorage = new Course(course.Name, course.Description, course.WorkLoad, (TargetAudience)targetAudience, course.Price);

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
        public string TargetAudience { get; set; }
        public double Price { get; set; }
    }
}