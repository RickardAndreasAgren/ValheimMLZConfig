using CreatureManager;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;
using MonsterLabZConfig;

namespace MonsterLabZConfig
{
    public class InstantiatePrefabSpawn : MonoBehaviour
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
                GameObject gameObject = Object.Instantiate(item, base.transform.transform.position, base.transform.transform.rotation);
                ZLog.Log($"Adding {gameObject.name} to a parent");
                gameObject.transform.SetParent(base.transform, worldPositionStays: true);
                gameObject.layer = 17;
                Rigidbody rBody = gameObject.GetComponent<Rigidbody>();
                if (rBody != null)
                {
                    rBody.automaticCenterOfMass = false;
                    rBody.automaticInertiaTensor = false;
                    rBody.isKinematic = true;
                }
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
                    ZLog.Log("[" + GetType().Name + "] Deparent " + spawnedMob.name);
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
