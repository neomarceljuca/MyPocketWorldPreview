using TMPro;
using UnityEngine;
namespace mpw.UI
{
    public class UI_Tooltip : MonoBehaviour
    {
        [SerializeField] Vector2 mouseOffset;
        public TextMeshProUGUI text;
        public TextMeshProUGUI text2;
        private Canvas canvas;
        private void Start()
        {
            canvas = MPWApp.Instance.UIManager.MainCanvas;
        }

        void Update()
        {
            Vector2 position;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                canvas.transform as RectTransform,
                Input.mousePosition,
                null,
                out position
            );
            transform.localPosition = position + mouseOffset;
        }

        public void SetTexts(string targetText, string targetText2)
        {
            if (text != null)
                text.text = targetText;
            if (text2 != null)
                text2.text = targetText2;
        }
    }
}
