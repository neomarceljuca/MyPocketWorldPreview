using UnityEngine;
using UnityEngine.EventSystems;

namespace mpw.UI
{
    public class UI_DisplayTooltip_Item : UI_DisplayTooltip
    {
        [SerializeField] UI_ItemObject _itemObject;
        public override void OnPointerEnter(PointerEventData eventData)
        {
            if (_itemObject == null || _itemObject.Parameters == null) return;
            tooltipText = _itemObject.Parameters.DisplayName;
            base.OnPointerEnter(eventData);
        }
    }
}
