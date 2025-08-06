using UnityEngine;
using mpw.InventorySystem;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using mpw.Multiplayer;

namespace mpw.Entity
{
    public class EntityReferences : SerializedMonoBehaviour
    {
        [SerializeField] private Transform bodyTransform;
        [SerializeField] private Inventory inventory;
        [SerializeField] private Dictionary<EquipmentCategory, SkinnedMeshRenderer> modelsPerCategory = new();

        [TabGroup("Tab", "Network"), SerializeField] private NetworkMovement networkController;

        [Title("Start up values"),SerializeField] ItemGroup startingEquipment;
        [SerializeField] ItemGroup startingInventory;

        public Transform BodyTransform => bodyTransform;
        public NetworkMovement NetworkController => networkController;

        public Inventory Inventory => inventory;
        public Dictionary<EquipmentCategory, SkinnedMeshRenderer> ModelsPerCategory => modelsPerCategory;
        public ItemGroup StartingEquipment => startingEquipment;
        public ItemGroup StartingInventory => startingInventory;
    }
}
