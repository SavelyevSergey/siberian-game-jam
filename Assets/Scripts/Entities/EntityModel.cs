using UnityEngine;

namespace Entities
{
    [CreateAssetMenu(menuName = "Game/Models/Entity", fileName = "Entity")]
    public class EntityModel : ScriptableObject
    {
        [SerializeField]
        private string _id;

        public string Id => _id;
    }
}