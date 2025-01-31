using UnityEngine;

namespace MonsterLabZConfig
{
    public class RotateTor1 : MonoBehaviour
    {
        public float TorRotationSpeed;

        private void Update()
        {
            Quaternion quaternion = Quaternion.AngleAxis(TorRotationSpeed * Time.deltaTime, Vector3.down);
            Quaternion quaternion2 = Quaternion.AngleAxis(TorRotationSpeed * Time.deltaTime, Vector3.down);
            base.transform.rotation *= quaternion;
            base.transform.rotation *= quaternion2;
        }
    }
}
