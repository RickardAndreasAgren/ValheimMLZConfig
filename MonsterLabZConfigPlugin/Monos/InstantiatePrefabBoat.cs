using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace MonsterLabZConfig
{
    public class InstantiatePrefabBoat : MonoBehaviour
    {
        public List<GameObject> m_spawnPrefab;

        private List<GameObject> m_spawnedMobs = new List<GameObject>();

        public bool m_attach;

        public bool m_moveToTop;

        public void Start()
        {
            ZLog.Log(GetType().Name + "." + MethodBase.GetCurrentMethod().Name + "()");
            foreach (GameObject item in m_spawnPrefab)
            {
                ZLog.Log("[" + GetType().Name + "] Spawning " + item.name);
                GameObject gameObject = Object.Instantiate(item, base.transform.transform.position, base.transform.transform.rotation);
                gameObject.transform.SetParent(base.transform, worldPositionStays: true);
                m_spawnedMobs.Add(gameObject);
            }
        }

        public void OnDestroy()
        {
            ZLog.Log(GetType().Name + "." + MethodBase.GetCurrentMethod().Name + "()");
            foreach (GameObject spawnedMob in m_spawnedMobs)
            {
                if (spawnedMob != null)
                {
                    ZLog.Log("[" + GetType().Name + "] Reparent " + spawnedMob.name);
                    spawnedMob.transform.parent = null;
                }
            }
        }
    }
}