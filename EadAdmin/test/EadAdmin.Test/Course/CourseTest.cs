using ExpectedObjects;
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
                TargetAudience = "Students",
                Price = (double)40
            };

            // Act
            var course = new Course(expectedCourse.Name, expectedCourse.WorkLoad, expectedCourse.TargetAudience, expectedCourse.Price);

            // Assert
            expectedCourse.ToExpectedObject().ShouldMatch(course);
        }
    }
    public class Course
    {
        public Course(string name, double workLoad, string targetAudience, double price)
        {
            Name = name;
            WorkLoad = workLoad;
            TargetAudience = targetAudience;
            Price = price;
        }

        public string Name { get; private set; }
        public double WorkLoad { get; private set; }
        public string TargetAudience { get; private set; }
        public double Price { get; private set; }
    }
}