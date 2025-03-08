using System.Collections.Generic;
using UnityEngine;

namespace MonsterLabZConfig
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
            componentRigidbody = GetComponent<Rigidbody>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.attachedRigidbody != null)
            {
                affectedBodies.Add(other.attachedRigidbody);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.attachedRigidbody != null)
            {
                affectedBodies.Remove(other.attachedRigidbody);
            }
        }

        private void FixedUpdate()
        {
            foreach (Rigidbody affectedBody in affectedBodies)
            {
                Vector3 normalized = (base.transform.position - affectedBody.position).normalized;
                float magnitude = (base.transform.position - affectedBody.position).magnitude;
                float num = (float)((double)ForceG * (double)affectedBody.mass * (double)componentRigidbody.mass / ((double)magnitude * (double)magnitude));
                affectedBody.AddForce(normalized * num * BodyKoeff);
                affectedBody.transform.RotateAround(Vector3.zero, Vector3.down, (float)(10.0 * (double)OrbitSpeed * 120.0));
            }
        }
    }
}
