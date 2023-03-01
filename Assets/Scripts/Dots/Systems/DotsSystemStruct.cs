using Dots.Components;
using Unity.Entities;
using UnityEngine;


namespace Dots.Systems
{
    public partial struct DotsSystemStruct : ISystem, ISystemStartStop
    {
        public void OnCreate(ref SystemState state)
        {
            var levelData = SystemAPI.ManagedAPI.GetSingleton<LevelData>();
            Debug.Log($"ISystem OnCreate levelData.Config.TestCount: {levelData.Config.TestCount}");
        }


        public void OnStartRunning(ref SystemState state)
        {
            var levelData = SystemAPI.ManagedAPI.GetSingleton<LevelData>();
            Debug.Log($"ISystem OnStartRunning levelData.Config.TestCount: {levelData.Config.TestCount}");
        }


        public void OnStopRunning(ref SystemState state)
        {
            var levelData = SystemAPI.ManagedAPI.GetSingleton<LevelData>();
            Debug.Log($"ISystem OnStopRunning levelData.Config.LevelHeight: {levelData.Config.LevelHeight}");
        }

        public void OnDestroy(ref SystemState state)
        {
            var levelData = SystemAPI.ManagedAPI.GetSingleton<LevelData>();
            Debug.Log($"ISystem OnDestroy levelData.Config.AddRemoveCount: {levelData.Config.AddRemoveCount}");
        }
    }
}