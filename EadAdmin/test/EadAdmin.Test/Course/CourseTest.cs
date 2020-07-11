using Castle.Core.Internal;
using ExpectedObjects;
using System;
using Xunit;

namespace EadAdmin.Domain.Course
{
    public class CourseTest
    {
        [Fact]
        public void ShouldCreateCourse()
        {
            // Arrange
            var expectedCourse = new
            {
                Name = "C#",
                WorkLoad = (double)55,
                TargetAudience = TargetAudience.Student,
                Price = (double)40
            };

            // Act
            var course = new Course(expectedCourse.Name, expectedCourse.WorkLoad, expectedCourse.TargetAudience, expectedCourse.Price);

            // Assert
            expectedCourse.ToExpectedObject().ShouldMatch(course);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void CourseShouldntHasAnEmptyOrNullName(string invalidName)
        {
            // Arrange
            var expectedCourse = new
            {
                Name = "C#",
                WorkLoad = (double)55,
                TargetAudience = TargetAudience.Student,
                Price = (double)40
            };

            // Act & Assert
            Assert.Throws<ArgumentException>(() => new Course(invalidName, expectedCourse.WorkLoad, expectedCourse.TargetAudience, expectedCourse.Price));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-2)]
        public void CourseShouldntHasLessThanAnHourOfWorkLoad(double invalidWorkLoad)
        {
            // Arrange
            var expectedCourse = new
            {
                Name = "C#",
                WorkLoad = invalidWorkLoad,
                TargetAudience = TargetAudience.Student,
                Price = (double)40
            };

            // Act & Assert
            Assert.Throws<ArgumentException>(() => new Course(expectedCourse.Name, invalidWorkLoad, expectedCourse.TargetAudience, expectedCourse.Price));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-2)]
        public void CourseShouldntHasLessThanOneValueOfPrice(double invalidPrice)
        {
            // Arrange
            var expectedCourse = new
            {
                Name = "C#",
                WorkLoad = (double)55,
                TargetAudience = TargetAudience.Student,
                Price = invalidPrice
            };

            // Act & Assert
            Assert.Throws<ArgumentException>(() => new Course(expectedCourse.Name, expectedCourse.WorkLoad, expectedCourse.TargetAudience, invalidPrice));
        }
    }

    public class Course
    {
        public Course(string name, double workLoad, TargetAudience targetAudience, double price)
        {
            if (name.IsNullOrEmpty())
                throw new ArgumentException();

            if (workLoad < 1)
                throw new ArgumentException();

            if (price < 1)
                throw new ArgumentException();

            Name = name;
            WorkLoad = workLoad;
            TargetAudience = targetAudience;
            Price = price;
        }

        public string Name { get; private set; }
        public double WorkLoad { get; private set; }
        public TargetAudience TargetAudience { get; private set; }
        public double Price { get; private set; }
    }

    public enum TargetAudience
    {
        Student,
        Universitary,
        Employee,
        Entrepernur
    }
}