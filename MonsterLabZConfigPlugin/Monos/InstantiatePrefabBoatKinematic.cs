using System.Collections.Generic;
using UnityEngine;

namespace MonsterLabZConfig
{
    public class InstantiatePrefabBoatKinematic : MonoBehaviour
    {
        public List<GameObject> m_spawnPrefab;

        private List<GameObject> m_spawnedMobs = new List<GameObject>();

        public bool m_attach;

        public bool m_moveToTop;

        public void Start()
        {
            foreach (GameObject item in m_spawnPrefab)
            {
                GameObject gameObject = Object.Instantiate(item, base.transform.transform.position, base.transform.transform.rotation);
                gameObject.transform.SetParent(base.transform, worldPositionStays: true);
                m_spawnedMobs.Add(gameObject);
            }
        }

        public void OnDestroy()
        {
            foreach (GameObject spawnedMob in m_spawnedMobs)
            {
                if (spawnedMob != null)
                {
                    spawnedMob.transform.parent = null;
                    spawnedMob.GetComponent<Rigidbody>().isKinematic = false;
                }
            }
        }
    }
}