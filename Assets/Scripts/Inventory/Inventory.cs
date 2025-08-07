using System.Linq;
using UnityEngine;

namespace mpw.InventorySystem
{
    public class Inventory : MonoBehaviour
    {
        [SerializeField] private float startingBallance;
        protected ItemParameters.ItemData[] data;
        private float currentBalance;

        public ItemParameters.ItemData[] Data => data;
        public float CurrentBalance
        {
            get { return currentBalance; }
            set { currentBalance = value; }
        }
        private void Start()
        {
            currentBalance = startingBallance;
        }

        public void InnitData(ItemGroup items)
        {
            data = items.Items.Select(x => x.DefaultItemData).ToArray();
        }

        public void InnitData(ItemParameters.ItemData[] data) 
        {
            this.data = data;
        }
    }
}
