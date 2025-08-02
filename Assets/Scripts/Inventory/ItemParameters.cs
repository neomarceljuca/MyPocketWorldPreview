using Sirenix.OdinInspector;
using UnityEngine;

namespace mpw.InventorySystem
{
    [CreateAssetMenu(fileName = "Item_", menuName = "mpw/Inventory/Item_Generic")]
    public class ItemParameters : SerializedScriptableObject
    {
        [SerializeField] private string displayName;
        [SerializeField] private Sprite icon;
        [SerializeField] private float price;
        [SerializeField] private int maxStack = 1;

        public string DisplayName => displayName;
        public Sprite Icon => icon;
        public float Price => price;
        public int MaxStack => maxStack;

        public class ItemData 
        {
            private ItemParameters parameters;

            public ItemParameters Parameters
            {
                get => parameters;
                set
                {
                    parameters = value;
                }
            }

            public ItemData() { }
            public ItemData(ItemParameters parameters) : this() => Parameters = parameters;
        }
    }
}
