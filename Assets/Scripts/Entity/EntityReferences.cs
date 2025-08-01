using UnityEngine;

namespace mpw.Entity
{
    public class EntityReferences : MonoBehaviour
    {
        [SerializeField] private Transform bodyTransform;
        [SerializeField] private CharacterController controller;

        public Transform BodyTransform => bodyTransform;
        public CharacterController Controller => controller;
    }
}
