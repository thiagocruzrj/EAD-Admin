using Bogus;
using EadAdmin.Domain.Courses;
using EadAdmin.DomainTest._Utils;
using EadAdmin.DomainTest.Builders;
using ExpectedObjects;
using System;
using Xunit;

namespace EadAdmin.DomainTest.CourseTest
{
    public class CourseTest
    {
        private readonly string _name;
        private readonly double _workLoad;
        private readonly TargetAudience _targetAudience;
        private readonly double _price;
        private readonly string _description;

        public CourseTest()
        {
            var faker = new Faker();
            _name = faker.Random.Word();
            _description = faker.Lorem.Paragraph();
            _workLoad = faker.Random.Double(50, 200);
            _targetAudience = TargetAudience.Student;
            _price = faker.Random.Double(21, 1000);
        }

        [Fact]
        public void ShouldCreateCourse()
        {
            // Arrange
            var expectedCourse = new
            {
                Name = _name,
                Description = _description,
                WorkLoad = _workLoad,
                TargetAudience = _targetAudience,
                Price = _price
            };

            // Act
            var course = new Course(expectedCourse.Name, expectedCourse.Description, expectedCourse.WorkLoad, expectedCourse.TargetAudience, expectedCourse.Price);

            // Assert
            expectedCourse.ToExpectedObject().ShouldMatch(course);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void CourseShouldntHasAnEmptyOrNullName(string invalidName)
        {
            // Arrange, Act & Assert
            Assert.Throws<ArgumentException>(() =>
                         BuilderCourse.New().WithName(invalidName).Build())
                        .WithMessage("Invalid Name");
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-2)]
        public void CourseShouldntHasLessThanAnHourOfWorkLoad(double invalidWorkLoad)
        {
            // Arrange, Act & Assert
            Assert.Throws<ArgumentException>(() =>
                        BuilderCourse.New().WithWorkload(invalidWorkLoad).Build())
                        .WithMessage("Work load should be greater than 1");
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-2)]
        public void CourseShouldntHasLessThanOneValueOfPrice(double invalidPrice)
        {
            // Arrange, Act & Assert
            Assert.Throws<ArgumentException>(() =>
                        BuilderCourse.New().WithPrice(invalidPrice).Build())
                        .WithMessage("Price should be greater than 1");
        }
    }
}