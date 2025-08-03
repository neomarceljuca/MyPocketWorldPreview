using Sirenix.OdinInspector;
using System;
using UnityEngine;
namespace mpw.InventorySystem
{
    [CreateAssetMenu(fileName = "Item_", menuName = "mpw/Inventory/Item_Equipment")]
    public class EquipmentParameters : ItemParameters
    {
        [BoxGroup("Equipment"), SerializeField] private EquipmentCategory category;
        [BoxGroup("Equipment"), SerializeField] private Mesh mesh;
        [BoxGroup("Equipment"), SerializeField] private Color defaultColor;
        [BoxGroup("Equipment"), SerializeField] private Material material;

        public Mesh Mesh => mesh;
        public Color DefaultColor => defaultColor;
        public EquipmentCategory Category => category;
        public Material Material => material;

        public class EquipmentData: ItemData
        {
        
        }
    }

    [Serializable]
    public enum EquipmentCategory 
    {
        Hair,
        Eyes,
        Cheeks,
        Mouth,
        Top,
        Bottom,
        Shoes
    }
}
