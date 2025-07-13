using System.Collections.Generic;
using UnityEngine;

namespace MonsterLabZ
{
    public class TornadoGravity : MonoBehaviour
    {
        public float ForceG;

        public float BodyKoeff;

        public float OrbitSpeed;

        private HashSet<Rigidbody> affectedBodies = new HashSet<Rigidbody>();

        private Rigidbody componentRigidbody;

        private void Start()
        {
            return;
        }

        private void OnTriggerEnter(Collider other)
        {
            return;
        }

        private void OnTriggerExit(Collider other)
        {
            return;
        }

        private void FixedUpdate()
        {
            return;
        }
    }
}
