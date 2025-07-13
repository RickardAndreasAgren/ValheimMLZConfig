using System.Collections.Generic;
using UnityEngine;
using MonsterLabZConfig;

namespace MonsterLabZ
{
    public class InstantiatePrefabBoatKinematic : MonoBehaviour
    {
        public List<GameObject> m_spawnPrefab;

        private List<GameObject> m_spawnedMobs = new List<GameObject>();

        public bool m_attach;

        public bool m_moveToTop;

        public void Start()
        {
            return;
        }

        public void OnDestroy()
        {
            return;
        }
    }
}