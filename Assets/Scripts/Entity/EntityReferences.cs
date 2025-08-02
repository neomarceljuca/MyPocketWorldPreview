using UnityEngine;
using mpw.InventorySystem;

namespace mpw.Entity
{
    public class EntityReferences : MonoBehaviour
    {
        [SerializeField] private Transform bodyTransform;
        [SerializeField] private CharacterController controller;
        [SerializeField] private Inventory inventory;

        public Transform BodyTransform => bodyTransform;
        public CharacterController Controller => controller;
        public Inventory Inventory => inventory;
    }
}
