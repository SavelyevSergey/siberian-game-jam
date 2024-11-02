using UnityEngine;

namespace Entities
{
    public class AEntity
    {
        private int _maxHp;
        private int _currentHp;

        public void Reset()
        {
            _currentHp = _maxHp;
        }
        
        public void Damage(int amount)
        {
            _currentHp -= amount;
            if (_currentHp <= 0)
            {
                //die
            }
        }

        public void Heal(int amount)
        {
            _currentHp += amount;
            if (_currentHp > _maxHp)
                _currentHp = _maxHp;
        }
    }
}