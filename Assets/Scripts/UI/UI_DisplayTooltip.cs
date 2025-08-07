using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using Sirenix.Utilities;

namespace mpw.UI
{
    public class UI_DisplayTooltip : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        protected string tooltipText = "";
        protected string tooltipText2 = "";
        void Start()
        {

        }

        public virtual void OnPointerEnter(PointerEventData eventData)
        {
            if (tooltipText.IsNullOrWhitespace()) return;
            MPWApp.Instance.UIManager.ShowTooltip(tooltipText, tooltipText2);
        }

        public virtual void OnPointerExit(PointerEventData eventData)
        {
            MPWApp.Instance.UIManager.HideTooltip();
        }
    }
}
