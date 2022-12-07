using Unity.Entities;
using UnityEngine;

namespace Mono
{
    public class Startup : MonoBehaviour
    {
        [SerializeField] private Config Config;
        [SerializeField] private SceneData SceneData;

        private World _ecsWorld;


        private void Start()
        {
            /*SceneData.TextUI = "count actor entities - {0}\n" +
                               "q - delete all entities with tag Actor\n" +
                               "i  - remove World and Dispose ";
                               */

            Debug.developerConsoleVisible = false;

            // Instantiate(Config.Graphy);

            CreateWorld();

            CreateLevelEntity();

            // SceneData.TextValue.text = string.Format(SceneData.TextUI, Config.TestCount);

            Debug.Log("Start");
        }

        private void CreateWorld()
        {
            _ecsWorld = new World("GameEcsWorld");
            World.DefaultGameObjectInjectionWorld = _ecsWorld;

            var systems = DefaultWorldInitialization.GetAllSystems(WorldSystemFilterFlags.Default);
            DefaultWorldInitialization.AddSystemsToRootLevelSystemGroups(_ecsWorld, systems);
            ScriptBehaviourUpdateOrder.AppendWorldToCurrentPlayerLoop(_ecsWorld);

            Debug.Log("Create World");
        }


        private void CreateLevelEntity()
        {
            var entityManager = _ecsWorld.EntityManager;

            var entity = entityManager.CreateEntity();
            entityManager.SetName(entity, "Level");
            entityManager.AddComponentObject(entity, Config);
            entityManager.AddComponentObject(entity, SceneData);
            entityManager.AddComponent<LevelTag>(entity);

            /*var actorArchetype = entityManager.CreateArchetype
            (
                typeof(LevelTag),
                ComponentType.Exclude<Config>(),
                ComponentType.ReadOnly<SceneData>()
            );
            var e = entityManager.CreateEntity(actorArchetype);
            entityManager.SetName(e, "LevelFromArchetype");
            */


            // _ecsWorld.GetOrCreateSystem<InitializationSystemGroup>().SetSingleton(new LevelTag());

            Debug.Log("Create Entity Level");
        }


        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.I))
            {
                if (_ecsWorld.IsCreated)
                    WorldDispose();
            }
        }

        private void OnDestroy()
        {
            if (_ecsWorld != null)
                WorldDispose();
        }


        private void WorldDispose()
        {
            ScriptBehaviourUpdateOrder.RemoveWorldFromCurrentPlayerLoop(_ecsWorld);
            _ecsWorld.Dispose();
            _ecsWorld = null;

            Debug.Log("World dispose");
        }
    }
}