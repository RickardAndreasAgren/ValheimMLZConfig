using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static UnityEngine.ParticleSystem;

namespace MonsterLabZ
{
    public class AIShipEffects : MonoBehaviour
    {
        public Transform m_shadow;

        public float m_offset = 0.01f;

        public float m_minimumWakeVel = 5f;

        public GameObject m_speedWakeRoot;

        public GameObject m_wakeSoundRoot;

        public GameObject m_inWaterSoundRoot;

        public float m_audioFadeDuration = 2f;

        public AudioSource m_sailSound;

        public float m_sailFadeDuration = 1f;

        public GameObject m_splashEffects;

        private float m_sailBaseVol = 1f;

        private ParticleSystem[] m_wakeParticles;

        private List<KeyValuePair<AudioSource, float>> m_wakeSounds = new List<KeyValuePair<AudioSource, float>>();

        private List<KeyValuePair<AudioSource, float>> m_inWaterSounds = new List<KeyValuePair<AudioSource, float>>();

        private Rigidbody m_body;

        private Ship m_ship;

        private void Awake()
        {
            ZNetView componentInParent = GetComponentInParent<ZNetView>();
            if ((bool)componentInParent && componentInParent.GetZDO() == null)
            {
                base.enabled = false;
                return;
            }

            m_body = GetComponentInParent<Rigidbody>();
            m_ship = GetComponentInParent<Ship>();
            if ((bool)m_speedWakeRoot)
            {
                m_wakeParticles = m_speedWakeRoot.GetComponentsInChildren<ParticleSystem>();
            }

            if ((bool)m_wakeSoundRoot)
            {
                AudioSource[] componentsInChildren = m_wakeSoundRoot.GetComponentsInChildren<AudioSource>();
                foreach (AudioSource audioSource in componentsInChildren)
                {
                    audioSource.pitch = Random.Range(0.9f, 1.1f);
                    m_wakeSounds.Add(new KeyValuePair<AudioSource, float>(audioSource, audioSource.volume));
                }
            }

            if ((bool)m_inWaterSoundRoot)
            {
                AudioSource[] componentsInChildren2 = m_inWaterSoundRoot.GetComponentsInChildren<AudioSource>();
                foreach (AudioSource audioSource2 in componentsInChildren2)
                {
                    audioSource2.pitch = Random.Range(0.9f, 1.1f);
                    m_inWaterSounds.Add(new KeyValuePair<AudioSource, float>(audioSource2, audioSource2.volume));
                }
            }

            if ((bool)m_sailSound)
            {
                m_sailBaseVol = m_sailSound.volume;
                m_sailSound.pitch = Random.Range(0.9f, 1.1f);
            }
        }

        private void LateUpdate()
        {
            float liquidLevel = Floating.GetLiquidLevel(base.transform.position);
            Vector3 position = base.transform.position;
            float deltaTime = Time.deltaTime;
            if ((double)position.y > (double)liquidLevel)
            {
                SetWake(enabled: false, deltaTime);
                FadeSounds(m_inWaterSounds, enabled: false, deltaTime);
                return;
            }

            bool flag = (double)m_body.velocity.magnitude > (double)m_minimumWakeVel;
            FadeSounds(m_inWaterSounds, enabled: true, deltaTime);
            SetWake(flag, deltaTime);
            if ((bool)m_sailSound)
            {
                FadeSound(m_sailSound, m_ship.IsSailUp() ? m_sailBaseVol : 0f, m_sailFadeDuration, deltaTime);
            }
        }

        private void SetWake(bool enabled, float dt)
        {
            ParticleSystem[] wakeParticles = m_wakeParticles;
            foreach (ParticleSystem particleSystem in wakeParticles)
            {
                ParticleSystem.EmissionModule emission = particleSystem.emission;
                emission.enabled = enabled;
            }

            FadeSounds(m_wakeSounds, enabled, dt);
        }

        private void FadeSounds(List<KeyValuePair<AudioSource, float>> sources, bool enabled, float dt)
        {
            foreach (KeyValuePair<AudioSource, float> source in sources)
            {
                if (enabled)
                {
                    FadeSound(source.Key, source.Value, m_audioFadeDuration, dt);
                }
                else
                {
                    FadeSound(source.Key, 0f, m_audioFadeDuration, dt);
                }
            }
        }

        private void FadeSound(AudioSource source, float target, float fadeDuration, float dt)
        {
            float maxDelta = dt / fadeDuration;
            if ((double)target > 0.0)
            {
                if (!source.isPlaying)
                {
                    source.Play();
                }

                source.volume = Mathf.MoveTowards(source.volume, target, maxDelta);
            }
            else if (source.isPlaying)
            {
                source.volume = Mathf.MoveTowards(source.volume, 0f, maxDelta);
                if (!((double)source.volume > 0.0))
                {
                    source.Stop();
                }
            }
        }
    }
}