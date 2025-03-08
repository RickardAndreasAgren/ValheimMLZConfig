using CreatureManager;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using MonsterLabZConfig;
using MonsterLabZConfig.Extensions;

namespace MonsterLabZConfig
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
                GameObject gameObject = GameObject.Instantiate(item, base.transform.transform.position, base.transform.transform.rotation);
                ZLog.Log($"Adding {gameObject.name} to a parent");

                gameObject.transform.SetParent(base.transform.parent, worldPositionStays: true);
                gameObject.layer = 17;
                
                Rigidbody rBody = gameObject.GetComponent<Rigidbody>();
                if (rBody != null)
                {
                    ZLog.Log($"{gameObject.name} prepared child RigidBody");
                    rBody.automaticCenterOfMass = false;
                    rBody.automaticInertiaTensor = false;
                    rBody.isKinematic = true;
                }

                List<Rigidbody> bodies = gameObject.GetComponentsInChildren<Rigidbody>().ToList();
                foreach(var b in bodies)
                {
                    ZLog.Log($"Dug out additional RigidBodies and adjusted in {gameObject.name}");
                    rBody.isKinematic = true;
                };
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
                    rBody.useGravity = true;
                    spawnedMob.layer = 9;

                    MonsterAI defaultAI = gameObject.GetComponent<MonsterAIMounted>();
                    MonsterAI.Destroy(defaultAI);
                    var returnedAI = gameObject.AddComponent<MonsterAI>();

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
