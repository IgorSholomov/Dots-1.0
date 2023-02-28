using Mono;
using SO;
using Unity.Entities;

namespace Dots.Components
{
    public class LevelManagerData: IComponentData
    {
        public SceneData SceneData;
        public Config Config;
    }
}