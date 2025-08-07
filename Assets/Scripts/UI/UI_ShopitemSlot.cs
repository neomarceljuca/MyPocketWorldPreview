using mpw.InventorySystem;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace mpw.UI
{
    public class UI_ShopitemSlot : UI_ItemDisplaySlot, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        [SerializeField] private CanvasGroup canvasGroup;
        private Canvas canvas;
        private Transform originalParent;
        private GridLayoutGroup originalGridZone;
        UI_Shop shopContainer => container as UI_Shop;

        private void Start()
        {
            canvasGroup = GetComponent<CanvasGroup>();
            canvas = MPWApp.Instance.UIManager.MainCanvas;
        }

        public override void Reset()
        {
            base.Reset();
        }


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

        private bool ValidateTransaction() 
        {
            return true;
        }
        #endregion

        #region Interfaces
        public void OnBeginDrag(PointerEventData eventData) 
        {
            if (Data == null) return;
            canvasGroup.blocksRaycasts = false;
            originalParent = icon.transform.parent;
            originalGridZone = originalParent.GetComponentInParent<GridLayoutGroup>();
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
            canvasGroup.blocksRaycasts = true;

            if (dropTarget == null)
            {
                ReturnToOriginalParent();
                return;
            }

            GridLayoutGroup newGridZone = dropTarget.GetComponentInParent<GridLayoutGroup>();

            if(newGridZone != null && originalGridZone != newGridZone) 
            {
                Debug.Log($"Item moved from {originalGridZone.name} to {newGridZone.name}");
            }

            ReturnToOriginalParent();
            if (newGridZone != null && ValidateTransaction()) 
            {
                SwapSlotsContent(dropTarget.GetComponent<UI_ShopitemSlot>());               
            }
        }
        #endregion
    }
}
