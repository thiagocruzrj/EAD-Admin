using System;

namespace EadAdmin.Domain.Courses
{
    public class StorageCourse
    {
        private readonly ICourseRepository _courseRepository;

        public StorageCourse(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public void Store(CourseDto course)
        {
            var savadCourse = _courseRepository.AddCourseByName(course.Name);

            if (savadCourse != null)
                throw new ArgumentException("Course name unavailable");

            Enum.TryParse(typeof(TargetAudience), course.TargetAudience, out var targetAudience);

            if (targetAudience == null)
                throw new ArgumentException("Target Audience invalid");

            var courseToStorage = new Course(course.Name, course.Description, course.WorkLoad, (TargetAudience)targetAudience, course.Price);

            _courseRepository.AddCourse(courseToStorage);
        }
    }
}