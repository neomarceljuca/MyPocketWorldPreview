using UnityEngine;
using Sirenix.OdinInspector;

namespace mpw.Entity
{
    public class Entity_Merchant : Entity
    {
        [SerializeField, TabGroup("Merchant")] float StartingMerchantBalance;

        protected override void Start()
        {
            base.Start();
            References.Inventory.InnitData(References.StartingInventory, StartingMerchantBalance);
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