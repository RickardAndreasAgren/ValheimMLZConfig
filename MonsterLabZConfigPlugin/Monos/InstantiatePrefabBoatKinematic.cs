using System.Collections.Generic;
using UnityEngine;
using MonsterLabZConfig;

//namespace MonsterLabZConfig
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
            foreach (GameObject item in m_spawnPrefab)
            {
                GameObject gameObject = Object.Instantiate(item, base.transform.transform.position, base.transform.transform.rotation);
                MonsterLabZConfig.MonsterLabZConfig.PluginLogger.LogWarning($"Adding {gameObject.name} to a parent");
                gameObject.transform.SetParent(base.transform, worldPositionStays: true);
                m_spawnedMobs.Add(gameObject);
                Rigidbody rBody = gameObject.GetComponent<Rigidbody>();
                if (rBody != null)
                {
                    rBody.automaticCenterOfMass = false;
                    rBody.automaticInertiaTensor = false;
                    rBody.isKinematic = false;
                }
            }
        }

        public void OnDestroy()
        {
            foreach (GameObject spawnedMob in m_spawnedMobs)
            {
                if (spawnedMob != null)
                {
                    spawnedMob.transform.parent = null;
                    var rBody = spawnedMob.GetComponent<Rigidbody>();
                    rBody.automaticCenterOfMass = true;
                    rBody.automaticInertiaTensor = true;
                    rBody.isKinematic = false;
                }
            }
        }
    }
}