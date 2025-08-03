using UnityEngine;
using mpw.InventorySystem;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using Sirenix.Serialization;

namespace mpw.Entity
{
    public class EntityReferences : SerializedMonoBehaviour
    {
        [SerializeField] private Transform bodyTransform;
        [SerializeField] private CharacterController controller;
        [SerializeField] private Inventory inventory;
        [SerializeField] private Dictionary<EquipmentCategory, SkinnedMeshRenderer> modelsPerCategory = new();

        [Title("Testing"),SerializeField] ItemGroup startingEquipmentTest;

        public Transform BodyTransform => bodyTransform;
        public CharacterController Controller => controller;
        public Inventory Inventory => inventory;
        public Dictionary<EquipmentCategory, SkinnedMeshRenderer> ModelsPerCategory => modelsPerCategory;

        public ItemGroup StartingEquipmentTest => startingEquipmentTest;
    }
}
