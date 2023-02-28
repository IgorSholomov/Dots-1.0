using Dots.Components;
using Mono;
using Unity.Entities;
using UnityEngine;

namespace Dots.Systems
{
    public partial struct DotsSystemStruct: ISystem, ISystemStartStop
    {
        public void OnCreate(ref SystemState state)
        {
            foreach (var sceneData in 
                     SystemAPI.Query<LevelTag>())
            {
                Debug.Log($"ISystem OnCreate SceneData {sceneData.ToString()}");
            }
        }

        public void OnStartRunning(ref SystemState state)
        {
            foreach (var levelManager in SystemAPI.Query<LevelManagerData>())
            {
                Debug.Log($"ISystem OnStartRunning Config.TestCount: {levelManager.Config.TestCount}");
            }
        }

        public void OnStopRunning(ref SystemState state)
        {
            foreach (var levelManager in SystemAPI.Query<LevelManagerData>())
            {
                Debug.Log($"ISystem OnStopRunning Config.LevelHeight: {levelManager.Config.LevelHeight}");
            }
        }
    }
}