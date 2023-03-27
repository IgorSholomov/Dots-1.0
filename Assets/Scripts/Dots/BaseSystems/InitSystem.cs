using Unity.Entities;

namespace Dots.BaseSystems
{
    [UpdateInGroup(typeof(InitGroup))]
    public abstract partial class InitSystem : SystemBase
    {
        protected override void OnStartRunning()
        {
            Enabled = false;
        }

        /*protected override void OnUpdate()
        {
            var levelData = SystemAPI.ManagedAPI.GetSingleton<LevelData>();
        }*/
    }
}