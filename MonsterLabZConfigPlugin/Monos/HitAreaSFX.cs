using System;
using UnityEngine;

namespace MonsterLabZConfig
{
    public class HitAreaSFX : MonoBehaviour, IDestructible
    {
        public Action<HitData, HitAreaSFX> m_onHit;

        public float m_health = 100000f;

        [NonSerialized]
        public GameObject m_parentObject;

        public float m_hitNoise;

        public EffectList m_hitEffect = new EffectList();

        public DestructibleType GetDestructibleType()
        {
            return DestructibleType.Default;
        }

        public void Damage(HitData hit)
        {
            if ((double)hit.GetTotalDamage() <= 0.0)
            {
                return;
            }

            m_hitEffect.Create(hit.m_point, Quaternion.identity, base.transform);
            if ((double)m_hitNoise > 0.0)
            {
                Player closestPlayer = Player.GetClosestPlayer(hit.m_point, 10f);
                if ((bool)closestPlayer)
                {
                    closestPlayer.AddNoise(m_hitNoise);
                }
            }

            if (m_onHit != null)
            {
                m_onHit(hit, this);
            }
        }
    }
}
