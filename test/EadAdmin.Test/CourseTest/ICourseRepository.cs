using EadAdmin.Domain.Courses;

namespace EadAdmin.DomainTest.CourseTest
{
    public interface ICourseRepository
    {
        void AddCourse(Course course);
        Course AddCourseByName(string courseName);
    }
}