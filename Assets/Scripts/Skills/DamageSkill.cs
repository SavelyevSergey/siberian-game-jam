using System;
using Entities;
using UnityEngine;

namespace Skills
{
    [Serializable]
    public class DamageSkill : ASkill
    {
        [SerializeField] private int _damage;


        public override string Name => "Damage Skill";

        public override void Apply(AEntity entity)
        {
            Debug.Log($"entity {entity.Id} takes {_damage} damage");
            entity.Damage(_damage);
        }
    }
}