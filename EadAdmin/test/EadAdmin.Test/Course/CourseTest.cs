using Castle.Core.Internal;
using EadAdmin.Domain._Utils;
using ExpectedObjects;
using System;
using Xunit;

namespace EadAdmin.Domain.Course
{
    public class CourseTest
    {
        private readonly string _name;
        private readonly double _workLoad;
        private readonly TargetAudience _targetAudience;
        private readonly double _price;

        public CourseTest()
        {
            _name = "C#";
            _workLoad = 80;
            _targetAudience = TargetAudience.Student;
            _price = 50;
        }

        [Fact]
        public void ShouldCreateCourse()
        {
            // Arrange
            var expectedCourse = new
            {
                Name = _name,
                WorkLoad = _workLoad,
                TargetAudience = _targetAudience,
                Price = _price
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
            // Arrange, Act & Assert
            Assert.Throws<ArgumentException>(() => 
                        new Course(invalidName, _workLoad, _targetAudience, _price)).WithMessage("Invalid Name");
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-2)]
        public void CourseShouldntHasLessThanAnHourOfWorkLoad(double invalidWorkLoad)
        {
            // Arrange, Act & Assert
            Assert.Throws<ArgumentException>(() =>
                    new Course(_name, invalidWorkLoad, _targetAudience, _price)).WithMessage("Work load should be greater than 1");
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
            Assert.Throws<ArgumentException>(() =>
                new Course(expectedCourse.Name, expectedCourse.WorkLoad, expectedCourse.TargetAudience, invalidPrice)).WithMessage("Price should be greater than 1");
        }
    }

    public class Course
    {
        public Course(string name, double workLoad, TargetAudience targetAudience, double price)
        {
            if (name.IsNullOrEmpty())
                throw new ArgumentException("Invalid Name");

            if (workLoad < 1)
                throw new ArgumentException("Work load should be greater than 1");

            if (price < 1)
                throw new ArgumentException("Price should be greater than 1");

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