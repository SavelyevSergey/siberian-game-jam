namespace Entities
{
    public class BasicEntity : AEntity
    {
        public BasicEntity(int hp, string id)
        {
            _id = id;
            _maxHp = hp;
            _currentHp = hp;
        }
    }
}