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

        [Fact]
        public void CourseShouldntHasAnEmptyName()
        {
            // Arrange
            var expectedCourse = new
            {
                Name = "C#",
                WorkLoad = (double)55,
                TargetAudience = TargetAudience.Student,
                Price = (double)40
            };

            // Act && Assert
            Assert.Throws<ArgumentException>(() => new Course(string.Empty, expectedCourse.WorkLoad, expectedCourse.TargetAudience, expectedCourse.Price));
        }
    }

    public class Course
    {
        public Course(string name, double workLoad, TargetAudience targetAudience, double price)
        {
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