using Entities;

namespace Skills
{
    public abstract class ASkill
    {
        public abstract string Name { get; }
        public abstract void Apply(AEntity entity);
    }
}