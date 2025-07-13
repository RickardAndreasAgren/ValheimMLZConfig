using System.Collections;
using UnityEngine;

namespace MonsterLabZ
{
    public class SetTextureOffset : MonoBehaviour
    {
        public Vector2 offsetValue;

        public Renderer rend;

        private void Start()
        {
            rend = GetComponent<Renderer>();
            StartCoroutine(MoveTheTexture());
        }

        private IEnumerator MoveTheTexture()
        {
            while (true)
            {
                yield return new WaitForSeconds(5f);
                offsetValue = rend.material.GetTextureOffset("_MainTex");
                offsetValue.y += 1f / 3f;
                rend.material.SetTextureOffset("_MainTex", new Vector2(offsetValue.x, offsetValue.y));
            }
        }
    }
}
