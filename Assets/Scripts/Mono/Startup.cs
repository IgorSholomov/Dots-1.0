using Dots.Components;
using SO;
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
            Debug.Log("Start");

            /*SceneData.TextUI = "count actor entities - {0}\n" +
                               "q - delete all entities with tag Actor\n" +
                               "i  - remove World and Dispose ";
                               */

            Debug.developerConsoleVisible = false;

            CreateWorld();

            // Instantiate(Config.Graphy);
            // SceneData.TextValue.text = string.Format(SceneData.TextUI, Config.TestCount);
        }


        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.I))
                if (_ecsWorld.IsCreated)
                    WorldDispose();
        }

        private void OnDestroy()
        {
            if (_ecsWorld != null)
                WorldDispose();
        }

        private void CreateWorld()
        {
            _ecsWorld = new World("GameEcsWorld");
            World.DefaultGameObjectInjectionWorld = _ecsWorld;

            Debug.Log("Create World");

            CreateLevelEntity();

            var systems = DefaultWorldInitialization.GetAllSystems(WorldSystemFilterFlags.Default);
            DefaultWorldInitialization.AddSystemsToRootLevelSystemGroups(_ecsWorld, systems);
            ScriptBehaviourUpdateOrder.AppendWorldToCurrentPlayerLoop(_ecsWorld);

            Debug.Log("Add Systems To Root Level");
        }


        private void CreateLevelEntity()
        {
            var entityManager = _ecsWorld.EntityManager;

            CreateWithEntityManager(entityManager);

            // CreateWithArchetype(entityManager);

            Debug.Log("Create Entity Level");
        }

        private void CreateWithEntityManager(EntityManager entityManager)
        {
            var entity = entityManager.CreateEntity();
            entityManager.SetName(entity, "Level");

            entityManager.AddComponentObject(entity, new LevelData
            {
                SceneData = SceneData,
                Config = Config
            });

            entityManager.AddComponent<LevelTag>(entity);
        }

        private void CreateWithArchetype(EntityManager entityManager)
        {
            var actorArchetype = entityManager.CreateArchetype
            (
                typeof(LevelTag),
                ComponentType.ReadOnly<LevelData>()
            );
            var ld = new LevelData { SceneData = SceneData, Config = Config };
            var e = entityManager.CreateEntity(actorArchetype);
            entityManager.SetComponentData(e, ld);
            entityManager.SetName(e, "LevelFromArchetype");
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