using System.Collections.Generic;
using UnityEngine;
using MonsterLabZConfig;

//namespace MonsterLabZConfig
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
            foreach (GameObject item in m_spawnPrefab)
            {
                GameObject gameObject = Object.Instantiate(item, base.transform.transform.position, base.transform.transform.rotation);
                MonsterLabZConfig.MonsterLabZConfig.PluginLogger.LogWarning($"Adding {gameObject.name} to a parent");
                ZLog.Log($"Adding {gameObject.name} to a parent");
                gameObject.transform.SetParent(base.transform, worldPositionStays: true);
                gameObject.layer = 17;
                Rigidbody rBody = gameObject.GetComponent<Rigidbody>();
                if (rBody != null)
                {
                    ZLog.Log($"{gameObject.name} prepared child RigidBody");
                    rBody.automaticCenterOfMass = false;
                    rBody.automaticInertiaTensor = false;
                    rBody.isKinematic = false;
                }
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

                    var rBody = spawnedMob.GetComponent<Rigidbody>();
                    rBody.automaticCenterOfMass = true;
                    rBody.automaticInertiaTensor = true;
                    rBody.isKinematic = false;
                    spawnedMob.layer = 9;
                    Humanoid component = spawnedMob.GetComponent<Humanoid>();
                    if (component != null)
                    {
                        component.m_rightItem = CommonResources.DwarfGoblinSpearData;
                        component.m_inventory.m_inventory[0] = CommonResources.DwarfGoblinSpearData;
                        component.m_turnSpeed = 300f;
                        component.m_runTurnSpeed = 100f;
                    }
                }
            }
        }
    }
}
