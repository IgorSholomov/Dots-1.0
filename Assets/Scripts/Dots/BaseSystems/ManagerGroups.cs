using Unity.Entities;

namespace Dots.BaseSystems
{
    [UpdateInGroup(typeof(InitializationSystemGroup))]
    public partial class InitGroup : ComponentSystemGroup { }


    [UpdateInGroup(typeof(InitializationSystemGroup))]
    public partial class InputGroup : ComponentSystemGroup { }
}