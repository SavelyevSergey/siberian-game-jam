using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Entities
{
    [Serializable]
    public class AEntity
    {
        [SerializeField, ReadOnly]
        protected string _id;
        
        [SerializeField, ReadOnly]
        protected int _maxHp;
        [SerializeField, ReadOnly]
        protected int _currentHp;

        public string Id => _id;

        public bool IsDead => _currentHp <= 0;

        public void Reset()
        {
            _currentHp = _maxHp;
        }
        
        public void Damage(int amount)
        {
            _currentHp -= amount;
            if (_currentHp <= 0)
            {
                Debug.Log($"{_id} dies");
                Debug.Log($"{_id}: {_currentHp}/{_maxHp} (dead)");
                //die
            }
            else
                Debug.Log($"{_id}: {_currentHp}/{_maxHp}");
            
        }

        public void Heal(int amount)
        {
            _currentHp += amount;
            if (_currentHp > _maxHp)
                _currentHp = _maxHp;
            Debug.Log($"{_id}: {_currentHp}/{_maxHp}");
        }
    }
}