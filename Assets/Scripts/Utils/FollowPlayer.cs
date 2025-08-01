using UnityEngine;

namespace mpw.Utils 
{
    public class FollowPlayer : MonoBehaviour
    {
        public Transform target;
        public Vector3 offset = new Vector3(0f, 2.265f, -3f);

        void LateUpdate()
        {
            if (target != null)
            {
                transform.position = target.position + offset;
            }
        }
    }
}