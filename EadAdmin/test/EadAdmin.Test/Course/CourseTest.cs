using Xunit;

namespace EadAdmin.Domain.Course
{
    public class CourseTest
    {
        private string name = "C#";
        private double workLoad = 55.5;
        private string tagetAudience = "Students";
        private double price = 40.5;

        [Fact]
        public void ShouldCreateCourse()
        {
            var course = new Course(name, workLoad, tagetAudience, price);
            Assert.Empty(name, course.Name);
            Assert.Empty(workLoad, course.WorkLoad);
            Assert.Empty(tagetAudience, course.TagetAudience);
            Assert.Empty(price, course.Price);
        }
    }
    public class Course
    {
        public Course(string name, double workLoad, string tagetAudience, double price)
        {

        }
    }
}