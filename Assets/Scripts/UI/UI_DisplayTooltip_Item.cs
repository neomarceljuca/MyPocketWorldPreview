using UnityEngine;
using UnityEngine.EventSystems;

namespace mpw.UI
{
    public class UI_DisplayTooltip_Item : UI_DisplayTooltip
    {
        [SerializeField] UI_ItemObject _itemObject;
        public override void OnPointerEnter(PointerEventData eventData)
        {
            if (_itemObject == null || _itemObject.Data == null) return;
            tooltipText = _itemObject.Data.Parameters.DisplayName;
            tooltipText2 = _itemObject.Data.Parameters.Price.ToString();
            base.OnPointerEnter(eventData);
        }
    }
}
