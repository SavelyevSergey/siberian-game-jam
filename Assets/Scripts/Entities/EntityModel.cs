using UnityEngine;

namespace Entities
{
    [CreateAssetMenu(menuName = "Game/Models/Entity", fileName = "Entity")]
    public class EntityModel : ScriptableObject
    {
        [SerializeField] private string _id;
        [SerializeField] private int _hp;

        public string Id => _id;
        public int Hp => _hp;
    }
}