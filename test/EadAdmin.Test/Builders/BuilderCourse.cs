using EadAdmin.Domain.Courses;

namespace EadAdmin.DomainTest.Builders
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
            _targetAudience = targetAudience;
            return this;
        }

        public Course Build()
        {
            return new Course(_name, _description, _workLoad, _targetAudience, _price);
        }
    }
}