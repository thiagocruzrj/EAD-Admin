using Bogus;
using EadAdmin.Domain.Courses;
using EadAdmin.DomainTest._Utils;
using EadAdmin.DomainTest.Builders;
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

        [Fact]
        public void ShouldntAddACourseWithSameName()
        {
            var savedCourse = BuilderCourse.New().WithName(_courseDto.Name).Build();
            _repositoryCourseMock.Setup(r => r.AddCourseByName(_courseDto.Name)).Returns(savedCourse);

            Assert.Throws<ArgumentException>(() => _storageCourse.Store(_courseDto))
                .WithMessage("Course name unavailable");
        }
    }
}