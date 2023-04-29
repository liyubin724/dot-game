using DotEngine.Frame;
using DotEngine.GOPool;
using UnityEngine;

namespace Game.GOPool
{
    public class InitGOPoolSystem : BaseSystem
    {
        protected override void OnActivate()
        {
            var poolMgr = PoolManager.CreateInstance();

            GameObject emptyGameObject = new GameObject();
            var spawnPool = poolMgr.CreateSpawnPool(SpawnPoolNames.INIT);
            var prefabPool = spawnPool.CreatePrefabPool(GameObjectPoolNames.INIT_EMPTY_GO, EPrefabTemplateType.RuntimeInstance, emptyGameObject);
            prefabPool.preloadTotalAmount = 10;
        }

        protected override void OnDeactivate()
        {
            PoolManager.DestroyInstance();
        }
    }
}
