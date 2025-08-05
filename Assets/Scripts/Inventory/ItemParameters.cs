using Sirenix.OdinInspector;
using UnityEngine;

namespace mpw.InventorySystem
{
    [CreateAssetMenu(fileName = "Item_", menuName = "mpw/Inventory/Item_Generic")]
    public class ItemParameters : SerializedScriptableObject
    {
        [SerializeField] private string displayName;
        [SerializeField] protected Sprite iconOverride;
        [SerializeField] private float price;
        [SerializeField] private int maxStack = 1;

        public string DisplayName => displayName;
        public virtual Sprite DisplayIcon => iconOverride;
        public float Price => price;
        public int MaxStack => maxStack;

        public virtual ItemData DefaultItemData => new(this);
        public class ItemData 
        {
            private ItemParameters parameters;

            public ItemParameters Parameters
            {
                get => parameters;
                protected set
                {
                    parameters = value;
                }
            }

            public ItemData() { }
            public ItemData(ItemParameters parameters) : this() => Parameters = parameters;
        }
    }
}
