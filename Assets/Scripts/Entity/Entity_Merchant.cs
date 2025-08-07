using UnityEngine;
using Sirenix.OdinInspector;

namespace mpw.Entity
{
    public class Entity_Merchant : Entity
    {
        protected override void Start()
        {
            base.Start();
            References.Inventory.InnitData(References.StartingInventory);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player")) 
            {
                MPWApp.Instance.UIManager.ToggleShopPrompt(true);
                MPWApp.Instance.UIManager.ShopPanel.Setup(this);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            MPWApp.Instance.UIManager.ToggleShopPrompt(false);
        }
    }
}