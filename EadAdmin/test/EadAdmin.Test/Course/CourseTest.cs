using Xunit;

namespace EadAdmin.Domain.Course
{
    public class CourseTest
    {
        [Fact]
        public void ShouldCreateCourse()
        {
            // Arrange
            string name = "C#";
            double workLoad = 55.5;
            string tagetAudience = "Students";
            double price = 40.5;

            // Act
            var course = new Course(name, workLoad, tagetAudience, price);

            // Assert
            Assert.Equal(name, course.Name);
            Assert.Equal(workLoad, course.WorkLoad);
            Assert.Equal(tagetAudience, course.TagetAudience);
            Assert.Equal(price, course.Price);
        }
    }
    public class Course
    {
        public Course(string name, double workLoad, string tagetAudience, double price)
        {

        }

        public string Name { get; internal set; }
        public double WorkLoad { get; internal set; }
        public string TagetAudience { get; internal set; }
        public double Price { get; internal set; }
    }
}