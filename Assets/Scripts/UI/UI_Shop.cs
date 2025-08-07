using mpw.Entity;
using mpw.InventorySystem;
using Sirenix.OdinInspector;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace mpw.UI
{
    public class UI_Shop : UI_ContainerBase
    {
        #region Variables
        [SerializeField] TextMeshProUGUI playerCurrency;
        [SerializeField] TextMeshProUGUI merchantCurrency;

        [SerializeField] GridLayoutGroup playerItemsGrid;
        [SerializeField] GridLayoutGroup merchantItemsGrid;
        [SerializeField] List<UI_ShopitemSlot> playerItemsSlots;
        [SerializeField] List<UI_ShopitemSlot> merchantItemsSlots;

        private Inventory playerInventory;
        private Inventory merchantInventory;

        #endregion
        #region Behavior
        public override void Show()
        {
            Setup();
            base.Show();
        }

        public override void Hide()
        {
            base.Hide();
        }
        #endregion

        #region Utilities
        public void Setup(Entity_Merchant tradingMerchant)
        {
            merchantInventory = tradingMerchant.References.Inventory;
            Setup();
        }
        public void Setup() 
        {
            playerInventory = MPWApp.Instance.LocalPlayer.References.Inventory;
            LoadInventory(playerInventory, playerItemsSlots);
            playerCurrency.text = playerInventory.CurrentBalance.ToString();
            LoadInventory(merchantInventory, merchantItemsSlots);
            merchantCurrency.text = merchantInventory.CurrentBalance.ToString();
        }

        public void LoadInventory(Inventory inventory, List<UI_ShopitemSlot> targetSlotList) 
        {
            if (inventory == null) return;
            for (int i = 0; i < targetSlotList.Count; i++)
            {
                ItemParameters.ItemData targetData = i < inventory.Data.Count()? inventory.Data[i] : null;
                targetSlotList[i].Setup(targetData, this, inventory);
            }
        }


        public void ProcessTransaction(Inventory from, Inventory to, float delta) 
        {
            from.CurrentBalance += delta;
            to.CurrentBalance -= delta;
            playerCurrency.text = playerInventory.CurrentBalance.ToString();
            merchantCurrency.text = merchantInventory.CurrentBalance.ToString();
        }

        public void UpdateInventoryData(GridLayoutGroup originalGLG, GridLayoutGroup newGLG)
        {
            if (originalGLG == newGLG) return;
            Inventory originalInventory = originalGLG.transform.GetChild(0).GetComponent<UI_ShopitemSlot>().Inventory;
            Inventory newInventory = newGLG.transform.GetChild(0).GetComponent<UI_ShopitemSlot>().Inventory;

            originalInventory.InnitData(
                originalGLG.GetComponentsInChildren<UI_ShopitemSlot>()
                .Where(slot => slot.Data != null)
                .Select(slot => slot.Data).ToArray());

            newInventory.InnitData(
                newGLG.GetComponentsInChildren<UI_ShopitemSlot>()
                .Where(slot => slot.Data != null)
                .Select(slot => slot.Data).ToArray());
        }
        #endregion

            #region External
        public void Button_Close() => MPWApp.Instance.UIManager.ToggleUI("Shop");
        #endregion
    }
}