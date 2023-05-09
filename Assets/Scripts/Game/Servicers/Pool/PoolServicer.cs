using DotEngine.Frame;
using DotEngine.GOPool;
using UnityEngine;

namespace Game.Servicers
{
    public class PoolServicer : IServicer
    {
        private PoolManager m_PoolMgr;

        public void OnRegistered()
        {
            m_PoolMgr = PoolManager.CreateInstance();
        }

        public void OnUnregistered()
        {
            m_PoolMgr = null;
            PoolManager.DestroyInstance();
        }

        public bool HasSpawnPool(string spawnName)
        {
            return m_PoolMgr.HasSpawnPool(spawnName);
        }

        public bool HasPrefabPool(string spawnName, string prefabName)
        {
            var spawnPool = m_PoolMgr.GetSpawnPool(spawnName);
            if (spawnPool == null)
            {
                return false;
            }
            return spawnPool.HasPrefabPool(prefabName);
        }

        public SpawnPool GetOrCreateSpawnPool(string spawnName)
        {
            return m_PoolMgr.GetSpawnPool(spawnName, true);
        }

        public PrefabPool CreatePrefabPool(
            string spawnName,
            string prefabName,
            EPrefabTemplateType templateType,
            GameObject template)
        {
            var spawnPool = m_PoolMgr.GetSpawnPool(spawnName, true);
            return spawnPool.CreatePrefabPool(prefabName, templateType, template);
        }

        public PrefabPool GetPrefabPool(
            string spawnName,
            string prefabName)
        {
            var spawnPool = m_PoolMgr.GetSpawnPool(spawnName, false);
            if (spawnPool == null)
            {
                return null;
            }
            return spawnPool.GetPrefabPool(prefabName);
        }

        public void DestroySpawnPool(string spawnName)
        {
            m_PoolMgr.DestroySpawnPool(spawnName);
        }

        public void DestroyPrefabPool(
            string spawnName,
            string prefabName)
        {
            var spawnPool = m_PoolMgr.GetSpawnPool(spawnName, false);
            if (spawnPool == null)
            {
                return;
            }
            spawnPool.DestroyPrefabPool(prefabName);
        }
    }
}
