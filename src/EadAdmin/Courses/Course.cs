using System;

namespace EadAdmin.Domain.Courses
{
    public class Course
    {
        public Course(string name, string description, double workLoad, TargetAudience targetAudience, double price)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException("Invalid Name");

            if (workLoad < 1)
                throw new ArgumentException("Work load should be greater than 1");

            if (price < 1)
                throw new ArgumentException("Price should be greater than 1");

            Name = name;
            Description = description;
            WorkLoad = workLoad;
            TargetAudience = targetAudience;
            Price = price;
        }

        public string Name { get; private set; }
        public string Description { get; private set; }
        public double WorkLoad { get; private set; }
        public TargetAudience TargetAudience { get; private set; }
        public double Price { get; private set; }
    }
}