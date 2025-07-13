using CreatureManager;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using MonsterLabZConfig;
using MonsterLabZConfig.Extensions;

namespace MonsterLabZ
{
    public class InstantiatePrefabLoxRider : MonoBehaviour
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
