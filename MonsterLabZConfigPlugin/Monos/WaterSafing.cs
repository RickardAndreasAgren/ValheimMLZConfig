using UnityEngine;

namespace MonsterLabZ
{
    public class WaterSafing : MonoBehaviour
    {
        public float power;

        private void Start()
        {
        }

        private void Update()
        {
        }

        private void OnTriggerStay(Collider col)
        {
            if (col.tag == "Physical")
            {
                var rBody = col.GetComponent<Rigidbody>();
                if (rBody != null && rBody.isKinematic == false)
                {
                    rBody.AddForce(base.transform.up * power);
                }
            }

            if (col.tag == "Player")
            {
                if (Input.GetKey(KeyCode.Space))
                {
                    col.GetComponent<CharacterController>().skinWidth = 3f;
                }
                else
                {
                    col.GetComponent<CharacterController>().skinWidth = 0.08f;
                }
            }
        }

        private void OnTriggerExit(Collider col)
        {
            if (col.tag == "Player")
            {
                col.GetComponent<CharacterController>().skinWidth = 0.08f;
            }
        }
    }
}
