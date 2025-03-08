using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace MonsterLabZConfig
{
    public class AmbienceSpawn : MonoBehaviour
    {
        private const float m_minPlayerDistance = 250f;

        private const float m_blockedMinTime = 4f;

        public GameObject m_AmbientPrefab;

        public float m_interval = 0.5f;

        private float m_lastSpawnTime;

        private float m_time;

        private void Start()
        {
            m_time = Random.Range(0f, m_interval);
        }

        private void Update()
        {
            m_time += Time.deltaTime;
            if (!((double)m_time <= (double)m_interval))
            {
                m_time = 0f;
                Spawn();
            }
        }

        private void Spawn()
        {
            Player localPlayer = Player.m_localPlayer;
            if (localPlayer == null || (double)Vector3.Distance(localPlayer.transform.position, base.transform.position) > 250.0)
            {
                m_lastSpawnTime = Time.time;
                return;
            }

            Object.Instantiate(m_AmbientPrefab, base.transform.position, base.transform.rotation);
            m_lastSpawnTime = Time.time;
        }
    }
}
