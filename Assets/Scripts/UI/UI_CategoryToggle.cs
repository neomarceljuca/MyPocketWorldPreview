using UnityEngine;
using mpw.InventorySystem;
using UnityEngine.Events;

namespace mpw.UI
{
    public class CategoryToggle : MonoBehaviour
    {
        public EquipmentCategory category;
        public UnityEvent<EquipmentCategory> onCategorySelected;

        public void TriggerCategory()
        {
            onCategorySelected.Invoke(category);
        }
    }
}
