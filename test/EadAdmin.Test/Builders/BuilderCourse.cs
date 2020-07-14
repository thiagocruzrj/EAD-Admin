using EadAdmin.Domain.Course;
using app = EadAdmin.Domain.Course;

namespace EadAdmin.Domain.Builders
{
    public class BuilderCourse
    {
        private string _name = "C#";
        private string _description = "Description Test";
        private double _workLoad = 80;
        private TargetAudience _targetAudience = TargetAudience.Student;
        private double _price = 40;

        public static BuilderCourse New()
        {
            return new BuilderCourse();
        }

        public BuilderCourse WithName(string name)
        {
            _name = name;
            return this;
        }

        public BuilderCourse WithDescription(string description)
        {
            _description = description;
            return this;
        }

        public BuilderCourse WithWorkload(double workload)
        {
            _workLoad = workload;
            return this;
        }

        public BuilderCourse WithPrice(double price)
        {
            _price = price;
            return this;
        }

        public BuilderCourse WithTargetAudience(TargetAudience targetAudience)
        {
            _targetAudience = TargetAudience.Student;
            return this;
        }

        public app.Course Build()
        {
            return new app.Course(_name, _description, _workLoad, _targetAudience, _price);
        }
    }
}