using System.Collections.Generic;
using UnityEngine;

namespace MonsterLabZConfig
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
            if (other.attachedRigidbody != null)
            {
                affectedBod.Add(other.attachedRigidbody);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.attachedRigidbody != null)
            {
                affectedBod.Remove(other.attachedRigidbody);
            }
        }

        private void FixedUpdate()
        {
            foreach (Rigidbody item in affectedBod)
            {
                Vector3 vector = base.transform.position - item.position;
                float sqrMagnitude = (base.transform.position - item.position).sqrMagnitude;
                float num = ForceGN * (item.mass - componRigidbody.mass) / sqrMagnitude;
                item.AddForce(vector * num * BodyKf);
            }
        }
    }
}
