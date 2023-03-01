using Mono;
using SO;
using Unity.Entities;

namespace Dots.Components
{
    public class LevelData: IComponentData
    {
        public SceneData SceneData;
        public Config Config;
    }
}