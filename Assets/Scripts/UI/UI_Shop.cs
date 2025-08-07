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


        [Title("Testing"), SerializeField] Inventory playerInventory;
        [SerializeField] Inventory merchantInventory;
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
        public void Setup() 
        {
            LoadInventory(MPWApp.Instance.LocalPlayer.References.Inventory, playerItemsSlots);
        }

        public void LoadInventory(Inventory inventory, List<UI_ShopitemSlot> targetSlotList) 
        {
            foreach (var slot in targetSlotList) 
            {
                slot.Reset();
            }
            for (int i = 0; i < inventory.Data.Count(); i++)
            {
                targetSlotList[i].Setup(inventory.Data[i], this);
            }
        }
        #endregion

        #region External
        public void Button_Close() => MPWApp.Instance.UIManager.ToggleUI("Shop");
        #endregion
    }
}