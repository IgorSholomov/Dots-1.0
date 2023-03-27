using Unity.Entities;
using UnityEngine;

namespace Mono
{
    public class Player : MonoBehaviour
    {
        public float Value = 12f;

        private EntityManager _entityManager;

        private Entity _owner;


        public void SetEntityData(Entity entity, EntityManager em)
        {
            _owner = entity;
            _entityManager = em;
        }
    }
}