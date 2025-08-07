using mpw.InventorySystem;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace mpw.UI
{
    public class UI_ShopitemSlot : UI_ItemDisplaySlot, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        #region Variables
        [SerializeField] private CanvasGroup canvasGroup;
        private Canvas canvas;
        private Transform originalParent;
        private GridLayoutGroup originalGridLayoutGroup;
        private Inventory inventory;
        UI_Shop shopContainer => container as UI_Shop;
       public Inventory Inventory 
        {
            get { return inventory; } 
            protected set { inventory = value; }
        } 
        #endregion
        #region Behavior
        private void Start()
        {
            canvasGroup = GetComponent<CanvasGroup>();
            canvas = MPWApp.Instance.UIManager.MainCanvas;
        }

        public override void Reset()
        {
            base.Reset();
        }

        public void Setup(ItemParameters.ItemData Data, UI_ContainerBase container, Inventory inventory) 
        {
            Setup(Data, container);
            this.inventory = inventory;
        }
        #endregion

        #region Utilities

        private void ReturnToOriginalParent()
        {
            icon.transform.SetParent(originalParent);
            icon.rectTransform.localPosition = Vector3.zero;
        }

        private void SwapSlotsContent(UI_ShopitemSlot targetSlot) 
        {
            ItemParameters.ItemData targetCurrentData = targetSlot.Data;
            targetSlot.Setup(this.Data, this.container);
            Setup(targetCurrentData, this.container);
        }

        private bool ValidateTransaction(UI_ShopitemSlot other) 
        {
            if(inventory == other)
                return true;
            float otherPrice = other.Data != null? other.Data.Parameters.Price : 0;
            float deltaCost = Data.Parameters.Price - otherPrice; //transaction attempt cost difference

            if (inventory.CurrentBalance + deltaCost >= 0 &&
                other.inventory.CurrentBalance - deltaCost >= 0) //if both inventories have enough money for transaction
            {
                shopContainer.ProcessTransaction(inventory, other.inventory, deltaCost);
                return true;
            }
            else
                return false;
        }
        #endregion

        #region Interfaces
        public void OnBeginDrag(PointerEventData eventData) 
        {
            if (Data == null) return;
            canvasGroup.blocksRaycasts = false;
            originalParent = icon.transform.parent;
            originalGridLayoutGroup = originalParent.GetComponentInParent<GridLayoutGroup>();
            icon.transform.SetParent(canvas.transform);
        }

        public void OnDrag(PointerEventData eventData) 
        {
            if (Data == null) return;
            icon.rectTransform.anchoredPosition = icon.rectTransform.anchoredPosition + (eventData.delta / canvas.scaleFactor);
        }

        public void OnEndDrag(PointerEventData eventData) 
        {
            if (Data == null) return;
            GameObject dropTarget = eventData.pointerEnter;
            UI_ShopitemSlot targetSlot = dropTarget.GetComponent<UI_ShopitemSlot>();
            canvasGroup.blocksRaycasts = true;

            if (dropTarget == null)
            {
                ReturnToOriginalParent();
                return;
            }

            GridLayoutGroup newGridLayoutGroup = dropTarget.GetComponentInParent<GridLayoutGroup>();

            ReturnToOriginalParent();
            if (newGridLayoutGroup != null && ValidateTransaction(targetSlot)) 
            {
                SwapSlotsContent(targetSlot);
                if (newGridLayoutGroup != null && originalGridLayoutGroup != newGridLayoutGroup)
                {
                    Debug.Log($"Item moved from {originalGridLayoutGroup.name} to {newGridLayoutGroup.name}");
                    shopContainer.UpdateInventoryData(originalGridLayoutGroup, newGridLayoutGroup);
                }
            }
        }
        #endregion
    }
}
