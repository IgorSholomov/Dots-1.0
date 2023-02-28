using Dots.Components;
using Mono;
using Unity.Entities;
using UnityEngine;

namespace Dots.Systems
{
    public partial class DotsTest: SystemBase
    {
        protected override void OnUpdate()
        {
            Entities
                .WithAll<LevelTag>()
                .ForEach((SceneData sceneData) =>
                {
                    Debug.Log($"DotsTestSystem OnUpdate {sceneData.Camera.orthographicSize}");
                    
                }).WithoutBurst().Run();
        }
    }
}