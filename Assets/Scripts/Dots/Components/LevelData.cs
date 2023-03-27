using Mono;
using SO;
using Unity.Entities;

namespace Dots.Components
{
    public class LevelData : IComponentData
    {
        public Config Config;
        public SceneData SceneData;
    }
}