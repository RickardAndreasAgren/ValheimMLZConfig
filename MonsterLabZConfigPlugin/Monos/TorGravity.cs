using System.Collections.Generic;
using UnityEngine;

namespace MonsterLabZ
{
    public class TorGravity : MonoBehaviour
    {
        public float ForceGN;

        public float BodyKf;

        private HashSet<Rigidbody> affectedBod = new HashSet<Rigidbody>();

        private Rigidbody componRigidbody;

        private void Start()
        {
            componRigidbody = GetComponent<Rigidbody>();
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
