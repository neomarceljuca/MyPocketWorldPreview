using UnityEngine;
namespace mpw.InventorySystem
{
    [CreateAssetMenu(fileName = "Item_", menuName = "mpw/Inventory/Item_Equipment")]
    public class EquipmentParameters : ItemParameters
    {
        [SerializeField] private GameObject model;
        [SerializeField] private Color defaultColor;


        public GameObject Model => model;
        public Color DefaultColor => defaultColor;

        public class EquipmentData: ItemData
        {
        
        }
    }

    enum EquipmentCategory 
    {
        Hair,
        Eyes,
        Cheeks,
        Mouth,
    }
}
