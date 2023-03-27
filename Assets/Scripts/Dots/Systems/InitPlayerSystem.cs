using Dots.BaseSystems;
using Dots.Components;
using Unity.Entities;
using UnityEngine;

namespace Dots.Systems
{
    public partial class InitPlayerSystem : InitSystem
    {
        protected override void OnUpdate()
        {
            Debug.Log("InitSystem Update");


            var entity = EntityManager.CreateEntity();
            EntityManager.SetName(entity, "Player");

            var player = SystemAPI.ManagedAPI.GetSingleton<LevelData>().SceneData.Player;

            player.SetEntityData(entity, EntityManager);

            // EntityManager.AddComponentObject(entity, player);

            EntityManager.AddComponent<PlayerTag>(entity);
        }
    }
}