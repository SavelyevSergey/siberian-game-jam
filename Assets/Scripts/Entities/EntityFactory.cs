namespace Entities
{
    public class EntityFactory
    {
        public EntityFactory()
        {
            
        }

        public AEntity Make(EntityModel model, string id)
        {
            return new BasicEntity(model.Hp, id);
        }

        public AEntity MakePlayer()
        {
            return new BasicEntity(int.MaxValue, "Player");
        }
    }
}