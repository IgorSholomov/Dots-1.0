using Dots.Components;
using Unity.Entities;
using UnityEngine;

namespace Dots.Systems
{
    public partial class DotsTestSystem : SystemBase
    {
        protected override void OnCreate()
        {
            var levelData = SystemAPI.ManagedAPI.GetSingleton<LevelData>();
            Debug.Log($"SystemBase OnCreate levelData.Config.TestCount: {levelData.Config.TestCount}");
        }


        protected override void OnStartRunning()
        {
            var levelData = SystemAPI.ManagedAPI.GetSingleton<LevelData>();
            Debug.Log(
                $"SystemBase OnStartRunning levelData.SceneData.Camera.depth: {levelData.SceneData.Camera.actualRenderingPath}");
        }


        protected override void OnStopRunning()
        {
            var levelData = SystemAPI.ManagedAPI.GetSingleton<LevelData>();
            Debug.Log($"SystemBase OnStopRunning levelData.Config.LevelHeight: {levelData.Config.LevelHeight}");
        }

        protected override void OnDestroy()
        {
            var levelData = SystemAPI.ManagedAPI.GetSingleton<LevelData>();
            Debug.Log($"SystemBase OnDestroy levelData.Config.AddRemoveCount: {levelData.Config.AddRemoveCount}");
        }

        protected override void OnUpdate() { }
    }
}