using System;
using Entities;
using UnityEngine;

namespace Skills
{
    [Serializable]
    public class DamageSkill : ASkill
    {
        [SerializeField] private int _damage;


        public override void Apply(AEntity entity)
        {
            entity.Damage(_damage);
        }
    }
}