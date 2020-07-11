using Xunit;

namespace EadAdmin.Domain.Course
{
    public class CourseTest
    {
        [Fact]
        public void ShouldCreateCourse()
        {
            // Arrange
            const string name = "C#";
            const double workLoad = 55.5;
            const string targetAudience = "Students";
            const double price = 40.5;

            // Act
            var course = new Course(name, workLoad, targetAudience, price);

            // Assert
            Assert.Equal(name, course.Name);
            Assert.Equal(workLoad, course.WorkLoad);
            Assert.Equal(targetAudience, course.TargetAudience);
            Assert.Equal(price, course.Price);
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

        public string Name { get; internal set; }
        public double WorkLoad { get; internal set; }
        public string TargetAudience { get; internal set; }
        public double Price { get; internal set; }
    }
}