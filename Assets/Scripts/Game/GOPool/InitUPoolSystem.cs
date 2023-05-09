using DotEngine.Frame;
using DotEngine.GOPool;
using Game.Servicers;
using UnityEngine;

namespace Game.GOPool
{
    public class InitUPoolSystem : BaseSystem
    {
        protected override void OnActivate()
        {
            var poolServicer = Facade.GetInstance().servicerCenter.Retrieve<PoolServicer>();
            var gameObject = new GameObject("empty");
            gameObject.hideFlags = HideFlags.DontSave;
            var prefabPool = poolServicer.CreatePrefabPool(
                SpawnPoolNames.GLOBAL,
                PrefabPoolNames.EMPTY_GAMEOBJECT,
                EPrefabTemplateType.RuntimeInstance,
                gameObject);
            prefabPool.preloadTotalAmount = 10;
        }

        protected override void OnDeactivate()
        {
            var poolServicer = Facade.GetInstance().servicerCenter.Retrieve<PoolServicer>();
            poolServicer.DestroyPrefabPool(SpawnPoolNames.GLOBAL, PrefabPoolNames.EMPTY_GAMEOBJECT);
        }
    }
}
