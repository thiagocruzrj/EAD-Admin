using EadAdmin.Domain.Course;
using app = EadAdmin.Domain.Course;

namespace EadAdmin.Domain.Builders
{
    public class BuilderCourse
    {
        private readonly string _name = "C#";
        private readonly string _description = "Description Test";
        private readonly double _workLoad = 80;
        private readonly TargetAudience _targetAudience = TargetAudience.Student;
        private readonly double _price = 40;

        public static BuilderCourse New()
        {
            return new BuilderCourse();
        }

        public app.Course Build()
        {
            return new app.Course(_name, _description, _workLoad, _targetAudience, _price);
        }
    }
}