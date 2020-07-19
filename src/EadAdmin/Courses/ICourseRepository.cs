namespace EadAdmin.Domain.Courses
{
    public interface ICourseRepository
    {
        void AddCourse(Course course);
        Course AddCourseByName(string courseName);
    }
}